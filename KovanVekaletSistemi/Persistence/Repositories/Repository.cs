using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KovanVekaletSistemi.Persistence.Repositories
{
    public class Repository<TEntity> where TEntity : class
    {
        private DbContext Context;
        public DbSet<TEntity> _entites;
        public Repository()
        {
            if (Context == null)
            {
                Context = new KovanDBContext();
            }
            _entites = Context.Set<TEntity>();
        }
        public Repository(DbContext context)
        {
            Context = context;

        }



        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entites.ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {

            return _entites.Where(predicate);
        }

        public IQueryable<TEntity> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, string[] include)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();
            foreach (string inc in include)
            {
                query = query.Include(inc);
            }

            return query.Where(predicate);
        }
        public IQueryable<TEntity> Find(string[] include)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();
            foreach (string inc in include)
            {
                query = query.Include(inc);
            }

            return query;
        }
        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _entites.SingleOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            _entites.Add(entity);
            Context.SaveChanges();
        }
        public void Done()
        {
            Context.SaveChanges();
        }

        public bool Update(TEntity entity)
        {
            bool result = false;
            try
            {
                Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                Context.SaveChanges();
                result = true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return result;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _entites.AddRange(entities);
            Context.SaveChanges();

        }

        public void Remove(TEntity entity)
        {
            Context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            _entites.Remove(entity);
            Context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entites.RemoveRange(entities);
            Context.SaveChanges();
        }

    }
}
