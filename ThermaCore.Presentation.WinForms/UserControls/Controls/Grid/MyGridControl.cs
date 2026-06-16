#pragma warning disable CS8618
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using ThermaCore.Presentation.WinForms.Interfaces;
using System.ComponentModel;
using System.Drawing;

namespace ThermaCore.Presentation.WinForms.UserControls.Grid
{
    [ToolboxItem(true)]
    public class MyGridControl : GridControl
    {
        protected override BaseView CreateDefaultView()
        {
            var view = (GridView)CreateView("MyGridView");

            // View Caption
            view.Appearance.ViewCaption.ForeColor = Color.FromArgb(64, 64, 64);
            view.Appearance.ViewCaption.Font = new Font("Segoe UI", 11.25f, FontStyle.Bold);

            // Header Panel
            var headerColor = Color.FromArgb(46, 134, 193); // #2E86C1
            view.Appearance.HeaderPanel.BackColor = headerColor;
            view.Appearance.HeaderPanel.ForeColor = Color.White;
            view.Appearance.HeaderPanel.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold);
            view.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;

            // Empty Area
            view.Appearance.Empty.BackColor = Color.FromArgb(245, 245, 245); // #F5F5F5
            view.Appearance.Empty.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular);

            // Zebra Striping
            view.OptionsView.EnableAppearanceEvenRow = true;
            view.Appearance.EvenRow.BackColor = Color.FromArgb(250, 250, 250); // #FAFAFA
            view.Appearance.EvenRow.Options.UseBackColor = true;

            view.OptionsView.EnableAppearanceOddRow = true;
            view.Appearance.OddRow.BackColor = Color.White;
            view.Appearance.OddRow.Options.UseBackColor = true;

            // Focused/Selected Rows
            var focusedBackColor = Color.FromArgb(255, 249, 219); // #FFF9DB
            view.Appearance.FocusedCell.BackColor = focusedBackColor;
            view.Appearance.FocusedRow.BackColor = focusedBackColor;
            view.Appearance.FocusedRow.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold);
            view.Appearance.FocusedRow.Options.UseFont = true;

            view.Appearance.HideSelectionRow.BackColor = focusedBackColor;

            view.Appearance.SelectedRow.BackColor = Color.FromArgb(204, 229, 255); // #CCE5FF
            view.Appearance.SelectedRow.ForeColor = Color.Black;
            view.Appearance.SelectedRow.Options.UseBackColor = true;
            view.Appearance.SelectedRow.Options.UseForeColor = true;

            // Data Rows
            view.Appearance.Row.BackColor = Color.White;
            view.Appearance.Row.ForeColor = Color.Black;
            view.Appearance.Row.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular);

            // Footer
            view.Appearance.FooterPanel.ForeColor = Color.FromArgb(64, 64, 64); // Koyu gri
            view.Appearance.FooterPanel.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold);

            // Options
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
            view.OptionsView.RowAutoHeight = true;
            view.OptionsView.HeaderFilterButtonShowMode = FilterButtonShowMode.Button;

            // Id Column
            var idColumn = new MyGridColumn
            {
                Caption = "Id",
                FieldName = "Id"
            };
            idColumn.OptionsColumn.AllowEdit = false;
            idColumn.OptionsColumn.ShowInCustomizationForm = false;
            view.Columns.Add(idColumn);

            // Kod Column
            var kodColumn = new MyGridColumn
            {
                Caption = "Kod",
                FieldName = "Kod"
            };
            kodColumn.OptionsColumn.AllowEdit = false;
            kodColumn.Visible = true;
            kodColumn.Width = 175;
            kodColumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
            kodColumn.AppearanceCell.Options.UseTextOptions = true;
            kodColumn.AppearanceCell.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular);
            kodColumn.AppearanceHeader.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold);
            kodColumn.AppearanceHeader.ForeColor = Color.White;
            kodColumn.AppearanceHeader.BackColor = headerColor;
            kodColumn.AppearanceHeader.Options.UseBackColor = true;
            kodColumn.AppearanceHeader.Options.UseFont = true;
            kodColumn.AppearanceHeader.Options.UseForeColor = true;

            view.Columns.Add(kodColumn);

            return view;
        }

        protected override void RegisterAvailableViewsCore(InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new MyGridInfoRegistrator());
        }

        private class MyGridInfoRegistrator : GridInfoRegistrator
        {
            public override string ViewName => "MyGridView";
            public override BaseView CreateView(GridControl grid) => new MyGridView(grid);
        }
    }

    public class MyGridView : GridView, IStatusBarKisaYol
    {
        public string StatusBarKisaYol { get; set; }
        public string StatusBarKisaYolAciklama { get; set; }
        public string StatusBarAciklama { get; set; }

        public MyGridView() { }
        public MyGridView(GridControl ownerGrid) : base(ownerGrid) { }

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
            return new MyGridColumnCollection(this);
        }

        private class MyGridColumnCollection : GridColumnCollection
        {
            public MyGridColumnCollection(ColumnView view) : base(view) { }

            protected override GridColumn CreateColumn()
            {
                var column = new MyGridColumn();
                column.OptionsColumn.AllowEdit = false;
                column.Width = 175;

                column.AppearanceHeader.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold);
                column.AppearanceHeader.ForeColor = Color.White;
                column.AppearanceHeader.BackColor = Color.FromArgb(46, 134, 193);
                column.AppearanceHeader.Options.UseBackColor = true;
                column.AppearanceHeader.Options.UseFont = true;
                column.AppearanceHeader.Options.UseForeColor = true;

                column.AppearanceCell.Font = new Font("Segoe UI", 9.75f, FontStyle.Regular);
                column.AppearanceCell.Options.UseFont = true;
                return column;
            }
        }
    }

    public class MyGridColumn : GridColumn, IStatusBarKisaYol
    {
        public string StatusBarKisaYol { get; set; }
        public string StatusBarKisaYolAciklama { get; set; }
        public string StatusBarAciklama { get; set; }
    }
}

