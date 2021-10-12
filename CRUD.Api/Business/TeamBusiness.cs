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
    public class TeamBusiness : ITeamContract
    {
        private readonly IBaseContract<Team> _repository;

        public TeamBusiness(IBaseContract<Team> repository)
        {
            _repository = repository;
        }

        public Team Create(Team team)
        {
            team.Id = Guid.NewGuid();

            if (!IsValid(team))
                return null;

            return _repository.Create(team);
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public ReturnView<IEnumerable<Team>> Find(TeamFilter filter)
        {
            ReturnView<IEnumerable<Team>> returnView = new();

            using CRUDContext context = new();

            var query = from team in context.Team select team;

            if (!string.IsNullOrEmpty(filter.Name))
                query = query.Where(t => t.Name.Contains(filter.Name));

            if(filter.Income != null)
                query = query.Where(t => t.Income.Equals(filter.Income));

            returnView.result = _repository.Find(query, filter.pageNumber, filter.pageSize);

            return returnView;
        }

        public Team Update(Team team)
        {
            if (!IsValid(team))
                return null;

            return _repository.Update(team);
        }

        private bool IsValid(Team team)
        {
            if (team.Id == Guid.Empty) { return false; }
            if (string.IsNullOrEmpty(team.Name) || team.Name.Length > 50) { return false; }
            if (team.Income <= 0 || team.Income > 9999999999999999.99) { return false; }

            return true;
        }
    }
}
