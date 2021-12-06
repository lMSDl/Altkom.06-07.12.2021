using Models;
using System;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IService<T>
    {
        int Create(T entity);
        T Read(int id);
        IEnumerable<T> Read();
        bool Update(int id, T entity);
        bool Delete(int id);
    }
}
