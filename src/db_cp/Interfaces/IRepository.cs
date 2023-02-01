using System;
using System.Collections.Generic;

namespace db_cp.Interfaces
{
    public interface IRepository<T>
    {
        T Add(T model);
        T Update(T model);
        T Delete(int id);

        IEnumerable<T> GetAll();
        T GetByID(int id);
    }
}
