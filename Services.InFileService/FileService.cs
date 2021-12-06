using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Services.InFileService
{
    public class FileService<T> : IService<T> where T : Entity
    {
        public int Create(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public T Read(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Read()
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
