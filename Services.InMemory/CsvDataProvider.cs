using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CsvDataProvider<T> : FileDataProvider<T>
    {
        public CsvDataProvider(string path) : base(path)
        {
        }

        protected override ICollection<T> DeserializeCache(string content)
        {
            throw new NotImplementedException();
        }

        protected override string SerializeCache(IEnumerable<T> cache)
        {
            throw new NotImplementedException();
        }
    }
}
