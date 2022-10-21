using System;
using System.Linq;
using IntroEFCore.ConsoleApp.Models;

namespace IntroEFCore.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new KontaktHomeContext();

            var persons = db.Persons.ToList();

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            foreach (var p in persons)
            {
                Console.WriteLine($"Id: {p.Id}, name: {p.Name}, surname: {p.Surname}, bd: {p.BirthDay?.ToString("dd-MM-yyyy")}");
            }

            Console.ReadKey();
        }
    }
}

