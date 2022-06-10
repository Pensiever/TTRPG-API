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
    public class GenresController : ControllerBase
    {

        private IGenresService _genresService;
        public GenresController(IGenresService genresService)
        {
            _genresService = genresService;
        }

        [Authorize("Admin")]
        [HttpPost("createGenre")]
        public IActionResult CreateGenre([FromBody] NewGenreInfo newGenre)
        {
            try
            {
                _genresService.CreateGenre(newGenre.toModel());
                return Ok("Genre créé");
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
                return Ok(_genresService.GetAll());
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
                return Ok(_genresService.GetById(Id));
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
                _genresService.Delete(Id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize("Admin")]
        [HttpPut]
        public IActionResult Update(Genre g)
        {
            try
            {
                _genresService.Update(g);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}