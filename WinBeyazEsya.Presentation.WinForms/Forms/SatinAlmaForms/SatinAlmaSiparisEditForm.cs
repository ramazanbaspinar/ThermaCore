using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
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

        public SatinAlmaSiparisEditForm()
        {
            InitializeComponent();
            BaseKartTuru = Domain.Enums.ModuleType.SatinalmaSiparisleri;
        }

        // Mimaride belirtilen ICurrencyService (dinamik eklendi) ve diğer servisler Constructor Injection ile alındı
        public SatinAlmaSiparisEditForm(
            WinBeyazEsya.Application.Interfaces.Purchasing.IPurchaseOrderService purchaseOrderService,
            WinBeyazEsya.Application.Interfaces.Definitions.ICurrentAccountService currentAccountService,
            WinBeyazEsya.Application.Interfaces.Definitions.IWarehouseService warehouseService,
            WinBeyazEsya.Application.Interfaces.System.IExchangeRateService exchangeRateService)
        {
            InitializeComponent();

            if (!DesignMode && Program.ServiceProvider != null)
            {
                _purchaseOrderService = purchaseOrderService;
                _currentAccountService = currentAccountService;
                _warehouseService = warehouseService;
                _exchangeRateService = exchangeRateService;
                
                Bll = _purchaseOrderService;
            }

            BaseKartTuru = Domain.Enums.ModuleType.SatinalmaSiparisleri;
        }

        protected override void EventsLoad()
        {
            base.EventsLoad();
            myGridView1.CellValueChanged += MyGridView1_CellValueChanged;
            myGridView1.ShownEditor += MyGridView1_ShownEditor;

            // Arama ve Kur Buton/Event atamaları
            glufTedarikciCari.SearchButtonClicked += GlufTedarikciCari_SearchButtonClicked;
            glufTeslimatDeposu.SearchButtonClicked += GlufTeslimatDeposu_SearchButtonClicked;
            
            cmbDovuzTuru.EditValueChanged += KurHesapla_EditValueChanged;
            txtSiparisTarihi.EditValueChanged += KurHesapla_EditValueChanged;
        }

        public override void Yukle()
        {
            // 5. TARİH VE SAAT FORMATI: Maskeleme (G -> kısa tarih ve kısa saat)
            txtSiparisTarihi.Properties.Mask.EditMask = "G";
            txtSiparisTarihi.Properties.Mask.UseMaskAsDisplayFormat = true;

            // 3. SİPARİŞ DURUMU (ENUM) YÜKLEMESİ
            cmbSiparisDurumu.Properties.Items.AddRange(WinBeyazEsya.Presentation.WinForms.Helpers.EnumFunctions.GetEnumDescriptionList<OrderStatus>().ToArray());

            // GridLookUpFind (gluf) Display ve Value Member Tanımlamaları
            glufTedarikciCari.Properties.ValueMember = "Id";
            glufTedarikciCari.Properties.DisplayMember = "Title"; // Cari Unvan

            glufTeslimatDeposu.Properties.ValueMember = "Id";
            glufTeslimatDeposu.Properties.DisplayMember = "Name"; // Depo Adı

            // 4. DÖVİZ TÜRÜ YÜKLEMESİ (Maliyet formundaki mantık)
            if (_exchangeRateService != null && !DesignMode)
            {
                var currencies = _exchangeRateService.GetAllRates().Select(x => x.CurrencyCode).Distinct().ToList();
                cmbDovuzTuru.Properties.Items.Clear();
                cmbDovuzTuru.Properties.Items.AddRange(currencies);
            }

            // Yeni Kayıt (EntityInsert) durumunda default değerler (Sipariş Tarihi = DateTime.Now)
            if (BaseIslemTuru == ActionType.EntityInsert)
                CurrentEntity = new Application.DTOs.Purchasing.PurchaseOrderDto { IsActive = true, OrderDate = DateTime.Now, Status = OrderStatus.Draft };
            else
                CurrentEntity = _purchaseOrderService.GetById(Id);

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Application.DTOs.Purchasing.PurchaseOrderDto)CurrentEntity;

            // 1. TEDARİKÇİ FİLTRELEMESİ VE YÜKLEMESİ
            if (_currentAccountService != null && !DesignMode)
            {
                glufTedarikciCari.Properties.DataSource = _currentAccountService.GetAll()
                    .Where(x => x.CardType == (int)CardType.Tedarikci || x.CardType == (int)CardType.MusteriVeTedarikci)
                    .ToList();
            }

            // 2. TESLİMAT DEPOSU FİLTRELEMESİ VE YÜKLEMESİ
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

            myGridControl1.DataSource = entity.Lines;

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
                Lines = myGridControl1.DataSource as List<Application.DTOs.Purchasing.PurchaseOrderLineDto> ?? new List<Application.DTOs.Purchasing.PurchaseOrderLineDto>()
            };

            CurrentEntity = dto;
            ButonEnabledDurumu();
        }

        #region Event Handlers & Lookup Seçimleri

        // 1. Arama Butonu - Tedarikçi Cari Listesi Açılması
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

        // 2. Arama Butonu - Depo Listesi Açılması
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

        // 4. OTOMATİK KUR ÇEKME İŞLEMİ (EffectiveSellingRate)
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
                        // O tarihe ait kur yoksa en son güncel kur
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

        private void MyGridView1_ShownEditor(object sender, EventArgs e)
        {
            var view = sender as GridView;
            if (view == null) return;

            if (view.FocusedColumn.FieldName == "MaterialId" && view.ActiveEditor is DevExpress.XtraEditors.SearchLookUpEdit editor)
            {
                var materialTypeValue = view.GetFocusedRowCellValue("MaterialType");
                if (materialTypeValue != null)
                {
                    // editor.Properties.DataSource = _materialService.GetMaterialsByType((int)materialTypeValue);
                }
            }
        }

        private void MyGridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var view = sender as GridView;
            if (view == null) return;

            if (e.Column.FieldName == "Quantity" || e.Column.FieldName == "UnitPrice")
            {
                var quantity = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, "Quantity") ?? 0);
                var unitPrice = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, "UnitPrice") ?? 0);
                var lineTotal = quantity * unitPrice;

                view.SetRowCellValue(e.RowHandle, "LineTotal", lineTotal);
                CalculateTotals();
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

            var lines = myGridControl1.DataSource as List<Application.DTOs.Purchasing.PurchaseOrderLineDto>;
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
        #endregion
    }
}