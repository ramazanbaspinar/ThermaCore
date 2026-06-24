using System;
using System.Linq;
using ThermaCore.Application.DTOs.Management;
using ThermaCore.Application.Interfaces.Repositories;
using ThermaCore.Domain.Entities.Management;
using ThermaCore.Domain.Enums;
using ThermaCore.Presentation.WinForms.Forms.BaseForms;
using ThermaCore.Presentation.WinForms.Helpers;

namespace ThermaCore.Presentation.WinForms.Forms.ParametrelerForms
{
    public partial class EmailParameterEditForm : BaseEditForm
    {
        private readonly IMasterRepository<EmailParameter> _emailParameterRepository;
        private readonly IMasterUnitOfWork _uow;
        private readonly ThermaCore.Application.Interfaces.Security.ICryptoService _cryptoService;

        public EmailParameterEditForm(IMasterRepository<EmailParameter> emailParameterRepository, IMasterUnitOfWork uow, ThermaCore.Application.Interfaces.Security.ICryptoService cryptoService)
        {
            InitializeComponent();
            _emailParameterRepository = emailParameterRepository;
            _uow = uow;
            _cryptoService = cryptoService;
            
            BaseKartTuru = ModuleType.EmailParameter;
            DataLayoutControl = myDataLayoutControl1;
            RequiresCodeTemplate = false; 

            HideItems = new DevExpress.XtraBars.BarItem[] { btnYeni, btnSil };

            btnTestMailGonder.Click += BtnTestMailGonder_Click;
            txtAliciEmail.EditValueChanged -= Control_EditValueChanged;
            txtAliciEmail.EditValueChanged += (s, e) => { txtAliciEmail.IsModified = false; };
        }

        private void BtnTestMailGonder_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAliciEmail.Text))
            {
                Messages.UyariMesaji("Lütfen test maili göndermek için bir alıcı e-posta adresi giriniz.");
                return;
            }

            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            try
            {
                using (var client = new System.Net.Mail.SmtpClient(txtSmtpServer.Text, Convert.ToInt32(txtPort.EditValue)))
                {
                    client.EnableSsl = chkEnableSsl.Checked;
                    client.Credentials = new System.Net.NetworkCredential(txtSenderEmail.Text, txtPassword.Text);

                    var mailMessage = new System.Net.Mail.MailMessage
                    {
                        From = new System.Net.Mail.MailAddress(txtSenderEmail.Text, txtSenderName.Text),
                        Subject = "ThermaCore Test E-Mail",
                        Body = "Bu e-posta ThermaCore sisteminden e-posta parametrelerinin test edilmesi amacıyla gönderilmiştir.",
                        IsBodyHtml = false
                    };
                    mailMessage.To.Add(txtAliciEmail.Text);

                    client.Send(mailMessage);
                }
                Messages.BilgiMesaji("Test e-postası başarıyla gönderildi.");
            }
            catch (Exception ex)
            {
                Messages.HataMesaji("Test e-postası gönderilirken bir hata oluştu:\n" + ex.Message);
            }
            finally
            {
                Cursor.Current = System.Windows.Forms.Cursors.Default;
            }
        }

        public override void Yukle()
        {
            var entity = _emailParameterRepository.GetAll().FirstOrDefault();
            if (entity != null)
            {
                CurrentEntity = new EmailParameterDto
                {
                    Id = entity.Id,
                    SmtpServer = entity.SmtpServer,
                    Port = entity.Port,
                    SenderName = entity.SenderName,
                    SenderEmail = entity.SenderEmail,
                    Password = entity.Password,
                    EnableSsl = entity.EnableSsl
                };

                txtSmtpServer.Text = entity.SmtpServer;
                txtPort.EditValue = entity.Port;
                txtSenderName.Text = entity.SenderName;
                txtSenderEmail.Text = entity.SenderEmail;
                txtPassword.Text = string.IsNullOrEmpty(entity.Password) ? "" : _cryptoService.Decrypt(entity.Password);
                chkEnableSsl.Checked = entity.EnableSsl;
                
                this.Id = entity.Id;
                BaseIslemTuru = ActionType.EntityUpdate;
            }
            else
            {
                CurrentEntity = new EmailParameterDto();
                BaseIslemTuru = ActionType.EntityInsert;
            }
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new EmailParameterDto
            {
                Id = this.Id,
                SmtpServer = txtSmtpServer.Text,
                Port = Convert.ToInt32(txtPort.EditValue),
                SenderName = txtSenderName.Text,
                SenderEmail = txtSenderEmail.Text,
                Password = txtPassword.Text,
                EnableSsl = chkEnableSsl.Checked
            };
        }

        protected override bool EntityInsert()
        {
            try
            {
                var dto = (EmailParameterDto)CurrentEntity;
                var entity = new EmailParameter
                {
                    Id = ThermaCore.Domain.Helpers.IdGenerator.GenerateId(),
                    SmtpServer = dto.SmtpServer,
                    Port = dto.Port,
                    SenderName = dto.SenderName,
                    SenderEmail = dto.SenderEmail,
                    Password = string.IsNullOrEmpty(dto.Password) ? "" : _cryptoService.Encrypt(dto.Password),
                    EnableSsl = dto.EnableSsl
                };

                _emailParameterRepository.Add(entity);
                _uow.SaveChanges();

                this.Id = entity.Id;
                Messages.KayitBasariliMesaji();
                BaseIslemTuru = ActionType.EntityUpdate;
                return true;
            }
            catch (Exception ex)
            {
                Messages.HataMesaji(ex.Message);
                return false;
            }
        }

        protected override bool EntityUpdate()
        {
            try
            {
                var dto = (EmailParameterDto)CurrentEntity;
                var entity = _emailParameterRepository.GetById(this.Id);
                if (entity != null)
                {
                    entity.SmtpServer = dto.SmtpServer;
                    entity.Port = dto.Port;
                    entity.SenderName = dto.SenderName;
                    entity.SenderEmail = dto.SenderEmail;
                    entity.Password = string.IsNullOrEmpty(dto.Password) ? "" : _cryptoService.Encrypt(dto.Password);
                    entity.EnableSsl = dto.EnableSsl;

                    _emailParameterRepository.Update(entity);
                    _uow.SaveChanges();

                    Messages.KayitBasariliMesaji();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Messages.HataMesaji(ex.Message);
                return false;
            }
        }
    }
}