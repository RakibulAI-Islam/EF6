using EFCore_DBLibrary;
using InventoryHelpers;
using InventoryModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace EFCore_Activity0402
{
    public class Program
    {
        private static IConfigurationRoot _configuration;
        private static DbContextOptionsBuilder<InventoryDbContext> _optionsBuilder;

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
            _optionsBuilder = new DbContextOptionsBuilder<InventoryDbContext>();
            _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("InventoryManager"));
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
            using (var db = new InventoryDbContext(_optionsBuilder.Options))
            {
                //Determine, If item exists :
                var existingItem = db.Items.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());

                if (existingItem == null)
                {
                    //Doesn't exist, Add it.
                    var item = new Item() { Name = name };
                    db.Items.Add(item);
                    db.SaveChanges();
                }
            }
        }

        private static void DeleteAllItems()
        {
            using (var db = new InventoryDbContext(_optionsBuilder.Options))
            {
                var items = db.Items.ToList();
                db.Items.RemoveRange(items);
                db.SaveChanges();
            }
        }

        private static void ListInventory()
        {
            using (var db = new InventoryDbContext(_optionsBuilder.Options))
            {
                var items = db.Items.OrderBy(x => x.Name).ToList();
                items.ForEach(x => Console.WriteLine($"New Item: {x.Name}"));
            }
        }

    }
}
