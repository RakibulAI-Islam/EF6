using _1_EF_DbLibrary;
using EF6_0302;
using Microsoft.EntityFrameworkCore;

/*
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
*/

namespace EF6_0302
{
    public class Program
    {
        private static IConfigurationRoot _configuration;
        private static DbContextOptionsBuilder<Inventory_DbContext> _optionsBuilder;

        static void Main(string[] args)
        {
            BuildOptions();
            //EnsureItems();
            //ListInventory();
        }

        static void BuildOptions()
        {
            _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
            _optionsBuilder = new DbContextOptionsBuilder<Inventory_DbContext>();

            _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("InventoryManager"));
        }

        /*static void EnsureItems()
        {
            EnsureItem("Batman Begins");
            EnsureItem("Inception");
            EnsureItem("Remember the Titans");
            EnsureItem("Star Wars: The Empire Strikes Back");
            EnsureItem("Top Gun");
        }*/

        /*private static void EnsureItem(string name)
        {
            using (var db = new InventoryDbContext(_optionsBuilder.Options))
            {
                //determine if item exists:
                var existingItem = db.Items.FirstOrDefault(x => x.Name.ToLower()
                                                            == name.ToLower());

                if (existingItem == null)
                {
                    //doesn't exist, add it.
                    var item = new Item() { Name = name };
                    db.Items.Add(item);
                    db.SaveChanges();
                }
            }
        }*/

        /*private static void ListInventory()
        {
            using (var db = new InventoryDbContext(_optionsBuilder.Options))
            {
                var items = db.Items.OrderBy(x => x.Name).ToList();
                items.ForEach(x => Console.WriteLine($"New Item: {x.Name}"));
            }
        }*/

    }
}
