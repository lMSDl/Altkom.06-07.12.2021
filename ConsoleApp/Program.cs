using System;
using Models;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Product product = new Product();

            product.Name = "mleko";
            product.Price = 1.2f;
            
            Console.WriteLine(product.Info);
            Console.WriteLine(product.Created);

            //Wykorzystanie inicjalizatora do przygotowania obiektu
            Pizza pizza = new Pizza() { Cheese = true, Sauce = true, Ham = true };
            pizza = new Pizza() { Cheese = true, Sauce = true };
            pizza = new Pizza(true, false, true) { Onion = true, Ham = false };


        }
    }
}