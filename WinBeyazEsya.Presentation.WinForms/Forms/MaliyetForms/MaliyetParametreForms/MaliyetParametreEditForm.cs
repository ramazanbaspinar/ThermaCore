using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using WinBeyazEsya.Application.DTOs.Management;
using WinBeyazEsya.Application.Interfaces.Management;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.MaliyetForms.MaliyetParametreForms
{
    public partial class MaliyetParametreEditForm : BaseEditForm
    {
        private readonly IMaliyetParametreService _maliyetParametreService;
        private MaliyetParametreDto _currentDto;

        public MaliyetParametreEditForm(IMaliyetParametreService maliyetParametreService)
        {
            InitializeComponent();
            _maliyetParametreService = maliyetParametreService;

            BaseIslemTuru = ActionType.EntityUpdate;
            BaseKartTuru = ModuleType.MaliyetParametreleri;
            KayitSonrasiFormuKapat = false; // Singleton form olduğu için kaydetten sonra kapanmamalı
            DataLayoutControls = new object[] { myDataLayoutControl1 };
        }

        public MaliyetParametreEditForm()
        {
            InitializeComponent();
        }

        public override void Yukle()
        {
            if (btnYeni != null) btnYeni.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (btnSil != null) btnSil.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            try
            {
                _currentDto = _maliyetParametreService?.GetMaliyetParametreAsync().GetAwaiter().GetResult() ?? new MaliyetParametreDto { Id = 0 };
            }
            catch (Exception ex)
            {
                Messages.HataBasligi(ex.Message, "Hata");
                _currentDto = new MaliyetParametreDto { Id = 0 };
            }

            CurrentEntity = _currentDto;
            OldEntity = new MaliyetParametreDto { Id = _currentDto.Id };

            NesneyiKontrollereBagla();
        }

        protected override void EventsLoad()
        {
            base.EventsLoad();
            if (propertyGridControl1 != null)
            {
                propertyGridControl1.CellValueChanged += PropertyGridControl1_CellValueChanged;
            }
        }

        private void PropertyGridControl1_CellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
        {
            CurrentEntityGuncelle();
            ButonEnabledDurumu();

            // PropertyGridControl BaseEdit sınıfından türemediği için BaseEditForm'daki 
            // FarklilikVarMi() metodunda yakalanamıyor. Bu nedenle manuel olarak aktif ediyoruz:
            if (btnKaydet != null) btnKaydet.Enabled = true;
            if (btnGerial != null) btnGerial.Enabled = true;
        }

        protected override void NesneyiKontrollereBagla()
        {
            if (_currentDto == null) return;
            propertyGridControl1.SelectedObject = _currentDto;
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = propertyGridControl1.SelectedObject as MaliyetParametreDto;
        }

        protected override void Button_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item.Name == "btnKaydet")
            {
                // Kullanıcının son yazdığı değerin hücreden çıkmadan DTO'ya işlenmesi için kritik
                propertyGridControl1.CloseEditor();
                // Kalan işlemleri (Kaydetme, OldEntity güncelleme, Buton durumlarını resetleme vs.)
                // BaseEditForm'un kendi standart işleyişine bırakıyoruz.
            }
            else if (e.Item.Name == "btnGerial")
            {
                propertyGridControl1.CloseEditor();
                // Geri al işlemini de BaseEditForm'a bırakıyoruz.
            }
            
            base.Button_ItemClick(sender, e);
        }

        protected override bool EntityInsert()
        {
            return SingletonKaydet();
        }

        protected override bool EntityUpdate()
        {
            return SingletonKaydet();
        }

        private bool SingletonKaydet()
        {
            try
            {
                if (_maliyetParametreService == null) return false;

                GuncelNesneOlustur();
                _currentDto = (MaliyetParametreDto)CurrentEntity;

                _maliyetParametreService.SaveParametreAsync(_currentDto).GetAwaiter().GetResult();
                return true;
            }
            catch (Exception ex)
            {
                Messages.HataBasligi(ex.Message, "Kayıt Hatası");
                return false;
            }
        }
    }
}
