
using System.Collections.Generic;

namespace LINQ.DataAccess
{
    public interface IRepository<T>
    {
        void Delete(int id);
        T ReadById(int id);
        IEnumerable<T> Read();
        void Update(T entity, int id);
        void Create(T newEntity);
    }
}
