using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using IEC77C_ADT_2022_23_1.Models;
using System.Net.Http.Json;

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
            HttpResponseMessage response = await myclient.PostAsJsonAsync("Store/Update", store);
            Console.WriteLine(
                $"{(response.IsSuccessStatusCode ? "Success" : "Error")} - {response.StatusCode}");
        }

        public async Task Update(Store store)
        {

        }

        public async Task Delete(Store store)
        {

        }



    }
}
