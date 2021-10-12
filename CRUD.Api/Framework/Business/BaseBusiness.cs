using CRUD.Api.Context;
using CRUD.Api.Framework.Contracts;
using CRUD.Api.Framework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUD.Api.Framework.Business
{
    public class BaseBusiness<T> : IBaseContract<T> where T : ModelBase
    {
        private CRUDContext _context;
        private DbSet<T> _dbSet;

        public BaseBusiness(CRUDContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public T Create(T item)
        {
            var query = _dbSet;
            var entity = Find(query.Where(x => x.Id.Equals(item.Id))).FirstOrDefault();

            if (entity == null)
            {
                try
                {
                    _dbSet.Add(item);
                    _context.SaveChanges();
                    return item;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
        public T Update(T item)
        {
            var query = _dbSet;
            var entity = Find(query.Where(x => x.Id.Equals(item.Id))).FirstOrDefault();

            if (entity != null)
            {
                try
                {
                    _context.Entry(entity).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return entity;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }
        public void Delete(Guid id)
        {
            var query = _dbSet;
            var entity = Find(query.Where(x => x.Id.Equals(id))).FirstOrDefault();

            if (entity != null)
            {
                try
                {
                    _dbSet.Remove(entity);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public bool Exist(Guid id)
        {
            return _dbSet.Any(x => x.Id.Equals(id));
        }
        public IEnumerable<T> Find(IQueryable<T> query, int pageNumber = 0, int pageSize = 0, bool asNoTracking = false)
        {
            query = PagedShearch(query, pageNumber, pageSize);

            if (asNoTracking)
                return query.AsNoTracking().ToList().AsEnumerable();

            var resultado = query.ToList().AsEnumerable();

            return resultado;
        }
        private IQueryable<T> PagedShearch(IQueryable<T> query, int pageNumber, int pageSize)
        {
            if (!IsPagedSearch(pageNumber, pageSize))
                return query;

            int skip = (int)Math.Ceiling(((decimal)pageNumber - 1) * pageSize);
            return query.Skip(skip).Take(pageSize);

            bool IsPagedSearch(int? pageNumber, int? pageSize)
            {
                if ((pageNumber == 0) && (pageSize == 0))
                    return false;

                return true;
            }
        }

    }
}
