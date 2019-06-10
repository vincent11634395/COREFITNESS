using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CoreFitnessWebApp.Models
{
    // Code-Based Configuration and Dependency resolution  
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    class CoreFitnessWebAppContext : DbContext
    {
        //Add your Dbsets here  
        public DbSet<Product> Products
        {
            get;
            set;
        }
        public DbSet<ShoppingCart> ShoppingCarts
        {
            get;
            set;
        }
        public CoreFitnessWebAppContext()
            //Reference the name of your connection string  
            : base("CoreFitnessWebAppEntities") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // it ignores Pluralizing Table Names (eg. Products would consider Product in Db Table name)
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}