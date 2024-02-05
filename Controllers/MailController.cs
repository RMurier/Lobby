using Lobby.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class MailController : Controller
{
    private readonly IMail _mail; 
    public MailController(IMail mail)
    {
        _mail = mail;
    }

    [HttpPost("SendMail")]
    [Authorize(Roles = "ADMIN,SENDMAIL")]
    public async Task<NoContentResult> SendMail(string to, string subject, string body)
    {
        await _mail.SendEmail(to, subject, body);
        return NoContent();
    }
}
