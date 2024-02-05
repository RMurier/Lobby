using Lobby.Interfaces;
using Lobby.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Lobby.Controllers
{
    [Route("api/[Controller]")]
    public class JWTController : Controller
    {
        private readonly ITokenService _tokenService;
        public JWTController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }
        [HttpPost("GetToken")]
        [AllowAnonymous]
        public async Task<ActionResult> GetToken([FromBody] GenerateTokenModel model)
        {
            return Ok(await _tokenService.GenerateToken(model));
        }
    }
}
