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
    public class GamesController : ControllerBase
    {
        private IGamesService _gamesService;
        public GamesController(IGamesService gamesService)
        {
            _gamesService = gamesService;
        }

        [Authorize("Admin")]
        [HttpPost("createGame")]
        public IActionResult CreateGame([FromBody] NewGameInfo newGame)
        {
            try
            {
                _gamesService.CreateGame(newGame.toModel());
                return Ok("Jeu créé");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_gamesService.GetAll());
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
                return Ok(_gamesService.GetById(Id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize("Admin")]
        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            try
            {
                _gamesService.Delete(Id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize("Admin")]
        [HttpPut]
        public IActionResult Update(Game g)
        {
            try
            {
                _gamesService.Update(g);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}