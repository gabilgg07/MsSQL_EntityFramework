using System;
using System.Linq;
using System.Text;
using IntroEFCore.ConsoleApp.Models;

namespace IntroEFCore.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            using (var db = new KontaktHomeContext())
            {
                Console.WriteLine("Quering with Linq");

                // ------------------------------------------------------------

                Console.WriteLine($"{new string('-', 50)}\n" +
                    $"select * from [dbo].[Persons]\n" +
                    $"{new string('-', 50)}");

                var personsAll = db.Persons.ToList();

                foreach (var p in personsAll)
                {
                    Console.WriteLine($"Id: {p.Id},\t name: {p.Name},\t surname: {p.Surname},\t bd: {p.BirthDay?.ToString("dd-MM-yyyy")}");
                }

                // ------------------------------------------------------------

                Console.WriteLine($"{new string('-', 50)}\n" +
                   $"select top(2) * from [dbo].[Persons]\n" +
                   $"{new string('-', 50)}");

                var personsTop2 = db.Persons
                    .Take(2) // alternative top(2)
                    .ToList();

                foreach (var p in personsTop2)
                {
                    Console.WriteLine($"Id: {p.Id},\t name: {p.Name},\t surname: {p.Surname},\t bd: {p.BirthDay:dd-MM-yyyy}");
                }

                // ------------------------------------------------------------

                Console.WriteLine($"{new string('-', 50)}\n" +
                   $"select top(2) * from [dbo].[Persons] order by [Id] desc \n" +
                   $"{new string('-', 50)}");

                var personsLast2 = db.Persons
                    .OrderByDescending(p=>p.Id) // alternative order by [Id] desc
                    .Take(2) // alternative top(2)
                    .ToList();

                foreach (var p in personsLast2)
                {
                    Console.WriteLine($"Id: {p.Id},\t name: {p.Name},\t surname: {p.Surname},\t bd: {p.BirthDay:dd-MM-yyyy}");
                }

                // ------------------------------------------------------------

                Console.WriteLine($"{new string('-', 50)}\n" +
                   $"select * from [dbo].[Persons] where [Id]=2 \n" +
                   $"{new string('-', 50)}");

                //var personsId2 = db.Persons
                //    .Where(p=>p.Id == 2) // alternative where [Id]=2
                //    .FirstOrDefault();

                // ve ya alternative

                var personsId2 = db.Persons
                    .FirstOrDefault(p => p.Id == 2); // alternative where [Id]=2
                if (personsId2 != null)
                {
                    Console.WriteLine($"Id: {personsId2.Id},\t name: {personsId2.Name},\t surname: {personsId2.Surname},\t " +
                        $"bd: {personsId2.BirthDay:dd-MM-yyyy}");
                }
                else
                {
                    Console.WriteLine("Note found!");
                }

                // ------------------------------------------------------------

                Console.WriteLine($"{new string('-', 50)}\n" +
                   $"select * from [dbo].[Persons] where [Name] = N'Qasım' \n" +
                   $"{new string('-', 50)}");

                //var personsNameQasim = db.Persons
                //    .Where(p => p.Name == "Qasım") // alternative where [Name] = N'Qasım'
                //    .ToList();

                var personsNameQasim = db.Persons
                    .Where(p => p.Name.Equals("Qasım")) // where [Name] = N'Qasım'
                    .ToList();

                foreach (var p in personsNameQasim)
                {
                    Console.WriteLine($"Id: {p.Id},\t name: {p.Name},\t surname: {p.Surname},\t bd: {p.BirthDay:dd-MM-yyyy}");
                }

                // ------------------------------------------------------------

                Console.WriteLine($"{new string('-', 50)}\n" +
                   $"select * from [dbo].[Persons] where [Name] like N'Qa%' \n" +
                   $"{new string('-', 50)}");

                var personsNameStartQa = db.Persons
                    .Where(p => p.Name.StartsWith("qa")) // alternative where [Name] like N'Qa%'
                    .ToList();

                foreach (var p in personsNameStartQa)
                {
                    Console.WriteLine($"Id: {p.Id},\t name: {p.Name},\t surname: {p.Surname},\t bd: {p.BirthDay:dd-MM-yyyy}");
                }

                // ------------------------------------------------------------

                Console.WriteLine($"{new string('-', 50)}\n" +
                   $"select * from [dbo].[Persons] where [Surname] like N'%ova' \n" +
                   $"{new string('-', 50)}");

                var personsNameEndOva = db.Persons
                    .Where(p => p.Surname.EndsWith("ova")) // alternative where [Name] like N'%ova'
                    .ToList();

                foreach (var p in personsNameEndOva)
                {
                    Console.WriteLine($"Id: {p.Id},\t name: {p.Name},\t surname: {p.Surname},\t bd: {p.BirthDay:dd-MM-yyyy}");
                }

                // ------------------------------------------------------------

                Console.WriteLine($"{new string('-', 50)}\n" +
                   $"select * from [dbo].[Persons] where [Name] like N'%ab%' \n" +
                   $"{new string('-', 50)}");

                var personsNameHasAb = db.Persons
                    .Where(p => p.Name.Contains("ab")) // alternative where [Name] like N'%ovaab%'
                    .ToList();

                foreach (var p in personsNameHasAb)
                {
                    Console.WriteLine($"Id: {p.Id},\t name: {p.Name},\t surname: {p.Surname},\t bd: {p.BirthDay:dd-MM-yyyy}");
                }

                // ------------------------------------------------------------

                Console.WriteLine($"{new string('-', 50)}\n" +
                   $"select * from [dbo].[Persons] where [Id] between 2 and 4 \n" +
                   $"{new string('-', 50)}");

                var personsIdBetween_2_4 = db.Persons
                    .Where(p => p.Id >=2 && p.Id <=4) // alternative where [Id] between 2 and 4
                    .ToList();

                foreach (var p in personsIdBetween_2_4)
                {
                    Console.WriteLine($"Id: {p.Id},\t name: {p.Name},\t surname: {p.Surname},\t bd: {p.BirthDay:dd-MM-yyyy}");
                }

                // ------------------------------------------------------------

                Console.WriteLine($"{new string('-', 50)}\n" +
                   $"select * from [dbo].[Persons] where [Id]=3 or [Id]=6 or [Id]=7 \n" +
                   $"{new string('-', 50)}");

                var personsIdOr_3_6_7 = db.Persons
                    .Where(p => p.Id == 3 || p.Id == 6 || p.Id == 7) // alternative where [Id]=3 or [Id]=6 or [Id]=7
                    .ToList();

                foreach (var p in personsIdOr_3_6_7)
                {
                    Console.WriteLine($"Id: {p.Id},\t name: {p.Name},\t surname: {p.Surname},\t bd: {p.BirthDay:dd-MM-yyyy}");
                }

                // ------------------------------------------------------------

                Console.WriteLine($"{new string('-', 50)}\n" +
                   $"select * from [dbo].[Persons] where NOT ([Id]=3 OR [Id]=6 OR [Id]=7) \n" +
                   $"{new string('-', 50)}");

                var personsIdNotOr_3_6_7 = db.Persons
                    .Where(p => !(p.Id == 3 || p.Id == 6 || p.Id == 7)) // alternative where NOT ([Id]=3 OR [Id]=6 OR [Id]=7)
                    .ToList();

                foreach (var p in personsIdNotOr_3_6_7)
                {
                    Console.WriteLine($"Id: {p.Id},\t name: {p.Name},\t surname: {p.Surname},\t bd: {p.BirthDay:dd-MM-yyyy}");
                }

                // ------------------------------------------------------------

                Console.WriteLine($"{new string('-', 50)}\n" +
                   $"select * from [dbo].[Persons] where [Id] in (2,3,5,7,8) \n" +
                   $"{new string('-', 50)}");
                int[] arr = { 2, 3, 5, 7, 8 };
                var personsIdIn_2_3_5_7_8 = db.Persons
                    // .Where(p => (new[] {2,3,5,7,8}).Contains(p.Id)) // alternative where [Id] in (2,3,5,7,8)
                    .Where(p => arr.Contains(p.Id))  // alternative where [Id] in (2,3,5,7,8)
                    .ToList();

                foreach (var p in personsIdIn_2_3_5_7_8)
                {
                    Console.WriteLine($"Id: {p.Id},\t name: {p.Name},\t surname: {p.Surname},\t bd: {p.BirthDay:dd-MM-yyyy}");
                }

                // ------------------------------------------------------------

                Console.WriteLine($"{new string('-', 50)}\n" +
                   $"select * from [dbo].[Persons] where [BirthDay] between '1991-07-01' and '1991-07-30' \n" +
                   $"{new string('-', 50)}");

                var personsBDBetween = db.Persons
                    .Where(p => p.BirthDay >= new DateTime(1991, 07, 01) && p.BirthDay <= new DateTime(1991, 07, 30))  // alternative where [BirthDay] between '1991-07-01' and '1991-07-30'
                    .ToList();

                foreach (var p in personsBDBetween)
                {
                    Console.WriteLine($"Id: {p.Id},\t name: {p.Name},\t surname: {p.Surname},\t bd: {p.BirthDay:dd-MM-yyyy}");
                }

                // ------------------------------------------------------------

                Console.WriteLine($"{new string('-', 50)}\n" +
                   $"select * from [dbo].[Persons] where [BirthDay] between '1991' and '2000' \n" +
                   $"{new string('-', 50)}");

                var personsBDBetweenYear = db.Persons
                    .Where(p => p.BirthDay >= new DateTime(1991, 01, 01) && p.BirthDay <= new DateTime(2000, 01, 01))  // alternative where [BirthDay] between '1991' and '2000'
                    .ToList();

                foreach (var p in personsBDBetweenYear)
                {
                    Console.WriteLine($"Id: {p.Id},\t name: {p.Name},\t surname: {p.Surname},\t bd: {p.BirthDay:dd-MM-yyyy}");
                }

                // ------------------------------------------------------------

                Console.WriteLine($"{new string('-', 50)}\n" +
                   $"select * from [dbo].[Persons] where [CreatedDate] >= '2022-06-01' and [CreatedDate] < '2022-07-01' \n" +
                   $"{new string('-', 50)}");

                var personsBDBetweenMonth = db.Persons
                    .Where(p => p.CreatedDate >= new DateTime(2022, 06, 01) && p.CreatedDate < new DateTime(2022, 07, 01))  // alternative where [CreatedDate] >= '2022-06-01' and [CreatedDate] < '2022-07-01'
                    .ToList();

                foreach (var p in personsBDBetweenMonth)
                {
                    Console.WriteLine($"Id: {p.Id},\t name: {p.Name},\t surname: {p.Surname},\t createdDate: {p.CreatedDate:dd-MM-yyyy}");
                }
            }


            //db.Dispose(); try-finaly block-unda mutleq yazilmalidir, using de ise ehtiyac yoxdu. 

            Console.ReadKey();
        }
    }
}

