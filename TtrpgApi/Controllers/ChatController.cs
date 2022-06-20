using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TtrpgApi.Domain;
using TtrpgApi.Hubs;
using TtrpgApi.Models;

namespace TtrpgApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly ChatHub _ch;

        public ChatController(ChatHub chathub)
        {
            _ch = chathub;
        }

        [HttpPost]
        public IActionResult AddRoom([FromQuery] string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest();
            }
            _ch.AddRoom(name);
            return Created("AddGroup", name);
        }

        [HttpGet]
        public List<string> GetAllRooms()
        {
            return _ch.GetAllRooms();
        }
    }
}
