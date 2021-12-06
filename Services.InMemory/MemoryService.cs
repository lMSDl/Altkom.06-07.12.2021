using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Services.InMemory
{
    public class MemoryService<T> : IService<T> where T : Entity
    {
        private ICollection<T> _entities = new List<T>();

        public int Create(T entity)
        {
            int maxId = 0;
            foreach (var item in _entities)
            {
                if (item.Id > maxId)
                    maxId = item.Id;
            }

            entity.Id = maxId + 1;
            _entities.Add(entity);

            return entity.Id;
        }

        public bool Delete(int id)
        {
            foreach (var item in _entities)
            {
                if(item.Id == id)
                {
                    return _entities.Remove(item);
                }
            }
            return false;
        }

        public T Read(int id)
        {
            foreach (var item in _entities)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public IEnumerable<T> Read()
        {
            return new List<T>(_entities);
        }

        public bool Update(int id, T entity)
        {
            if(Delete(id))
            {
                entity.Id = id;
                _entities.Add(entity);
                return true;
            }
            return false;
        }
    }
}
