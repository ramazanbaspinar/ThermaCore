namespace WinBeyazEsya.Application.Interfaces.Mailing;

public interface IMailService
{
    void SendPasswordResetMail(string email, string password);
    void SendErrorLogMail(string exceptionMessage, string stackTrace);
}

