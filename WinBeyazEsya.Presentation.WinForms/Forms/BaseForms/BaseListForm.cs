using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting.Native;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using WinBeyazEsya.Application.DTOs.Base;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Presentation.WinForms.Enums;
using WinBeyazEsya.Presentation.WinForms.Helpers;
using WinBeyazEsya.Application.Interfaces.System;

namespace WinBeyazEsya.Presentation.WinForms.Forms.BaseForms
{
    public partial class BaseListForm : RibbonForm
    {
        #region Variables

        protected long _filtreId;
        private bool _formSablonKayitEdilecek;
        private bool _tabloSablonKayitEdilecek;
        private System.IO.MemoryStream? _defaultLayoutStream;
        protected bool AktifKartlariGoster = true;
        protected object FormShow = default!;
        protected ModuleType BaseKartTuru;
        protected object Bll = default!;
        protected object Bll2 = default!;
        protected ControlNavigator Navigator = default!;
        protected BarItem[] ShowItems = default!;
        protected BarItem[] HideItems = default!;
        protected internal GridView Tablo = default!;
        protected internal bool AktifPasifButonGoster = false;
        protected internal bool MultiSelect;
        protected internal BaseDto SelectedEntity = default!;
        protected internal long? SeciliGelecekId;
        protected internal IList<long> ListeDisiTutulacakKayitlar = default!;
        protected internal SelectRowFunctions RowSelect = default!; 
        protected internal IList<BaseDto> SelectedEntities = default!;
        protected internal bool EklenebilecekEntityVar = false;
        protected internal FormAcilisTuru FormAcilisTuru;

        private bool? _hasInsertPermission;
        private bool? _hasUpdatePermission;
        private bool? _hasDeletePermission;
        private bool? _hasReadPermission;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BarStaticItem barEnter { get; set; } = new BarStaticItem();
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BarStaticItem barEnterAciklama { get; set; } = new BarStaticItem();

        #endregion

        public BaseListForm()
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

        private void EventsLoad()
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
            Shown += BaseListForm_Shown;
            Load += BaseListForm_Load;
            FormClosing += BaseListForm_FormClosing;
            LocationChanged += BaseListForm_LocationChanged;
            SizeChanged += BaseListForm_SizeChanged;
        }

        //Functions

        private void ButonGizleGoster()
        {
            if (btnSec != null) btnSec.Visibility = !IsMdiChild ? BarItemVisibility.Always : BarItemVisibility.Never;
            if (barEnter != null) barEnter.Visibility = !IsMdiChild ? BarItemVisibility.Always : BarItemVisibility.Never;
            if (barEnterAciklama != null) barEnterAciklama.Visibility = !IsMdiChild ? BarItemVisibility.Always : BarItemVisibility.Never;
            if (btnAktifPasifKayitlar != null) btnAktifPasifKayitlar.Visibility = AktifPasifButonGoster ? BarItemVisibility.Always : BarItemVisibility.Never;

            if (ShowItems != null)
                foreach (var x in ShowItems) x.Visibility = BarItemVisibility.Always;
            
            if (HideItems != null)
                foreach (var x in HideItems) x.Visibility = BarItemVisibility.Never;

            // Alt kısımdaki kısayol açıklamalarını üstteki butonların görünürlüğüne bağlayalım
            if (bsiYeni != null && btnYeni != null)
            {
                bsiYeni.Visibility = btnYeni.Visibility;
                bsiYeniAciklama.Visibility = btnYeni.Visibility;
                bsiSil.Visibility = btnSil.Visibility;
                bsiSilAciklama.Visibility = btnSil.Visibility;
                bsiDuzelt.Visibility = btnDuzelt.Visibility;
                bsiDuzeltAciklama.Visibility = btnDuzelt.Visibility;
                barSec.Visibility = btnSec.Visibility;
                barSecAciklama.Visibility = btnSec.Visibility;
                bsiYenile.Visibility = btnYenile.Visibility;
                bsiYenileAciklama.Visibility = btnYenile.Visibility;
                bsiYazdir.Visibility = btnYazdir.Visibility;
                bsiYazdirAciklama.Visibility = btnYazdir.Visibility;
                bsiKapat.Visibility = btnKapat.Visibility;
                bsiKapatAciklama.Visibility = btnKapat.Visibility;
            }
        }

        private void SablonKaydet()
        {
            if (_formSablonKayitEdilecek) Helpers.LayoutHelper.KaydetForm(this);
            if (_tabloSablonKayitEdilecek && Tablo != null) Helpers.LayoutHelper.KaydetGrid(Tablo);
        }

        private void SablonYukle()
        {
            if (IsMdiChild)
                Helpers.LayoutHelper.YukleGrid(Tablo);
            else
            {
                Helpers.LayoutHelper.YukleForm(this);
                Helpers.LayoutHelper.YukleGrid(Tablo);
            }
        }

        private void FiltreSec()
        {
            // Filtre Seç logic
        }

        private void FormCaptionAyarla()
        {
            if (btnAktifPasifKayitlar == null)
            {
                Listele();
                return;
            }
            else if (AktifKartlariGoster)
            {
                btnAktifPasifKayitlar.Caption = "Pasif Kayıtlar";
                if (Tablo != null) Tablo.ViewCaption = Text;
            }
            else
            {
                btnAktifPasifKayitlar.Caption = "Aktif Kayıtlar";
                if (Tablo != null) Tablo.ViewCaption = Text + " - Pasif Kayıtlar";
            }
            Listele();
        }

        protected virtual void SelectEntity()
        {
            if (MultiSelect)
            {
                SelectedEntities = new List<BaseDto>();
                
                if (RowSelect != null)
                {
                    if (RowSelect.SelectedRowCount == 0)
                    {
                        Messages.UyariMesaji("Lütfen bir kayıt seçiniz.");
                        return;
                    }
                    SelectedEntities = RowSelect.GetSelectedRows().ToList();
                }
                 
            }
            else
            {
                if (Tablo != null && Tablo.FocusedRowHandle >= 0)
                {
                    var rowObj = Tablo.GetRow(Tablo.FocusedRowHandle) as BaseDto;
                    if (rowObj != null)
                    {
                        SelectedEntities = new List<BaseDto> { rowObj };
                    }
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void IslemTuruSec()
        {
            if (FormAcilisTuru != FormAcilisTuru.Tanimsiz)
            {
                switch (FormAcilisTuru)
                {
                    case FormAcilisTuru.Secim:
                        SelectEntity();
                        return;

                    case FormAcilisTuru.Duzenleme:
                    case FormAcilisTuru.Liste:
                        if (btnDuzelt != null) btnDuzelt.PerformClick();
                        return;
                }
            }

            if (!IsMdiChild)
                SelectEntity();
            else
            {
                if (btnDuzelt != null) btnDuzelt.PerformClick();
            }
        }

        protected virtual void ShowEditFormDefault(long id)
        {
            if (id <= 0) return;
            AktifKartlariGoster = true;
            FormCaptionAyarla();
            Tablo.RowFocus("Id", id);
        }

        protected virtual void DegiskenleriDoldur() { }

        protected virtual void ShowEditForm(long id)
        {
        }

        protected virtual void EntityDelete()
        {
        }

        protected virtual void Listele() { }

        protected virtual void Yazdir()
        {
        }
        protected virtual void Yazdir2()
        {
        }

        protected virtual void BaskiOnizleme() { }

        protected virtual void Aktar() { }

        protected virtual void Aktar2() { }

        protected virtual void OrtalamaSevkMetresi() { }

        protected virtual void UretimAdetGiris() { }

        protected virtual void BagliKayitAc() { }

        protected virtual void TumunuSec() { }

        protected virtual void TumSecimleriKaldir() { }

        protected virtual void UretimPlanlama() { }

        protected virtual void YetkiKontroluYap()
        {
            if ((int)BaseKartTuru == 0)
            {
                if (!IsDesignMode)
                {
                    throw new InvalidOperationException($"{this.GetType().Name} formunda BaseKartTuru (Yetki Modülü) atanmamış! Lütfen constructor içerisinde BaseKartTuru değerini belirleyiniz.");
                }
                return;
            }

            if (Program.ServiceProvider == null) return;
            var authService = (WinBeyazEsya.Application.Services.Management.IAuthService?)Program.ServiceProvider.GetService(typeof(WinBeyazEsya.Application.Services.Management.IAuthService));
            if (authService == null) return;

            if (_hasInsertPermission == null || _hasUpdatePermission == null || _hasDeletePermission == null || _hasReadPermission == null)
            {
                _hasInsertPermission = authService.HasPermission(BaseKartTuru, PermissionType.CanAdd);
                _hasUpdatePermission = authService.HasPermission(BaseKartTuru, PermissionType.CanEdit);
                _hasDeletePermission = authService.HasPermission(BaseKartTuru, PermissionType.CanDelete);
                _hasReadPermission = authService.HasPermission(BaseKartTuru, PermissionType.CanView);
            }

            bool hasInsert = _hasInsertPermission.Value;
            bool hasUpdate = _hasUpdatePermission.Value;
            bool hasDelete = _hasDeletePermission.Value;
            bool hasRead = _hasReadPermission.Value;

            if (btnYeni != null && !hasInsert) btnYeni.Enabled = false;
            if (btnDuzelt != null && !hasRead) btnDuzelt.Enabled = false;
            if (btnSil != null && !hasDelete) btnSil.Enabled = false;

            ButonGizleGoster();
        }

        protected internal void Yukle()
        {
            DegiskenleriDoldur();
            YetkiKontroluYap();

            if (Tablo != null)
            {
                Tablo.OptionsSelection.MultiSelect = MultiSelect;
                if (Navigator != null) Navigator.NavigatableControl = Tablo.GridControl;
                
                // Tablo eventlerini ancak tablo değişkene atandıktan sonra bağlayabiliriz
                Tablo.DoubleClick -= Tablo_DoubleClick;
                Tablo.KeyDown -= Tablo_KeyDown;
                Tablo.MouseUp -= Tablo_MouseUp;
                Tablo.ColumnWidthChanged -= Tablo_ColumnWidthChanged;
                Tablo.ColumnPositionChanged -= Tablo_ColumnPositionChanged;
                Tablo.EndSorting -= Tablo_EndSorting;
                Tablo.FilterEditorCreated -= Tablo_FilterEditorCreated;
                Tablo.ColumnFilterChanged -= Tablo_ColumnFilterChanged;

                Tablo.DoubleClick += Tablo_DoubleClick;
                Tablo.KeyDown += Tablo_KeyDown;
                Tablo.MouseUp += Tablo_MouseUp;
                Tablo.ColumnWidthChanged += Tablo_ColumnWidthChanged;
                Tablo.ColumnPositionChanged += Tablo_ColumnPositionChanged;
                Tablo.EndSorting += Tablo_EndSorting;
                Tablo.FilterEditorCreated += Tablo_FilterEditorCreated;
                Tablo.ColumnFilterChanged += Tablo_ColumnFilterChanged;
            }

            Cursor.Current = Cursors.WaitCursor;
            Listele();
            Cursor.Current = Cursors.Default;
        }

        protected virtual void Duzelt() { }

        //Events

        protected virtual void Button_ItemClick(object? sender, ItemClickEventArgs e)
        {
            if (IsDesignMode) return;

            var name = e.Item.Name;

            if (Program.ServiceProvider != null && (int)BaseKartTuru != 0)
            {
                var authService = (WinBeyazEsya.Application.Services.Management.IAuthService?)Program.ServiceProvider.GetService(typeof(WinBeyazEsya.Application.Services.Management.IAuthService));
                if (authService != null)
                {
                    if (_hasInsertPermission == null || _hasUpdatePermission == null || _hasDeletePermission == null || _hasReadPermission == null)
                    {
                        _hasInsertPermission = authService.HasPermission(BaseKartTuru, PermissionType.CanAdd);
                        _hasUpdatePermission = authService.HasPermission(BaseKartTuru, PermissionType.CanEdit);
                        _hasDeletePermission = authService.HasPermission(BaseKartTuru, PermissionType.CanDelete);
                        _hasReadPermission = authService.HasPermission(BaseKartTuru, PermissionType.CanView);
                    }

                    bool hasInsert = _hasInsertPermission.Value;
                    bool hasUpdate = _hasUpdatePermission.Value;
                    bool hasDelete = _hasDeletePermission.Value;
                    bool hasRead = _hasReadPermission.Value;

                    if (name == "btnYeni" && !hasInsert) { Messages.UyariMesaji("Bu işlem için yetkiniz bulunmamaktadır."); return; }
                    if (name == "btnSil" && !hasDelete) { Messages.UyariMesaji("Bu işlem için yetkiniz bulunmamaktadır."); return; }
                    if (name == "btnDuzelt" && !hasRead) { Messages.UyariMesaji("Bu işlem (Görüntüleme) için yetkiniz bulunmamaktadır."); return; }
                }
            }

            Cursor.Current = Cursors.WaitCursor;

            if (name == "btnStandartExcelDosyasi")
                TabloDisariAktar("ExcelStandart");
            else if (name == "btnFormatliExcelDosyasi")
                TabloDisariAktar("ExcelFormatli");
            else if (name == "btnFormatsizExcelDosyasi")
                TabloDisariAktar("ExcelFormatsiz");
            else if (name == "btnWordDosyasi")
                TabloDisariAktar("WordDosyasi");
            else if (name == "btnPdfDosyasi")
                TabloDisariAktar("PdfDosyasi");
            else if (name == "btnTxtDosyasi")
                TabloDisariAktar("TxtDosyasi");
            else if (name == "btnYeni")
            {
                ShowEditForm(-1);
            }
            else if (name == "btnDuzelt")
            {
                long id = -1;
                if (Tablo != null && Tablo.FocusedRowHandle >= 0)
                {
                    var rowObj = Tablo.GetRowCellValue(Tablo.FocusedRowHandle, "Id");
                    if (rowObj != null && long.TryParse(rowObj.ToString(), out long parsedId))
                    {
                        id = parsedId;
                    }
                }
                if (id >= 0) ShowEditForm(id);
            }
            else if (name == "btnSil")
            {
                long id = -1;
                if (Tablo != null && Tablo.FocusedRowHandle >= 0)
                {
                    var rowObj = Tablo.GetRowCellValue(Tablo.FocusedRowHandle, "Id");
                    if (rowObj != null && long.TryParse(rowObj.ToString(), out long parsedId))
                    {
                        id = parsedId;
                    }
                }
                if (id >= 0) EntityDelete();
            }
            else if (name == "btnSec")
                SelectEntity();
            else if (name == "btnYenile")
                Listele();
            else if (name == "btnFiltrele")
                FiltreSec();
            else if (name == "btnKolonlar")
            {
                if (Tablo != null)
                {
                    if (Tablo.CustomizationForm == null)
                        Tablo.ShowCustomization();
                    else
                        Tablo.HideCustomization();
                }
            }
            else if (name == "btnBagliKayitlar")
                BagliKayitAc();
            else if (name == "btnFavorilereEkle")
                FavoriDurumunuDegistir();
            else if (name == "btnYazdir")
                Yazdir();
            else if (name == "btnYazdir2")
                Yazdir2();
            else if (name == "btnTabloYazdir")
                Yazdir();
            else if (name == "btnBaskiOnizle")
                BaskiOnizleme();
            else if (name == "btnAktar")
                Aktar();
            else if (name == "btnAktar2")
                Aktar2();
            else if (name == "btnUrunUretimAdediGiris")
                UretimAdetGiris();
            else if (name == "btnTasarimDegistir")
                Duzelt();
            else if (name == "btnTumunuSec")
                TumunuSec();
            else if (name == "btnTumSecimleriKaldir")
                TumSecimleriKaldir();
            else if (name == "btnSevkMetreDetay")
                OrtalamaSevkMetresi();
            else if (name == "btnKapat")
                Close();
            else if (name == "btnAktifPasifKayitlar")
            {
                AktifKartlariGoster = !AktifKartlariGoster;
                FormCaptionAyarla();
            }
            else if (name == "btnUretimPlanlama")
                UretimPlanlama();

            Cursor.Current = Cursors.Default;
        }

        private void Tablo_DoubleClick(object? sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            IslemTuruSec();
            Cursor.Current = Cursors.Default;
        }

        private void Tablo_KeyDown(object? sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    IslemTuruSec();
                    break;
                case Keys.Escape:
                    Close();
                    break;
            }
        }

        private void Tablo_MouseUp(object? sender, MouseEventArgs e)
        {
        }

        private void Tablo_ColumnWidthChanged(object? sender, DevExpress.XtraGrid.Views.Base.ColumnEventArgs e)
        {
            _tabloSablonKayitEdilecek = true;
        }

        private void Tablo_ColumnPositionChanged(object? sender, EventArgs e)
        {
            _tabloSablonKayitEdilecek = true;
        }

        private void Tablo_EndSorting(object? sender, EventArgs e)
        {
            _tabloSablonKayitEdilecek = true;
        }

        private void Tablo_FilterEditorCreated(object? sender, DevExpress.XtraGrid.Views.Base.FilterControlEventArgs e)
        {
            e.ShowFilterEditor = false;
        }

        private void Tablo_ColumnFilterChanged(object? sender, EventArgs e)
        {
            if (Tablo != null && string.IsNullOrEmpty(Tablo.ActiveFilterString))
                _filtreId = 0;
        }

        private void BaseListForm_Shown(object? sender, EventArgs e)
        {
            if (IsDesignMode) return;

            if (Tablo != null) Tablo.Focus();
            ButonGizleGoster();

            if (IsMdiChild || SeciliGelecekId == null) return;
            Tablo.RowFocus("Id", SeciliGelecekId);
        }

        private void BaseListForm_Load(object? sender, EventArgs e)
        {
            if (IsDesignMode) return;
            Yukle();
            
            if (Tablo != null)
            {
                _defaultLayoutStream = new System.IO.MemoryStream();
                Tablo.SaveLayoutToStream(_defaultLayoutStream);
                _defaultLayoutStream.Position = 0;
            }
            
            SablonYukle();
            FormCaptionAyarla();
            FavoriDurumunuKontrolEt();
        }


        private void FavoriDurumunuDegistir()
        {
            if (Program.ServiceProvider == null) return;
            var currentTenantService = (ICurrentTenantService?)Program.ServiceProvider.GetService(typeof(ICurrentTenantService));
            var favoriteService = (WinBeyazEsya.Application.Interfaces.Management.IUserFavoriteService?)Program.ServiceProvider.GetService(typeof(WinBeyazEsya.Application.Interfaces.Management.IUserFavoriteService));
            
            if (currentTenantService != null && favoriteService != null)
            {
                favoriteService.ToggleFavorite(currentTenantService.UserId, this.Text, this.GetType().FullName!);
                FavoriDurumunuKontrolEt(); 
                
                if (this.MdiParent is WinBeyazEsya.Presentation.WinForms.Forms.GenelForms.AnaForm anaForm)
                {
                    anaForm.LoadFavorites();
                }
            }
        }

        private void FavoriDurumunuKontrolEt()
        {
            if (Program.ServiceProvider == null || btnFavorilereEkle == null) return;
            var currentTenantService = (ICurrentTenantService?)Program.ServiceProvider.GetService(typeof(ICurrentTenantService));
            var favoriteService = (WinBeyazEsya.Application.Interfaces.Management.IUserFavoriteService?)Program.ServiceProvider.GetService(typeof(WinBeyazEsya.Application.Interfaces.Management.IUserFavoriteService));
            
            if (currentTenantService != null && favoriteService != null)
            {
                bool isFavorite = favoriteService.IsFavorite(currentTenantService.UserId, this.GetType().FullName!);
                if (isFavorite)
                {
                    btnFavorilereEkle.Caption = "Favorilerden Çıkar";
                    btnFavorilereEkle.ImageOptions.Image = Properties.Resources.deletelist_16x16; 
                }
                else
                {
                    btnFavorilereEkle.Caption = "Favorilere Ekle";
                    btnFavorilereEkle.ImageOptions.Image = Properties.Resources.feature_16x16;
                }
            }
        }

        private void BaseListForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (IsDesignMode) return;
            SablonKaydet();
        }

        private void BaseListForm_LocationChanged(object? sender, EventArgs e)
        {
            if (!IsMdiChild)
                _formSablonKayitEdilecek = true;
        }

        private void BaseListForm_SizeChanged(object? sender, EventArgs e)
        {
            if (!IsMdiChild)
                _formSablonKayitEdilecek = true;
        }

        protected virtual void TabloDisariAktar(string dosyaTuru)
        {
            if (Tablo == null) return;

            try
            {
                switch (dosyaTuru)
                {
                    case "ExcelStandart":
                        using (var dialog = new SaveFileDialog { Filter = "Excel Documents (*.xlsx)|*.xlsx", Title = "Excel'e Aktar (Standart)" })
                            if (dialog.ShowDialog() == DialogResult.OK) Tablo.ExportToXlsx(dialog.FileName);
                        break;
                    case "ExcelFormatli":
                        using (var dialog = new SaveFileDialog { Filter = "Excel Documents (*.xlsx)|*.xlsx", Title = "Excel'e Aktar (Formatlı)" })
                            if (dialog.ShowDialog() == DialogResult.OK) Tablo.ExportToXlsx(dialog.FileName, new DevExpress.XtraPrinting.XlsxExportOptions { TextExportMode = DevExpress.XtraPrinting.TextExportMode.Text });
                        break;
                    case "ExcelFormatsiz":
                        using (var dialog = new SaveFileDialog { Filter = "Excel Documents (*.xlsx)|*.xlsx", Title = "Excel'e Aktar (Formatsız)" })
                            if (dialog.ShowDialog() == DialogResult.OK) Tablo.ExportToXlsx(dialog.FileName, new DevExpress.XtraPrinting.XlsxExportOptions { TextExportMode = DevExpress.XtraPrinting.TextExportMode.Value });
                        break;
                    case "PdfDosyasi":
                        using (var dialog = new SaveFileDialog { Filter = "PDF Documents (*.pdf)|*.pdf", Title = "PDF'e Aktar" })
                            if (dialog.ShowDialog() == DialogResult.OK) Tablo.ExportToPdf(dialog.FileName);
                        break;
                    case "WordDosyasi":
                        using (var dialog = new SaveFileDialog { Filter = "Word Documents (*.docx)|*.docx", Title = "Word'e Aktar" })
                            if (dialog.ShowDialog() == DialogResult.OK) Tablo.ExportToDocx(dialog.FileName);
                        break;
                    case "TxtDosyasi":
                        using (var dialog = new SaveFileDialog { Filter = "Text Documents (*.txt)|*.txt", Title = "TXT'e Aktar" })
                            if (dialog.ShowDialog() == DialogResult.OK) Tablo.ExportToText(dialog.FileName);
                        break;
                }
            }
            catch (Exception ex)
            {
                Messages.HataMesaji(ex.Message);
            }
        }
    }
}
