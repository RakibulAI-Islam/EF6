
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source='RAKIB-PC\\MSSQLSERVER01';Initial Catalog='InventoryManagerDb'; Trusted_Connection='True'");
            }
        }
    }
}
