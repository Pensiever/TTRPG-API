using Microsoft.AspNetCore.Mvc;
using TtrpgApi.Models;
using TtrpgApi.Services.Interfaces;

namespace TtrpgApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ITokenService _tokenService;

        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("auth")]
        public IActionResult Auth([FromBody] LoginInfo model)
        {
            ConnectedQuester quester;
            try
            {
                quester = _tokenService.Authenticate(model.Username, model.Password);
            }
            catch (Exception e)
            {
                return BadRequest("Pseudo ou password incorrect");
            }


            if (quester == null)
            {
                return BadRequest(new { message = "Aucun compte ne correspond à ce pseudo !" });
            }

            return Ok(quester);
        }
    }
}
