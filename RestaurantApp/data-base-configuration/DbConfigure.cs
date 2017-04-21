using MySql.Data.MySqlClient;
using RestaurantApp.model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.data_base_configuration
{

    class MyDBContext : DbContext
    {
        public MyDBContext() : base("mysqlconn")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<FoodStuff> FoodStuffs { get; set; }
        public DbSet<Table> Tables { get; set; }
    }
}
