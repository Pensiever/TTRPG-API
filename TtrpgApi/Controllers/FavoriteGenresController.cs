﻿using Microsoft.AspNetCore.Authorization;
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
    public class FavoriteGenresController : ControllerBase
    {

        private IFavoritesService _favoritesService;
        public FavoriteGenresController(IFavoritesService favoritesService)
        {
            _favoritesService = favoritesService;
        }


        [Authorize("Quester")]
        [HttpPost("Id")]
        public IActionResult addFavoriteGenre(int Id)
        {
            try
            {
                int questerId = int.Parse(User.FindFirstValue(ClaimTypes.Name));
                _favoritesService.addFavoriteGenre(questerId, Id);
                return Ok("Ajouté aux préférences");
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
                return Ok(_favoritesService.GetAllGenres(questerId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize("Quester")]
        [HttpDelete("{FavoriteId}")]
        public IActionResult deleteGenre(int FavoriteId)
        {
            try
            {
                _favoritesService.DeleteGenre(FavoriteId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}