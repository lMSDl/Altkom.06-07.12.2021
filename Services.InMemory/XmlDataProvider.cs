using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class XmlDataProvider<T> : JsonDataProvider<T>
    {
        public XmlDataProvider(string path) : base(path)
        {
        }

        protected override ICollection<T> DeserializeCache(string content)
        {
            return new List<T>();
        }

        protected override string SerializeCache(IEnumerable<T> cache)
        {
            var json = base.SerializeCache(cache);
            json = $"{{\"{typeof(T).Name}\": {json} }}";
            var xml = JsonConvert.DeserializeXNode(json, "root");
            return xml.ToString();
        }
    }
}
