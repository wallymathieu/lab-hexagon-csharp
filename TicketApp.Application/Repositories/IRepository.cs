using System.Linq;

namespace TicketApp.Application.Repositories
{
    public interface IRepository<T,TKey>{
        T Save(T entity);
        // EmptyResultDataAccessException
        void Delete(TKey code);
        IQueryable<T> FindAll();
        // EmptyResultDataAccessException
        T FindOne(TKey code);
    }
}