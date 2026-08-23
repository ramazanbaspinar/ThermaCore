using System.Net;
using System.Net.Mail;
using WinBeyazEsya.Application.Interfaces.Mailing;
using WinBeyazEsya.Application.Interfaces.Repositories;
using WinBeyazEsya.Application.Interfaces.Security;
using WinBeyazEsya.Domain.Entities.Management;

namespace WinBeyazEsya.Infrastructure.Mailing;

public class MailService : IMailService
{
    private readonly IMasterRepository<EmailParameter> _emailParameterRepository;
    private readonly ICryptoService _cryptoService;

    public MailService(IMasterRepository<EmailParameter> emailParameterRepository, ICryptoService cryptoService)
    {
        _emailParameterRepository = emailParameterRepository;
        _cryptoService = cryptoService;
    }

    public void SendPasswordResetMail(string email, string password)
    {
        var mailParam = _emailParameterRepository.GetAll().FirstOrDefault();
        if (mailParam == null)
            throw new Exception("Sistemde kayıtlı e-posta ayarı bulunamadı. Lütfen parametreleri kontrol ediniz.");

        string decryptedPassword = _cryptoService.Decrypt(mailParam.Password);

        using (SmtpClient client = new SmtpClient(mailParam.SmtpServer, mailParam.Port))
        {
            client.Credentials = new NetworkCredential(mailParam.SenderEmail, decryptedPassword);
            client.EnableSsl = mailParam.EnableSsl;

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(mailParam.SenderEmail, mailParam.SenderName);
            mailMessage.To.Add(email);
            mailMessage.Subject = "WinBeyazEsya ERP - Parola Sıfırlama Kodu";
            mailMessage.Body = $"<h2 style='color:#ee1d23;'>WinBeyazEsya ERP Şifre Sıfırlama Talebi</h2>" +
                               $"<p>Hesabınız için şifre sıfırlama talebinde bulundunuz.</p>" +
                               $"<p>Doğrulama Kodunuz: <strong><span style='font-size:20px;'>{password}</span></strong></p>" +
                               $"<p><em>Bu kod 3 dakika boyunca geçerlidir.</em></p>";
            mailMessage.IsBodyHtml = true;

            client.Send(mailMessage);
        }
    }

    public void SendErrorLogMail(string exceptionMessage, string stackTrace)
    {
        // TODO: Geliştirici veya destek ekibine e-posta gönderme altyapısı kurulacak
        throw new NotImplementedException();
    }

    public async global::System.Threading.Tasks.Task SendMailAsync(global::System.Collections.Generic.List<string> to, string subject, string body)
    {
        if (to == null || !to.Any()) return;

        var mailParam = _emailParameterRepository.GetAll().FirstOrDefault();
        if (mailParam == null)
            throw new Exception("Sistemde kayıtlı e-posta ayarı bulunamadı. Lütfen parametreleri kontrol ediniz.");

        string decryptedPassword = _cryptoService.Decrypt(mailParam.Password);

        using (SmtpClient client = new SmtpClient(mailParam.SmtpServer, mailParam.Port))
        {
            client.Credentials = new NetworkCredential(mailParam.SenderEmail, decryptedPassword);
            client.EnableSsl = mailParam.EnableSsl;

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(mailParam.SenderEmail, mailParam.SenderName);

            foreach (var email in to)
            {
                if (!string.IsNullOrWhiteSpace(email))
                    mailMessage.To.Add(email);
            }

            if (mailMessage.To.Count == 0) return;

            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;

            await client.SendMailAsync(mailMessage);
        }
    }
}

