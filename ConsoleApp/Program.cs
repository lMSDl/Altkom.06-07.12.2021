using System;
using Models;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Product product = Product.Instance;

            product.Name = "mleko";
            product.Price = 1.2f;

            product = Product.Instance;

            Console.WriteLine(product.Info);
            Console.WriteLine(product.Created);

            //Wykorzystanie inicjalizatora do przygotowania obiektu
            Pizza pizza = new Pizza() { Cheese = true, Sauce = true, Ham = true };
            pizza = new Pizza() { Cheese = true, Sauce = true };
            pizza = new Pizza(true, false, true) { Onion = true, Ham = false };


            var person1 = new Person();
            Console.WriteLine($"{person1.FullName} ({person1.CreatedDate})" );
            var person2 = new Person() { FirstName = "Ewa", LastName = "Ewowska", BirthDate = new DateTime(1986, 12, 5) };

            Console.WriteLine($"{person2.FullName} ({person2.CreatedDate})");
            var person3 = new Person();
            person3.FirstName = "Piotr";
            person3.LastName = "Piotrowski";
            person3.BirthDate = new DateTime(1990, 5, 12);
            Console.WriteLine($"{person3.FullName} ({person3.CreatedDate})");

        }
    }
}