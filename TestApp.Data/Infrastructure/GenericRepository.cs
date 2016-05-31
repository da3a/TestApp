using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestApp.Data;
using TestApp.Entities;

namespace Lubrizol.IVD.Data.Infrastructure
{
    public class GenericRepository<TEntity> where TEntity : BaseEntity
    {
        private TestAppContext context;
        internal DbSet<TEntity> dbSet;
        internal IDatabaseFactory databaseFactory;

        //public GenericRepository(TestAppContext context)
        //{
        //    this.context = context;
        //    this.dbSet = context.Set<TEntity>();
        //}

        public GenericRepository(IDatabaseFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory; 
            this.dbSet = Context.Set<TEntity>();
        }

        //protected IDatabaseFactory DatabaseFactory { get; private set; }

        protected TestAppContext Context
        {
            get { return this.context ?? (context = databaseFactory.Get()); }
        }

        public virtual IEnumerable<TEntity> GetWithRawSQL(string query, params object[] parameters)
        {
            return dbSet.SqlQuery(query, parameters);
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (
                var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual IEnumerable<TEntity> Get(
          Expression<Func<TEntity, bool>> filter = null,
          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
          params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var include in includeProperties)
            {
                query = query.Include(include);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public virtual TEntity GetById(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            entity.CreatedBy = Thread.CurrentPrincipal.Identity.Name;
            entity.CreatedDate = DateTime.Now;
            entity.ModifiedBy = Thread.CurrentPrincipal.Identity.Name;
            entity.ModifiedDate = entity.CreatedDate;
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entity = dbSet.Find(id);
            Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            entity.ModifiedBy = Thread.CurrentPrincipal.Identity.Name;;
            entity.ModifiedDate = DateTime.Now;
            context.Entry(entity).State = EntityState.Modified;
        }

        //public virtual void Save()
        //{
        //    context.SaveChanges();
        //}
    }
}
