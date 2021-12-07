using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Services
{
    public class XmlDataProvider<T> : JsonDataProvider<T>
    {
        public XmlDataProvider(string path) : base(path)
        {
        }

        protected override ICollection<T> DeserializeCache(string content)
        {
            var xml = XDocument.Parse(content);
            var json = JsonConvert.SerializeXNode(xml, Formatting.None, true);
            json = json.Substring(4 + typeof(T).Name.Length);
            json = json.Substring(0, json.Length - 1);
            if (!json.StartsWith("["))
                json = $"[{json}]";
            return base.DeserializeCache(json);
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
