using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.LambdaExpressions
{
    public class LinqExamples
    {
        int[] numbers = new[] { 1, 2, 5, 7, 3, 8, 0, 9 };
        IEnumerable<string> strings = "Ala ma kota i dwa psy".Split(' ').ToList();

        IEnumerable<Person> People = new List<Person>()
        {
            new Person { FirstName = "Adam", LastName = "Adamski", BirthDate = new DateTime(1975, 2, 23) },
            new Person { FirstName = "Ewa", LastName = "Adamska", BirthDate = new DateTime(1990, 2, 23) },
            new Person { FirstName = "Adam", LastName = "Ewowski", BirthDate = new DateTime(1954, 2, 23) },
            new Person { FirstName = "Ewa", LastName = "Ewowska", BirthDate = new DateTime(1999, 2, 23) },
            new Person { FirstName = "Piotr", LastName = "Piotrowski", BirthDate = new DateTime(1989, 2, 23) },
            new Person { FirstName = "Piotr", LastName = "Adamski", BirthDate = new DateTime(1960, 2, 23) },
            new Person { FirstName = "Ewa", LastName = "Piotrowska", BirthDate = new DateTime(1998, 2, 23) },
            new Person { FirstName = "Piotr", LastName = "Ewowski", BirthDate = new DateTime(1967, 2, 23) },
        };

        public void Test()
        {
            var query1 = from value in numbers where value >= 4 select value;
            var query2 = from value in numbers where value >= 4 orderby value descending select value ;
            var query3 = from person in People where person.BirthDate.Year > 1990 select person.FullName;

            var query4 = numbers.Where(x => x >= 4).ToList();
            var query5 = numbers.Where(x => x >= 4).OrderByDescending(param => param).ToList();
            var query6 = People.Where(x => x.BirthDate.Year > 1990).Select(x => x.FullName).ToList();

            var query7 = People.Skip(1).Take(3).Where(x => x.FirstName == "Ewa").Where(x => x.BirthDate.Year >= 1990).FirstOrDefault();
            var query8 = People.Where(x => x.LastName.Contains("ADAM")).Average(x => DateTime.Now.Year - x.BirthDate.Year);

        }
    }
}
