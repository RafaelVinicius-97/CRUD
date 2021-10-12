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
    public class TeamController : Controller
    {
        private readonly ITeamContract _teamContract;
        public TeamController(ITeamContract teamContract)
        {
            _teamContract = teamContract;
        }

        [HttpPost("CreateTeam")]
        public ActionResult<Team> CreateTeam([FromBody] Team team)
        {
            return _teamContract.Create(team);
        }

        [HttpPut("UpdateTeam")]
        public ActionResult<Team> UpdateTeam([FromBody] Team team)
        {
            return _teamContract.Update(team);
        }

        [HttpGet("GetTeams")]
        public ActionResult<ReturnView<IEnumerable<Team>>> GetTeams([FromQuery] TeamFilter filter)
        {
            return _teamContract.Find(filter);
        }

        [HttpDelete("DeleteTeam")]
        public void DeleteTeam([FromQuery]Guid id)
        {
            _teamContract.Delete(id);
        }
    }
}
