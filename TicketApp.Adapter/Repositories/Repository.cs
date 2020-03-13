using System;
using System.Linq;

namespace TicketApp.Application.Repositories
{
    internal abstract class Repository<T,TKey>: IRepository<T, TKey> where T:class
    {

        protected readonly AppDbContext appDbContext;

        public Repository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public virtual void Delete(TKey code)
        {
            appDbContext.Remove(appDbContext.Find<T>(code));
            appDbContext.SaveChanges();
        }

        public virtual IQueryable<T> FindAll()
        {
            return appDbContext.Set<T>();
        }

        public virtual T FindOne(TKey code)
        {
            return appDbContext.Find<T>(code);
        }

        public virtual T Save(T entity)
        {
            appDbContext.Update<T>(entity);
            appDbContext.SaveChanges();
            return entity;
        }
    }
}