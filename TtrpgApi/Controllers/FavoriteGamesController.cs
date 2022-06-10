using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TtrpgApi.Models;
using TtrpgApi.Tools;
using Model_BLL.Models;
using Model_BLL.Services.Interfaces;

namespace TtrpgApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteGamesController : ControllerBase
    {

        private IFavoritesService _favoritesService;
        public FavoriteGamesController(IFavoritesService favoritesService)
        {
            _favoritesService = favoritesService;
        }


        [Authorize("Quester")]
        [HttpPost("addFavoriteGame")]
        public IActionResult addFavoriteGame([FromBody] ConnectedQuester q, Game g)
        {
            try
            {
                _favoritesService.addFavoriteGame(q.toModel(), g);
                return Ok("Ajouté aux préférences");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize("Quester")]
        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            try
            {
                return Ok(_favoritesService.GetAllGames(Id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize("Quester")]
        [HttpGet("{QuesterId}{GameId}")]
        public IActionResult GetGame(int QuesterId, int GameId)
        {
            try
            {
                return Ok(_favoritesService.GetGameById(QuesterId, GameId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        

        [Authorize("Quester")]
        [HttpDelete("{QuesterId}{GameId}")]
        public IActionResult deleteGame(int QuesterId, int GameId)
        {
            try
            {
                _favoritesService.DeleteGame(QuesterId, GameId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}