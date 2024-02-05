using Lobby.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lobby.Interfaces
{
    public interface ITokenService
    {
        public Task<string> GenerateToken([FromBody] GenerateTokenModel model);
    }
}
