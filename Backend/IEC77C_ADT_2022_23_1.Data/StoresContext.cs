using System;
using System.Data.Entity;
using IEC77C_ADT_2022_23_1;

namespace IEC77C_ADT_2022_23_1.Data
{
    //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True; MultipleActiveResultSets=True;
    

    public class StoresContext : DbContext
    {
        public virtual DbSet<Store> Stores { get; set; }
        
        public virtual DbSet<Company> Companies { get; set; }

        public virtual DbSet<City> Cities { get; set; }
    }

}
