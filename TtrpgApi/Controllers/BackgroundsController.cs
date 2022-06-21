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

        [Authorize("Admin")]
        [HttpPost("addBackground")]
        public IActionResult addBackground([FromBody] NewBackground b)
        {
            try
            {
                _backgroundsService.addBackground(b.toModel());
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
                return Ok(_backgroundsService.GetAllBackgrounds());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize("Admin")]
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _backgroundsService.DeleteBackground(Id);
                return Ok();
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
                return Ok(_backgroundsService.GetById(Id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize("Admin")]
        [HttpPut]
        public IActionResult Update([FromBody] Background b)
        {
            try
            {
                _backgroundsService.UpdateBackground(b);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
