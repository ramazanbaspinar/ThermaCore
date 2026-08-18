using WinBeyazEsya.Application.DTOs.Management;
using WinBeyazEsya.Application.Services.Management;
using WinBeyazEsya.Domain.Enums;
using WinBeyazEsya.Presentation.WinForms.Forms.BaseForms;
using WinBeyazEsya.Presentation.WinForms.Helpers;

namespace WinBeyazEsya.Presentation.WinForms.Forms.TerminalForms
{
    public partial class TerminalEditForm : BaseEditForm
    {
        private readonly ITerminalService _terminalService = default!;

        public TerminalEditForm()
        {
            InitializeComponent();
        }

        public TerminalEditForm(ITerminalService terminalService)
        {
            InitializeComponent();
            _terminalService = terminalService;
            BaseKartTuru = WinBeyazEsya.Domain.Enums.ModuleType.TerminalYonetimi;
            DataLayoutControl = myDataLayoutControlPro1;
            Bll = _terminalService;
            HideItems = new DevExpress.XtraBars.BarItem[] { btnYeni, btnSil };
            RequiresCodeTemplate = false; // Code template mantýðýný devre dýþý býrakýyoruz, çünkü Cihaz Adý'ný manuel alýyoruz
        }

        public override void Yukle()
        {
            txtHardwareId.Properties.PasswordChar = '*';

            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                var dto = _terminalService.GetById(Id);
                if (dto != null)
                {
                    txtCihazAdi.Text = dto.Code;
                    txtHardwareId.Text = dto.HardwareId;
                    txtAciklama.Text = dto.Description;
                    tglDurum.IsOn = dto.IsActive;
                }
            }
            else
            {
                txtCihazAdi.Text = "";
                txtHardwareId.Text = "";
                txtAciklama.Text = "";
                tglDurum.IsOn = true;
            }
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new TerminalDto
            {
                Id = this.Id,
                Code = txtCihazAdi.Text,
                HardwareId = txtHardwareId.Text,
                Description = txtAciklama.Text,
                IsActive = tglDurum.IsOn
            };
            ButonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            var dto = (TerminalDto)CurrentEntity;
            dto.Id = BaseIslemTuru.IdOlustur(OldEntity);
            Id = _terminalService.Insert(dto);
            return true;
        }

        protected override bool EntityUpdate()
        {
            var dto = (TerminalDto)CurrentEntity;
            _terminalService.Update(dto);
            return true;
        }

        protected override void EntityDelete()
        {
            if (Id <= 0) return;

            if (Messages.SilMesaj("Terminal") == DialogResult.Yes)
            {
                try
                {
                    _terminalService.Delete(Id);
                    RefreshYapilacak = true;
                    Close();
                }
                catch (Exception ex)
                {
                    Messages.HataMesaji(ex.Message);
                }
            }
        }
    }
}

