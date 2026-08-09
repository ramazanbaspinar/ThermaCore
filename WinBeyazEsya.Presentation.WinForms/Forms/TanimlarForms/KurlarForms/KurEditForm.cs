using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Domain.Entities.Management;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TanimlarForms.KurlarForms
{
    public partial class KurEditForm : BaseEditForm
    {
        private readonly IRepository<ExchangeRate> _exchangeRateRepository = default!;
        private readonly IUnitOfWork _uow = default!;

        public KurEditForm()
        {
            InitializeComponent();
        }

        public KurEditForm(IRepository<ExchangeRate> exchangeRateRepository, IUnitOfWork uow)
        {
            InitializeComponent();
            _exchangeRateRepository = exchangeRateRepository;
            _uow = uow;

            BaseKartTuru = ModuleType.KurTanimlari;
            DataLayoutControls = new object[] { myDataLayoutControl1, myDataLayoutControl2, myDataLayoutControl3, myDataLayoutControl4 };
            RequiresCodeTemplate = false;

            HideItems = new DevExpress.XtraBars.BarItem[] { btnYeni, btnSil };

            // Kurlar dýþarýdan beslendiði için read-only olan alanlar
            txtTarih.Properties.ReadOnly = true;
            txtDovizKodu.Properties.ReadOnly = true;
            txtTcmbAlis.Properties.ReadOnly = true;
            txtTcmbSatis.Properties.ReadOnly = true;
        }

        public override void Yukle()
        {
            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                var kur = _exchangeRateRepository.GetById(Id);
                if (kur != null)
                {
                    txtTarih.DateTime = kur.RateDate;
                    txtDovizKodu.Text = kur.CurrencyCode;
                    txtTcmbAlis.Value = kur.TcmbBuyingRate;
                    txtTcmbSatis.Value = kur.TcmbSellingRate;
                    txtGecerliAlis.Value = kur.EffectiveBuyingRate;
                    txtGecerliSatis.Value = kur.EffectiveSellingRate;
                }
            }
            else
            {
                txtTarih.DateTime = DateTime.Today;
                txtDovizKodu.Text = "";
                txtTcmbAlis.Value = 0;
                txtTcmbSatis.Value = 0;
                txtGecerliAlis.Value = 0;
                txtGecerliSatis.Value = 0;
            }
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new WinBeyazEsya.Application.DTOs.Management.ExchangeRateDto
            {
                Id = this.Id,
                RateDate = txtTarih.DateTime,
                CurrencyCode = txtDovizKodu.Text,
                TcmbBuyingRate = txtTcmbAlis.Value,
                TcmbSellingRate = txtTcmbSatis.Value,
                EffectiveBuyingRate = txtGecerliAlis.Value,
                EffectiveSellingRate = txtGecerliSatis.Value
            };
            ButonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            XtraMessageBox.Show("Kur tablosuna manuel kayýt eklenemez.", "Yetki Hatasý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        protected override bool EntityUpdate()
        {
            var formEntity = (WinBeyazEsya.Application.DTOs.Management.ExchangeRateDto)CurrentEntity;

            var entity = _exchangeRateRepository.GetById(Id);
            if (entity != null)
            {
                // Kullanýcý yalnýzca efektif kurlarý güncelleyebilir
                entity.EffectiveBuyingRate = formEntity.EffectiveBuyingRate;
                entity.EffectiveSellingRate = formEntity.EffectiveSellingRate;

                _exchangeRateRepository.Update(entity);
                _uow.SaveChanges();
            }

            return true;
        }

        protected override void EntityDelete()
        {
            XtraMessageBox.Show("Kur tanýmlarýnda silme iþlemi yapýlamaz.", "Yetki Hatasý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}

