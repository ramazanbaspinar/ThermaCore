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
using System.Linq;
using ThermaCore.Presentation.WinForms.Functions;

namespace ThermaCore.Presentation.WinForms.Forms.BaseForms
{
    public partial class BaseEditForm : RibbonForm
    {
        public virtual long FirmaId { get; set; } = 0;
        public virtual bool FirmaKisaKodKullan { get; set; } = false;

        #region Variables

        private bool _formSablonKayitEdilecek;
        private bool _isSaving = false;
        protected bool _isBinding = false;
        protected bool _isCheckedListBoxModified = false;
        protected bool _geriAlKapat = false;
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
        protected bool RequiresCodeTemplate = true;
        protected virtual string CodeControlName => "txtKod";

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BarStaticItem statusBarAciklama { get; set; } = new BarStaticItem();
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BarStaticItem statusBarKisaYol { get; set; } = new BarStaticItem();
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BarStaticItem statusBarKisaYolAciklama { get; set; } = new BarStaticItem();

        protected DevExpress.XtraBars.BarButtonItem btnYazdir2 = null!;
        protected DevExpress.XtraBars.PopupMenu resimMenu = null!;

        #endregion

        protected virtual void YetkiKontroluYap()
        {
            if ((int)BaseKartTuru == 0) return;

            if (Program.ServiceProvider == null) return;
            var authService = (ThermaCore.Application.Services.Management.IAuthService?)Program.ServiceProvider.GetService(typeof(ThermaCore.Application.Services.Management.IAuthService));
            if (authService == null) return;

            bool hasInsert = authService.HasPermission(BaseKartTuru, PermissionType.CanAdd);
            bool hasUpdate = authService.HasPermission(BaseKartTuru, PermissionType.CanEdit);
            bool hasDelete = authService.HasPermission(BaseKartTuru, PermissionType.CanDelete);

            if (BaseIslemTuru == ActionType.EntityInsert && !hasInsert)
            {
                if (btnKaydet != null) btnKaydet.Enabled = false;
                if (btnYeni != null) btnYeni.Enabled = false;
                if (btnSil != null) btnSil.Enabled = false;
            }
            else if (BaseIslemTuru == ActionType.EntityUpdate && !hasUpdate)
            {
                if (btnKaydet != null) btnKaydet.Enabled = false;
                if (btnGerial != null) btnGerial.Enabled = false;
                if (btnYeni != null) btnYeni.Enabled = false;
                if (btnSil != null) btnSil.Enabled = false;

                LockFormControls(this.Controls);
                
                if (!this.Text.Contains("[SADECE GÖRÜNTÜLEME]"))
                {
                    this.Text += " [SADECE GÖRÜNTÜLEME]";
                }
            }
            else
            {
                if (btnYeni != null && !hasInsert) btnYeni.Enabled = false;
                if (btnSil != null && !hasDelete) btnSil.Enabled = false;
            }
        }

        protected virtual void LockFormControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is DevExpress.XtraEditors.BaseEdit baseEdit)
                {
                    baseEdit.Properties.ReadOnly = true;
                }
                else if (control is DevExpress.XtraGrid.GridControl gridControl)
                {
                    gridControl.Enabled = false;
                }

                if (control.Controls.Count > 0)
                {
                    LockFormControls(control.Controls);
                }
            }
        }

        public BaseEditForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            if (!IsDesignMode)
            {
                this.KeyPreview = true;
                EventsLoad();
            }
            base.OnLoad(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                Close();
            }
            base.OnKeyDown(e);
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

            InitializeResimMenu();
            BindControlEvents(this.Controls);
            BindPictureEditControls(this.Controls);
        }

        private void InitializeResimMenu()
        {
            if (IsDesignMode) return;

            var manager = (this.ribbon != null) ? this.ribbon.Manager : new DevExpress.XtraBars.BarManager { Form = this };
            
            resimMenu = new DevExpress.XtraBars.PopupMenu(manager);

            var btnResimSec = new DevExpress.XtraBars.BarButtonItem(manager, "Resim Seç");
            btnResimSec.ItemClick += (s, e) => { (resimMenu.Tag as ThermaCore.Presentation.WinForms.UserControls.Controls.MyPictureEdit)?.ResimSec(); };

            var btnKamera = new DevExpress.XtraBars.BarButtonItem(manager, "Kameradan Çek");
            btnKamera.ItemClick += (s, e) => { (resimMenu.Tag as ThermaCore.Presentation.WinForms.UserControls.Controls.MyPictureEdit)?.ShowTakePictureDialog(); };

            var btnResimBuyut = new DevExpress.XtraBars.BarButtonItem(manager, "Resmi Büyüt");
            btnResimBuyut.ItemClick += (s, e) => { (resimMenu.Tag as ThermaCore.Presentation.WinForms.UserControls.Controls.MyPictureEdit)?.ResimBuyut(); };

            var btnResimIndir = new DevExpress.XtraBars.BarButtonItem(manager, "Resmi İndir");
            btnResimIndir.ItemClick += (s, e) => { (resimMenu.Tag as ThermaCore.Presentation.WinForms.UserControls.Controls.MyPictureEdit)?.ResimIndir(); };

            var btnResimSil = new DevExpress.XtraBars.BarButtonItem(manager, "Resim Sil");
            btnResimSil.ItemClick += (s, e) => { (resimMenu.Tag as ThermaCore.Presentation.WinForms.UserControls.Controls.MyPictureEdit)?.ResimSil(); };

            resimMenu.AddItems(new BarItem[] { btnResimSec, btnKamera, btnResimBuyut, btnResimIndir, btnResimSil });
        }

        protected virtual void BindPictureEditControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is ThermaCore.Presentation.WinForms.UserControls.Controls.MyPictureEdit pictureEdit)
                {
                    if (resimMenu != null && pictureEdit.ContextMenuStrip == null)
                    {
                        pictureEdit.Sec(resimMenu);
                    }
                }

                if (control.Controls.Count > 0)
                {
                    BindPictureEditControls(control.Controls);
                }
            }
        }

        protected virtual void BindControlEvents(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is DevExpress.XtraEditors.BaseEdit baseEdit)
                {
                    baseEdit.EditValueChanged -= Control_EditValueChanged; // Önlem olarak
                    baseEdit.EditValueChanged += Control_EditValueChanged;
                }
                else if (control is DevExpress.XtraEditors.CheckedListBoxControl checkedListBox)
                {
                    checkedListBox.ItemCheck -= CheckedListBox_ItemCheck;
                    checkedListBox.ItemCheck += CheckedListBox_ItemCheck;
                }
                
                if (control.Controls.Count > 0)
                {
                    BindControlEvents(control.Controls);
                }
            }
        }

        protected virtual void ResetControlIsModified(Control.ControlCollection controls)
        {
            _isCheckedListBoxModified = false;
            foreach (Control control in controls)
            {
                if (control is DevExpress.XtraEditors.BaseEdit baseEdit)
                {
                    baseEdit.IsModified = false;
                }
                
                if (control.Controls.Count > 0)
                {
                    ResetControlIsModified(control.Controls);
                }
            }
        }

        //Functions

        protected BaseDto CloneEntity(BaseDto entity)
        {
            if (entity == null) return null!;
            var type = entity.GetType();
            var cloned = (BaseDto)Activator.CreateInstance(type)!;
            
            var properties = type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
                                 .Where(p => p.CanRead && p.CanWrite);
            foreach (var prop in properties)
            {
                var value = prop.GetValue(entity, null);
                prop.SetValue(cloned, value, null);
            }
            return cloned;
        }

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
            {
                _isBinding = true;
                Yukle();
                CurrentEntityGuncelle();
                _isBinding = false;
                
                OldEntity = CloneEntity(CurrentEntity);
                ResetControlIsModified(this.Controls);
                ButonEnabledDurumu();
            }
            else
            {
                _geriAlKapat = true;
                Close();
            }
            Cursor.Current = Cursors.Default;
        }

        protected bool Kaydet(bool kapanis, bool prompt = true)
        {
            if (_isSaving) return true;
            _isSaving = true;

            try
            {
                bool KayitIslemi()
                {
                    Cursor.Current = Cursors.WaitCursor;

                    try
                    {
                        switch (BaseIslemTuru)
                        {
                            case ActionType.EntityInsert:
                            case ActionType.EntityUpdate:
                                if (Program.ServiceProvider != null && CurrentEntity != null)
                                {
                                    bool hasTempCode = false;
                                    if (string.IsNullOrWhiteSpace(CurrentEntity.Code)) 
                                    {
                                        CurrentEntity.Code = "TEMP_VALIDATION_CODE";
                                        hasTempCode = true;
                                    }

                                    var validatorType = typeof(FluentValidation.IValidator<>).MakeGenericType(CurrentEntity.GetType());
                                    var validator = Program.ServiceProvider.GetService(validatorType) as FluentValidation.IValidator;
                                    if (validator != null)
                                    {
                                        var contextType = typeof(FluentValidation.ValidationContext<>).MakeGenericType(CurrentEntity.GetType());
                                        var context = (FluentValidation.IValidationContext)Activator.CreateInstance(contextType, CurrentEntity)!;
                                        var valResult = validator.Validate(context);
                                        
                                        if (hasTempCode) CurrentEntity.Code = string.Empty;

                                        if (!valResult.IsValid)
                                        {
                                            throw new FluentValidation.ValidationException(valResult.Errors);
                                        }
                                    }
                                    else
                                    {
                                        if (hasTempCode) CurrentEntity.Code = string.Empty;
                                        throw new InvalidOperationException($"{CurrentEntity.GetType().Name} için DI Container'da FluentValidation (IValidator) kaydı bulunamadı! Lütfen ApplicationServiceRegistration içerisine validator sınıfını kaydettiğinizden emin olun.");
                                    }
                                }

                                if (BaseIslemTuru == ActionType.EntityInsert)
                                {
                                    UretilecekKoduHazirla();
                                    if (EntityInsert())
                                        return KayitSonrasiIslemler();
                                }
                                else if (BaseIslemTuru == ActionType.EntityUpdate)
                                {
                                    if (EntityUpdate())
                                        return KayitSonrasiIslemler();
                                }
                                break;
                        }
                    }
                    catch (FluentValidation.ValidationException ex)
                    {
                        System.Linq.Enumerable.FirstOrDefault(ex.Errors);
                        Messages.UyariMesaji(string.Join("\n", System.Linq.Enumerable.Select(ex.Errors, e => e.ErrorMessage)));
                        var firstError = System.Linq.Enumerable.FirstOrDefault(ex.Errors);
                        if (firstError != null)
                        {
                            FocusControlByPropertyName(firstError.PropertyName);
                        }
                    }
                    finally
                    {
                        Cursor.Current = Cursors.Default;
                    }

                    return false;
                }

                bool KayitSonrasiIslemler()
                {
                    OldEntity = CloneEntity(CurrentEntity);
                    RefreshYapilacak = true;
                    
                    BaseIslemTuru = BaseIslemTuru == ActionType.EntityInsert ? ActionType.EntityUpdate : BaseIslemTuru;
                    ButonEnabledDurumu();

                    KodKullanildiKaydet();

                    if (KayitSonrasiFormuKapat && kapanis)
                        Close();
                    else
                    {
                        _isBinding = true;
                        Yukle();
                        _isBinding = false;
                        ResetControlIsModified(this.Controls);
                    }

                    return true;
                }

                CurrentEntityGuncelle();

                var result = prompt ? (kapanis ? Messages.KapanisMesaj() : Messages.KayitMesaj()) : DialogResult.Yes;

                switch (result)
                {
                    case DialogResult.Yes:
                        return KayitIslemi();

                    case DialogResult.No:
                        return true;

                    case DialogResult.Cancel:
                        return false;
                }

                return false;
            }
            finally
            {
                _isSaving = false;
            }
        }

        private void SablonYukle()
        {
            Helpers.LayoutHelper.YukleForm(this);
        }

        private void FarkliKaydet()
        {
            if (Messages.EvetSeciliEvetHayir("Mevcut Kayıt Referans Alınarak Yeni Bir Kayıt Oluşturulacaktır. Onaylıyor Musunuz?", "Kayıt Onayı") != DialogResult.Yes) return;

            BaseIslemTuru = ActionType.EntityInsert;
            _isBinding = true;
            Yukle();
            ApplyCodeTemplateLogic();
            CurrentEntityGuncelle();
            _isBinding = false;
            ResetControlIsModified(this.Controls);
            
            OldEntity = CloneEntity(CurrentEntity);
            ButonEnabledDurumu();

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

        protected virtual bool IsCodeUnique(string code)
        {
            return true; // Varsayılan olarak her zaman benzersiz kabul edilir. Ezilmesi gerekir.
        }

        protected virtual void UretilecekKoduHazirla()
        {
            var kodControl = this.Controls.Find(CodeControlName, true).FirstOrDefault() as DevExpress.XtraEditors.TextEdit;
            
            if (kodControl != null && !string.IsNullOrWhiteSpace(kodControl.Text) && kodControl.Text != "< Otomatik Üretilecek >")
            {
                if (CurrentEntity != null)
                    CurrentEntity.Code = kodControl.Text;
                return;
            }

            var codeService = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetService<ICodeGenerationService>(Program.ServiceProvider);
            if (codeService != null)
            {
                string code = "";
                for (int i = 0; i < 20; i++)
                {
                    code = System.Threading.Tasks.Task.Run(async () => await codeService.GetNewCodeAsync(BaseKartTuru, FirmaId)).GetAwaiter().GetResult();
                    
                    if (string.IsNullOrEmpty(code)) 
                        break;
                    
                    if (IsCodeUnique(code)) 
                        break;
                }

                if (!string.IsNullOrEmpty(code))
                {
                    if (kodControl != null)
                    {
                        kodControl.Text = code;
                    }
                    if (CurrentEntity != null)
                        CurrentEntity.Code = code;
                }
            }
        }

        protected virtual void NesneyiKontrollereBagla() { }

        protected virtual void GuncelNesneOlustur() { }

        protected void CurrentEntityGuncelle()
        {
            GuncelNesneOlustur();
            if (CurrentEntity != null)
            {
                var properties = CurrentEntity.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                foreach (var prop in properties)
                {
                    if (prop.PropertyType == typeof(string) && prop.CanWrite && prop.CanRead)
                    {
                        var val = prop.GetValue(CurrentEntity) as string;
                        if (val != null && string.IsNullOrWhiteSpace(val))
                        {
                            prop.SetValue(CurrentEntity, null);
                        }
                    }
                }
            }
        }

        public virtual void Yukle() { }

        protected internal virtual object ReturnEntity() { return null!; }

        protected virtual void TabloYukle() { }

        protected virtual void SifreSifirla() { }

        protected internal virtual void ButonEnabledDurumu()
        {
            if (!IsLoaded) return;
            UIExtensions.ButtonEnabledDurumu(btnYeni, btnKaydet, btnGerial, btnSil, btnYenile, btnYazdir, btnYazdir2, OldEntity, CurrentEntity, BaseIslemTuru);
            YetkiKontroluYap();
        }

        protected virtual void FocusControlByPropertyName(string propertyName)
        {
            var ctrl = FindControlByPropertyName(this.Controls, propertyName);

            if (ctrl != null) 
            {
                ctrl.Select(); // DevExpress bileşenlerinde Focus öncesi Select garanti eder
                ctrl.Focus();
            }
        }

        private Control? FindControlByPropertyName(Control.ControlCollection controls, string propertyName)
        {
            foreach (Control c in controls)
            {
                if (c.Name.EndsWith(propertyName, StringComparison.InvariantCultureIgnoreCase)) return c;
                if (c.Tag != null && c.Tag.ToString() == propertyName) return c;
                
                var child = FindControlByPropertyName(c.Controls, propertyName);
                if (child != null) return child;
            }
            return null;
        }

        //Events

        protected virtual void Button_ItemClick(object? sender, ItemClickEventArgs e)
        {
            if (IsDesignMode) return;

            var name = e.Item.Name;

            if (Program.ServiceProvider != null && (int)BaseKartTuru != 0)
            {
                var authService = (ThermaCore.Application.Services.Management.IAuthService?)Program.ServiceProvider.GetService(typeof(ThermaCore.Application.Services.Management.IAuthService));
                if (authService != null)
                {
                    bool hasInsert = authService.HasPermission(BaseKartTuru, PermissionType.CanAdd);
                    bool hasUpdate = authService.HasPermission(BaseKartTuru, PermissionType.CanEdit);
                    bool hasDelete = authService.HasPermission(BaseKartTuru, PermissionType.CanDelete);

                    if (name == "btnYeni" && !hasInsert) { Messages.UyariMesaji("Bu işlem için yetkiniz bulunmamaktadır."); return; }
                    if (name == "btnSil" && !hasDelete) { Messages.UyariMesaji("Bu işlem için yetkiniz bulunmamaktadır."); return; }
                    if (name == "btnKaydet" || name == "btnFarkliKaydet")
                    {
                        if (BaseIslemTuru == ActionType.EntityInsert && !hasInsert) { Messages.UyariMesaji("Bu işlem için yetkiniz bulunmamaktadır."); return; }
                        if (BaseIslemTuru == ActionType.EntityUpdate && !hasUpdate) { Messages.UyariMesaji("Bu işlem için yetkiniz bulunmamaktadır."); return; }
                    }
                }
            }

            Cursor.Current = Cursors.WaitCursor;

            if (name == "btnYeni")
            {
                BaseIslemTuru = ActionType.EntityInsert;
                this.Id = 0;
                _isBinding = true;
                Yukle();
                ApplyCodeTemplateLogic();
                CurrentEntityGuncelle();
                _isBinding = false;
                ResetControlIsModified(this.Controls);
                ButonEnabledDurumu();
            }
            else if (name == "btnKaydet")
                Kaydet(true, false);
            else if (name == "btnFarkliKaydet")
                FarkliKaydet();
            else if (name == "btnGerial")
                GeriAl();
            else if (name == "btnYenile")
            {
                _isBinding = true;
                Yukle();
                _isBinding = false;
                ResetControlIsModified(this.Controls);
            }
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
            _isBinding = true;
            Yukle();
            CurrentEntityGuncelle();
            _isBinding = false;
            ResetControlIsModified(this.Controls);
            
            OldEntity = CloneEntity(CurrentEntity);
            IsLoaded = true;
            ButonEnabledDurumu();
            ButonGizleGoster();

            ApplyCodeTemplateLogic();
            YetkiKontroluYap();
        }

        protected virtual void ApplyCodeTemplateLogic()
        {
            if (!RequiresCodeTemplate) return;

            var sablonRepo = Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetService<ThermaCore.Application.Interfaces.Repositories.IMasterRepository<ThermaCore.Domain.Entities.Management.CodeTemplate>>(Program.ServiceProvider);
            ThermaCore.Domain.Entities.Management.CodeTemplate sablon = null;

            if (sablonRepo != null)
            {
                sablon = System.Linq.Enumerable.FirstOrDefault(sablonRepo.Find(x => x.Module == BaseKartTuru && !x.IsDeleted));
            }

            var kodControl = this.Controls.Find(CodeControlName, true).FirstOrDefault() as DevExpress.XtraEditors.TextEdit;
            if (kodControl != null)
            {
                bool isReadOnly = true;

                if (sablon == null || !sablon.IsAutoCodeGenerationEnabled)
                {
                    isReadOnly = false;
                }
                else if (sablon.IsUserInterventionAllowed)
                {
                    isReadOnly = false;
                }

                kodControl.Properties.ReadOnly = isReadOnly;

                if (BaseIslemTuru == ActionType.EntityInsert)
                {
                    kodControl.Text = "";
                    kodControl.Properties.NullValuePrompt = isReadOnly ? "< Otomatik Üretilecek >" : "";
                }
            }
        }

        protected virtual void BaseEditForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (IsDesignMode) return;

            if (FormSablonKaydet)
                SablonKaydet();

            if (_geriAlKapat || _isSaving || btnKaydet.Visibility == DevExpress.XtraBars.BarItemVisibility.Never || !btnKaydet.Enabled) return;

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
            if (_isBinding || !IsLoaded) return;
            
            // Eğer hiçbir UI kontrolü (TextBox vb.) kullanıcı tarafından değiştirilmediyse (IsModified = false), 
            // asenkron yüklemeler yüzünden gereksiz yere Butonları aktif etmesini (Bug) engelle:
            if (!FarklilikVarMi(this.Controls)) return;

            CurrentEntityGuncelle();
            ButonEnabledDurumu();
        }

        private void CheckedListBox_ItemCheck(object? sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            if (_isBinding || !IsLoaded) return;
            _isCheckedListBoxModified = true;
            Control_EditValueChanged(sender, e);
        }

        private bool FarklilikVarMi(Control.ControlCollection controls)
        {
            if (_isCheckedListBoxModified) return true;

            foreach (Control control in controls)
            {
                if (control is DevExpress.XtraEditors.BaseEdit baseEdit && baseEdit.IsModified)
                    return true;
                if (control.Controls.Count > 0 && FarklilikVarMi(control.Controls))
                    return true;
            }
            return false;
        }

        protected virtual void Control_SelectedValueChanged(object? sender, EventArgs e) { }

        protected virtual void Control_IdChanged(object? sender, EventArgs e)
        {
            if (!IsLoaded) return;
            CurrentEntityGuncelle();
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
