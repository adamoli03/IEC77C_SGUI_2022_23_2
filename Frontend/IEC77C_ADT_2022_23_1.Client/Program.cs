using System;
using System.Collections.Generic;
using IEC77C_ADT_2022_23_1;
using IEC77C_ADT_2022_23_1.Models;
using ConsoleTools;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;

namespace IEC77C_ADT_2022_23_1.Client
{
    


    class Program
    {
        static void Main(string[] args)
        {
           
           

            
        }

        static async Task<List<Store>> GetStores()
        {
            

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5000/");

                var responseTask = client.GetAsync("store");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                }
                HttpResponseMessage response = await client.GetAsync("api/store");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    stores
                }
            
            }
        }
    }
}
