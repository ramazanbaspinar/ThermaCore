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

namespace WinBeyazEsya.Presentation.WinForms.Forms.StokYonetimiForms
{
    public partial class StokBakiyeListForm : BaseListForm
    {
        private readonly WinBeyazEsya.Application.Interfaces.Services.IStockTransactionService? _stockService;

        public StokBakiyeListForm()
        {
            InitializeComponent();
            var serviceProvider = Program.ServiceProvider;
            if (!DesignMode && serviceProvider != null)
            {
                _stockService = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetService<WinBeyazEsya.Application.Interfaces.Services.IStockTransactionService>(serviceProvider);
            }
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = myGridView1;
            BaseKartTuru = Domain.Enums.ModuleType.StokBakiyeIzleme;
            Navigator = longNavigator1.Navigator;
            AktifPasifButonGoster = false;

            // KESİNLİKLE GİZLE KURALI:
            if (btnYeni != null) btnYeni.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (btnSil != null) btnSil.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (btnDuzelt != null) btnDuzelt.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (btnSec != null) btnSec.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (btnFavorilereEkle != null) btnFavorilereEkle.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            // Form sadece izleme ekranıdır
            myGridView1.OptionsBehavior.Editable = false;

              // Sağ tık menüsünden Kayıt Bilgileri butonunu gizle
            if (SagTikMenu != null)
            {
                foreach (DevExpress.XtraBars.BarItemLink link in SagTikMenu.ItemLinks)
                {
                    if (link.Item != null && link.Item.Name == "btnKayitBilgileri")
                    {
                        link.Item.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        break;
                    }
                }
            }

            // WarehouseName Grouping:
            if (myGridView1.Columns["WarehouseName"] != null)
            {
                myGridView1.Columns["WarehouseName"].GroupIndex = 0;
            }

            // Balance <= 0 Kırmızı FormatRule
            if (myGridView1.Columns["Balance"] != null)
            {
                var rule = new DevExpress.XtraGrid.StyleFormatCondition();
                rule.Column = myGridView1.Columns["Balance"];
                rule.Condition = DevExpress.XtraGrid.FormatConditionEnum.LessOrEqual;
                rule.Value1 = 0m;
                rule.Appearance.ForeColor = System.Drawing.Color.Red;
                rule.Appearance.Options.UseForeColor = true;
                rule.ApplyToRow = true;
                myGridView1.FormatConditions.Add(rule);
            }
        }

        protected override void SelectEntity()
        {
            // Çift tıklandığında formun kapanmasını engelle
        }

        protected override void Listele()
        {
            if (_stockService == null) return;
            var data = _stockService.GetInventoryStatusAsync().GetAwaiter().GetResult();
            myGridControl1.DataSource = new System.ComponentModel.BindingList<WinBeyazEsya.Application.DTOs.Inventory.InventoryStatusListDto>(data);
        }
    }
}