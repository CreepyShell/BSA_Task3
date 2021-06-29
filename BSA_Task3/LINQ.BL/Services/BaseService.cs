using LINQ.DataAccess;
using LINQ.DataAccess.Models;
using System.Collections.Generic;

namespace LINQ.BL.Services
{
    public abstract class BaseService<T>
        where T : BaseModel
    {
        protected ListModels listModels = ListModels.GetListModels();

        protected RepositoryMethods<T> methods;

        protected IEnumerable<T> BaseRead() => methods.Read();
        protected T BaseReadById(int id) => methods.ReadById(id);
        protected void BaseDelete(int id) => methods.Delete(id);
        protected void BaseUpdate(T entity, int id) => methods.Update(entity, id);
        protected void BaseCreate(T entity) => methods.Create(entity);
    }
}
