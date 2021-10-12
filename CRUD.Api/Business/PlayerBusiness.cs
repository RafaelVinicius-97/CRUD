using CRUD.Api.Context;
using CRUD.Api.Contracts;
using CRUD.Api.Framework.Contracts;
using CRUD.Api.Models;
using CRUD.Api.Models.Filters;
using CRUD.Api.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUD.Api.Business
{
    public class PlayerBusiness : IPlayerContract
    {
        private readonly IBaseContract<Player> _repository;

        public PlayerBusiness(IBaseContract<Player> repository)
        {
            _repository = repository;
        }

        public Player Create(Player player)
        {
            if (!IsValid(player))
                return null;

            return _repository.Create(player);
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public ReturnView<IEnumerable<Player>> Find(PlayerFilter filter)
        {
            ReturnView<IEnumerable<Player>> returnView = new();

            using CRUDContext context = new();

            var query = from p in context.Player select p;

            if (!string.IsNullOrEmpty(filter.Name))
                query = query.Where(p => p.Name.Contains(filter.Name));

            if (filter.Wage != null)
                query = query.Where(p => p.Wage.Equals(filter.Wage));

            if (filter.TeamId != null)
                query = query.Where(p => p.TeamId == filter.TeamId);

            returnView.result = _repository.Find(query, filter.pageNumber, filter.pageSize);

            return returnView;

        }

        public Player Update(Player player)
        {
            if (!IsValid(player))
                return null;

            return _repository.Update(player);
        }

        private bool IsValid(Player player)
        {
            if (player.Id == Guid.Empty) { return false; }
            if (player.TeamId == Guid.Empty) { return false; }
            if (string.IsNullOrEmpty(player.Name) || player.Name.Length > 50) { return false; }
            if (player.Wage <= 0 || player.Wage > 9999999999999999.99) { return false; }

            return true;
        }
    }
}
