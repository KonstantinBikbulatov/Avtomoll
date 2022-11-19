using System.Collections.Generic;

namespace Avtomoll.Abstract
{
    public interface IRepository<T>
    {
        T FindByName(string name);

        IEnumerable<T> GetList();

        void Create(T model);

        T Read(long id);

        void Update(T model);

        void Delete(long id);
    }
}