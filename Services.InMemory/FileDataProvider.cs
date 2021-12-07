using Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FileDataProvider<T> : ICollection<T>
    {
        private string _path;
        private ICollection<T> _cache;

        public FileDataProvider(string path)
        {
            _path = path;
            ReadCache();
        }

        private void ReadCache()
        {
            _cache = new List<T>();
        }

        private void WriteCache()
        {
            File.WriteAllText(_path, SerializeCache());
            /*
                //blok using - automatyczne wywołanie Dispose po wyjściu z bloku
                using (var fileStream = new FileStream(_path, FileMode.Create, FileAccess.Write))
                {
                    using (var streamWriter = new StreamWriter(fileStream))
                    {
                        streamWriter.Write("Hello");
                        streamWriter.Flush();
                    }
                }
                //streamWriter.Dispose();
                //fileStream.Dispose();
            */
        }

        private string SerializeCache()
        {
            var settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                DateFormatString = "yyyy-MM-dd HH:mm:ss"
            };

            return JsonConvert.SerializeObject(_cache, settings);
        }


        public int Count => _cache?.Count() ?? 0;

        public bool IsReadOnly => _cache?.IsReadOnly ?? true;

        public void Add(T item)
        {
            //if (cache != null)
            //    cache.Add(item);
            _cache?.Add(item);
            WriteCache();
        }

        public void Clear()
        {
            _cache?.Clear();
            WriteCache();
        }

        public bool Contains(T item)
        {
            return _cache?.Contains(item) ?? false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _cache?.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _cache?.GetEnumerator();
        }

        public bool Remove(T item)
        {
            var result = _cache?.Remove(item) ?? false;
            if(result)
                WriteCache();
            return result;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
