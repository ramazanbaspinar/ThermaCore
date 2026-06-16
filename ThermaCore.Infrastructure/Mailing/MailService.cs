using System;
using System.Net.Mail;

namespace ThermaCore.Infrastructure.Mailing;

public class MailService : IMailService
{
    public void SendPasswordResetMail(string email, string password)
    {
        // TODO: SmtpClient ve e-posta şablonu ayarlamaları yapılacak
        throw new NotImplementedException();
    }

    public void SendErrorLogMail(string exceptionMessage, string stackTrace)
    {
        // TODO: Geliştirici veya destek ekibine e-posta gönderme altyapısı kurulacak
        throw new NotImplementedException();
    }
}
