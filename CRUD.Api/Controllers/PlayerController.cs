using CRUD.Api.Contracts;
using CRUD.Api.Models;
using CRUD.Api.Models.Filters;
using CRUD.Api.Models.Views;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CRUD.Api.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:ApiVersion}/[controller]")]
    public class PlayerController : Controller
    {
        private readonly IPlayerContract _playerContract;
        public PlayerController(IPlayerContract playerContract)
        {
            _playerContract = playerContract;
        }

        [HttpPost("CreatePlayer")]
        public ActionResult<Player> CreatePlayer([FromBody] Player player)
        {
            return _playerContract.Create(player);
        }

        [HttpPut("UpdatePlayer")]
        public ActionResult<Player> UpdatePlayer([FromBody] Player player)
        {
            return _playerContract.Update(player);
        }

        [HttpGet("GetPlayers")]
        public ActionResult<ReturnView<IEnumerable<Player>>> GetPlayers([FromQuery] PlayerFilter filter)
        {
            return _playerContract.Find(filter);
        }

        [HttpDelete("DeletePlayer")]
        public void DeletePlayer(Guid id)
        {
            _playerContract.Delete(id);
        }
    }
}
