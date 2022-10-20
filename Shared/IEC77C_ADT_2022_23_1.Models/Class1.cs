using System;
using System.Data;


namespace IEC77C_ADT_2022_23_1.Models
{
    public class Store
    {
        public Store(int store_Id, int company_ID, int city_ID, string adress, int size)
        {
            Store_Id = store_Id;
            Company_ID = company_ID;
            City_ID = city_ID;
            Adress = adress;
            Size = size;
        }

        int Store_Id { get; set; }
        int Company_ID { get; set; }
        int City_ID { get; set; }
        string Adress { get; set; }
        int Size { get; set; } //squareMeters
    }

    public class Company
    {
        public Company(int company_ID, string name, int networth)
        {
            Company_ID = company_ID;
            Name = name;
            this.networth = networth;
        }

        int Company_ID { get; set; }
        string Name { get; set; }
        int networth { get; set; }
    }

    public class City
    {
        public City(int city_ID, string city_Name, string state, string country)
        {
            City_ID = city_ID;
            City_Name = city_Name;
            State = state;
            Country = country;
        }

        int City_ID { get; set; }
        string City_Name { get; set; }
        string State { get; set; }
        string Country { get; set; }

    }


}
