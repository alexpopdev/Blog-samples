namespace AutomateEntityFrameworkMocking.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;

    using AutomateEntityFrameworkMocking.Domain;

    /// <summary>
    /// IDbContext is created from the example described and made available here: http://blogs.clariusconsulting.net/kzu/how-to-design-a-unit-testable-domain-model-with-entity-framework-code-first/
    /// </summary>
    public partial class NorthwindEntities : DbContext, IDbContext
    {
        static NorthwindEntities()
        {
            QueryableExtensions.Includer = new DbIncluder();
        }

        public NorthwindEntities(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            // Get the ObjectContext related to this DbContext
            var objectContext = (this as IObjectContextAdapter).ObjectContext;

            // Sets the command timeout for all the commands
            objectContext.CommandTimeout = 300;
        }

        private class DbIncluder : QueryableExtensions.IIncluder
        {
            public IQueryable<T> Include<T, TProperty>(IQueryable<T> source, Expression<Func<T, TProperty>> path)
                where T : class
            {
                return DbExtensions.Include(source, path);
            }
        }


        void IDbContext.SaveChanges()
        {
            this.SaveChanges();
        }

        public void Add<T>(T entity) where T : class
        {
            this.Set<T>().Add(entity);
        }

        public void Delete<TEntity, TEntityKey>(TEntityKey id) where TEntity : class
        {
            var saved = this.Set<TEntity>().Find(id);
            this.Set<TEntity>().Remove(saved);
            //saved.IsDeleted = true;
        }

        public void Delete<TEntity>(TEntity item) where TEntity : class
        {
            this.Set<TEntity>().Remove(item);
            //saved.IsDeleted = true;
        }

    }
}
