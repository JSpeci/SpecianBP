using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpecianBP.Entities;

namespace SpecianBP.Db
{
    public class DbService : DbContext
    {
        public DbService(DbContextOptions<DbService> options) : base(options)
        {

        }

        public DbService(DbContextOptions<DbService> options, IServiceProvider serviceProvider) : base(options)
        {
            _serviceProvider = serviceProvider;
        }

        private readonly IServiceProvider _serviceProvider;

        //Wwb app entitites
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserUserRole> UserUserRole { get; set; }

        //Data series 
        public DbSet<Voltage> Voltages { get; set; }
        public DbSet<Current> Current { get; set; }
        public DbSet<Symmetrical_Components> Symmetrical_Components { get; set; }
        public DbSet<Frequency> Frequency { get; set; }
        public DbSet<Power> Power { get; set; }
        public DbSet<Temperature> Temperature { get; set; }
        public DbSet<Comm> Comm { get; set; }
        public DbSet<Status> Status { get; set; }

        public void InitializeDatabase()
        {
            DbInitializer.InitializeDb(this);
            var items = DataClassGenerator.GetDataItems(typeof(TestData));
            AddRange(items);
            SaveChanges();
        }
    }
}
