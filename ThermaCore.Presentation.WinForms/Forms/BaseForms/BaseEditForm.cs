using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraVerticalGrid;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using ThermaCore.Application.DTOs.Base;
using ThermaCore.Domain.Enums;
using ThermaCore.Presentation.WinForms.Helpers;
using ThermaCore.Application.Interfaces.System;

namespace ThermaCore.Presentation.WinForms.Forms.BaseForms
{
    public partial class BaseEditForm : RibbonForm
    {
        public virtual long FirmaId { get; set; } = 0;
        public virtual bool FirmaKisaKodKullan { get; set; } = false;

        #region Variables

        private bool _formSablonKayitEdilecek;
        protected object DataLayoutControl = default!;
        protected object[] DataLayoutControls = default!;
        protected object Bll = default!;

        protected ModuleType BaseKartTuru;
        protected BaseDto OldEntity = default!;
        protected BaseDto CurrentEntity = default!;
        protected bool IsLoaded;
        protected bool KayitSonrasiFormuKapat = true;
        protected bool FormSablonKaydet = true;
        protected BarItem[] ShowItems = default!;
        protected BarItem[] HideItems = default!;
        protected internal ActionType BaseIslemTuru;
        protected internal long Id;
        protected internal bool RefreshYapilacak;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BarStaticItem statusBarAciklama { get; set; } = new BarStaticItem();
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BarStaticItem statusBarKisaYol { get; set; } = new BarStaticItem();
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BarStaticItem statusBarKisaYolAciklama { get; set; } = new BarStaticItem();

        protected DevExpress.XtraBars.BarButtonItem btnYazdir2 = null!;

        #endregion

        public BaseEditForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            if (!IsDesignMode)
            {
                EventsLoad();
            }
            base.OnLoad(e);
        }

        protected bool IsDesignMode => LicenseManager.UsageMode == LicenseUsageMode.Designtime || this.DesignMode;

        protected virtual void EventsLoad()
        {
            if (IsDesignMode) return;

            //Button Events
            if (ribbon != null)
            {
                foreach (var item in ribbon.Items)
                {
                    switch (item)
                    {
                        case BarItem button:
                            button.ItemClick += Button_ItemClick;
                            break;
                    }
                }
            }

            //Form Events
            LocationChanged += BaseEditForm_LocationChanged;
            SizeChanged += BaseEditForm_SizeChanged;
            Load += BaseEditForm_Load;
            FormClosing += BaseEditForm_FormClosing;
            Shown += BaseEditForm_Shown;

            // Control event wiring can be customized by derived classes 
            // since we don't have direct access to UI Control specific types like FilterControl here.
        }

        //Functions

        protected virtual void EntityDelete()
        {
            RefreshYapilacak = true;
            Close();
        }

        private void ButonGizleGoster()
        {
            if (ShowItems != null)
                foreach (var x in ShowItems) x.Visibility = BarItemVisibility.Always;

            if (HideItems != null)
                foreach (var x in HideItems) x.Visibility = BarItemVisibility.Never;
        }

        public virtual void IdAtaVeAc(long id)
        {
            this.Id = id;
            this.BaseIslemTuru = id > 0 ? ActionType.EntityUpdate : ActionType.EntityInsert;
            this.ShowDialog();
        }

        private void GeriAl()
        {
            if (Messages.HayirSeciliEvetHayir("Yapılan Değişiklikler Geri Alınacaktır. Onaylıyor Musunuz?", "Geri Al Onayı") != DialogResult.Yes) return;
            Cursor.Current = Cursors.WaitCursor;
            if (BaseIslemTuru == ActionType.EntityUpdate)
                Yukle();
            else
            {
                btnKaydet.Enabled = false;
                Close();
            }
            Cursor.Current = Cursors.Default;
        }

        protected bool Kaydet(bool kapanis)
        {
            bool KayitIslemi()
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (BaseIslemTuru)
                {
                    case ActionType.EntityInsert:
                        if (EntityInsert())
                            return KayitSonrasiIslemler();
                        break;

                    case ActionType.EntityUpdate:
                        if (EntityUpdate())
                            return KayitSonrasiIslemler();
                        break;
                }

                Cursor.Current = Cursors.Default;
                return false;
            }

            bool KayitSonrasiIslemler()
            {
                OldEntity = CurrentEntity;
                RefreshYapilacak = true;
                ButonEnabledDurumu();

                KodKullanildiKaydet();

                if (KayitSonrasiFormuKapat && kapanis)
                    Close();
                else
                {
                    BaseIslemTuru = BaseIslemTuru == ActionType.EntityInsert ? ActionType.EntityUpdate : BaseIslemTuru;
                    Yukle();
                }

                return true;
            }

            GuncelNesneOlustur();

            var result = kapanis ? Messages.KapanisMesaj() : Messages.KayitMesaj();

            switch (result)
            {
                case DialogResult.Yes:
                    return KayitIslemi();

                case DialogResult.No:
                    // If kapanis, maybe we close without saving
                    return true;

                case DialogResult.Cancel:
                    return false;
            }

            return false;
        }

        private void SablonYukle()
        {
            Helpers.LayoutHelper.YukleForm(this);
        }

        private void FarkliKaydet()
        {
            if (Messages.EvetSeciliEvetHayir("Mevcut Kayıt Referans Alınarak Yeni Bir Kayıt Oluşturulacaktır. Onaylıyor Musunuz?", "Kayıt Onayı") != DialogResult.Yes) return;

            BaseIslemTuru = ActionType.EntityInsert;
            Yukle();

            if (Kaydet(true))
                Close();
        }

        protected virtual void FiltreUygula() { }

        protected void SablonKaydet()
        {
            if (_formSablonKayitEdilecek) Helpers.LayoutHelper.KaydetForm(this);
        }

        protected virtual void BaskiOnizleme() { }

        protected virtual void Yenile() { }

        protected virtual void AracTemizle() { }

        protected virtual void Yazdir() { }

        protected virtual void Yazdir2() { }

        protected virtual void HesapMakinesiAc() { }

        protected virtual void IpAdresiGoster() { }

        protected virtual void SifreDegistir() { }

        protected virtual void SecimYap(object sender) { }

        protected virtual bool EntityInsert()
        {
            return false;
        }

        protected virtual bool EntityUpdate()
        {
            return false;
        }

        protected virtual void KodKullanildiKaydet()
        {
        }

        protected virtual void NesneyiKontrollereBagla() { }

        protected virtual void GuncelNesneOlustur() { }

        public virtual void Yukle() { }

        protected internal virtual object ReturnEntity() { return null!; }

        protected virtual void TabloYukle() { }

        protected virtual void SifreSifirla() { }

        protected internal virtual void ButonEnabledDurumu()
        {
            if (!IsLoaded) return;
            UIExtensions.ButtonEnabledDurumu(btnYeni, btnKaydet, btnGerial, btnSil, btnYenile, btnYazdir, btnYazdir2, OldEntity, CurrentEntity, BaseIslemTuru);
        }

        //Events

        protected virtual void Button_ItemClick(object? sender, ItemClickEventArgs e)
        {
            if (IsDesignMode) return;

            Cursor.Current = Cursors.WaitCursor;

            var name = e.Item.Name;

            if (name == "btnYeni")
            {
                BaseIslemTuru = ActionType.EntityInsert;
                Yukle();
            }
            else if (name == "btnKaydet")
                Kaydet(true);
            else if (name == "btnFarkliKaydet")
                FarkliKaydet();
            else if (name == "btnGerial")
                GeriAl();
            else if (name == "btnYenile")
                Yukle();
            else if (name == "btnAracTemizle")
                AracTemizle();
            else if (name == "btnSil")
            {
                EntityDelete();
            }
            else if (name == "btnUygula")
                FiltreUygula();
            else if (name == "btnYazdir")
                Yazdir();
            else if (name == "btnYazdir2")
                Yazdir2();
            else if (name == "btnBaskiOnizle")
                BaskiOnizleme();
            else if (name == "btnHesapMakinesi")
                HesapMakinesiAc();
            else if (name == "btnIpAdresim")
                IpAdresiGoster();
            else if (name == "btnSifreSifirla")
                SifreSifirla();
            else if (name == "btnSifreDegistir")
                SifreDegistir();
            else if (name == "btnKapat")
                Close();

            Cursor.Current = Cursors.Default;
        }

        private void BaseEditForm_LocationChanged(object? sender, EventArgs e)
        {
            if (!IsDesignMode) _formSablonKayitEdilecek = true;
        }

        private void BaseEditForm_SizeChanged(object? sender, EventArgs e)
        {
            if (!IsDesignMode) _formSablonKayitEdilecek = true;
        }

        private void BaseEditForm_Load(object? sender, EventArgs e)
        {
            if (IsDesignMode) return;

            SablonYukle();
            Yukle();
            GuncelNesneOlustur();
            OldEntity = CurrentEntity;
            IsLoaded = true;
            ButonEnabledDurumu();
            ButonGizleGoster();
        }

        protected virtual void BaseEditForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (IsDesignMode) return;

            if (FormSablonKaydet)
                SablonKaydet();

            if (btnKaydet.Visibility == DevExpress.XtraBars.BarItemVisibility.Never || !btnKaydet.Enabled) return;

            if (!Kaydet(true)) e.Cancel = true;
        }

        protected virtual void BaseEditForm_Shown(object? sender, EventArgs e) { }

        protected virtual void Control_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        protected virtual void Control_GotFocus(object? sender, EventArgs e)
        {
            statusBarKisaYol.Visibility = BarItemVisibility.Always;
            statusBarKisaYolAciklama.Visibility = BarItemVisibility.Always;
        }

        protected virtual void Control_Leave(object? sender, EventArgs e)
        {
            statusBarKisaYol.Visibility = BarItemVisibility.Never;
            statusBarKisaYolAciklama.Visibility = BarItemVisibility.Never;
        }

        protected virtual void Control_Enter(object? sender, EventArgs e) { }

        protected virtual void Control_EditValueChanged(object? sender, EventArgs e)
        {
            if (!IsLoaded) return;
            GuncelNesneOlustur();
            ButonEnabledDurumu();
        }

        protected virtual void Control_SelectedValueChanged(object? sender, EventArgs e) { }

        protected virtual void Control_IdChanged(object? sender, EventArgs e)
        {
            if (!IsLoaded) return;
            GuncelNesneOlustur();
            ButonEnabledDurumu();
        }

        protected virtual void Control_EnabledChange(object? sender, EventArgs e) { }

        protected virtual void Control_ButtonClick(object? sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (sender != null) SecimYap(sender);
        }

        protected virtual void Control_DoubleClick(object? sender, EventArgs e)
        {
            if (sender != null) SecimYap(sender);
        }

        protected virtual void Control_SelectedPageChanged(object? sender, SelectedPageChangedEventArgs e) { }
        protected virtual void Control_FocusedRowChanged(object? sender, DevExpress.XtraVerticalGrid.Events.FocusedRowChangedEventArgs e) { }
        protected virtual void Control_CellValueChanged(object? sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e) { }
    }
}