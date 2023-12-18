using System.Linq;
using TicketApp.Application.Repositories;

namespace TicketApp.Adapter.Repositories
{
    internal abstract class Repository<T, TKey>(AppDbContext appDbContext) : IRepository<T, TKey>
        where T : class
    {

        protected readonly AppDbContext AppDbContext = appDbContext;

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