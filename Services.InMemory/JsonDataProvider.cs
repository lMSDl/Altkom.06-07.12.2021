using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class JsonDataProvider<T> : FileDataProvider<T>
    {
        public JsonDataProvider(string path) : base(path)
        {
        }

        private JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented,
            DefaultValueHandling = DefaultValueHandling.Ignore,
            DateFormatString = "yyyy-MM-dd HH:mm:ss"
        };

        protected override string SerializeCache(IEnumerable<T> input)
        {
            return JsonConvert.SerializeObject(input, JsonSerializerSettings);
        }

        protected override ICollection<T> DeserializeCache(string input)
        {
            return JsonConvert.DeserializeObject<ICollection<T>>(input, JsonSerializerSettings);
        }
    }
}
