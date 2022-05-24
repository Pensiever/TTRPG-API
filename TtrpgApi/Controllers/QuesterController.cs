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
    public class QuesterController : ControllerBase
    {
        private IQuesterService _questerService;
        public QuesterController(IQuesterService questerService)
        {
            _questerService = questerService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] NewQuesterInfo newQuester)
        {
            try
            {
                _questerService.Register(newQuester.toModel());
                return Ok("Compte enregistré");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize("Admin")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_questerService.GetAll());
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
                return Ok(_questerService.GetById(Id));
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
                _questerService.Switchactivate(Id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize("Quester")]
        [HttpPut]
        public IActionResult Update(Quester q)
        {
            try
            {
                _questerService.Update(q);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize("Admin")]
        [HttpPut("/setAdmin/{Id}")]
        public IActionResult SwitchAdmin(int Id)
        {
            try
            {
                _questerService.SwitchAdmin(Id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
