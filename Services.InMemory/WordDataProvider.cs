using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public class WordDataProvider : FileDataProvider<Person>
    {
        public WordDataProvider(string path) : base(path)
        {
        }

        protected override ICollection<Person> DeserializeCache(string content)
        {
            return new List<Person>();
        }

        protected override string SerializeCache(IEnumerable<Person> cache)
        {
            return string.Join("\n", cache.Select(x => $"{x.FullName}"));
        }

        protected override void WriteCache()
        {
            using (var wordDoc = new WordDoc())
            {
                wordDoc.CreateDocument();
                wordDoc.AppendText(SerializeCache(_cache), true, false);
                wordDoc.SaveAs(_path);
            }
        }
    }
}
