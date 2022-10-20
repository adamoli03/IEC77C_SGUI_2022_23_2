using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEC77C_ADT_2022_23_1.Data
{
    public class Store
    {
        int Store_Id { get; set; }
        int Company_ID { get; set; }
        int City_ID { get; set; }
        string Adress { get; set; }
        int Size { get; set; } //squareMeters
    }

    public class Company
    {
        int Company_ID { get; set; }
        string Name { get; set; }
        int networth { get; set; }
    }

    public class City
    {
        int City_ID { get; set; }
        string City_Name { get; set; }
        string State { get; set; }
        string Country { get; set; }

    }

    public class temp
    {
        Store store1 = new Store()
        {
            Store_ID = 1,
            Company_ID = 2,
            City_ID = 34,
            Adress = "Ballószögi út 123A",
            Size = 355
        };
        //Tablename.Store.Add(store1);
        //Tablename.SaveChanges();
    }
}
