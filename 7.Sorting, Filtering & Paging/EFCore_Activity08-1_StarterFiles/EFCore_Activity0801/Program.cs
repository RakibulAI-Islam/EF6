using System;
using EFCore_DBLibrary;
using InventoryHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace EFCore_Activity0801
{
    class Program
    {
        private static IConfigurationRoot _configuration;
        private static DbContextOptionsBuilder<AdventureWorksContext_2022> _optionsBuilder;

        static void Main(string[] args)
        {
            BuildOptions();
            
            Console.WriteLine("List People Then Order and Take");
            ListPeopleThenOrderAndTake();
            Console.WriteLine("Query People, order, then list and take");
            QueryPeopleOrderedToListAndTake();
        }

        static void BuildOptions()
        {
            _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
            _optionsBuilder = new DbContextOptionsBuilder<AdventureWorksContext_2022>();
            _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("AdventureWorks_2022"));
        }

        private static void ListPeopleThenOrderAndTake()
        {
            using (var db = new AdventureWorksContext_2022(_optionsBuilder.Options))
            {
                var people = db.People.ToList().OrderByDescending(x => x.LastName);
                foreach (var person in people.Take(10))
                {
                    Console.WriteLine($"{person.FirstName} {person.LastName}");
                }
            }
        }

        private static void QueryPeopleOrderedToListAndTake()
        {
            using (var db = new AdventureWorksContext_2022(_optionsBuilder.Options))
            {
                var query = db.People.OrderByDescending(x => x.LastName);
                var result = query.Take(10);

                foreach (var person in result)
                {
                    Console.WriteLine($"{person.FirstName} {person.LastName}");
                }
            }
        }
    }
}


