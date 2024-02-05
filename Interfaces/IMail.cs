namespace Lobby.Interfaces
{
    public interface IMail
    {
        public Task SendEmail(string to, string subject, string body);
    }
}
