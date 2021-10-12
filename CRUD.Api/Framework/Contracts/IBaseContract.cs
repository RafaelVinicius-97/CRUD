using CRUD.Api.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUD.Api.Framework.Contracts
{
    public interface IBaseContract<T> where T : ModelBase
    {
        T Create(T entity);
        IEnumerable<T> Find(IQueryable<T> query, int pageNumber = 0 , int pageSize = 0, bool useAsNoTracking = false);
        T Update(T entity);
        void Delete(Guid id);
        bool Exist(Guid id);
    }
}
