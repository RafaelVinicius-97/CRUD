using CRUD.Api.Models;
using CRUD.Api.Models.Filters;
using CRUD.Api.Models.Views;
using System;
using System.Collections.Generic;

namespace CRUD.Api.Contracts
{
    public interface IPlayerContract
    {
        Player Create(Player player);
        ReturnView<IEnumerable<Player>> Find(PlayerFilter filter);
        Player Update(Player player);
        void Delete(Guid id);
    }
}
