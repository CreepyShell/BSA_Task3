using System;
using System.Collections.Generic;
using System.Linq;
using LINQ.DataAccess;
using LINQ.DataAccess.Models;

namespace LINQ.DataAccess
{
    public class RepositoryMethods<TEntity> : IRepository<TEntity>
        where TEntity:BaseModel
    {
        private IList<TEntity> _List;
        public RepositoryMethods(IList<TEntity> list)
        {
            _List = list;
        }
        public void Create(TEntity newEntity)
        {
            if (_List.Count(list => list.Id == newEntity.Id) > 0)
            {
                throw new InvalidOperationException("Can not add an exiting task");
            }
            _List.Add(newEntity);
        }
        public void Delete(int id)
        {
            TEntity deletedTask = _List.Where(task => task.Id == id).First();
            if (deletedTask == null)
            {
                throw new InvalidOperationException("Can not delete an don`t exiting task");
            }
            _List.Remove(deletedTask);
        }
        public void Update(TEntity entity, int entityId)
        {
            TEntity updatedList = _List.Where(task => task.Id == entityId).First();
            if (updatedList != null)
            {
                this.Delete(updatedList.Id);
                this.Create(entity);
            }

        }
        public  IEnumerable<TEntity> Read() => _List;

        public TEntity ReadById(int id) => _List.Where(l => l.Id == id).First();

    }
}
