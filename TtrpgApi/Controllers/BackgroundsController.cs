using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TtrpgApi.Models;
using TtrpgApi.Tools;
using Model_BLL.Models;
using Model_BLL.Services.Interfaces;
using System.Security.Claims;

namespace TtrpgApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BackgroundsController : ControllerBase
    {

        private IBackgroundsService _backgroundsService;
        public BackgroundsController(IBackgroundsService backgroundsService)
        {
            _backgroundsService = backgroundsService;
        }

        [Authorize("Quester")]
        [HttpPost("Id")]
        public IActionResult addBackground([FromBody] Background b)
        {
            try
            {
                _backgroundsService.addBackground(b);
                return Ok("Ajouté aux backgrounds");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize("Quester")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                int questerId = int.Parse(User.FindFirstValue(ClaimTypes.Name));
                return Ok(_favoritesService.GetAllGames(questerId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize("Quester")]
        [HttpDelete("{FavoriteId}")]
        public IActionResult deleteGame(int FavoriteId)
        {
            try
            {
                _favoritesService.DeleteGame(FavoriteId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
