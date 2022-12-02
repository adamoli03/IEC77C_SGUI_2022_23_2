using System;
using System.Collections.Generic;
using IEC77C_ADT_2022_23_1;
using IEC77C_ADT_2022_23_1.Models;
using ConsoleTools;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Net.Http.Json;

namespace IEC77C_ADT_2022_23_1.Client
{



    class Program
    {
        private static HttpClient thisclient = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:51272"),
        };

        

        static async Task Main(string[] args)
        {
            StoreRequest store = new(thisclient);
            await store.GetAll();
            Console.WriteLine();
            await store.FindByID(2);

            await store.Add(new Store
            {
                Store_ID = 3,
                Size = 10,
                Address = "random street 10",
                City_ID = 3,
                Company_ID = 10
            });
            


        }
    }
}
