﻿
using Inventory_Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace _1_EF_DbLibrary
{
    public class Inventory_DbContext : DbContext
    {
        private static IConfigurationRoot _configuration;
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
            {   /*
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Connection_String");
                */

                /*
                _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
                _optionsBuilder = new DbContextOptionsBuilder<Inventory_DbContext>();

                _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("InventoryManager"));
                */

                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional:true,reloadOnChange:true );
                _configuration = builder.Build();
                var cnstr = _configuration.GetConnectionString("InventoryManager");
                optionsBuilder.UseSqlServer(cnstr);
            
            }
        }
    }
}
