using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;

using WinBeyazEsya.Application.DTOs.Definitions;
using WinBeyazEsya.Application.Interfaces.Definitions;
using WinBeyazEsya.Presentation.WinForms.Helpers;
using WinBeyazEsya.Domain.Enums;
using Microsoft.Extensions.DependencyInjection;
using DevExpress.XtraGrid.Menu;
using DevExpress.Utils.Menu;
using WinBeyazEsya.Application.Interfaces.Repositories.Definitions;

namespace WinBeyazEsya.Presentation.WinForms.Forms.UretimForms
{
    public partial class UrunReceteEditForm : BaseEditForm
    {
        private readonly IProductRecipeService? _productRecipeService;
        private readonly IServiceProvider? _serviceProvider;
        private readonly IUnitRepository? _unitRepository;
        private readonly IGeneralExpenseService? _generalExpenseService;
        private readonly ICurrentAccountService? _currentAccountService;
        private ProductRecipeDto _currentDto = new ProductRecipeDto();
        private BindingList<ProductRecipeLineDto> _lines = new BindingList<ProductRecipeLineDto>();
        private string _defaultCurrency = "TL";
        private decimal _totalOverhead = 0;
        private decimal _totalRecipeCost = 0;
        private decimal _netMaterialCost = 0;
        private string _costBreakdownText = "";
        private bool _isGridModified = false;

        public UrunReceteEditForm(IProductRecipeService? productRecipeService = null, IServiceProvider? serviceProvider = null, IUnitRepository? unitRepository = null, IGeneralExpenseService? generalExpenseService = null, ICurrentAccountService? currentAccountService = null)
        {
            InitializeComponent();
            txtToplamReceteMaliyeti.Properties.ReadOnly = true;
            txtKur.Properties.ReadOnly = true;
            BaseKartTuru = WinBeyazEsya.Domain.Enums.ModuleType.ProductRecipe;
            _productRecipeService = productRecipeService;
            _serviceProvider = serviceProvider;
            _unitRepository = unitRepository;
            _generalExpenseService = generalExpenseService;
            _currentAccountService = currentAccountService;

            DataLayoutControl = myDataLayoutControl1;
            DataLayoutControls = new object[] { myDataLayoutControl2 };
            Bll = _productRecipeService;
            
            if (glufMamul != null)
                glufMamul.EditValueChanged += GlufMamul_EditValueChanged;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            if (!DesignMode)
            {
                txtRevizyonNo.Properties.ReadOnly = true;

                if (_serviceProvider != null)
                {
                    var finishedGoodService = _serviceProvider.GetService<IFinishedGoodService>();
                    if (finishedGoodService != null)
                    {
                        glufMamul.Properties.DataSource = finishedGoodService.GetAll().Where(x => x.IsActive).ToList();
                        glufMamul.Properties.ValueMember = "Id";
                        glufMamul.Properties.DisplayMember = "Name";
                    }
                }

                if (_unitRepository != null)
                {
                    var repoUnit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
                    repoUnit.DataSource = _unitRepository.Find(x => x.IsActive).ToList();
                    repoUnit.ValueMember = "Id";
                    repoUnit.DisplayMember = "Name";
                    repoUnit.Columns.Clear();
                    repoUnit.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Birim"));
                    repoUnit.ShowHeader = true;
                    
                    myGridControl1.RepositoryItems.Add(repoUnit);
                    myGridView1.Columns["UnitId"].ColumnEdit = repoUnit;
                }

                TreeListDoldur();
                
                myGridControl1.DataSource = _lines;
                
                // Allow drag-drop setup
                treeList1.OptionsBehavior.DragNodes = true;
                myGridControl1.AllowDrop = true;

                if (_serviceProvider != null)
                {
                    var paramService = _serviceProvider.GetService<WinBeyazEsya.Application.Interfaces.Management.ISystemParameterService>();
                    if (paramService != null)
                    {
                        var param = paramService.GetSystemParameterAsync().GetAwaiter().GetResult();
                        if (param != null && !string.IsNullOrEmpty(param.LocalCurrency))
                            _defaultCurrency = param.LocalCurrency;
                    }

                    var exchangeService = _serviceProvider.GetService<WinBeyazEsya.Application.Interfaces.System.IExchangeRateService>();
                    if (exchangeService != null)
                    {
                        var rates = exchangeService.GetAllRates();
                        var usd = rates.Where(x => x.CurrencyCode == "USD").OrderByDescending(x => x.RateDate).FirstOrDefault();
                        var eur = rates.Where(x => x.CurrencyCode == "EUR").OrderByDescending(x => x.RateDate).FirstOrDefault();
                        string kurText = "Kur: ";
                        if (usd != null) kurText += $"USD {usd.EffectiveSellingRate:n4} - ";
                        if (eur != null) kurText += $"EUR {eur.EffectiveSellingRate:n4}";
                        //lblKur.Text = kurText.TrimEnd('-', ' ');
                    }
                }

                GridAyarlariniYap();
                
                // Yükleme sonrası grid düzenini geri yükle
                Helpers.LayoutHelper.YukleGrid(myGridView1);
                
                _ = MaliyetiHesaplaAsync();
            }
        }

        protected override void EventsLoad()
        {
            base.EventsLoad();
            
            if (glufMamul != null) 
            {
                glufMamul.SearchButtonClicked += glufMamul_SearchButtonClicked;
                glufMamul.EditValueChanged += GlufMamul_EditValueChanged;
            }

            if (!DesignMode)
            {
                if (btnRevizeEt != null) btnRevizeEt.Click -= BtnRevizeEt_Click;
                if (btnKopyala != null) btnKopyala.Click -= BtnKopyala_Click;
                if (btnMaliyetiGuncelle != null) btnMaliyetiGuncelle.Click -= BtnMaliyetiGuncelle_Click;
                if (btnMaliyetKirilimi != null) btnMaliyetKirilimi.Click -= BtnMaliyetKirilimi_Click;

                treeList1.MouseDown -= TreeList1_MouseDown;
                treeList1.MouseMove -= TreeList1_MouseMove;
                myGridControl1.DragOver -= MyGridControl1_DragOver;
                myGridControl1.DragDrop -= MyGridControl1_DragDrop;
                treeList1.NodeCellStyle -= TreeList1_NodeCellStyle;
                treeList1.PopupMenuShowing -= TreeList1_PopupMenuShowing;
                myGridView1.PopupMenuShowing -= MyGridView1_PopupMenuShowing;
                myGridView1.RowCellStyle -= MyGridView1_RowCellStyle;

                treeList1.MouseDown += TreeList1_MouseDown;
                treeList1.MouseMove += TreeList1_MouseMove;
                myGridControl1.DragOver += MyGridControl1_DragOver;
                myGridControl1.DragDrop += MyGridControl1_DragDrop;
                treeList1.NodeCellStyle += TreeList1_NodeCellStyle;
                treeList1.PopupMenuShowing += TreeList1_PopupMenuShowing;
                myGridView1.PopupMenuShowing += MyGridView1_PopupMenuShowing;
                myGridView1.RowCellStyle += MyGridView1_RowCellStyle;
                myGridView1.ShowingEditor += MyGridView1_ShowingEditor;

                if (btnRevizeEt != null) btnRevizeEt.Click += BtnRevizeEt_Click;
                if (btnKopyala != null) btnKopyala.Click += BtnKopyala_Click;
                myGridView1.CustomColumnDisplayText += MyGridView1_CustomColumnDisplayText;
                myGridView1.CellValueChanged += MyGridView1_CellValueChanged;
                myGridView1.RowDeleted += MyGridView1_RowDeleted;
                
                if (btnMaliyetiGuncelle != null) btnMaliyetiGuncelle.Click += BtnMaliyetiGuncelle_Click;
                if (btnMaliyetKirilimi != null) btnMaliyetKirilimi.Click += BtnMaliyetKirilimi_Click;
            }
        }

        private void GridAyarlariniYap()
        {
            if (myGridView1.Columns["MaterialCode"] != null)
                myGridView1.Columns["MaterialCode"].Visible = false;

            if (myGridView1.Columns["WeightKg"] == null && myGridView1.Columns["Weight"] != null)
            {
                myGridView1.Columns["Weight"].FieldName = "WeightKg";
                myGridView1.Columns["WeightKg"].Caption = "Ağırlık (Kg)";
            }

            if (_serviceProvider != null)
            {
                var chemicalService = _serviceProvider.GetService<IChemicalAndInsulationGroupService>();
                if (chemicalService != null)
                {
                    var repoCoating = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
                    repoCoating.DataSource = chemicalService.GetAll().Where(x => x.IsActive).ToList();
                    repoCoating.ValueMember = "Id";
                    repoCoating.DisplayMember = "Name";
                    repoCoating.NullText = "";
                    
                    var view = new DevExpress.XtraGrid.Views.Grid.GridView();
                    view.Columns.AddVisible("Name", "Kaplama Malzemesi");
                    repoCoating.PopupView = view;
                    
                    myGridControl1.RepositoryItems.Add(repoCoating);
                    myGridView1.Columns["CoatingMaterialId"].ColumnEdit = repoCoating;
                }
            }

            if (_currentAccountService != null)
            {
                var repoSupplier = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
                repoSupplier.DataSource = _currentAccountService.GetAll()
                    .Where(x => x.IsActive && (x.CardType == (int)CardType.Tedarikci || x.CardType == (int)CardType.MusteriVeTedarikci)).ToList();
                repoSupplier.ValueMember = "Id";
                repoSupplier.DisplayMember = "Title";
                repoSupplier.NullText = "";

                var viewSupplier = new DevExpress.XtraGrid.Views.Grid.GridView();
                viewSupplier.Columns.AddVisible("Title", "Cari Ünvanı");
                repoSupplier.PopupView = viewSupplier;

                myGridControl1.RepositoryItems.Add(repoSupplier);
                if (myGridView1.Columns["SupplierId"] != null)
                {
                    myGridView1.Columns["SupplierId"].ColumnEdit = repoSupplier;
                }
            }

            if (myGridView1.Columns["WasteRate"] != null)
            {
                var repoWasteRate = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
                repoWasteRate.MinValue = 0;
                repoWasteRate.MaxValue = 100;
                repoWasteRate.IsFloatValue = true;
                repoWasteRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                repoWasteRate.DisplayFormat.FormatString = "n2";
                repoWasteRate.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                repoWasteRate.EditFormat.FormatString = "n2";
                repoWasteRate.EditMask = "n2";
                repoWasteRate.UseMaskAsDisplayFormat = true;
                
                myGridControl1.RepositoryItems.Add(repoWasteRate);
                myGridView1.Columns["WasteRate"].ColumnEdit = repoWasteRate;
            }

            var maliyetParametreService = _serviceProvider?.GetService<WinBeyazEsya.Application.Interfaces.Management.IMaliyetParametreService>();
            bool useWasteRate = true;
            if (maliyetParametreService != null)
            {
                var parametre = maliyetParametreService.GetMaliyetParametreAsync().GetAwaiter().GetResult();
                if (parametre != null)
                {
                    useWasteRate = parametre.UseWasteRate;
                }
            }

            var lockedColumns = new List<string> { "MaterialGroupName", "MaterialName", "UnitId", "SurfaceCoatingType", "TotalMaterialCost", "WeightKg", "UnitPrice" };
            if (!useWasteRate)
            {
                lockedColumns.Add("WasteRate");
            }
            // Note: CoatingAmount, CoatingMaterialId, ManualCoatingCost are controlled via ShowingEditor based on MaterialType.
            string[] n6Columns = { "WeightKg" };
            string[] n4Columns = { "UnitPrice", "TotalMaterialCost", "ManualCoatingCost" };
            string[] n2Columns = { "Quantity", "CoatingAmount" };

            myGridView1.OptionsView.ShowFooter = true;
            if (myGridView1.Columns["TotalMaterialCost"] != null)
            {
                myGridView1.Columns["TotalMaterialCost"].Summary.Clear();
                myGridView1.Columns["TotalMaterialCost"].Summary.Add(new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalMaterialCost", "Net Malzeme Tutarı: {0:n2} " + _defaultCurrency));
            }

            decimal totalOverhead = 0;
            if (_generalExpenseService != null)
            {
                var expenses = _generalExpenseService.GetAll().Where(x => x.IsActive).ToList();
                var exchangeService = _serviceProvider?.GetService<WinBeyazEsya.Application.Interfaces.System.IExchangeRateService>();
                var rates = exchangeService?.GetAllRates().ToList();
                foreach(var exp in expenses)
                {
                    decimal amount = exp.Cost;
                    if (!string.IsNullOrEmpty(exp.CurrencyCode) && exp.CurrencyCode != _defaultCurrency && rates != null)
                    {
                        var rate = rates.Where(x => x.CurrencyCode == exp.CurrencyCode).OrderByDescending(x => x.RateDate).FirstOrDefault();
                        if (rate != null) amount *= rate.EffectiveSellingRate;
                    }
                    totalOverhead += amount;
                }
            }
            _totalOverhead = totalOverhead;

            if (myGridView1.Columns["UnitPrice"] != null)
            {
                myGridView1.Columns["UnitPrice"].Summary.Clear();
                var overheadSummary = new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "UnitPrice", "Genel Üretim Gideri: {0:n2} " + _defaultCurrency);
                myGridView1.Columns["UnitPrice"].Summary.Add(overheadSummary);
                myGridView1.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                myGridView1.CustomSummaryCalculate -= MyGridView1_CustomSummaryCalculate;
                myGridView1.CustomSummaryCalculate += MyGridView1_CustomSummaryCalculate;
            }
            
            if (myGridView1.Columns["MaterialName"] != null)
            {
                myGridView1.Columns["MaterialName"].Summary.Clear();
            }

            foreach (DevExpress.XtraGrid.Columns.GridColumn col in myGridView1.Columns)
            {
                if (lockedColumns.Contains(col.FieldName))
                {
                    col.OptionsColumn.AllowEdit = false;
                    col.OptionsColumn.ReadOnly = true;
                }
                else
                {
                    col.OptionsColumn.AllowEdit = true;
                    col.OptionsColumn.ReadOnly = false;
                }

                if (n6Columns.Contains(col.FieldName))
                {
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    col.DisplayFormat.FormatString = "n6";
                    col.RealColumnEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    col.RealColumnEdit.EditFormat.FormatString = "n6";
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                }
                else if (n4Columns.Contains(col.FieldName))
                {
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    col.DisplayFormat.FormatString = "n4";
                    col.RealColumnEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    col.RealColumnEdit.EditFormat.FormatString = "n4";
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                }
                else if (n2Columns.Contains(col.FieldName))
                {
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    col.DisplayFormat.FormatString = "n2";
                    col.RealColumnEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    col.RealColumnEdit.EditFormat.FormatString = "n2";
                    col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                }
            }
            
            // Sadece Miktar Kolonu İçin Özel Formatlama (Display, Group ve Focus/EditMask)
            var miktarRepo = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            miktarRepo.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            miktarRepo.Mask.EditMask = "n2";
            miktarRepo.Mask.UseMaskAsDisplayFormat = true;
            myGridControl1.RepositoryItems.Add(miktarRepo);
            
            colMiktar.ColumnEdit = miktarRepo;
            colMiktar.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colMiktar.DisplayFormat.FormatString = "n2";
            colMiktar.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            colMiktar.GroupFormat.FormatString = "n2";
            
            // Sadece Kaplama (gr) Kolonu İçin Özel Formatlama
            if (colKaplamaGr != null)
            {
                var kaplamaGrRepo = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
                kaplamaGrRepo.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                kaplamaGrRepo.Mask.EditMask = "n2";
                kaplamaGrRepo.Mask.UseMaskAsDisplayFormat = true;
                myGridControl1.RepositoryItems.Add(kaplamaGrRepo);
                
                colKaplamaGr.ColumnEdit = kaplamaGrRepo;
                colKaplamaGr.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                colKaplamaGr.DisplayFormat.FormatString = "n2";
                colKaplamaGr.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                colKaplamaGr.GroupFormat.FormatString = "n2";
            }
        }

        private void MyGridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;
            
            if (myGridView1.IsCellSelected(e.RowHandle, e.Column)) return;

            var row = myGridView1.GetRow(e.RowHandle) as ProductRecipeLineDto;
            
            if (e.Column.FieldName == "TotalMaterialCost")
            {
                e.Appearance.BackColor = Color.FromArgb(225, 222, 235);
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                e.Appearance.ForeColor = Color.FromArgb(55, 65, 81);
                return;
            }

            if (row != null && (e.Column.FieldName == "CoatingAmount" || e.Column.FieldName == "CoatingMaterialId" || e.Column.FieldName == "ManualCoatingCost"))
            {
                if (row.MaterialType != MaterialType.MetalAndSheet)
                {
                    e.Appearance.BackColor = Color.FromArgb(244, 244, 244);
                    e.Appearance.ForeColor = Color.FromArgb(55, 65, 81);
                    return;
                }
                else
                {
                    bool isOpen = false;
                    if (e.Column.FieldName == "CoatingAmount" || e.Column.FieldName == "CoatingMaterialId")
                    {
                        if (row.SurfaceCoatingType != "Diger") isOpen = true;
                    }
                    else if (e.Column.FieldName == "ManualCoatingCost")
                    {
                        if (row.SurfaceCoatingType == "Diger") isOpen = true;
                    }
                    
                    if (isOpen)
                    {
                        if (!myGridView1.IsCellSelected(e.RowHandle, e.Column)) e.Appearance.BackColor = Color.FromArgb(236, 246, 255);
                        e.Appearance.ForeColor = Color.FromArgb(55, 65, 81);
                    }
                    else
                    {
                        e.Appearance.BackColor = Color.FromArgb(244, 244, 244);
                        e.Appearance.ForeColor = Color.FromArgb(55, 65, 81);
                    }
                    return;
                }
            }

            if (e.Column.OptionsColumn.AllowEdit)
            {
                if (!myGridView1.IsCellSelected(e.RowHandle, e.Column)) e.Appearance.BackColor = Color.FromArgb(236, 246, 255);
                e.Appearance.ForeColor = Color.FromArgb(55, 65, 81);
            }
            else
            {
                e.Appearance.BackColor = Color.FromArgb(244, 244, 244);
                e.Appearance.ForeColor = Color.FromArgb(55, 65, 81);
            }
        }

        private void MyGridView1_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if (e.IsTotalSummary && (e.Item as DevExpress.XtraGrid.GridColumnSummaryItem)?.FieldName == "UnitPrice")
            {
                e.TotalValue = _totalOverhead;
            }
        }

        private void MyGridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (view == null) return;
            var row = view.GetFocusedRow() as ProductRecipeLineDto;
            if (row == null) return;

            if (view.FocusedColumn.FieldName == "CoatingAmount" || view.FocusedColumn.FieldName == "CoatingMaterialId")
            {
                if (row.MaterialType != MaterialType.MetalAndSheet)
                    e.Cancel = true;
                else if (row.SurfaceCoatingType == "Diger")
                    e.Cancel = true;
            }
            else if (view.FocusedColumn.FieldName == "ManualCoatingCost")
            {
                if (row.MaterialType == MaterialType.MetalAndSheet && row.SurfaceCoatingType == "Diger")
                    e.Cancel = false;
                else
                    e.Cancel = true;
            }
        }

        private void MyGridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (view == null || e.ListSourceRowIndex < 0) return;
            var row = view.GetRow(view.GetRowHandle(e.ListSourceRowIndex)) as ProductRecipeLineDto;
            if (row == null) return;

            if (e.Column.FieldName == "CoatingAmount" || e.Column.FieldName == "ManualCoatingCost" || e.Column.FieldName == "WeightKg")
            {
                if (row.MaterialType != MaterialType.MetalAndSheet)
                    e.DisplayText = string.Empty;
            }
            else if (e.Column.FieldName == "UnitPrice" || e.Column.FieldName == "TotalMaterialCost")
            {
                if (e.Value != null && !string.IsNullOrEmpty(row.CurrencyCode))
                {
                    e.DisplayText = $"{Convert.ToDecimal(e.Value):n4} {row.CurrencyCode}";
                }
            }
        }

        private void MyGridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (_isBinding) return;
            
            _isGridModified = true;
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (view == null) return;
            var row = view.GetRow(e.RowHandle) as ProductRecipeLineDto;
            if (row == null) return;

            if (e.Column.FieldName == "Quantity" || e.Column.FieldName == "UnitPrice" || e.Column.FieldName == "CoatingAmount" || e.Column.FieldName == "CoatingMaterialId" || e.Column.FieldName == "ManualCoatingCost" || e.Column.FieldName == "WasteRate" || e.Column.FieldName == "WeightKg")
            {
                decimal totalCost = 0;
                
                if (row.MaterialType == MaterialType.MetalAndSheet)
                {
                    decimal coatingCost = 0;
                    if (row.SurfaceCoatingType == "Diger")
                    {
                        coatingCost = row.ManualCoatingCost;
                    }
                    else if (row.CoatingMaterialId.HasValue && row.CoatingAmount > 0)
                    {
                        var chemicalService = _serviceProvider?.GetService<IChemicalAndInsulationGroupService>();
                        var costService = _serviceProvider?.GetService<WinBeyazEsya.Application.Interfaces.Production.IMaterialCostService>();
                        if (costService != null)
                        {
                            var allCosts = costService.GetAllByMaterialType(WinBeyazEsya.Domain.Enums.ModuleType.KimyaVeYalitimGrubuMaliyetleri);
                            var coatCostObj = allCosts?.FirstOrDefault(x => x.MaterialId == row.CoatingMaterialId.Value);
                            if (coatCostObj != null)
                            {
                                decimal bFiyat = coatCostObj.Cost;
                                if (!string.IsNullOrEmpty(coatCostObj.CurrencyCode) && coatCostObj.CurrencyCode != _defaultCurrency)
                                {
                                    var exchangeService = _serviceProvider?.GetService<WinBeyazEsya.Application.Interfaces.System.IExchangeRateService>();
                                    var bRate = exchangeService?.GetAllRates().Where(x => x.CurrencyCode == coatCostObj.CurrencyCode).OrderByDescending(x => x.RateDate).FirstOrDefault();
                                    if (bRate != null) bFiyat *= bRate.EffectiveSellingRate;
                                }
                                coatingCost = (row.CoatingAmount / 1000m) * bFiyat;
                            }
                        }
                    }
                    
                    decimal materialCost = (row.WeightKg * row.UnitPrice * row.Quantity);
                    if (row.WasteRate > 0)
                    {
                        materialCost = materialCost + (materialCost * row.WasteRate / 100);
                    }
                    
                    totalCost = materialCost + coatingCost;
                }
                else
                {
                    decimal materialCost = row.Quantity * row.UnitPrice;
                    if (row.WasteRate > 0)
                    {
                        materialCost = materialCost + (materialCost * row.WasteRate / 100);
                    }
                    totalCost = materialCost;
                }

                row.TotalMaterialCost = totalCost;
                view.RefreshRow(e.RowHandle);
            }

            myGridView1.PostEditor();
            myGridView1.UpdateCurrentRow();
            myGridView1.UpdateTotalSummary();
            _ = MaliyetiHesaplaAsync(false);
            
            GuncelNesneOlustur();
            ButonEnabledDurumu();
        }

        private void MyGridView1_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            if (_isBinding) return;
            
            _isGridModified = true;
            GuncelNesneOlustur();
            ButonEnabledDurumu();
        }

        private string GetEnumDescription(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            if (field == null) return value.ToString();
            var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
        }

        private class MaterialDragDropBox
        {
            public long MaterialId { get; set; }
            public string MaterialCode { get; set; }
            public string MaterialName { get; set; }
            public long UnitId { get; set; }
            public string UnitName { get; set; }
            public MaterialType MaterialType { get; set; }
        }

        private void TreeListDoldur()
        {
            treeList1.ClearNodes();
            treeList1.Columns.Clear();
            var col = treeList1.Columns.Add();
            col.Caption = "Hammadde Grupları";
            col.VisibleIndex = 0;
            col.OptionsColumn.AllowEdit = false;

            if (_serviceProvider == null) return;

            var metalService = _serviceProvider.GetService<IMetalSheetGroupService>();
            if (metalService != null)
            {
                var parent = treeList1.AppendNode(new object[] { GetEnumDescription(MaterialType.MetalAndSheet) }, null);
                parent.Tag = MaterialType.MetalAndSheet;
                foreach(var item in metalService.GetAll().Where(x => x.IsActive))
                {
                    var child = treeList1.AppendNode(new object[] { item.Name }, parent);
                    child.Tag = new MaterialDragDropBox { MaterialId = item.Id, MaterialCode = item.Code, MaterialName = item.Name, UnitId = item.BaseUnitId, UnitName = item.BaseUnitName, MaterialType = MaterialType.MetalAndSheet };
                }
            }

            var elecService = _serviceProvider.GetService<IElectricalElectronicGroupService>();
            if (elecService != null)
            {
                var parent = treeList1.AppendNode(new object[] { GetEnumDescription(MaterialType.ElectricalElectronic) }, null);
                parent.Tag = MaterialType.ElectricalElectronic;
                foreach(var item in elecService.GetAll().Where(x => x.IsActive))
                {
                    var child = treeList1.AppendNode(new object[] { item.Name }, parent);
                    child.Tag = new MaterialDragDropBox { MaterialId = item.Id, MaterialCode = item.Code, MaterialName = item.Name, UnitId = item.BaseUnitId, UnitName = item.BaseUnitName, MaterialType = MaterialType.ElectricalElectronic };
                }
            }
            
            var gasService = _serviceProvider.GetService<IGasAndIgnitionGroupService>();
            if (gasService != null)
            {
                var parent = treeList1.AppendNode(new object[] { GetEnumDescription(MaterialType.GasAndIgnition) }, null);
                parent.Tag = MaterialType.GasAndIgnition;
                foreach(var item in gasService.GetAll().Where(x => x.IsActive))
                {
                    var child = treeList1.AppendNode(new object[] { item.Name }, parent);
                    child.Tag = new MaterialDragDropBox { MaterialId = item.Id, MaterialCode = item.Code, MaterialName = item.Name, UnitId = item.BaseUnitId, UnitName = item.BaseUnitName, MaterialType = MaterialType.GasAndIgnition };
                }
            }

            var plasticService = _serviceProvider.GetService<IPlasticAndVisualPartsGroupService>();
            if (plasticService != null)
            {
                var parent = treeList1.AppendNode(new object[] { GetEnumDescription(MaterialType.PlasticAndVisualParts) }, null);
                parent.Tag = MaterialType.PlasticAndVisualParts;
                foreach(var item in plasticService.GetAll().Where(x => x.IsActive))
                {
                    var child = treeList1.AppendNode(new object[] { item.Name }, parent);
                    child.Tag = new MaterialDragDropBox { MaterialId = item.Id, MaterialCode = item.Code, MaterialName = item.Name, UnitId = item.BaseUnitId, UnitName = item.BaseUnitName, MaterialType = MaterialType.PlasticAndVisualParts };
                }
            }

            var chemicalService = _serviceProvider.GetService<IChemicalAndInsulationGroupService>();
            if (chemicalService != null)
            {
                var parent = treeList1.AppendNode(new object[] { GetEnumDescription(MaterialType.ChemicalAndInsulation) }, null);
                parent.Tag = MaterialType.ChemicalAndInsulation;
                foreach(var item in chemicalService.GetAll().Where(x => x.IsActive))
                {
                    var child = treeList1.AppendNode(new object[] { item.Name }, parent);
                    child.Tag = new MaterialDragDropBox { MaterialId = item.Id, MaterialCode = item.Code, MaterialName = item.Name, UnitId = item.BaseUnitId, UnitName = item.BaseUnitName, MaterialType = MaterialType.ChemicalAndInsulation };
                }
            }

            var mechService = _serviceProvider.GetService<IMechanicalAndHardwareGroupService>();
            if (mechService != null)
            {
                var parent = treeList1.AppendNode(new object[] { GetEnumDescription(MaterialType.MechanicalAndHardware) }, null);
                parent.Tag = MaterialType.MechanicalAndHardware;
                foreach(var item in mechService.GetAll().Where(x => x.IsActive))
                {
                    var child = treeList1.AppendNode(new object[] { item.Name }, parent);
                    child.Tag = new MaterialDragDropBox { MaterialId = item.Id, MaterialCode = item.Code, MaterialName = item.Name, UnitId = item.BaseUnitId, UnitName = item.BaseUnitName, MaterialType = MaterialType.MechanicalAndHardware };
                }
            }

            var packService = _serviceProvider.GetService<IPackagingAndPrintingGroupService>();
            if (packService != null)
            {
                var parent = treeList1.AppendNode(new object[] { GetEnumDescription(MaterialType.PackagingAndPrinting) }, null);
                parent.Tag = MaterialType.PackagingAndPrinting;
                foreach(var item in packService.GetAll().Where(x => x.IsActive))
                {
                    var child = treeList1.AppendNode(new object[] { item.Name }, parent);
                    child.Tag = new MaterialDragDropBox { MaterialId = item.Id, MaterialCode = item.Code, MaterialName = item.Name, UnitId = item.BaseUnitId, UnitName = item.BaseUnitName, MaterialType = MaterialType.PackagingAndPrinting };
                }
            }

            var wireService = _serviceProvider.GetService<IWireAndGridGroupService>();
            if (wireService != null)
            {
                var parent = treeList1.AppendNode(new object[] { GetEnumDescription(MaterialType.WireAndGrid) }, null);
                parent.Tag = MaterialType.WireAndGrid;
                foreach(var item in wireService.GetAll().Where(x => x.IsActive))
                {
                    var child = treeList1.AppendNode(new object[] { item.Name }, parent);
                    child.Tag = new MaterialDragDropBox { MaterialId = item.Id, MaterialCode = item.Code, MaterialName = item.Name, UnitId = item.BaseUnitId, UnitName = item.BaseUnitName, MaterialType = MaterialType.WireAndGrid };
                }
            }

            var otherService = _serviceProvider.GetService<IOtherMaterialGroupService>();
            if (otherService != null)
            {
                var parent = treeList1.AppendNode(new object[] { GetEnumDescription(MaterialType.OtherMaterial) }, null);
                parent.Tag = MaterialType.OtherMaterial;
                foreach(var item in otherService.GetAll().Where(x => x.IsActive))
                {
                    var child = treeList1.AppendNode(new object[] { item.Name }, parent);
                    child.Tag = new MaterialDragDropBox { MaterialId = item.Id, MaterialCode = item.Code, MaterialName = item.Name, UnitId = item.BaseUnitId, UnitName = item.BaseUnitName, MaterialType = MaterialType.OtherMaterial };
                }
            }
            
            treeList1.ExpandAll();
        }

        private void glufMamul_SearchButtonClicked(object? sender, EventArgs e)
        {
            if (_serviceProvider != null)
            {
                var form = _serviceProvider.GetRequiredService<WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.MamulForms.MamulListForm>();
                if (form != null)
                {
                    form.FormAcilisTuru = WinBeyazEsya.Presentation.WinForms.Enums.FormAcilisTuru.Secim;
                    form.ShowDialog();
                    
                    var finishedGoodService = _serviceProvider.GetService<IFinishedGoodService>();
                    if (finishedGoodService != null && glufMamul != null)
                    {
                        glufMamul.Properties.DataSource = finishedGoodService.GetAll().Where(x => x.IsActive).ToList();
                    }
                    
                    if (form.DialogResult == DialogResult.OK && form.SelectedEntities?.Count > 0 && glufMamul != null)
                    {
                        var secilenId = form.SelectedEntities[0].Id;
                        glufMamul.EditValue = secilenId;
                        _currentDto.FinishedGoodId = secilenId;
                    }
                }
            }
        }

        private void GlufMamul_EditValueChanged(object? sender, EventArgs e)
        {
            bool hasMamul = glufMamul?.EditValue != null && Convert.ToInt64(glufMamul.EditValue) > 0;
            if (treeList1 != null) treeList1.Enabled = hasMamul;
            if (myGridControl1 != null) myGridControl1.Enabled = hasMamul;
        }

        public override void Yukle()
        {
            if (BaseIslemTuru == ActionType.EntityInsert)
            {
                OldEntity = new ProductRecipeDto();
                Id = BaseIslemTuru.IdOlustur(OldEntity);
            }
            else
            {
                OldEntity = _productRecipeService?.GetById(Id);
                if (OldEntity == null)
                {
                    Messages.HataMesaji("Kayıt bulunamadı!");
                    return;
                }
            }

            CurrentEntity = CloneEntity(OldEntity);
            _currentDto = (ProductRecipeDto)CurrentEntity;

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            CurrentEntity = _currentDto;
            _isGridModified = false;
            
            if (_currentDto == null) return;
            
            if (this.Id <= 0 || BaseIslemTuru == ActionType.EntityInsert)
            {
                if (string.IsNullOrEmpty(_currentDto.RevisionNumber))
                    _currentDto.RevisionNumber = "01";
            }

            txtKod.Text = _currentDto.Code;
            txtReceteAdi.Text = _currentDto.Name;
            glufMamul.EditValue = _currentDto.FinishedGoodId > 0 ? _currentDto.FinishedGoodId : null;
            txtAciklama.Text = _currentDto.Description;
            txtTarih.EditValue = _currentDto.Date;
            
            if (int.TryParse(_currentDto.RevisionNumber, out int revNo))
            {
                txtRevizyonNo.EditValue = revNo;
            }
            else
            {
                txtRevizyonNo.Text = _currentDto.RevisionNumber;
            }
            
            var exchangeService = _serviceProvider?.GetService<WinBeyazEsya.Application.Interfaces.System.IExchangeRateService>();
            if (exchangeService != null)
            {
                var rates = exchangeService.GetAllRates();
                var usd = rates.Where(x => x.CurrencyCode == "USD").OrderByDescending(x => x.RateDate).FirstOrDefault();
                var eur = rates.Where(x => x.CurrencyCode == "EUR").OrderByDescending(x => x.RateDate).FirstOrDefault();
                string kurText = "";
                if (usd != null) kurText += $"USD {usd.EffectiveSellingRate:n4} - ";
                if (eur != null) kurText += $"EUR {eur.EffectiveSellingRate:n4}";
                txtKur.Text = kurText.TrimEnd('-', ' ');
            }
            
            _totalRecipeCost = _currentDto.TotalCost;
            _netMaterialCost = _currentDto.NetMaterialCost;
            
            txtToplamReceteMaliyeti.Text = $"{_currentDto.TotalCost:n2} {_defaultCurrency}";
            txtRevizyonNo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtRevizyonNo.Properties.DisplayFormat.FormatString = "00";

            _lines.Clear();
            if (_currentDto.Lines != null)
            {
                foreach(var line in _currentDto.Lines)
                {
                    _lines.Add(line);
                }
            }
            myGridControl1.DataSource = _lines;

            if (!string.IsNullOrEmpty(_currentDto.RevisionNumber) && int.TryParse(_currentDto.RevisionNumber, out int parsedRevNo))
            {
                txtRevizyonNo.EditValue = parsedRevNo;
            }
            else
            {
                txtRevizyonNo.EditValue = 1;
            }
            
            tglDurum.IsOn = _currentDto.IsActive;
            tglDurum.EditValueChanged -= Control_EditValueChanged;
            tglDurum.EditValueChanged += Control_EditValueChanged;
            
            bool hasMamul = _currentDto.FinishedGoodId > 0;
            if (treeList1 != null) treeList1.Enabled = hasMamul;
            if (myGridControl1 != null) myGridControl1.Enabled = hasMamul;

            if (btnRevizeEt != null) btnRevizeEt.Enabled = _currentDto.Id > 0;
            if (btnKopyala != null) btnKopyala.Enabled = _currentDto.Id > 0;
        }

        protected override void GuncelNesneOlustur()
        {
            if (_currentDto == null) _currentDto = new ProductRecipeDto();

            _currentDto.Code = txtKod.Text;
            _currentDto.Name = txtReceteAdi.Text;
            _currentDto.FinishedGoodId = Convert.ToInt64(glufMamul.EditValue);
            _currentDto.Description = txtAciklama.Text;
            if (txtTarih.EditValue != null && txtTarih.EditValue != DBNull.Value)
            {
                _currentDto.Date = Convert.ToDateTime(txtTarih.EditValue);
            }
            _currentDto.IsActive = tglDurum.IsOn;
            
            if (decimal.TryParse(txtKur.Text, out decimal rate))
            {
                // Kullanıcının txtKur içeriğinde sadece text göstermek istediği durumda bu parse başarısız olur
                // Ancak yine de önceki davranışı korumak adına parse etmeyi deniyoruz.
            }
            _currentDto.TotalCost = _totalRecipeCost;
            _currentDto.NetMaterialCost = _netMaterialCost;
            
            _currentDto.RevisionNumber = Convert.ToInt32(txtRevizyonNo.Value).ToString("00");
            
            _currentDto.Lines = _lines.ToList();
            CurrentEntity = _currentDto;
        }

        private void TreeList1_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            if (e.Node.ParentNode == null)
            {
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
        }

        private DevExpress.XtraTreeList.Nodes.TreeListNode? _dragNode;

        private void TreeList1_MouseDown(object sender, MouseEventArgs e)
        {
            var hitInfo = treeList1.CalcHitInfo(e.Location);
            _dragNode = hitInfo.Node;
        }

        private void TreeList1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _dragNode != null)
            {
                treeList1.DoDragDrop(_dragNode, DragDropEffects.Copy);
            }
        }

        private void TreeList1_PopupMenuShowing(object sender, DevExpress.XtraTreeList.PopupMenuShowingEventArgs e)
        {
            // DevExpress varsayılan menülerini Türkçeleştirme
            foreach (DXMenuItem menuItem in e.Menu.Items)
            {
                if (menuItem.Caption == "Full Expand") menuItem.Caption = "Tümünü Genişlet";
                if (menuItem.Caption == "Full Collapse") menuItem.Caption = "Tümünü Daralt";
            }

            if (e.HitInfo.InRow)
            {
                treeList1.FocusedNode = e.HitInfo.Node;
                var item = new DXMenuItem("Seçileni Reçeteye Ekle", new EventHandler(TreeListEkle_Click));
                e.Menu.Items.Add(item);
            }
        }

        private void MyGridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.Menu == null)
            {
                e.Menu = new GridViewMenu(myGridView1);
            }

            if (e.HitInfo.InRow)
            {
                if (e.HitInfo.RowHandle < 0) // Group Row
                {
                    var item = new DXMenuItem("Gruptaki Tümünü Reçeteden Çıkar", new EventHandler(MiDeleteGroup_Click));
                    item.Tag = e.HitInfo.RowHandle;
                    e.Menu.Items.Add(item);

                    e.Menu.Items.Add(new DXMenuItem("Genişlet", (s, ev) => myGridView1.ExpandGroupRow(e.HitInfo.RowHandle)));
                    e.Menu.Items.Add(new DXMenuItem("Daralt", (s, ev) => myGridView1.CollapseGroupRow(e.HitInfo.RowHandle)));
                }
                else
                {
                    var item = new DXMenuItem("Reçeteden Çıkar", new EventHandler(MiDelete_Click));
                    e.Menu.Items.Add(item);
                }
            }

            // Genel Menüler
            e.Menu.Items.Add(new DXMenuItem("Tümünü Genişlet", (s, ev) => myGridView1.ExpandAllGroups()));
            e.Menu.Items.Add(new DXMenuItem("Tümünü Daralt", (s, ev) => myGridView1.CollapseAllGroups()));
        }

        private void MyGridControl1_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(typeof(DevExpress.XtraTreeList.Nodes.TreeListNode)))
            {
                var node = e.Data.GetData(typeof(DevExpress.XtraTreeList.Nodes.TreeListNode)) as DevExpress.XtraTreeList.Nodes.TreeListNode;
                if (node != null && node.Tag is MaterialDragDropBox)
                {
                    e.Effect = DragDropEffects.Copy;
                    return;
                }
            }
            
            e.Effect = DragDropEffects.None;
        }

        private void MyGridControl1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetData(typeof(DevExpress.XtraTreeList.Nodes.TreeListNode)) is DevExpress.XtraTreeList.Nodes.TreeListNode node)
            {
                if (node.Tag is MaterialDragDropBox dragData)
                {
                    EkleHammadde(dragData);
                }
            }
        }

        private void TreeListEkle_Click(object? sender, EventArgs e)
        {
            var node = treeList1.FocusedNode;
            if (node != null && node.Tag is MaterialDragDropBox dragData)
            {
                EkleHammadde(dragData);
            }
        }

        protected override void EntityDelete()
        {
            if (Id <= 0) return;

            if (Helpers.Messages.SilMesaj("Ürün Reçetesi") == DialogResult.Yes)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _productRecipeService.Delete(Id);
                    RefreshYapilacak = true;
                    Close();
                }
                catch (Exception ex)
                {
                    Helpers.Messages.HataMesaji(ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void MiDelete_Click(object? sender, EventArgs e)
        {
            var row = myGridView1.GetFocusedRow() as ProductRecipeLineDto;
            if (row != null)
            {
                _lines.Remove(row);
                myGridView1.RefreshData();
                myGridView1.UpdateTotalSummary();
                _ = MaliyetiHesaplaAsync(false);
            }
        }

        private void MiDeleteGroup_Click(object? sender, EventArgs e)
        {
            if (sender is DXMenuItem menuItem && menuItem.Tag is int groupRowHandle)
            {
                var childRowCount = myGridView1.GetChildRowCount(groupRowHandle);
                var rowsToDelete = new List<ProductRecipeLineDto>();
                for (int i = 0; i < childRowCount; i++)
                {
                    var childRowHandle = myGridView1.GetChildRowHandle(groupRowHandle, i);
                    var row = myGridView1.GetRow(childRowHandle) as ProductRecipeLineDto;
                    if (row != null)
                        rowsToDelete.Add(row);
                }
                
                foreach(var row in rowsToDelete)
                {
                    _lines.Remove(row);
                }
                myGridView1.RefreshData();
                myGridView1.UpdateTotalSummary();
                _ = MaliyetiHesaplaAsync(false);
            }
        }

        private void EkleHammadde(MaterialDragDropBox dragData)
        {
            if (dragData == null) return;
            
            if (_lines.Any(x => x.MaterialId == dragData.MaterialId && x.MaterialType == dragData.MaterialType))
            {
                if (XtraMessageBox.Show("Bu hammadde reçetede zaten ekli. Yine de eklemek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
            }
            
            decimal unitCost = 0;
            string currencyCode = "";
            string surfaceCoatingType = "";
            decimal weightKg = 0;

            var costService = _serviceProvider?.GetService<WinBeyazEsya.Application.Interfaces.Production.IMaterialCostService>();
            if (costService != null)
            {
                WinBeyazEsya.Domain.Enums.ModuleType? modType = null;
                switch (dragData.MaterialType)
                {
                    case MaterialType.MetalAndSheet: modType = WinBeyazEsya.Domain.Enums.ModuleType.MetalVeSacGrubuMaliyetleri; break;
                    case MaterialType.ElectricalElectronic: modType = WinBeyazEsya.Domain.Enums.ModuleType.ElektrikVeElektronikGrubuMaliyetleri; break;
                    case MaterialType.GasAndIgnition: modType = WinBeyazEsya.Domain.Enums.ModuleType.GazVeAteslemeGrubuMaliyetleri; break;
                    case MaterialType.PlasticAndVisualParts: modType = WinBeyazEsya.Domain.Enums.ModuleType.PlastikVeGorselAksamGrubuMaliyetleri; break;
                    case MaterialType.ChemicalAndInsulation: modType = WinBeyazEsya.Domain.Enums.ModuleType.KimyaVeYalitimGrubuMaliyetleri; break;
                    case MaterialType.MechanicalAndHardware: modType = WinBeyazEsya.Domain.Enums.ModuleType.MekanikVeHirdavatGrubuMaliyetleri; break;
                    case MaterialType.PackagingAndPrinting: modType = WinBeyazEsya.Domain.Enums.ModuleType.AmbalajVeMatbaaGrubuMaliyetleri; break;
                    case MaterialType.WireAndGrid: modType = WinBeyazEsya.Domain.Enums.ModuleType.TelVeIzgaraGrubuMaliyetleri; break;
                    case MaterialType.OtherMaterial: modType = WinBeyazEsya.Domain.Enums.ModuleType.DigerMalzemeGrubuMaliyetleri; break;
                }
                
                if (modType.HasValue)
                {
                    var allCosts = costService.GetAllByMaterialType(modType.Value);
                    var costObj = allCosts?.FirstOrDefault(x => x.MaterialId == dragData.MaterialId);
                    if (costObj != null)
                    {
                        unitCost = costObj.Cost;
                        currencyCode = costObj.CurrencyCode;

                        if (!string.IsNullOrEmpty(currencyCode) && currencyCode != _defaultCurrency)
                        {
                            var exchangeService = _serviceProvider?.GetService<WinBeyazEsya.Application.Interfaces.System.IExchangeRateService>();
                            var rate = exchangeService?.GetAllRates().Where(x => x.CurrencyCode == currencyCode).OrderByDescending(x => x.RateDate).FirstOrDefault();
                            if (rate != null)
                            {
                                unitCost *= rate.EffectiveSellingRate;
                                currencyCode = _defaultCurrency;
                            }
                        }
                    }
                }
            }

            if (dragData.MaterialType == MaterialType.MetalAndSheet)
            {
                var metalService = _serviceProvider?.GetService<IMetalSheetGroupService>();
                if (metalService != null)
                {
                    var metalObj = metalService.GetById(dragData.MaterialId);
                    if (metalObj != null)
                    {
                        surfaceCoatingType = metalObj.SurfaceCoatingType.ToString();
                        weightKg = metalObj.Weight;
                    }
                }
            }

            var maliyetParametreService = _serviceProvider?.GetService<WinBeyazEsya.Application.Interfaces.Management.IMaliyetParametreService>();
            decimal wasteRate = 0;
            if (maliyetParametreService != null)
            {
                var parametre = maliyetParametreService.GetMaliyetParametreAsync().GetAwaiter().GetResult();
                if (parametre != null && parametre.UseWasteRate)
                {
                    wasteRate = parametre.WastageRate;
                }
            }

            decimal totalCostInitial = dragData.MaterialType == MaterialType.MetalAndSheet ? (weightKg * unitCost * 1) : (unitCost * 1);
            if (wasteRate > 0)
            {
                totalCostInitial = totalCostInitial + (totalCostInitial * wasteRate / 100);
            }

            var newLine = new ProductRecipeLineDto
            {
                MaterialId = dragData.MaterialId,
                MaterialName = dragData.MaterialName,
                MaterialGroupName = GetEnumDescription(dragData.MaterialType),
                UnitId = dragData.UnitId,
                UnitName = dragData.UnitName,
                MaterialType = dragData.MaterialType,
                Quantity = 1,
                WeightKg = weightKg,
                WasteRate = wasteRate,
                SurfaceCoatingType = surfaceCoatingType,
                UnitPrice = unitCost,
                CurrencyCode = currencyCode,
                TotalMaterialCost = totalCostInitial
            };
            
            _lines.Add(newLine);
            myGridView1.RefreshData();
            int newRowHandle = myGridView1.GetRowHandle(_lines.Count - 1);
            myGridView1.MakeRowVisible(newRowHandle);
            myGridView1.FocusedRowHandle = newRowHandle;
            myGridView1.UpdateTotalSummary();
            _ = MaliyetiHesaplaAsync(false);
            
            _isGridModified = true;
            GuncelNesneOlustur();
            ButonEnabledDurumu();
        }

        protected override bool FarklilikVarMi(Control.ControlCollection controls)
        {
            if (_isGridModified) return true;
            return base.FarklilikVarMi(controls);
        }

        protected override void BaseEditForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (!IsDesignMode)
            {
                Helpers.LayoutHelper.KaydetGrid(myGridView1);
            }
            base.BaseEditForm_FormClosing(sender, e);
        }

        protected override bool EntityInsert()
        {
            if (glufMamul.EditValue == null || Convert.ToInt64(glufMamul.EditValue) <= 0)
            {
                XtraMessageBox.Show("Lütfen öncelikle bir Mamül seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!ValidateCoatingRules()) return false;
            if (!ValidateZeroCost()) return false;
            if (_productRecipeService == null) return false;

            try
            {
                var dto = (ProductRecipeDto)CurrentEntity;
                dto.Id = BaseIslemTuru.IdOlustur(OldEntity);
                Id = _productRecipeService.Insert(dto);
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
            if (glufMamul.EditValue == null || Convert.ToInt64(glufMamul.EditValue) <= 0)
            {
                XtraMessageBox.Show("Lütfen öncelikle bir Mamül seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!ValidateCoatingRules()) return false;
            if (!ValidateZeroCost()) return false;
            if (_productRecipeService == null) return false;

            try
            {
                var dto = (ProductRecipeDto)CurrentEntity;
                _productRecipeService.Update(dto);
                return true;
            }
            catch (Exception ex)
            {
                string msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                Helpers.Messages.HataBasligi(msg, "Kayıt Hatası");
                return false;
            }
        }

        private bool ValidateZeroCost()
        {
            var invalidLines = _lines.Where(x => x.UnitPrice <= 0).ToList();
            if (invalidLines.Count > 0)
            {
                if (invalidLines.Count <= 3)
                {
                    string names = string.Join(", ", invalidLines.Select(x => x.MaterialName));
                    XtraMessageBox.Show($"Reçetede ekli şu hammaddelerin maliyeti sistemde tanımlanmamış: [{names}]. Lütfen kontrol ediniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    XtraMessageBox.Show("Kullanılan hammaddeler arasında birim fiyatı tanımlanmayanlar var. Lütfen hammadde maliyetlerini kontrol ediniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return false;
            }
            return true;
        }

        private bool ValidateCoatingRules()
        {
            for (int i = 0; i < myGridView1.RowCount; i++)
            {
                var row = myGridView1.GetRow(i) as ProductRecipeLineDto;
                if (row == null) continue;

                if (row.MaterialType == MaterialType.MetalAndSheet)
                {
                    if (row.SurfaceCoatingType == "Boya" || row.SurfaceCoatingType == "Emaye")
                    {
                        if (row.CoatingMaterialId == null || row.CoatingMaterialId <= 0 || row.CoatingAmount <= 0)
                        {
                            XtraMessageBox.Show("Metal ve sac grubu için kaplama malzemesi ve kaplama(gr) alanları zorunludur.", "Eksik Veri", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            myGridView1.FocusedRowHandle = i;
                            myGridView1.FocusedColumn = myGridView1.Columns["CoatingMaterialId"] ?? myGridView1.Columns["CoatingAmount"];
                            return false;
                        }
                    }
                    else if (row.SurfaceCoatingType == "Diger")
                    {
                        if (row.ManualCoatingCost <= 0)
                        {
                            XtraMessageBox.Show("Metal ve Sac grubu için 'Diğer' kaplama türü seçildiğinde Manuel Kaplama Maliyeti 0'dan büyük olmalıdır!", "Eksik Veri", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            myGridView1.FocusedRowHandle = i;
                            myGridView1.FocusedColumn = myGridView1.Columns["ManualCoatingCost"];
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private async void BtnMaliyetiGuncelle_Click(object? sender, EventArgs e)
        {
            if (!ValidateCoatingRules()) return;
            await MaliyetiHesaplaAsync(true);
        }

        private void BtnMaliyetKirilimi_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_costBreakdownText))
            {
                XtraMessageBox.Show("Önce maliyeti güncelleyiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            XtraMessageBox.Show(_costBreakdownText, "Maliyet Kırılımı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async Task MaliyetiHesaplaAsync(bool isManualClick = false)
        {
            if (glufMamul.EditValue == null || Convert.ToInt64(glufMamul.EditValue) <= 0)
            {
                if (isManualClick)
                    XtraMessageBox.Show("Lütfen maliyet hesaplaması için öncelikle bir Mamül seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                txtToplamReceteMaliyeti.Text = $"0.00 {_defaultCurrency}";
                return;
            }

            if (_serviceProvider == null) return;
            
            var finishedGoodService = _serviceProvider.GetService<IFinishedGoodService>();
            var maliyetParametreService = _serviceProvider.GetService<WinBeyazEsya.Application.Interfaces.Management.IMaliyetParametreService>();
            
            if (finishedGoodService == null || maliyetParametreService == null) return;

            long finishedGoodId = Convert.ToInt64(glufMamul.EditValue);

            var finishedGood = finishedGoodService.GetById(finishedGoodId);
            if (finishedGood == null) return;

            var parametre = await maliyetParametreService.GetMaliyetParametreAsync();
            if (parametre == null) return;

            int aylikUretimAdedi = 1;
            string grupAdi = finishedGood.GroupType.ToString();
            
            switch (finishedGood.GroupType)
            {
                case FinishedGoodGroupType.Firin:
                    aylikUretimAdedi = parametre.OvenAvgMonthlyProduction > 0 ? parametre.OvenAvgMonthlyProduction : 1;
                    grupAdi = "Fırın";
                    break;
                case FinishedGoodGroupType.Ocak:
                    aylikUretimAdedi = parametre.CookerAvgMonthlyProduction > 0 ? parametre.CookerAvgMonthlyProduction : 1;
                    grupAdi = "Ocak";
                    break;
                case FinishedGoodGroupType.Ankastre:
                    aylikUretimAdedi = parametre.BuiltInAvgMonthlyProduction > 0 ? parametre.BuiltInAvgMonthlyProduction : 1;
                    grupAdi = "Ankastre";
                    break;
                case FinishedGoodGroupType.Tamboy:
                    aylikUretimAdedi = parametre.FreestandingAvgMonthlyProduction > 0 ? parametre.FreestandingAvgMonthlyProduction : 1;
                    grupAdi = "Tamboy";
                    break;
                case FinishedGoodGroupType.Diger:
                    aylikUretimAdedi = parametre.OtherAvgMonthlyProduction > 0 ? parametre.OtherAvgMonthlyProduction : 1;
                    grupAdi = "Diğer";
                    break;
            }

            decimal birimBasinaGug = _totalOverhead / aylikUretimAdedi;

            decimal netMalzemeTutari = 0;
            if (myGridView1.Columns["TotalMaterialCost"] != null && myGridView1.Columns["TotalMaterialCost"].SummaryItem.SummaryValue != null)
            {
                netMalzemeTutari = Convert.ToDecimal(myGridView1.Columns["TotalMaterialCost"].SummaryItem.SummaryValue);
            }
            else
            {
                netMalzemeTutari = _lines.Sum(x => x.TotalMaterialCost);
            }
            
            _netMaterialCost = netMalzemeTutari;
            _totalRecipeCost = netMalzemeTutari + birimBasinaGug;

            string kurText = "";
            var exchangeService = _serviceProvider.GetService<WinBeyazEsya.Application.Interfaces.System.IExchangeRateService>();
            if (exchangeService != null)
            {
                var rates = exchangeService.GetAllRates();
                var usd = rates.Where(x => x.CurrencyCode == "USD").OrderByDescending(x => x.RateDate).FirstOrDefault();
                var eur = rates.Where(x => x.CurrencyCode == "EUR").OrderByDescending(x => x.RateDate).FirstOrDefault();
                if (usd != null) kurText += $"USD {usd.EffectiveSellingRate:n4} - ";
                if (eur != null) kurText += $"EUR {eur.EffectiveSellingRate:n4}";
                kurText = kurText.TrimEnd('-', ' ');
                
                txtKur.Text = kurText;
            }
            
            txtToplamReceteMaliyeti.Text = $"{_totalRecipeCost:n2} {_defaultCurrency}";

            var sb = new StringBuilder();
            sb.AppendLine($"Ürün Grubu: {grupAdi} (Aylık Üretim: {aylikUretimAdedi} Adet)");
            sb.AppendLine($"Net Malzeme Tutarı: {netMalzemeTutari:n2} {_defaultCurrency}");
            sb.AppendLine($"Birim Başına GÜG Payı: {birimBasinaGug:n2} {_defaultCurrency} (Toplam Gider / {aylikUretimAdedi})");
            sb.AppendLine($"Fire Maliyeti: Satır bazlı (ürün detayında) hesaplanmaktadır.");
            
            if (parametre.UseMaturityDifference)
            {
                sb.AppendLine("Vade Farkı: (İleride Cari Tanımlar Modülü devreye girdiğinde gün bazlı hesaplanacaktır)");
            }
            
            sb.AppendLine(new string('-', 50));
            sb.AppendLine($"TOPLAM REÇETE MALİYETİ: {_totalRecipeCost:n2} {_defaultCurrency}");

            _costBreakdownText = sb.ToString();

            if (isManualClick)
            {
                XtraMessageBox.Show("Maliyetler güncel parametrelere göre başarıyla hesaplandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnKopyala_Click(object? sender, EventArgs e)
        {
            if (_currentDto == null || _currentDto.Id <= 0) return;

            var serialized = System.Text.Json.JsonSerializer.Serialize(_currentDto);
            var clone = System.Text.Json.JsonSerializer.Deserialize<WinBeyazEsya.Application.DTOs.Definitions.ProductRecipeDto>(serialized);

            if (clone != null)
            {
                clone.Id = 0;
                clone.Code = "< Otomatik Üretilecek >";
                clone.RevisionNumber = "01";
                clone.IsActive = true;
                if (clone.Lines != null)
                {
                    foreach (var line in clone.Lines)
                    {
                        line.Id = 0;
                        line.ProductRecipeId = 0;
                    }
                }

                _currentDto = clone;
                CurrentEntity = clone;
                BaseIslemTuru = ActionType.EntityInsert;
                this.Id = 0;
                
                NesneyiKontrollereBagla();
                ButonEnabledDurumu();
                Helpers.Messages.BilgiMesaji("Reçete başarıyla kopyalandı. Yeni kayıt olarak kaydedebilirsiniz.");
            }
        }

        private void BtnRevizeEt_Click(object? sender, EventArgs e)
        {
            if (_currentDto == null || _currentDto.Id <= 0) return;

            if (Helpers.Messages.HayirSeciliEvetHayir("Mevcut reçete pasife alınacak ve yeni revizyon oluşturulacaktır. Onaylıyor musunuz?", "Revizyon Onayı") != DialogResult.Yes)
                return;

            _currentDto.IsActive = false;
            
            if (_productRecipeService != null)
            {
                _productRecipeService.Update(_currentDto);
            }

            var serialized = System.Text.Json.JsonSerializer.Serialize(_currentDto);
            var clone = System.Text.Json.JsonSerializer.Deserialize<WinBeyazEsya.Application.DTOs.Definitions.ProductRecipeDto>(serialized);

            if (clone != null)
            {
                clone.Id = 0;
                
                if (int.TryParse(clone.RevisionNumber, out int revNo))
                {
                    clone.RevisionNumber = (revNo + 1).ToString("D2");
                }
                else
                {
                    clone.RevisionNumber = "02";
                }
                
                clone.IsActive = true;
                
                if (clone.Lines != null)
                {
                    foreach (var line in clone.Lines)
                    {
                        line.Id = 0;
                        line.ProductRecipeId = 0;
                    }
                }

                _currentDto = clone;
                CurrentEntity = clone;
                BaseIslemTuru = ActionType.EntityInsert;
                this.Id = 0;
                
                NesneyiKontrollereBagla();
                ButonEnabledDurumu();
                Helpers.Messages.BilgiMesaji($"Yeni revizyon ({clone.RevisionNumber}) oluşturuldu. Değişikliklerinizi yapıp kaydedebilirsiniz.");
            }
        }
    }
}
