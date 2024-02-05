using Lobby.Interfaces;
using System.Net;
using System.Net.Mail;

public class MailService : IMail
{
    /// <summary>
    /// Send a mail.
    /// </summary>
    /// <param name="to">Email to send</param>
    /// <param name="subject">Subject of the mal</param>
    /// <param name="body">Body (HTML) of the mail</param>
    /// <returns></returns>
    public async Task SendEmail(string to, string subject, string body)
    {
        var fromAddress = new MailAddress("noreply@romainmurier.com", "Romain MURIER");
        var toAddress = new MailAddress(to);
        const string fromPassword = "dofus1810";

        var smtp = new SmtpClient
        {
            Host = "plesk1.dyjix.eu",
            Port = 25,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
        };

        using (var message = new MailMessage(fromAddress, toAddress)
        {
            IsBodyHtml = true,
            Subject = subject,
            Body = body
        })
        {
            smtp.Send(message);
        }
    }
}
