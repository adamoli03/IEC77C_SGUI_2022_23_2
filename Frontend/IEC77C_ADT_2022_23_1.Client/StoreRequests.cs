using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using IEC77C_ADT_2022_23_1.Models;
using System.Net.Http.Json;
using System.ServiceModel;
using System.Net.Http.Headers;
using System.Threading;

namespace IEC77C_ADT_2022_23_1.Client
{
    
    class StoreRequest
    {
        static HttpClient myclient;
        public StoreRequest(HttpClient client)
        {
            myclient = client;
        }

        public async Task GetAll()
        {
            
            List<Store> stores = await myclient.GetFromJsonAsync<List<Store>>("store/get-all-stores");
            foreach (var element in stores)
            {
                Console.WriteLine(element.GetString());
            }
        }

        public async Task FindByID(int id)
        {
            Store store = await myclient.GetFromJsonAsync<Store>($"Store/find-by-id/{id}");
            Console.WriteLine(store.GetString());
        }


        public async Task Add(Store store)
        {
            store.Store_ID = default(int);

            HttpResponseMessage response = await myclient.PostAsJsonAsync("Store/Add", store);
            Console.WriteLine(
                $"{(response.IsSuccessStatusCode ? "Success" : "Error")} - {response.StatusCode}");
        }
        
        public async Task Update(Store store)
        {
            using StringContent jsonContent = new(
                JsonSerializer.Serialize(store),
                Encoding.UTF8,
                "application/json");

            using HttpResponseMessage response = await myclient.PatchAsync("Store/Update",jsonContent);

            response.EnsureSuccessStatusCode();
            Console.WriteLine(
                $"{(response.IsSuccessStatusCode ? "Success" : "Error")} - {response.StatusCode}");
        }

        public async Task Delete(Store store)
        {
            using HttpResponseMessage response = await myclient.DeleteAsync($"Store/Delete/{store.Store_ID}");

            response.EnsureSuccessStatusCode();
            
            Console.WriteLine($"{(response.IsSuccessStatusCode ? "Success" : "Error")} - {response.StatusCode}");

        }

        public async Task GetTotalSize(int id)
        {
            int result = await myclient.GetFromJsonAsync<int>($"Store/{id}/Total-Size");
            Console.WriteLine($"The total size is: {result}");
        }


    }
}
