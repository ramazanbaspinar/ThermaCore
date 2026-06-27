using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System.ComponentModel;
using ThermaCore.Presentation.WinForms.Interfaces;

namespace ThermaCore.Presentation.WinForms.UserControls.Grid
{
    [ToolboxItem(true)]
    public class MyGridControlPro : GridControl
    {
        protected override BaseView CreateDefaultView()
        {
            var view = (GridView)CreateView("MyGridViewPro");

            // --- 1. GÖRSEL AYARLAR (DevExpress Standartı ve Skin Uyumlu) ---
            view.OptionsView.EnableAppearanceEvenRow = true; // Zebra deseni açık, rengi aktif temadan alacak.
            view.OptionsView.RowAutoHeight = false; // ERP'lerde veri yoğunluğu önemlidir, satırlar standart boyda olmalı.

            // --- 2. İŞLEVSEL AYARLAR (Senin Kuralların) ---
            view.OptionsMenu.EnableColumnMenu = false;
            view.OptionsMenu.EnableFooterMenu = false;
            view.OptionsMenu.EnableGroupPanelMenu = false;

            view.OptionsNavigation.EnterMoveNextColumn = true;

            view.OptionsPrint.AutoWidth = false;
            view.OptionsPrint.PrintFooter = false;
            view.OptionsPrint.PrintGroupFooter = false;

            view.OptionsView.ShowViewCaption = true;
            view.OptionsView.ShowAutoFilterRow = true;
            view.OptionsView.ShowGroupPanel = false;
            view.OptionsView.ColumnAutoWidth = false;
            view.OptionsView.HeaderFilterButtonShowMode = FilterButtonShowMode.Button;

            // --- 3. STANDART KOLONLAR ---
            var idColumn = new MyGridColumnPro
            {
                Caption = "Id",
                FieldName = "Id"
            };
            idColumn.OptionsColumn.AllowEdit = false;
            idColumn.OptionsColumn.ShowInCustomizationForm = false;
            view.Columns.Add(idColumn);

            var kodColumn = new MyGridColumnPro
            {
                Caption = "Kod",
                FieldName = "Kod"
            };
            kodColumn.OptionsColumn.AllowEdit = false;
            kodColumn.Visible = true;
            kodColumn.Width = 120; // Standart ve makul bir genişlik
            kodColumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            kodColumn.AppearanceCell.Options.UseTextOptions = true;
            view.Columns.Add(kodColumn);

            return view;
        }

        protected override void RegisterAvailableViewsCore(InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new MyGridInfoRegistratorPro());
        }

        private class MyGridInfoRegistratorPro : GridInfoRegistrator
        {
            public override string ViewName => "MyGridViewPro";
            public override BaseView CreateView(GridControl grid) => new MyGridViewPro(grid);
        }
    }

    public class MyGridViewPro : GridView, IStatusBarKisaYol // Arayüzü kendi projene göre dahil et
    {
        public string StatusBarKisaYol { get; set; }
        public string StatusBarKisaYolAciklama { get; set; }
        public string StatusBarAciklama { get; set; }

        public MyGridViewPro() { }
        public MyGridViewPro(GridControl ownerGrid) : base(ownerGrid) { }

        protected override void OnColumnChangedCore(GridColumn column)
        {
            base.OnColumnChangedCore(column);

            if (column.ColumnEdit == null) return;

            if (column.ColumnEdit.GetType() == typeof(RepositoryItemDateEdit))
            {
                column.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                ((RepositoryItemDateEdit)column.ColumnEdit).Mask.MaskType = MaskType.DateTimeAdvancingCaret;
            }
        }

        protected override GridColumnCollection CreateColumnCollection()
        {
            return new MyGridColumnCollectionPro(this);
        }

        private class MyGridColumnCollectionPro : GridColumnCollection
        {
            public MyGridColumnCollectionPro(ColumnView view) : base(view) { }

            protected override GridColumn CreateColumn()
            {
                var column = new MyGridColumnPro();
                column.OptionsColumn.AllowEdit = false;
                return column;
            }
        }
    }

    public class MyGridColumnPro : GridColumn, IStatusBarKisaYol
    {
        public string StatusBarKisaYol { get; set; }
        public string StatusBarKisaYolAciklama { get; set; }
        public string StatusBarAciklama { get; set; }
    }
}