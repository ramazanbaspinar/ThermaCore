using WinBeyazEsya.Presentation.WinForms.UserControls.Base;
#pragma warning disable CS8618
using DevExpress.XtraBars;
using WinBeyazEsya.Presentation.WinForms.Helpers;
using System;
using System.Data;
using System.Linq;

namespace WinBeyazEsya.Presentation.WinForms.UserControls.GenelEditFormTable
{
    public partial class YetkiProfilleriTable : BaseTablo
    {
        public YetkiProfilleriTable()
        {
            InitializeComponent();
            // Bll = new ModulIslemYetkisiBll();
            Tablo = tablo;
            ShowItems = new BarItem[] { btnTumunuSec, btnTumSecimleriKaldir };
            EventsLoad();
        }

        protected internal override void Listele() { /* TODO: Migrate logic */ }

        protected override void HareketEkle() { /* TODO: Migrate logic */ }

        protected override void RowCellAllowEdit() { /* TODO: Migrate logic */ }

        protected override void CheckEdit_CheckedChanged(object? sender, EventArgs e)
        {
            //checkboc a tıklanınca direk onaylanmış gibi işlem yapar
            insUptNavigator.Navigator.Buttons.DoClick(insUptNavigator.Navigator.Buttons.EndEdit);
        }

        protected override void TumunuSec() { /* TODO: Migrate logic */ }

        protected override void TumSecimleriKaldir() { /* TODO: Migrate logic */ }
    }
}





