namespace WinBeyazEsya.Application.Interfaces.Mailing;

public interface IMailService
{
    void SendPasswordResetMail(string email, string password);
    void SendErrorLogMail(string exceptionMessage, string stackTrace);
    global::System.Threading.Tasks.Task SendMailAsync(global::System.Collections.Generic.List<string> to, string subject, string body);
}

