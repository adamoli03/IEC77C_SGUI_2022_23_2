using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEC77C_ADT_2022_23_1.Data
{
    public class Store
    {
        public int Store_ID { get; set; }
        public int Company_ID { get; set; }
        public int City_ID { get; set; }
        public string Address { get; set; }
        public int Size { get; set; } //squareMeters
    }

    public class Company
    {
        public int Company_ID { get; set; }
        public string Name { get; set; }
        public int networth { get; set; }
    }

    public class City
    {
        public int City_ID { get; set; }
        public string City_Name { get; set; }
        public string Country { get; set; }

    }

    public class temp
    {
        
     
        
    }
}
