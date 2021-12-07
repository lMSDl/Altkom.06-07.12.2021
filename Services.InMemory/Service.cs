using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class Service<T> : IService<T> where T : Entity
    {
        private ICollection<T> _entities;

        public Service(ICollection<T> entities)
        {
            _entities = entities;
        }

        public int Create(T entity)
        {
            //int maxId = 0;
            //foreach (var item in _entities)
            //{
            //    if (item.Id > maxId)
            //        maxId = item.Id;
            //}

            //entity.Id = maxId + 1;
            if (!_entities.Any())
                entity.Id = 1;
            else
                entity.Id = _entities.Max(x => x.Id) + 1;
            _entities.Add(entity);

            return entity.Id;
        }

        public bool Delete(int id)
        {
            var entity = Read(id);
            if (entity != null)
                return _entities.Remove(entity);
            return false;
        }

        public T Read(int id)
        {
            //foreach (var item in _entities)
            //{
            //    if (item.Id == id)
            //    {
            //        return item;
            //    }
            //}
            //return null;
            return _entities.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> Read()
        {
            //return new List<T>(_entities);
            return _entities.ToList();
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
