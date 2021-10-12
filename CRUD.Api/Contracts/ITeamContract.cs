using CRUD.Api.Models;
using CRUD.Api.Models.Filters;
using CRUD.Api.Models.Views;
using System;
using System.Collections.Generic;

namespace CRUD.Api.Contracts
{
    public interface ITeamContract
    {
        Team Create(Team team);
        ReturnView<IEnumerable<Team>> Find(TeamFilter filter);
        Team Update(Team team);
        void Delete(Guid id);
    }
}
