using System.Linq;

namespace DearDiary.Data.Repositories
{
    public interface IEFGenericRepository<T> where T : class
    {
        IQueryable<T> All { get; }

        T GetById(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
