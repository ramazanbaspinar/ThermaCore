using System.Windows.Forms;
using WinBeyazEsya.Application.DTOs.Management;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Domain.Entities.Management;
using WinBeyazEsya.Domain.Extensions;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.KodYonetimForms
{
    public partial class KodLogEditForm : BaseEditForm
    {
        private readonly ICodeLogRepository _codeLogRepository = default!;
        private readonly IMasterUnitOfWork _uow = default!;

        public KodLogEditForm()
        {
            InitializeComponent();
        }

        public KodLogEditForm(ICodeLogRepository codeLogRepository, IMasterUnitOfWork uow)
        {
            InitializeComponent();
            _codeLogRepository = codeLogRepository;
            _uow = uow;

            DataLayoutControl = myDataLayoutControl1;
            HideItems = new DevExpress.XtraBars.BarItem[] { btnYeni, btnSil };
            txtSonKodDegeri.EditValueChanged += (sender, args) => GuncelNesneOlustur();
        }

        public override void Yukle()
        {
            var codeLog = _codeLogRepository.GetById(Id);

            if (codeLog != null)
            {
                var dto = new CodeLogDto
                {
                    Id = codeLog.Id,
                    Module = codeLog.Module,
                    LastCodeValue = codeLog.LastCodeValue,
                    CompanyCode = codeLog.CompanyCode,
                    DateKey = codeLog.DateKey,
                    BranchId = codeLog.BranchId
                };
                OldEntity = dto;

                Text = $"Kod Log Düzenle (Modül: {WinBeyazEsya.Domain.Extensions.EnumExtensions.ToName(codeLog.Module)})";
                txtSonKodDegeri.Value = codeLog.LastCodeValue;
            }
        }

        protected override void GuncelNesneOlustur()
        {
            var dto = new CodeLogDto();
            if (OldEntity != null)
            {
                var old = (CodeLogDto)OldEntity;
                dto.Id = old.Id;
                dto.Module = old.Module;
                dto.CompanyCode = old.CompanyCode;
                dto.DateKey = old.DateKey;
                dto.BranchId = old.BranchId;
            }
            dto.LastCodeValue = (int)txtSonKodDegeri.Value;
            CurrentEntity = dto;
            ButonEnabledDurumu();
        }

        public override void IdAtaVeAc(long id)
        {
            this.Id = id;
            this.BaseIslemTuru = WinBeyazEsya.Domain.Enums.ActionType.EntityUpdate;
            this.ShowDialog();
        }

        protected override bool EntityInsert()
        {
            return false;
        }

        protected override bool EntityUpdate()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var dto = (CodeLogDto)CurrentEntity;
                var codeLog = _codeLogRepository.GetById(dto.Id);
                if (codeLog != null)
                {
                    codeLog.LastCodeValue = dto.LastCodeValue;
                    // Güvenlik: Sadece sayaç güncelleniyor
                    _codeLogRepository.Update(codeLog);
                    _uow.SaveChanges();

                    Messages.BilgiBasligi("Kod sayacı başarıyla güncellendi.", "Bilgi");
                    return true;
                }
                return false;
            }
            catch (System.Exception ex)
            {
                Messages.HataBasligi($"Güncelleme sırasında hata oluştu:\n{ex.Message}", "Hata");
                return false;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        protected override void EntityDelete()
        {
            // İşlem yapılmayacak
        }
    }
}
