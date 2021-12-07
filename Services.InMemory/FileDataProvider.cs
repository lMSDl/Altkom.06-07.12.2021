using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Services
{
    public abstract class FileDataProvider<T> : ICollection<T>
    {
        protected string _path;
        protected ICollection<T> _cache;

        private Encryptor _encryptor = new Encryptor("123123123");
        public FileDataProvider(string path)
        {
            _path = path;
            ReadCache();
        }

        private void ReadCache()
        {
            if (File.Exists(_path))
            {
                //string content = File.ReadAllText(_path);

                //using (var fileStream = new FileStream(_path, FileMode.Open, FileAccess.Read))
                //using (var streamReader = new StreamReader(fileStream))
                //{
                //    content = streamReader.ReadToEnd();
                //}

                var bytes = File.ReadAllBytes(_path);

                var content = Encoding.Unicode.GetString(_encryptor.Decrypt(bytes, "AlaMaKota"));

                _cache = DeserializeCache(content);
            }
            else
            {
                _cache = new List<T>();
            }
        }


        protected virtual void WriteCache()
        {
            //File.WriteAllText(_path, SerializeCache(_cache));
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

            var result = _encryptor.Encrypt(SerializeCache(_cache), "AlaMaKota");
            File.WriteAllBytes(_path, result);
        }

        protected abstract ICollection<T> DeserializeCache(string content);
        protected abstract string SerializeCache(IEnumerable<T> cache);

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
            return _cache?.GetEnumerator() ?? Enumerable.Empty<T>().GetEnumerator();
        }

        public bool Remove(T item)
        {
            var result = _cache?.Remove(item) ?? false;
            if (result)
                WriteCache();
            return result;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
