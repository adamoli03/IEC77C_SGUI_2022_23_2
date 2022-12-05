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

        public Store InputStore()
        {
            Store store = new Store();
            Console.WriteLine("Company ID: ");
            store.Company_ID = int.Parse(Console.ReadLine());
            Console.WriteLine("City ID: ");
            store.City_ID = int.Parse(Console.ReadLine());
            Console.WriteLine("Address: ");
            store.Address = Console.ReadLine();
            Console.WriteLine("Size of store: ");
            store.Size = int.Parse(Console.ReadLine());
            return store;
        }

        public async Task GetAll()
        {
            
            List<Store> stores = await myclient.GetFromJsonAsync<List<Store>>("store/Get-All");
            foreach (var element in stores)
            {
                Console.WriteLine(element.GetString());
            }
        }

        public async Task FindByID(int id)
        {
            Store store = await myclient.GetFromJsonAsync<Store>($"Store/FindById/{id}");
            Console.WriteLine(store.GetString());
        }


        public async Task Add()
        {
            
            Store store = InputStore();

            HttpResponseMessage response = await myclient.PostAsJsonAsync("Store/Add", store);
            Console.WriteLine(
                $"{(response.IsSuccessStatusCode ? "Success" : "Error")} - {response.StatusCode}");
        }
        
        public async Task Update()
        {
            Store store = InputStore();
            Console.WriteLine("Store ID: ");
            store.Store_ID = int.Parse(Console.ReadLine());

            using StringContent jsonContent = new(
                JsonSerializer.Serialize(store),
                Encoding.UTF8,
                "application/json");

            using HttpResponseMessage response = await myclient.PatchAsync("Store/Update",jsonContent);

            response.EnsureSuccessStatusCode();
            Console.WriteLine(
                $"{(response.IsSuccessStatusCode ? "Success" : "Error")} - {response.StatusCode}");
        }

        public async Task Delete()
        {
            Console.WriteLine("The id of the store you want to delete: ");
            Store store = new Store { Store_ID = int.Parse(Console.ReadLine()) };
            using HttpResponseMessage response = await myclient.DeleteAsync($"Store/Delete/{store.Store_ID}");

            response.EnsureSuccessStatusCode();
            
            Console.WriteLine($"{(response.IsSuccessStatusCode ? "Success" : "Error")} - {response.StatusCode}");

        }

        public async Task GetTotalSize()
        {
            Console.WriteLine("The id of the company: ");
            int id = int.Parse(Console.ReadLine());
            int result = await myclient.GetFromJsonAsync<int>($"Store/{id}/Total-Size");
            Console.WriteLine($"The total size is: {result}");
        }


    }
}
