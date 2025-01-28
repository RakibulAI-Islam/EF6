
using Inventory_Models;
using Microsoft.EntityFrameworkCore;

namespace _1_EF_DbLibrary
{
    public class Inventory_DbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        
        public Inventory_DbContext() { } //For Scaffolding.
        
        public Inventory_DbContext( DbContextOptions options) : base( options) //For Dependency Injection.
        { }
        
        /*public AdventureWorks_2022Context(DbContextOptions<AdventureWorks_2022Context> options)
            : base(options)
        {
        }*/
    }
}
