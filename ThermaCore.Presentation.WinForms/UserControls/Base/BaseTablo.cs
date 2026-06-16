#pragma warning disable CS8618
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using ThermaCore.Application.Interfaces.Base;
using ThermaCore.Application.DTOs.Base;
using ThermaCore.Domain.Entities.Base;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Interfaces;
using ThermaCore.Presentation.WinForms.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ThermaCore.Presentation.WinForms.UserControls.Base
{
    public partial class BaseTablo : XtraUserControl
    {
        private bool _isLoaded;
        private bool _tabloSablonKayitEdilecek;
        protected internal GridView Tablo;
        protected BarItem[] ShowItems;
        protected BarItem[] HideItems;
        protected IBaseService Bll;
        protected IList<long> ListeDisiTutulacakKayitlar;
        protected internal bool TableValueChanged;
        protected internal BaseEditForm OwnerForm;

        public BaseTablo()
        {
            InitializeComponent();
        }

        protected void EventsLoad()
        {
            // Button Events
            foreach (BarItem button in barManager.Items)
                button.ItemClick += Button_ItemClick;

            foreach (GridColumn column in Tablo.Columns)
            {
                if (column.ColumnEdit == null) continue;
                var type = column.ColumnEdit.GetType();

                if (type == typeof(RepositoryItemImageComboBox))
                    ((RepositoryItemImageComboBox)column.ColumnEdit).SelectedValueChanged += ImageComboBox_SelectedValueChanged;

                if (type == typeof(RepositoryItemCheckEdit))
                    ((RepositoryItemCheckEdit)column.ColumnEdit).CheckedChanged += CheckEdit_CheckedChanged;
            }

            // Navigator Events
            insUptNavigator.Navigator.ButtonClick += Navigator_ButtonClick;

            // Table Events
            Tablo.CellValueChanged += Tablo_CellValueChanged;
            Tablo.MouseUp += Tablo_MouseUp;
            Tablo.GotFocus += Tablo_GotFocus;
            Tablo.LostFocus += Tablo_LostFocus;
            Tablo.KeyDown += Tablo_KeyDown;
            Tablo.FocusedColumnChanged += Tablo_FocusedColumnChanged;
            Tablo.ColumnPositionChanged += Tablo_SablonChanged;
            Tablo.ColumnWidthChanged += Tablo_SablonChanged;
            Tablo.EndSorting += Tablo_SablonChanged;
            Tablo.DoubleClick += Tablo_DoubleClick;
            Tablo.FocusedRowObjectChanged += Tablo_FocusedRowObjectChanged; //satırlarda veri değişikliği varsa algılıyor
            Tablo.RowCountChanged += Tablo_RowCountChanged;
        }

        protected internal void Yukle()
        {
            _isLoaded = true;
            TableValueChanged = false;
            OwnerForm.ButonEnabledDurumu();
            insUptNavigator.Navigator.NavigatableControl = Tablo.GridControl;
            SablonYukle();
            Listele();
            ButonGizleGoster();
            Tablo_LostFocus(Tablo, EventArgs.Empty);
        }

        private void SablonYukle()
        {
            LayoutHelper.YukleGrid(Tablo);
        }

        protected void SablonKaydet()
        {
            if (_tabloSablonKayitEdilecek)
                LayoutHelper.KaydetGrid(Tablo);
        }

        protected internal virtual void Listele()
        {
        }

        private void ButonGizleGoster()
        {
            ShowItems?.ForEach(x => x.Visibility = BarItemVisibility.Always);
            HideItems?.ForEach(x => x.Visibility = BarItemVisibility.Never);
        }

        protected virtual void HareketEkle()
        {
        }

        protected virtual void HareketSil()
        {
            if (Tablo.DataRowCount == 0) return;    //kayıt yoksa return yap
            if (Messages.SilMesaj("İşlem Satırı") != DialogResult.Yes) return;   //yes e basılmadıysa return yap

            Tablo.GetRow<BaseHareketDto>().Delete = true;
            Tablo.RefreshData();
            ButonEnabledDurumu(true);
        }



        protected void ButonEnabledDurumu(bool durum)
        {
            TableValueChanged = durum;
            OwnerForm.ButonEnabledDurumu();
        }

        protected internal virtual bool HataliGiris()
        {
            return false;
        }
        protected virtual void OpenEntity()
        {
        }
        protected virtual void SutunGizleGoster()
        {
        }
        protected virtual void RowCellAllowEdit()
        {
        }

        protected virtual void IptalEt()
        {
        }

        protected virtual void IptalGeriAl()
        {
        }

        protected virtual void TumunuSec()
        {
        }

        protected virtual void TumSecimleriKaldir()
        {
        }

        protected virtual void TumHareketleriSil()
        {
            if (Tablo.DataRowCount == 0) return;  // Hiç kayıt yoksa çık

            if (Messages.HayirSeciliEvetHayir("Tüm Kayıtlar Silinecektir. Onaylıyor Musunuz?", "Tüm Kayıtları Silme Onayı") != DialogResult.Yes) return;

            var source = Tablo.DataController.ListSource.Cast<BaseHareketDto>().ToList();

            foreach (var entity in source)
            {
                entity.Delete = true;
            }

            Tablo.RefreshData();
            ButonEnabledDurumu(true);
        }

        private void Kolonlar()
        {
            if (Tablo.CustomizationForm == null)
                Tablo.ShowCustomization();
            else
                Tablo.HideCustomization();
        }


        protected internal bool Kaydet()
        {
            insUptNavigator.Navigator.Buttons.DoClick(insUptNavigator.Navigator.Buttons.EndEdit); //end edit butonuna tıklanmış gibi işlem yap (kullanıcı girdiği sayıyı onaylamadan kaydet butonuna basarsa kaydetsin diye)
            var source = Tablo.DataController.ListSource;

            var insert = source.Cast<BaseHareketDto>().Where(x => x.Insert && !x.Delete).Cast<BaseHareketDto>().ToList();
            var update = source.Cast<BaseHareketDto>().Where(x => x.Update && !x.Delete).Cast<BaseHareketDto>().ToList();
            var delete = source.Cast<BaseHareketDto>().Where(x => x.Delete && !x.Insert).Cast<BaseHareketDto>().ToList();//(1:28:00)

            if (insert.Any())//insertde değer varsa
                if (!((IBaseHareketService)Bll).Insert(insert))
                {
                    Messages.HataMesaji($"{Tablo.ViewCaption} Tablosundaki Hareketler Eklenemedi.");
                    return false;
                }

            if (update.Any())//insertde değer varsa
                if (!((IBaseHareketService)Bll).Update(update))
                {
                    Messages.HataMesaji($"{Tablo.ViewCaption} Tablosundaki Hareketler Güncellenemedi.");
                    return false;
                }

            if (delete.Any())//insertde değer varsa
                if (!((IBaseHareketService)Bll).Delete(delete))
                {
                    Messages.HataMesaji($"{Tablo.ViewCaption} Tablosundaki Hareketler Silinemedi.");
                    return false;
                }

            ButonEnabledDurumu(false);
            return true;
        }

        protected virtual void BelgeHareketleri()
        {
        }

        private void Button_ItemClick(object? sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (e.Item == btnHareketEkle)
                HareketEkle();
            else if (e.Item == btnHareketSil)
                HareketSil();
            else if (e.Item == btnKartDuzenle)
                OpenEntity();
            else if (e.Item == btnIptalEt)
                IptalEt();
            else if (e.Item == btnIptalGeriAl)
                IptalGeriAl();
            else if (e.Item == btnBelgeHareketleri)
                BelgeHareketleri();
            else if (e.Item == btnTumunuSec)
                TumunuSec();
            else if (e.Item == btnTumSecimleriKaldir)
                TumSecimleriKaldir();
            else if (e.Item == btnTumHareketleriSil)
                TumHareketleriSil();
            else if (e.Item == btnKolonlar)
                Kolonlar();
            Cursor.Current = DefaultCursor;
        }
        protected virtual void ImageComboBox_SelectedValueChanged(object? sender, EventArgs e)
        {
        }

        protected virtual void CheckEdit_CheckedChanged(object? sender, EventArgs e)
        {
        }

        private void Navigator_ButtonClick(object? sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button == insUptNavigator.Navigator.Buttons.Append)
                HareketEkle();
            else if (e.Button == insUptNavigator.Navigator.Buttons.Remove)
                HareketSil();

            if (e.Button == insUptNavigator.Navigator.Buttons.Append || e.Button == insUptNavigator.Navigator.Buttons.Remove)
                e.Handled = true;
        }

        protected virtual void Tablo_CellValueChanged(object? sender, CellValueChangedEventArgs e)
        {
            if (!_isLoaded) return;

            var entity = Tablo.GetRow<BaseHareketDto>();
            if (!entity.Insert)
                entity.Update = true;

            ButonEnabledDurumu(true);
        }

        protected virtual void Tablo_MouseUp(object? sender, MouseEventArgs e)
        {
            if (popupMenu == null) return;

            if (e.Button != MouseButtons.Right) return;

            btnHareketSil.Enabled = Tablo.RowCount > 0;
            btnKartDuzenle.Enabled = Tablo.RowCount > 0;
            btnIptalEt.Enabled = Tablo.RowCount > 0;
            btnIptalGeriAl.Enabled = Tablo.RowCount > 0;

            e.SagTikMenuGoster(popupMenu);
        }

        private void Tablo_GotFocus(object? sender, EventArgs e)
        {
            OwnerForm.statusBarKisaYol.Visibility = BarItemVisibility.Always;
            OwnerForm.statusBarKisaYolAciklama.Visibility = BarItemVisibility.Always;

            OwnerForm.statusBarAciklama.Caption = ((IStatusBarKisaYol)(sender ?? this)).StatusBarAciklama;
            OwnerForm.statusBarKisaYol.Caption = ((IStatusBarKisaYol)(sender ?? this)).StatusBarKisaYol;
            OwnerForm.statusBarKisaYolAciklama.Caption = ((IStatusBarKisaYol)(sender ?? this)).StatusBarKisaYolAciklama;
        }

        private void Tablo_LostFocus(object? sender, EventArgs e)
        {
            OwnerForm.statusBarKisaYol.Visibility = BarItemVisibility.Never;
            OwnerForm.statusBarKisaYolAciklama.Visibility = BarItemVisibility.Never;
        }

        private void Tablo_KeyDown(object? sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    if (Tablo.IsEditorFocused)
                        insUptNavigator.Navigator.Buttons.DoClick(insUptNavigator.Navigator.Buttons.CancelEdit);
                    else
                        OwnerForm.Close();
                    break;

                case Keys.Tab:
                case Keys.Left:
                case Keys.Right:
                case Keys.Up:
                case Keys.Down:
                    insUptNavigator.Navigator.Buttons.DoClick(insUptNavigator.Navigator.Buttons.EndEdit);
                    break;

                case Keys.Insert when e.Shift:
                    HareketEkle();
                    break;

                case Keys.Delete when e.Modifiers == Keys.Shift: //CTRL+SHİFT+DELETE İLE ÇAKIŞMAYI ÖNLEMEK İÇİN  e.Modifiers == Keys.Shift AYNU ANDA 2 TUŞA BASILMASINI ARAR 3. TUŞA BASILINCA DEVREDEN ÇIKAR
                    HareketSil();
                    break;

                case Keys.F3:
                    OpenEntity();
                    break;

                case Keys.T when e.Control:
                    IptalEt();
                    break;

                case Keys.R when e.Control:
                    IptalGeriAl();
                    break;

                case Keys.F6:
                    BelgeHareketleri();
                    break;
            }
        }

        protected virtual void Tablo_FocusedColumnChanged(object? sender, FocusedColumnChangedEventArgs e)
        {
            if (OwnerForm == null) return;

            OwnerForm.statusBarKisaYol.Visibility = BarItemVisibility.Never;
            OwnerForm.statusBarKisaYolAciklama.Visibility = BarItemVisibility.Never;

            if (!e.FocusedColumn.OptionsColumn.AllowEdit)//yazılabilir mi değil mi
                Tablo_GotFocus(sender, EventArgs.Empty);
            else if (((IStatusBarKisaYol)e.FocusedColumn).StatusBarKisaYol != null)
            {
                OwnerForm.statusBarKisaYol.Visibility = BarItemVisibility.Always;
                OwnerForm.statusBarKisaYolAciklama.Visibility = BarItemVisibility.Always;

                OwnerForm.statusBarAciklama.Caption = ((IStatusBarKisaYol)e.FocusedColumn).StatusBarAciklama;
                OwnerForm.statusBarKisaYol.Caption = ((IStatusBarKisaYol)e.FocusedColumn).StatusBarKisaYol;
                OwnerForm.statusBarKisaYolAciklama.Caption = ((IStatusBarKisaYol)e.FocusedColumn).StatusBarKisaYolAciklama;
            }
            else if (((IStatusBarKisaYol)e.FocusedColumn).StatusBarAciklama != null)
                OwnerForm.statusBarAciklama.Caption = ((IStatusBarKisaYol)e.FocusedColumn).StatusBarAciklama;
        }

        private void Tablo_SablonChanged(object? sender, EventArgs e)
        {
            _tabloSablonKayitEdilecek = true;
            SablonKaydet();
        }

        private void Tablo_DoubleClick(object? sender, EventArgs e)
        {
            OpenEntity();
        }

        protected virtual void Tablo_FocusedRowObjectChanged(object? sender, FocusedRowObjectChangedEventArgs e)
        {
            SutunGizleGoster();
            RowCellAllowEdit();
        }

        protected virtual void Tablo_RowCountChanged(object? sender, EventArgs e)
        {
        }
    }
}

