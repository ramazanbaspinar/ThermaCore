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
            BaseKartTuru = WinBeyazEsya.Domain.Enums.ModuleType.MaliyetParametreleri;
            _maliyetParametreService = maliyetParametreService;

            BaseIslemTuru = ActionType.EntityUpdate;
            BaseKartTuru = ModuleType.MaliyetParametreleri;
            KayitSonrasiFormuKapat = false; // Singleton form olduğu için kaydetten sonra kapanmamalı
            DataLayoutControls = new object[] { myDataLayoutControl1 };
        }

        public MaliyetParametreEditForm()
        {
            InitializeComponent();
            BaseKartTuru = WinBeyazEsya.Domain.Enums.ModuleType.MaliyetParametreleri;
        }

        public override void Yukle()
        {
            if (btnYeni != null) btnYeni.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (btnSil != null) btnSil.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            try
            {
                _currentDto = _maliyetParametreService?.GetMaliyetParametreAsync().GetAwaiter().GetResult();
                
                if (_currentDto == null || _currentDto.Id == 0)
                {
                    _currentDto = new MaliyetParametreDto { Id = 0 };
                    BaseIslemTuru = ActionType.EntityInsert;
                }
                else
                {
                    BaseIslemTuru = ActionType.EntityUpdate;
                }
            }
            catch (Exception ex)
            {
                Messages.HataBasligi(ex.Message, "Hata");
                _currentDto = new MaliyetParametreDto { Id = 0 };
                BaseIslemTuru = ActionType.EntityInsert;
            }

            CurrentEntity = _currentDto;
            OldEntity = new MaliyetParametreDto 
            { 
                Id = _currentDto.Id,
                WastageRate = _currentDto.WastageRate,
                MaturityDifferenceRate = _currentDto.MaturityDifferenceRate,
                AverageProductionValue = _currentDto.AverageProductionValue
            };

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
            // KURAL 1: Tetikleyici Kopukluğu (Manuel tetikleme)
            Control_EditValueChanged(sender, e);
        }

        protected override void NesneyiKontrollereBagla()
        {
            if (_currentDto == null) return;
            propertyGridControl1.SelectedObject = _currentDto;
        }

        protected override void GuncelNesneOlustur()
        {
            // KURAL 2: Veri Kopukluğu (Manuel nesne aktarımı)
            var gridNesnesi = (MaliyetParametreDto)propertyGridControl1.SelectedObject;
            if (gridNesnesi != null)
            {
                CurrentEntity = new MaliyetParametreDto 
                {
                    // KURAL 3: Id değerinin kaybolmamasını sağlıyoruz
                    Id = _currentDto?.Id ?? 0,
                    WastageRate = gridNesnesi.WastageRate,
                    MaturityDifferenceRate = gridNesnesi.MaturityDifferenceRate,
                    AverageProductionValue = gridNesnesi.AverageProductionValue
                };
            }
        }

        protected override bool FarklilikVarMi(System.Windows.Forms.Control.ControlCollection controls)
        {
            var selected = propertyGridControl1.SelectedObject as MaliyetParametreDto;
            var old = OldEntity as MaliyetParametreDto;

            if (selected == null || old == null) return false;

            return selected.WastageRate != old.WastageRate ||
                   selected.MaturityDifferenceRate != old.MaturityDifferenceRate ||
                   selected.AverageProductionValue != old.AverageProductionValue;
        }

        protected override void Button_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item.Name == "btnKaydet")
            {
                // Kullanıcının son yazdığı değerin hücreden çıkmadan DTO'ya işlenmesi için kritik
                propertyGridControl1.PostEditor();
                propertyGridControl1.CloseEditor();
                // Kalan işlemleri (Kaydetme, OldEntity güncelleme, Buton durumlarını resetleme vs.)
                // BaseEditForm'un kendi standart işleyişine bırakıyoruz.
            }
            else if (e.Item.Name == "btnGerial")
            {
                propertyGridControl1.PostEditor();
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
