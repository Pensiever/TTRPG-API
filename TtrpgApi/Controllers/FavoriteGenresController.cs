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
    public class FavoriteGenresController : ControllerBase
    {

        private IFavoritesService _favoritesService;
        public FavoriteGenresController(IFavoritesService favoritesService)
        {
            _favoritesService = favoritesService;
        }


        [Authorize("Quester")]
        [HttpPost("addFavoriteGenre")]
        public IActionResult addFavoriteGenre([FromBody] ConnectedQuester q, Genre g)
        {
            try
            {
                _favoritesService.addFavoriteGenre(q, g);
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
                return Ok(_favoritesService.GetAllGenres(Id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize("Quester")]
        [HttpGet("{Id}")]
        public IActionResult GetGenre([FromBody] ConnectedQuester q, int Id)
        {
            try
            {
                return Ok(_favoritesService.GetGenreById(q, Id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize("Quester")]
        [HttpDelete("{QuesterId}{GenreId}")]
        public IActionResult deleteGenre(int QuesterId, int GenreId)
        {
            try
            {
                _favoritesService.DeleteGenre(QuesterId, GenreId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}