using System;
using System.Collections.Generic;
using IEC77C_ADT_2022_23_1;
using IEC77C_ADT_2022_23_1.Models;
using ConsoleTools;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Threading;

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
            CityRequest city = new(thisclient);
            CompanyRequest company = new(thisclient);
            try
            {
                var StoreSubMenu = new ConsoleMenu(args, level: 1)
                    .Add("List", async () => { Thread.Sleep(20); await store.GetAll(); })
                    .Add("Add", async () => await store.Add())
                    .Add("Update", async () => await store.Update())
                    .Add("Delete", async () => await store.Delete())
                    .Add("Get Total Size", async () => await store.GetTotalSize())
                    .Add("Exit", ConsoleMenu.Close);

                var CitySubMenu = new ConsoleMenu(args, level: 1)
                    .Add("List", async () => { Thread.Sleep(20); await city.GetAll(); })
                    .Add("Add", async () => await city.Add())
                    .Add("Update", async () => await city.Update())
                    .Add("Delete", async () => await city.Delete())
                    .Add("Most cities", async () => await city.GetMostStores())
                    .Add("List countries", async () => await city.GetListCountries())
                    .Add("List companies", async () => await city.GetListCompanies())
                    .Add("Exit", ConsoleMenu.Close);

                var CompanySubMenu = new ConsoleMenu(args, level: 1)
                    .Add("List", async () => { Thread.Sleep(20); await company.GetAll(); })
                    .Add("Add", async () => await company.Add())
                    .Add("Update", async () => await company.Update())
                    .Add("Delete", async () => await company.Delete())
                    .Add("City presence", async () => await company.GetCityCount())
                    .Add("Exit", ConsoleMenu.Close);

                var menu = new ConsoleMenu(args, level: 0)
                    .Add("Stores", () => StoreSubMenu.Show())
                    .Add("Cities", () => CitySubMenu.Show())
                    .Add("Companies", () => CompanySubMenu.Show())
                    .Add("Exit", ConsoleMenu.Close);


                menu.Show();
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong input"); 

            }
            
            
            
            
        }
    }
}
