using System;
using System.Data;
using Microsoft.EntityFrameworkCore;
using IEC77C_ADT_2022_23_1;
using IEC77C_ADT_2022_23_1.Models;

namespace IEC77C_ADT_2022_23_1.Data
{
    //data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True; MultipleActiveResultSets=True;

    public class CompanyContext : DbContext
    {
        
        public CompanyContext()
        {
            this.Database.EnsureCreated();
        }
        
        public virtual DbSet<Store> Stores { get; set; }
        
        public virtual DbSet<Company> Companies { get; set; }

        public virtual DbSet<City> Cities { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Store>().HasData
            (
                new Store
                {
                    Store_ID = 1,
                    Company_ID = 1,
                    City_ID = 1,
                    Address = "Hollow avenue 12",
                    Size = 50
                },
                new Store
                {
                    Store_ID = 2,
                    Company_ID = 1,
                    City_ID = 1,
                    Address = "Smith street 3",
                    Size = 30
                },
                new Store
                {
                    Store_ID = 3,
                    Company_ID = 2,
                    City_ID = 2,
                    Address = "Andrássy Street 12/B",
                    Size = 120
                },
                new Store
                {
                    Store_ID = 4,
                    Company_ID = 3,
                    City_ID = 2,
                    Address = "Balogh Street 2",
                    Size = 320
                },
                new Store
                {
                    Store_ID = 5,
                    Company_ID = 2,
                    City_ID = 3,
                    Address = "Mexican street 96A",
                    Size = 50
                }
            );

            modelBuilder.Entity<Company>().HasData
            (
                new Company
                {
                    Company_ID = 1,
                    Name = "Dadidas",
                    networth = 150
                },
                new Company
                {
                    Company_ID = 2,
                    Name = "TrickShop",
                    networth = 70
                },
                new Company
                {
                    Company_ID = 3,
                    Name = "Nikea",
                    networth = 110
                }
            );
            modelBuilder.Entity<City>().HasData
            (
                new City
                {
                    City_ID = 1,
                    City_Name = "Dude-a-Pest",
                    Country = "Hungry"
                },
                new City
                {
                    City_ID = 2,
                    City_Name = "Nailed", //Szeged
                    Country = "Hungry"
                },
                new City
                {
                    City_ID = 3,
                    City_Name = "Hamsterdam",
                    Country = "Neitherlands"
                }

            );

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"data Source=(LocalDB)\MSSQLLocalDB;
                    AttachDbFilename=|DataDirectory|\Database1.mdf;
                    Integrated Security=True; MultipleActiveResultSets=True");
            }
        }
    }

}
/**/