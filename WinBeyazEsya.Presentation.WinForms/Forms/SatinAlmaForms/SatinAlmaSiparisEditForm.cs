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

        public SatinAlmaSiparisEditForm()
        {
            InitializeComponent();
        }

        public SatinAlmaSiparisEditForm(WinBeyazEsya.Application.Interfaces.Purchasing.IPurchaseOrderService purchaseOrderService)
        {
            InitializeComponent();

            if (!DesignMode && Program.ServiceProvider != null)
            {
                _purchaseOrderService = purchaseOrderService;
                Bll = _purchaseOrderService;
            }

            BaseKartTuru = Domain.Enums.ModuleType.SatinalmaSiparisleri;
        }

        protected override void EventsLoad()
        {
            base.EventsLoad();
            myGridView1.CellValueChanged += MyGridView1_CellValueChanged;
            myGridView1.ShownEditor += MyGridView1_ShownEditor;
        }

        public override void Yukle()
        {
            if (BaseIslemTuru == ActionType.EntityInsert)
                CurrentEntity = new Application.DTOs.Purchasing.PurchaseOrderDto { IsActive = true, OrderDate = DateTime.Now, Status = OrderStatus.Draft };
            else
                CurrentEntity = _purchaseOrderService.GetById(Id);

            NesneyiKontrollereBagla();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Application.DTOs.Purchasing.PurchaseOrderDto)CurrentEntity;

            txtKod.Text = entity.Code;
            txtBelgeNo.Text = entity.DocumentNo;
            txtSiparisTarihi.EditValue = entity.OrderDate;
            txtTeslimatTarihi.EditValue = entity.DeliveryDate;
            glufTedarikciCari.EditValue = entity.SupplierId == 0 ? null : entity.SupplierId;
            glufTeslimatDeposu.EditValue = entity.WarehouseId;
            cmbDovuzTuru.EditValue = entity.CurrencyId;
            txtDovizKuru.Value = entity.ExchangeRate;
            cmbSiparisDurumu.EditValue = entity.Status;
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
                CurrencyId = (long?)cmbDovuzTuru.EditValue,
                ExchangeRate = txtDovizKuru.Value,
                Status = cmbSiparisDurumu.EditValue != null ? (OrderStatus)cmbSiparisDurumu.EditValue : OrderStatus.Draft,
                Description = txtAciklama.Text,
                SubTotal = txtToplam.Value,
                TaxAmount = txtToplamKDV.Value,
                GrandTotal = txtNet.Value,
                Lines = myGridControl1.DataSource as List<Application.DTOs.Purchasing.PurchaseOrderLineDto> ?? new List<Application.DTOs.Purchasing.PurchaseOrderLineDto>()
            };

            CurrentEntity = dto;
            ButonEnabledDurumu();
        }

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

            // Malzeme hücresine tıklandığında dinamik filtreleme (Cascading Lookup)
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

                // Değişikliği sonsuz döngüye sokmamak için SetRowCellValue kullanıyoruz.
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
    }
}