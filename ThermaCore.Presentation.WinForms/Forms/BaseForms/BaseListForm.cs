using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using ThermaCore.Application.Interfaces.System;
using ThermaCore.Presentation.WinForms.Helpers;
using DevExpress.XtraBars.Ribbon;

namespace ThermaCore.Presentation.WinForms.Forms.BaseForms
{
    public partial class BaseListForm : RibbonForm
    {
        protected GridView Tablo = default!;
        protected bool AktifKartlariGoster = true;
        protected long? SeciliGelecekId;

        private bool _formSablonKayitEdilecek;
        private bool _tabloSablonKayitEdilecek;

        public BaseListForm()
        {
            InitializeComponent();
            
            if (!IsDesignMode)
            {
                this.Load += BaseListForm_Load;
                this.FormClosing += BaseListForm_FormClosing;
            }
        }

        protected bool IsDesignMode => LicenseManager.UsageMode == LicenseUsageMode.Designtime || this.DesignMode;

        private void BaseListForm_Load(object? sender, EventArgs e)
        {
            if (IsDesignMode) return;

            try
            {
                var layoutService = Program.ServiceProvider?.GetService<ILayoutService>();
                // İleride Grid ve Form layout yükleme kodları eklenecek
            }
            catch { }

            Listele();
            ButonEnabledDurumu();

            if (Tablo != null)
            {
                Tablo.DoubleClick += Tablo_DoubleClick;
                Tablo.KeyDown += Tablo_KeyDown;
                Tablo.ColumnWidthChanged += Tablo_ColumnWidthChanged;
            }
        }

        private void BaseListForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (IsDesignMode) return;

            try
            {
                var layoutService = Program.ServiceProvider?.GetService<ILayoutService>();
                if (_formSablonKayitEdilecek || _tabloSablonKayitEdilecek)
                {
                    // İleride Grid ve Form layout kaydetme kodları eklenecek
                }
            }
            catch { }
        }

        protected virtual void Tablo_DoubleClick(object? sender, EventArgs e)
        {
            if (IsDesignMode || Tablo == null) return;

            long id = Tablo.GetRowId();
            if (id > 0)
            {
                ShowEditForm(id);
            }
        }

        protected virtual void Tablo_KeyDown(object? sender, KeyEventArgs e)
        {
            if (IsDesignMode || Tablo == null) return;
            
            if (e.KeyCode == Keys.Enter)
            {
                long id = Tablo.GetRowId();
                if (id > 0)
                {
                    ShowEditForm(id);
                }
            }
        }

        protected virtual void Tablo_ColumnWidthChanged(object? sender, DevExpress.XtraGrid.Views.Base.ColumnEventArgs e)
        {
            if (IsDesignMode) return;
            _tabloSablonKayitEdilecek = true;
        }

        protected virtual void Button_ItemClick(object? sender, ItemClickEventArgs e)
        {
            if (IsDesignMode) return;

            long id = Tablo?.GetRowId() ?? 0;

            switch (e.Item.Name)
            {
                case "btnYeni":
                    ShowEditForm(-1);
                    break;
                case "btnDuzelt":
                    if (id > 0) ShowEditForm(id);
                    break;
                case "btnSil":
                    if (id > 0) EntityDelete();
                    break;
                case "btnYenile":
                    Listele();
                    break;
                case "btnCikis":
                    this.Close();
                    break;
            }
        }

        protected virtual void Listele() { }
        protected virtual void ShowEditForm(long id) { }
        protected virtual void EntityDelete() { }
        protected virtual void ButonEnabledDurumu() { }
    }
}