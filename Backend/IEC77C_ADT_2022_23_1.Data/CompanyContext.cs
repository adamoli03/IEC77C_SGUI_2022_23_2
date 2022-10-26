using System;
using System.Data;
using Microsoft.EntityFrameworkCore;
using IEC77C_ADT_2022_23_1;

namespace IEC77C_ADT_2022_23_1.Data
{
    //data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True; MultipleActiveResultSets=True;

    public class CompanyContext : DbContext
    {
        
        public CompanyContext()
        {
            this.Database.EnsureCreated();
        }
        
        public virtual DbSet<Store> Store { get; set; }
        
        public virtual DbSet<Company> Company { get; set; }

        public virtual DbSet<City> City { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Store>(entity =>
           {
               entity.HasKey(e => e.Store_ID);

               entity.Property(e => e.Store_ID).HasColumnName("STORE_ID");

               entity.Property(e => e.Company_ID)
                   .HasColumnName("COMPANY_ID")
                   .HasColumnType("int");

               entity.Property(e => e.City_ID)
                   .HasColumnName("CITY_ID")
                   .HasColumnType("int");

               entity.Property(e => e.Address)
                   .HasColumnName("ADDRESS")
                   .HasColumnType("varchar2)");

               entity.Property(e => e.Size)
                   .HasColumnName("SIZE")
                   .HasColumnType("int");

            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.Company_ID);

                entity.Property(e => e.Name)
                    .HasColumnName("COMPANY_NAME")
                    .HasColumnType("varchar2")
                    .HasMaxLength(15);

                entity.Property(e => e.networth)
                    .HasColumnName("NETWORTH")
                    .HasColumnType("int");

            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.City_ID);

                entity.Property(e => e.City_Name)
                    .HasColumnName("CITY_NAME")
                    .HasColumnType("varchar2")
                    .HasMaxLength(20);

                entity.Property(e => e.Country)
                    .HasColumnName("COUNTRY")
                    .HasColumnType("varchar2")
                    .HasMaxLength(20);



            });

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