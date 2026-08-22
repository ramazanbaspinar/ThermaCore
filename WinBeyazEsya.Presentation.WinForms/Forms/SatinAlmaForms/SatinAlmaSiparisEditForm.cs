using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.SatinAlmaForms
{
    public partial class SatinAlmaSiparisEditForm : BaseEditForm
    {
        private readonly WinBeyazEsya.Application.Interfaces.Purchasing.IPurchaseOrderService _purchaseOrderService = default!;
        private readonly WinBeyazEsya.Application.Interfaces.Definitions.ICurrentAccountService _currentAccountService = default!;
        private readonly WinBeyazEsya.Application.Interfaces.Definitions.IWarehouseService _warehouseService = default!;
        private readonly WinBeyazEsya.Application.Interfaces.System.IExchangeRateService _exchangeRateService = default!;
        private readonly WinBeyazEsya.Application.Interfaces.Production.IRawMaterialService _rawMaterialService = default!;
        private readonly WinBeyazEsya.Application.Interfaces.Definitions.IUnitConversionService _unitConversionService = default!;

        // Dinamik Eklenen Bileşenler
        private PopupMenu popupMenuGrid;
        private BarManager barManager;
        private RepositoryItemSearchLookUpEdit repoMalzeme;
        private RepositoryItemSpinEdit repoFiyat;
        private RepositoryItemLookUpEdit repoBirim;
        private List<MaterialLookupDto> _allMaterials;
        private Dictionary<long, List<UnitDropdownItem>> _materialUnitsCache = new Dictionary<long, List<UnitDropdownItem>>();
        private object _oldUnitId;

        public SatinAlmaSiparisEditForm()
        {
            InitializeComponent();
            BaseKartTuru = Domain.Enums.ModuleType.SatinalmaSiparisleri;
            InitGridPopupMenu();
        }

        public SatinAlmaSiparisEditForm(
            WinBeyazEsya.Application.Interfaces.Purchasing.IPurchaseOrderService purchaseOrderService,
            WinBeyazEsya.Application.Interfaces.Definitions.ICurrentAccountService currentAccountService,
            WinBeyazEsya.Application.Interfaces.Definitions.IWarehouseService warehouseService,
            WinBeyazEsya.Application.Interfaces.System.IExchangeRateService exchangeRateService,
            WinBeyazEsya.Application.Interfaces.Production.IRawMaterialService rawMaterialService,
            WinBeyazEsya.Application.Interfaces.Definitions.IUnitConversionService unitConversionService)
        {
            InitializeComponent();

            if (!DesignMode && Program.ServiceProvider != null)
            {
                _purchaseOrderService = purchaseOrderService;
                _currentAccountService = currentAccountService;
                _warehouseService = warehouseService;
                _exchangeRateService = exchangeRateService;
                _rawMaterialService = rawMaterialService;
                _unitConversionService = unitConversionService;
                
                Bll = _purchaseOrderService;
            }

            BaseKartTuru = Domain.Enums.ModuleType.SatinalmaSiparisleri;
            InitGridPopupMenu();
        }

        private void InitGridPopupMenu()
        {
            barManager = new BarManager();
            barManager.Form = this;
            popupMenuGrid = new PopupMenu(barManager);
            
            var btnAdd = new DevExpress.XtraBars.BarButtonItem(barManager, "Satır Ekle");
            btnAdd.ItemClick += BtnAdd_ItemClick;
            
            var btnDelete = new DevExpress.XtraBars.BarButtonItem(barManager, "Satır Sil");
            btnDelete.ItemClick += BtnDelete_ItemClick;

            popupMenuGrid.ItemLinks.Add(btnAdd);
            popupMenuGrid.ItemLinks.Add(btnDelete);
        }

        private void BtnAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (cmbDovuzTuru.EditValue == null || string.IsNullOrWhiteSpace(cmbDovuzTuru.EditValue.ToString()))
            {
                XtraMessageBox.Show("Lütfen önce Döviz Türü seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var lines = myGridControl1.DataSource as BindingList<Application.DTOs.Purchasing.PurchaseOrderLineDto>;
            if (lines == null)
            {
                var list = myGridControl1.DataSource as List<Application.DTOs.Purchasing.PurchaseOrderLineDto> ?? new List<Application.DTOs.Purchasing.PurchaseOrderLineDto>();
                lines = new BindingList<Application.DTOs.Purchasing.PurchaseOrderLineDto>(list);
                myGridControl1.DataSource = lines;
            }

            myGridView1.AddNewRow();
        }

        private void MyGridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            var view = sender as GridView;
            if (view == null) return;

            string currentCurrency = cmbDovuzTuru.EditValue?.ToString() ?? "";
            
            view.SetRowCellValue(e.RowHandle, "CurrencyCode", currentCurrency);
            view.SetRowCellValue(e.RowHandle, "Quantity", 1);
            view.SetRowCellValue(e.RowHandle, "TaxRate", 20m);
        }

        private void BtnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            myGridView1.DeleteSelectedRows();
            CalculateTotals();
        }

        protected override void EventsLoad()
        {
            base.EventsLoad();
            myGridView1.CellValueChanged += MyGridView1_CellValueChanged;
            myGridView1.ShowingEditor += MyGridView1_ShowingEditor;
            myGridView1.ShownEditor += MyGridView1_ShownEditor;
            myGridView1.PopupMenuShowing += MyGridView1_PopupMenuShowing;
            myGridView1.InitNewRow += MyGridView1_InitNewRow;
            myGridView1.CustomColumnDisplayText += MyGridView1_CustomColumnDisplayText;

            glufTedarikciCari.SearchButtonClicked += GlufTedarikciCari_SearchButtonClicked;
            glufTeslimatDeposu.SearchButtonClicked += GlufTeslimatDeposu_SearchButtonClicked;
            
            cmbDovuzTuru.EditValueChanged += KurHesapla_EditValueChanged;
            txtSiparisTarihi.EditValueChanged += KurHesapla_EditValueChanged;
            cmbDovuzTuru.EditValueChanged += CmbDovuzTuru_EditValueChanged;
        }

        private void MyGridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow || e.HitInfo.InRowCell || e.HitInfo.HitTest == DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.EmptyRow)
            {
                popupMenuGrid.ShowPopup(myGridControl1.PointToScreen(e.Point));
            }
        }

        private void View_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            var gridView = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            string searchText = glufTedarikciCari.Text?.ToLower() ?? "";
            
            if (string.IsNullOrEmpty(searchText) || searchText == glufTedarikciCari.Properties.NullText.ToLower()) 
                return;
                
            var row = gridView.GetRow(e.ListSourceRow) as Application.DTOs.Definitions.CurrentAccountDto;
            if (row != null)
            {
                bool matchCode = row.Code != null && row.Code.ToLower().Contains(searchText);
                bool matchTitle = row.Title != null && row.Title.ToLower().Contains(searchText);
                
                if (matchCode || matchTitle)
                {
                    e.Visible = true;
                    e.Handled = true;
                }
                else
                {
                    e.Visible = false;
                    e.Handled = true;
                }
            }
        }

        private void MyGridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "BaseReceivedQuantity" || e.Column.FieldName == "BaseRemainingQuantity")
            {
                var view = sender as GridView;
                if (view != null && e.ListSourceRowIndex >= 0)
                {
                    var materialIdValue = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "MaterialId");
                    if (materialIdValue != null && materialIdValue != DBNull.Value)
                    {
                        long materialId = Convert.ToInt64(materialIdValue);
                        var material = _allMaterials?.FirstOrDefault(x => x.Id == materialId);
                        
                        string baseUnitName = "";
                        if (material != null && material.BaseUnitId.HasValue)
                        {
                            var allUnits = repoBirim.DataSource as List<UnitDropdownItem>;
                            var unit = allUnits?.FirstOrDefault(u => u.Id == material.BaseUnitId.Value);
                            if (unit != null)
                            {
                                baseUnitName = unit.Name;
                            }
                        }
                        
                        if (e.Value != null)
                        {
                            decimal val = Convert.ToDecimal(e.Value);
                            string formattedValue = val.ToString("#,##0.####");
                            e.DisplayText = $"{formattedValue} {baseUnitName}".Trim();
                        }
                    }
                }
            }
        }

        private void CmbDovuzTuru_EditValueChanged(object sender, EventArgs e)
        {
            if (myGridView1.RowCount > 0 && cmbDovuzTuru.EditValue != null)
            {
                string newCurrency = cmbDovuzTuru.EditValue.ToString();
                for (int i = 0; i < myGridView1.RowCount; i++)
                {
                    myGridView1.SetRowCellValue(i, "CurrencyCode", newCurrency);
                }
                myGridView1.RefreshData();
            }
        }

        public override void Yukle()
        {
            myGridView1.OptionsView.ShowAutoFilterRow = false;

            if (colGelenMiktar != null)
            {
                colGelenMiktar.FieldName = "BaseReceivedQuantity";
                colGelenMiktar.Caption = "Gelen Miktar";
            }
            if (colBekleyenMiktar != null)
            {
                colBekleyenMiktar.FieldName = "BaseRemainingQuantity";
                colBekleyenMiktar.Caption = "Bekleyen Miktar";
            }

            txtSiparisTarihi.Properties.Mask.EditMask = "g";
            txtSiparisTarihi.Properties.Mask.UseMaskAsDisplayFormat = true;

            cmbSiparisDurumu.Properties.Items.AddRange(WinBeyazEsya.Presentation.WinForms.Helpers.EnumFunctions.GetEnumDescriptionList<OrderStatus>().ToArray());

            glufTedarikciCari.Properties.ValueMember = "Id";
            glufTedarikciCari.Properties.DisplayMember = "Title";

            glufTeslimatDeposu.Properties.ValueMember = "Id";
            glufTeslimatDeposu.Properties.DisplayMember = "Name";

            if (_exchangeRateService != null && !DesignMode)
            {
                var currencies = _exchangeRateService.GetAllRates().Select(x => x.CurrencyCode).Distinct().ToList();
                cmbDovuzTuru.Properties.Items.Clear();
                cmbDovuzTuru.Properties.Items.AddRange(currencies);
            }

            InitGridRepositoryItems();

            if (BaseIslemTuru == ActionType.EntityInsert)
                CurrentEntity = new Application.DTOs.Purchasing.PurchaseOrderDto { IsActive = true, OrderDate = DateTime.Now, Status = OrderStatus.Draft, ExchangeRate = 1 };
            else
                CurrentEntity = _purchaseOrderService.GetById(Id);

            NesneyiKontrollereBagla();
        }

        private void InitGridRepositoryItems()
        {
            repoFiyat = new RepositoryItemSpinEdit();
            repoFiyat.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            repoFiyat.DisplayFormat.FormatString = "n4";
            repoFiyat.EditMask = "n4";
            myGridControl1.RepositoryItems.Add(repoFiyat);
            if (myGridView1.Columns["UnitPrice"] != null)
                myGridView1.Columns["UnitPrice"].ColumnEdit = repoFiyat;

            repoMalzeme = new RepositoryItemSearchLookUpEdit();
            if (!DesignMode)
            {
                try
                {
                    LoadAllMaterials();
                    
                    if (_allMaterials == null || _allMaterials.Count == 0)
                    {
                        XtraMessageBox.Show("Uyarı: Veritabanında aktif malzeme bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                    repoMalzeme.DataSource = _allMaterials;
                    repoMalzeme.DisplayMember = "Name";
                    repoMalzeme.ValueMember = "Id";
                    repoMalzeme.NullText = "Malzeme Seçiniz";
                    repoMalzeme.PopulateViewColumns();
                    
                    var view = repoMalzeme.View;
                    if (view.Columns["Id"] != null) view.Columns["Id"].Visible = false;
                    if (view.Columns["BaseUnitId"] != null) view.Columns["BaseUnitId"].Visible = false;
                    if (view.Columns["BaseUnitName"] != null) view.Columns["BaseUnitName"].Visible = false;
                    
                    if (view.Columns["Code"] != null) 
                    {
                        view.Columns["Code"].Caption = "Kodu";
                        view.Columns["Code"].Visible = true;
                        view.Columns["Code"].Width = 50;
                    }
                    
                    if (view.Columns["Name"] != null) 
                    {
                        view.Columns["Name"].Caption = "Adı";
                        view.Columns["Name"].Visible = true;
                        view.Columns["Name"].Width = 250;
                    }
                    
                    if (view.Columns["MaterialGroupName"] != null) 
                    {
                        view.Columns["MaterialGroupName"].Caption = "Grup";
                        view.Columns["MaterialGroupName"].Visible = true;
                        view.Columns["MaterialGroupName"].GroupIndex = 0;
                    }

                    // Grup başlığındaki "Grup: " yazısını kaldır sadece grubun adı kalsın
                    view.GroupFormat = "{1} {2}";
                    
                    // Arama yapıldığında grupları otomatik aç, silindiğinde kapat
                    view.RowCountChanged += (s, e) =>
                    {
                        if (view.ActiveFilter != null && !view.ActiveFilter.IsEmpty)
                        {
                            view.ExpandAllGroups();
                        }
                        else
                        {
                            view.CollapseAllGroups();
                        }
                    };

                    repoMalzeme.Popup += (s, e) =>
                    {
                        if (view.ActiveFilter == null || view.ActiveFilter.IsEmpty)
                        {
                            view.CollapseAllGroups();
                        }
                    };

                    myGridControl1.RepositoryItems.Add(repoMalzeme);
                    if (myGridView1.Columns["MaterialId"] != null)
                        myGridView1.Columns["MaterialId"].ColumnEdit = repoMalzeme;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Malzemeler yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            repoBirim = new RepositoryItemLookUpEdit();
            repoBirim.NullText = "Birim Seçiniz";

            if (!DesignMode && Program.ServiceProvider != null)
            {
                var unitRepo = (WinBeyazEsya.Application.Interfaces.Repositories.Definitions.IUnitRepository?)Program.ServiceProvider.GetService(typeof(WinBeyazEsya.Application.Interfaces.Repositories.Definitions.IUnitRepository));
                if (unitRepo != null)
                {
                    repoBirim.DataSource = unitRepo.Find(x => x.IsActive).Select(x => new UnitDropdownItem { Id = x.Id, Name = x.Name }).ToList();
                    repoBirim.DisplayMember = "Name";
                    repoBirim.ValueMember = "Id";
                    repoBirim.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Birim Adı"));
                    repoBirim.ShowHeader = false;
                }
            }

            myGridControl1.RepositoryItems.Add(repoBirim);
            if (myGridView1.Columns["UnitId"] != null)
            {
                myGridView1.Columns["UnitId"].ColumnEdit = repoBirim;
            }

            if (myGridView1.Columns["CurrencyCode"] != null)
                myGridView1.Columns["CurrencyCode"].OptionsColumn.AllowEdit = false;
                
            if (myGridView1.Columns["LineTotal"] != null)
                myGridView1.Columns["LineTotal"].OptionsColumn.AllowEdit = false;
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Application.DTOs.Purchasing.PurchaseOrderDto)CurrentEntity;

            if (_currentAccountService != null && !DesignMode)
            {
                glufTedarikciCari.Properties.DataSource = _currentAccountService.GetAll()
                    .Where(x => x.CardType == (int)CardType.Tedarikci || x.CardType == (int)CardType.MusteriVeTedarikci)
                    .ToList();
                    
                var view = glufTedarikciCari.Properties.PopupView as DevExpress.XtraGrid.Views.Grid.GridView;
                if (view != null)
                {
                    view.Columns.Clear();
                    
                    var colCode = view.Columns.AddField("Code");
                    colCode.Caption = "Cari Kod";
                    colCode.Visible = true;
                    colCode.VisibleIndex = 0;
                    colCode.Width = 60;

                    var colTitle = view.Columns.AddField("Title");
                    colTitle.Caption = "Cari Unvan";
                    colTitle.Visible = true;
                    colTitle.VisibleIndex = 1;
                    colTitle.Width = 240;
                    
                    // Çoklu arama özelliği (Hem kod hem unvan)
                    view.OptionsFind.AlwaysVisible = true;
                    view.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
                    view.OptionsFind.FindFilterColumns = "Code;Title";
                    view.OptionsFind.FindNullPrompt = "Kod veya Unvan Ara...";
                    
                    glufTedarikciCari.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                    glufTedarikciCari.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
                    glufTedarikciCari.Properties.ImmediatePopup = true;
                    
                    view.CustomRowFilter -= View_CustomRowFilter;
                    view.CustomRowFilter += View_CustomRowFilter;
                }
            }

            if (_warehouseService != null && !DesignMode)
            {
                glufTeslimatDeposu.Properties.DataSource = _warehouseService.GetAll()
                    .Where(x => x.IsActive)
                    .ToList();
            }

            txtKod.Text = entity.Code;
            txtBelgeNo.Text = entity.DocumentNo;
            txtSiparisTarihi.EditValue = entity.OrderDate;
            txtTeslimatTarihi.EditValue = entity.DeliveryDate;
            glufTedarikciCari.EditValue = entity.SupplierId == 0 ? null : entity.SupplierId;
            glufTeslimatDeposu.EditValue = entity.WarehouseId;
            
            if (!string.IsNullOrEmpty(entity.CurrencyCode))
                cmbDovuzTuru.EditValue = entity.CurrencyCode;

            txtDovizKuru.Value = entity.ExchangeRate;
            cmbSiparisDurumu.SelectedItem = entity.Status.ToName();
            txtAciklama.Text = entity.Description;

            txtToplam.Value = entity.SubTotal;
            txtToplamKDV.Value = entity.TaxAmount;
            txtNet.Value = entity.GrandTotal;

            if (entity.Lines != null)
            {
                foreach (var line in entity.Lines)
                {
                    line.ConversionFactor = GetUnitConversionFactor(line.MaterialId, line.UnitId);
                    line.CurrencyCode = entity.CurrencyCode;
                }
            }

            myGridControl1.DataSource = new BindingList<Application.DTOs.Purchasing.PurchaseOrderLineDto>(entity.Lines ?? new List<Application.DTOs.Purchasing.PurchaseOrderLineDto>());

            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                cmbDovuzTuru.ReadOnly = true;
            }
            else
            {
                cmbDovuzTuru.ReadOnly = false;
                txtKod.Text = "Yeni Sipariş";
            }
        }

        protected override void GuncelNesneOlustur()
        {
            var lines = myGridControl1.DataSource as BindingList<Application.DTOs.Purchasing.PurchaseOrderLineDto>;
            var dtoList = lines != null ? lines.ToList() : new List<Application.DTOs.Purchasing.PurchaseOrderLineDto>();

            var dto = new Application.DTOs.Purchasing.PurchaseOrderDto
            {
                Id = Id,
                Code = txtKod.Text,
                DocumentNo = txtBelgeNo.Text,
                OrderDate = txtSiparisTarihi.EditValue != null ? (DateTime)txtSiparisTarihi.EditValue : DateTime.Now,
                DeliveryDate = txtTeslimatTarihi.EditValue as DateTime?,
                SupplierId = (long)(glufTedarikciCari.EditValue ?? 0L),
                WarehouseId = (long?)glufTeslimatDeposu.EditValue,
                CurrencyCode = cmbDovuzTuru.EditValue?.ToString(),
                ExchangeRate = txtDovizKuru.Value,
                Status = cmbSiparisDurumu.SelectedItem != null ? WinBeyazEsya.Presentation.WinForms.Helpers.EnumFunctions.GetEnum<OrderStatus>(cmbSiparisDurumu.SelectedItem.ToString()) : OrderStatus.Draft,
                Description = txtAciklama.Text,
                SubTotal = txtToplam.Value,
                TaxAmount = txtToplamKDV.Value,
                GrandTotal = txtNet.Value,
                Lines = dtoList
            };

            CurrentEntity = dto;
            ButonEnabledDurumu();
        }

        #region Event Handlers & Lookup Seçimleri

        private void GlufTedarikciCari_SearchButtonClicked(object? sender, EventArgs e)
        {
            if (Program.ServiceProvider != null)
            {
                var form = Microsoft.Extensions.DependencyInjection.ActivatorUtilities.CreateInstance<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.CariTanimForms.CariTanimListForm>(Program.ServiceProvider);
                form.FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
                form.ShowDialog();

                if (form.DialogResult == DialogResult.OK && form.SelectedEntities != null && form.SelectedEntities.Count > 0)
                {
                    glufTedarikciCari.EditValue = form.SelectedEntities[0].Id;
                }
            }
        }

        private void GlufTeslimatDeposu_SearchButtonClicked(object? sender, EventArgs e)
        {
            if (Program.ServiceProvider != null)
            {
                var form = Microsoft.Extensions.DependencyInjection.ActivatorUtilities.CreateInstance<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.DepoTanimForms.DepoTanimListForm>(Program.ServiceProvider);
                form.FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
                form.ShowDialog();

                if (form.DialogResult == DialogResult.OK && form.SelectedEntities != null && form.SelectedEntities.Count > 0)
                {
                    glufTeslimatDeposu.EditValue = form.SelectedEntities[0].Id;
                }
            }
        }

        private void KurHesapla_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbDovuzTuru.SelectedItem == null || txtSiparisTarihi.EditValue == null || _exchangeRateService == null) return;
            
            if (cmbDovuzTuru.EditValue != null)
            {
                string currencyCode = cmbDovuzTuru.EditValue.ToString();
                DateTime orderDate = (DateTime)txtSiparisTarihi.EditValue;

                if (currencyCode == "TRY" || currencyCode == "TL")
                {
                    txtDovizKuru.Value = 1;
                }
                else
                {
                    var rates = _exchangeRateService.GetAllRates()
                        .Where(x => x.CurrencyCode == currencyCode && x.RateDate.Date <= orderDate.Date)
                        .OrderByDescending(x => x.RateDate)
                        .ToList();

                    if (rates.Any())
                    {
                        txtDovizKuru.Value = rates.First().EffectiveSellingRate;
                    }
                    else
                    {
                        var latest = _exchangeRateService.GetAllRates()
                            .Where(x => x.CurrencyCode == currencyCode)
                            .OrderByDescending(x => x.RateDate)
                            .FirstOrDefault();

                        txtDovizKuru.Value = latest != null ? latest.EffectiveSellingRate : 1;
                    }
                }
            }
        }
        
        #endregion

        #region Helpers & Data Methods

        protected override bool EntityInsert()
        {
            myGridView1.PostEditor();
            try
            {
                var dto = (Application.DTOs.Purchasing.PurchaseOrderDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);
                Id = _purchaseOrderService.Insert(dto);
                return Id > 0;
            }
            catch (Exception ex)
            {
                string msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                Helpers.Messages.HataBasligi(msg, "Kayıt Hatası");
                return false;
            }
        }

        protected override bool EntityUpdate()
        {
            myGridView1.PostEditor();
            try
            {
                _purchaseOrderService.Update((Application.DTOs.Purchasing.PurchaseOrderDto)CurrentEntity);
                return true;
            }
            catch (Exception ex)
            {
                string msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                Helpers.Messages.HataBasligi(msg, "Güncelleme Hatası");
                return false;
            }
        }

        private void MyGridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            var view = sender as GridView;
            if (view == null) return;

            if (view.FocusedColumn.FieldName == "UnitId")
            {
                _oldUnitId = view.GetFocusedRowCellValue("UnitId");
                
                var materialIdValue = view.GetFocusedRowCellValue("MaterialId");
                if (materialIdValue == null || materialIdValue == DBNull.Value || Convert.ToInt64(materialIdValue) <= 0)
                {
                    e.Cancel = true; // Malzeme seçilmeden Birim seçilemez
                }
            }
        }

        private void MyGridView1_ShownEditor(object sender, EventArgs e)
        {
            var view = sender as GridView;
            if (view == null) return;

            if (view.FocusedColumn.FieldName == "UnitId" && view.ActiveEditor is DevExpress.XtraEditors.LookUpEdit editor)
            {
                var materialIdValue = view.GetFocusedRowCellValue("MaterialId");
                if (materialIdValue != null && materialIdValue != DBNull.Value)
                {
                    long materialId = Convert.ToInt64(materialIdValue);
                    if (materialId > 0)
                    {
                        var allowedUnits = GetUnitsForMaterial(materialId);
                        editor.Properties.DataSource = allowedUnits;
                    }
                }
            }
        }

        private void MyGridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var view = sender as GridView;
            if (view == null) return;

            if (e.Column.FieldName == "MaterialId")
            {
                var materialIdValue = e.Value;
                if (materialIdValue != null && materialIdValue != DBNull.Value)
                {
                    long materialId = Convert.ToInt64(materialIdValue);
                    
                    var material = _allMaterials?.FirstOrDefault(x => x.Id == materialId);
                    if (material != null && material.BaseUnitId.HasValue)
                    {
                        view.SetRowCellValue(e.RowHandle, "UnitId", material.BaseUnitId.Value);
                    }
                }
                else
                {
                    view.SetRowCellValue(e.RowHandle, "UnitId", null);
                }
            }
            else if (e.Column.FieldName == "UnitId")
            {
                var newUnitIdValue = e.Value;
                if (newUnitIdValue != null && newUnitIdValue != DBNull.Value && _oldUnitId != null && _oldUnitId != DBNull.Value)
                {
                    long newUnitId = Convert.ToInt64(newUnitIdValue);
                    long oldUnitId = Convert.ToInt64(_oldUnitId);

                    if (newUnitId != oldUnitId)
                    {
                        var materialIdValue = view.GetRowCellValue(e.RowHandle, "MaterialId");
                        if (materialIdValue != null && materialIdValue != DBNull.Value)
                        {
                            long materialId = Convert.ToInt64(materialIdValue);

                            decimal oldFactor = GetUnitConversionFactor(materialId, oldUnitId);
                            decimal newFactor = GetUnitConversionFactor(materialId, newUnitId);
                            
                            var row = view.GetRow(e.RowHandle) as Application.DTOs.Purchasing.PurchaseOrderLineDto;
                            if (row != null)
                            {
                                row.ConversionFactor = newFactor;
                            }
                            
                            var currentPrice = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, "UnitPrice") ?? 0);

                            if (oldFactor != 0)
                            {
                                decimal basePrice = currentPrice / oldFactor;
                                decimal newPrice = basePrice * newFactor;
                                view.SetRowCellValue(e.RowHandle, "UnitPrice", newPrice);
                            }
                            
                            view.RefreshRow(e.RowHandle);
                        }
                    }
                }
            }
            else if (e.Column.FieldName == "Quantity" || e.Column.FieldName == "UnitPrice")
            {
                var quantity = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, "Quantity") ?? 0);
                var unitPrice = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, "UnitPrice") ?? 0);
                var lineTotal = quantity * unitPrice;

                view.SetRowCellValue(e.RowHandle, "LineTotal", lineTotal);
                CalculateTotals();
                
                if (e.Column.FieldName == "Quantity")
                {
                    view.RefreshRow(e.RowHandle);
                }
            }
            else if (e.Column.FieldName == "TaxRate" || e.Column.FieldName == "LineTotal")
            {
                CalculateTotals();
            }
        }

        private void CalculateTotals()
        {
            myGridView1.PostEditor();
            myGridView1.UpdateCurrentRow();

            var lines = myGridControl1.DataSource as BindingList<Application.DTOs.Purchasing.PurchaseOrderLineDto>;
            if (lines != null)
            {
                decimal subTotal = lines.Sum(x => x.LineTotal);
                decimal taxAmount = lines.Sum(x => x.LineTotal * (x.TaxRate / 100m));
                decimal grandTotal = subTotal + taxAmount;

                txtToplam.Value = subTotal;
                txtToplamKDV.Value = taxAmount;
                txtNet.Value = grandTotal;
            }
        }

        #region Birim (Unit) — DevExpress ShownEditor Mimarisi

        private List<UnitDropdownItem> GetUnitsForMaterial(long materialId)
        {
            if (_materialUnitsCache.ContainsKey(materialId))
                return _materialUnitsCache[materialId];

            var unitList = new List<UnitDropdownItem>();
            if (materialId <= 0) return unitList;

            var material = _allMaterials?.FirstOrDefault(x => x.Id == materialId);
            if (material == null) return unitList;

            // Ana repodaki tüm birimleri al (İsimleri kesin dolu olan yer burası)
            var allUnits = repoBirim.DataSource as List<UnitDropdownItem>;

            if (material.BaseUnitId.HasValue)
            {
                var baseUnit = allUnits?.FirstOrDefault(u => u.Id == material.BaseUnitId.Value);
                string unitName = baseUnit != null ? baseUnit.Name : material.BaseUnitName;
                unitList.Add(new UnitDropdownItem { Id = material.BaseUnitId.Value, Name = unitName ?? "" });
            }

            if (_unitConversionService != null)
            {
                var conversions = _unitConversionService.GetByEntityId(materialId).ToList();
                foreach (var conv in conversions)
                {
                    if (unitList.All(x => x.Id != conv.UnitId))
                    {
                        var convUnit = allUnits?.FirstOrDefault(u => u.Id == conv.UnitId);
                        string unitName = convUnit != null ? convUnit.Name : conv.UnitName;
                        unitList.Add(new UnitDropdownItem { Id = conv.UnitId, Name = unitName ?? "" });
                    }
                }
            }

            _materialUnitsCache[materialId] = unitList;
            return unitList;
        }

        private decimal GetUnitConversionFactor(long materialId, long unitId)
        {
            var material = _allMaterials?.FirstOrDefault(x => x.Id == materialId);
            if (material == null) return 1m;
            
            if (material.BaseUnitId.HasValue && material.BaseUnitId.Value == unitId)
                return 1m;
                
            if (_unitConversionService != null)
            {
                var conv = _unitConversionService.GetByEntityId(materialId).FirstOrDefault(x => x.UnitId == unitId);
                if (conv != null && conv.Divisor != 0)
                {
                    return conv.Multiplier / conv.Divisor;
                }
            }
            return 1m;
        }

        #endregion

        private void LoadAllMaterials()
        {
            _allMaterials = new List<MaterialLookupDto>();
            if (Program.ServiceProvider == null || DesignMode) return;

            var metalService = (WinBeyazEsya.Application.Interfaces.Definitions.IMetalSheetGroupService?)Program.ServiceProvider.GetService(typeof(WinBeyazEsya.Application.Interfaces.Definitions.IMetalSheetGroupService));
            var electricService = (WinBeyazEsya.Application.Interfaces.Definitions.IElectricalElectronicGroupService?)Program.ServiceProvider.GetService(typeof(WinBeyazEsya.Application.Interfaces.Definitions.IElectricalElectronicGroupService));
            var plasticService = (WinBeyazEsya.Application.Interfaces.Definitions.IPlasticAndVisualPartsGroupService?)Program.ServiceProvider.GetService(typeof(WinBeyazEsya.Application.Interfaces.Definitions.IPlasticAndVisualPartsGroupService));
            var chemicalService = (WinBeyazEsya.Application.Interfaces.Definitions.IChemicalAndInsulationGroupService?)Program.ServiceProvider.GetService(typeof(WinBeyazEsya.Application.Interfaces.Definitions.IChemicalAndInsulationGroupService));
            var mechanicService = (WinBeyazEsya.Application.Interfaces.Definitions.IMechanicalAndHardwareGroupService?)Program.ServiceProvider.GetService(typeof(WinBeyazEsya.Application.Interfaces.Definitions.IMechanicalAndHardwareGroupService));
            var packService = (WinBeyazEsya.Application.Interfaces.Definitions.IPackagingAndPrintingGroupService?)Program.ServiceProvider.GetService(typeof(WinBeyazEsya.Application.Interfaces.Definitions.IPackagingAndPrintingGroupService));
            var wireService = (WinBeyazEsya.Application.Interfaces.Definitions.IWireAndGridGroupService?)Program.ServiceProvider.GetService(typeof(WinBeyazEsya.Application.Interfaces.Definitions.IWireAndGridGroupService));
            var otherService = (WinBeyazEsya.Application.Interfaces.Definitions.IOtherMaterialGroupService?)Program.ServiceProvider.GetService(typeof(WinBeyazEsya.Application.Interfaces.Definitions.IOtherMaterialGroupService));

            if (metalService != null)
                _allMaterials.AddRange(metalService.GetAll().Where(x => x.IsActive).Select(x => new MaterialLookupDto { Id = x.Id, Code = x.Code, Name = x.Name, BaseUnitId = x.BaseUnitId, BaseUnitName = x.BaseUnitName, MaterialGroupName = "Metal ve Sac Grubu" }));
            
            if (electricService != null)
                _allMaterials.AddRange(electricService.GetAll().Where(x => x.IsActive).Select(x => new MaterialLookupDto { Id = x.Id, Code = x.Code, Name = x.Name, BaseUnitId = x.BaseUnitId, BaseUnitName = x.BaseUnitName, MaterialGroupName = "Elektrik ve Elektronik Grubu" }));
                
            if (plasticService != null)
                _allMaterials.AddRange(plasticService.GetAll().Where(x => x.IsActive).Select(x => new MaterialLookupDto { Id = x.Id, Code = x.Code, Name = x.Name, BaseUnitId = x.BaseUnitId, BaseUnitName = x.BaseUnitName, MaterialGroupName = "Plastik ve Görsel Aksam Grubu" }));
                
            if (chemicalService != null)
                _allMaterials.AddRange(chemicalService.GetAll().Where(x => x.IsActive).Select(x => new MaterialLookupDto { Id = x.Id, Code = x.Code, Name = x.Name, BaseUnitId = x.BaseUnitId, BaseUnitName = x.BaseUnitName, MaterialGroupName = "Kimya ve Yalıtım Grubu" }));
                
            if (mechanicService != null)
                _allMaterials.AddRange(mechanicService.GetAll().Where(x => x.IsActive).Select(x => new MaterialLookupDto { Id = x.Id, Code = x.Code, Name = x.Name, BaseUnitId = x.BaseUnitId, BaseUnitName = x.BaseUnitName, MaterialGroupName = "Mekanik ve Hırdavat Grubu" }));
                
            if (packService != null)
                _allMaterials.AddRange(packService.GetAll().Where(x => x.IsActive).Select(x => new MaterialLookupDto { Id = x.Id, Code = x.Code, Name = x.Name, BaseUnitId = x.BaseUnitId, BaseUnitName = x.BaseUnitName, MaterialGroupName = "Ambalaj ve Matbaa Grubu" }));
                
            if (wireService != null)
                _allMaterials.AddRange(wireService.GetAll().Where(x => x.IsActive).Select(x => new MaterialLookupDto { Id = x.Id, Code = x.Code, Name = x.Name, BaseUnitId = x.BaseUnitId, BaseUnitName = x.BaseUnitName, MaterialGroupName = "Tel ve Izgara Grubu" }));
                
            if (otherService != null)
                _allMaterials.AddRange(otherService.GetAll().Where(x => x.IsActive).Select(x => new MaterialLookupDto { Id = x.Id, Code = x.Code, Name = x.Name, BaseUnitId = x.BaseUnitId, BaseUnitName = x.BaseUnitName, MaterialGroupName = "Diğer Malzeme Grubu" }));
        }
        #endregion
    }

    public class MaterialLookupDto
    {
        public long Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public long? BaseUnitId { get; set; }
        public string BaseUnitName { get; set; } = string.Empty;
        public string MaterialGroupName { get; set; } = string.Empty;
    }

    public class UnitDropdownItem
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}