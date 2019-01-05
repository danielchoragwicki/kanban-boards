using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace kanban_boards.Repository
{
    public class Repository<TEnity> : IRepository<TEnity> where TEnity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            this.Context = context;
        }

        public void Put(TEnity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Add(TEnity entity)
        {
            Context.Set<TEnity>().Add(entity);
        }

        public void Delete(TEnity entity)
        {
            Context.Set<TEnity>().Remove(entity);
        }

        public IEnumerable<TEnity> Find(Expression<Func<TEnity, bool>> predicate)
        {
            return Context.Set<TEnity>().Where(predicate);
        }

        public TEnity Get(int id)
        {
            return Context.Set<TEnity>().Find(id);
        }

        public IEnumerable<TEnity> GetAll()
        {
            return Context.Set<TEnity>().ToList();
        }
    }
}