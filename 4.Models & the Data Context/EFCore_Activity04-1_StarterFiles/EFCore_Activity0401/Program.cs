
using EFCore_DBLibrary;
using InventoryModels;
using Inventiry_Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace EFCore_Activity0401
{
    public class Program
    {
        private static IConfigurationRoot _configuration;
        private static DbContextOptionsBuilder<Inventory_DbContext> _optionsBuilder;
        
        //private static IConfigurationRoot _configuration;
        //private static DbContextOptionsBuilder<InventoryDbContext> _optionsBuilder;
        private const string _systemUserId = "2fd28110-93d0-427d-9207-d55dbca680fa";
        private const string _loggedInUserId = "e2eb8989-a81a-4151-8e86-eb95a7961da2";

        static void Main(string[] args)
        {
            BuildOptions();
            DeleteAllItems();
            EnsureItems();
            ListInventory();
        }

        static void BuildOptions()
        {
            _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
            _optionsBuilder = new DbContextOptionsBuilder<Inventory_DbContext>();
            _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("InventoryManager"));
        }

        private static void DeleteAllItems()
        {
            using (var db = new Inventory_DbContext(_optionsBuilder.Options))
            {
                var items = db.Items.ToList();
                db.Items.RemoveRange(items);
                db.SaveChanges();
            }
        }

        static void EnsureItems()
        {
            EnsureItem("Batman Begins");
            EnsureItem("Inception");
            EnsureItem("Remember the Titans");
            EnsureItem("Star Wars: The Empire Strikes Back");
            EnsureItem("Top Gun");
        }

        private static void EnsureItem(string name)
        {
            Random r = new Random();
            
            using (var db = new Inventory_DbContext(_optionsBuilder.Options))
            {
                //Determine, if item exists:
                var existingItem = db.Items.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());

                if (existingItem == null)
                {
                   //Doesn't exist, add it.
                    var item = new Item() { Name = name,
                                            CreatedByUserId = _loggedInUserId,
                                             IsActive = true,
                                             Quantity = r.Next()
                                          };
                    
                    db.Items.Add(item);
                    db.SaveChanges();
                }
            }
        }

        private static void ListInventory()
        {
            using (var db = new Inventory_DbContext(_optionsBuilder.Options))
            {
                var items = db.Items.OrderBy(x => x.Name).ToList();
                items.ForEach(x => Console.WriteLine($"New Item: {x.Name}"));
            }
        }

    } 
}
