using System;
using ConsoleApp.Delegates;
using Models;
using Services.InFileService;
using Services.InMemory;
using Services.Interfaces;

namespace ConsoleApp
{
    class Program
    {
        static IService<Educator> Service { get; set; } = new MemoryService<Educator>();

        static void Main(string[] args)
        {
            var example = new EventExample();
            example.NumberEvent += delegate () { Console.WriteLine("=="); };
            example.NumberEvent += delegate () { Console.WriteLine("--"); };
            //example.NumberEvent = null;

            example.Test();

            new BuildInDelegatesExample().Test();

                var person1 = new Educator() { FirstName = "Ewa", LastName = "Ewowska", BirthDate = new DateTime(1986, 12, 5) };
            var person2 = new Educator() { FirstName = "Adam", LastName = "Adamski", BirthDate = new DateTime(1986, 12, 5) };

            Service.Create(person1);
            Service.Create(person2);

            var people = Service.Read();

            Service.Delete(1);

            Service  = new FileService<Educator>();

            people = Service.Read();

        }

        private static void HelloWorld()
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
            Console.WriteLine($"{person1.FullName} ({person1.CreatedDate})");
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