using System;
using System.Linq;
using System.Windows.Forms;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Application.Services.Management;
using ThermaCore.Domain.Enums;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Helpers;

namespace ThermaCore.Presentation.WinForms.Forms.TerminalForms
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
            BaseKartTuru = ThermaCore.Domain.Enums.ModuleType.TerminalYonetimi;
            DataLayoutControl = myDataLayoutControlPro1;
            Bll = _terminalService;
            HideItems = new DevExpress.XtraBars.BarItem[] { btnYeni, btnSil };
            RequiresCodeTemplate = false; // Code template mantığını devre dışı bırakıyoruz, çünkü Cihaz Adı'nı manuel alıyoruz
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