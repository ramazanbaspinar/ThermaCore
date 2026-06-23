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
            this.BaseKartTuru = ModuleType.TerminalYonetimi;
        }

        public override void Yukle()
        {
            if (BaseIslemTuru == ActionType.EntityUpdate)
            {
                var dto = _terminalService.GetById(Id);
                if (dto != null)
                {
                    txtCihazAdi.Text = dto.DeviceName;
                    txtEthernetMacAdresi.Text = dto.EthernetMacAddress;
                    txtWifiMacAdresi.Text = dto.WifiMacAddress;
                    txtVpnMacAdresi.Text = dto.VpnMacAddress;
                    txtIpAdresi.Text = dto.IpAddress;
                    txtAciklama.Text = dto.Description;
                    
                    var kodCtrl = this.Controls.Find("txtKod", true).FirstOrDefault();
                    if (kodCtrl != null) kodCtrl.Text = dto.Code;

                    var durumCtrl = this.Controls.Find("tglDurum", true).FirstOrDefault();
                    if (durumCtrl is DevExpress.XtraEditors.ToggleSwitch tgl) tgl.IsOn = dto.IsActive;
                }
            }
            else
            {
                txtCihazAdi.Text = "";
                txtEthernetMacAdresi.Text = "";
                txtWifiMacAdresi.Text = "";
                txtVpnMacAdresi.Text = "";
                txtIpAdresi.Text = "";
                txtAciklama.Text = "";
                
                var durumCtrl = this.Controls.Find("tglDurum", true).FirstOrDefault();
                if (durumCtrl is DevExpress.XtraEditors.ToggleSwitch tgl) tgl.IsOn = true;
            }
        }

        protected override void GuncelNesneOlustur()
        {
            var code = "";
            var kodCtrl = this.Controls.Find("txtKod", true).FirstOrDefault();
            if (kodCtrl != null) code = kodCtrl.Text;

            var isActive = true;
            var durumCtrl = this.Controls.Find("tglDurum", true).FirstOrDefault();
            if (durumCtrl is DevExpress.XtraEditors.ToggleSwitch tgl) isActive = tgl.IsOn;

            CurrentEntity = new TerminalDto
            {
                Id = this.Id,
                Code = code,
                DeviceName = txtCihazAdi.Text,
                EthernetMacAddress = txtEthernetMacAdresi.Text,
                WifiMacAddress = txtWifiMacAdresi.Text,
                VpnMacAddress = txtVpnMacAdresi.Text,
                IpAddress = txtIpAdresi.Text,
                Description = txtAciklama.Text,
                IsActive = isActive
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