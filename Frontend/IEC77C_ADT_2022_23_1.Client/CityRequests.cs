using IEC77C_ADT_2022_23_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IEC77C_ADT_2022_23_1.Client
{
    class CityRequest
    {
        static HttpClient myclient;
        public CityRequest(HttpClient client)
        {
            myclient = client;
        }

        public async Task GetAll()
        {

            List<City> cities = await myclient.GetFromJsonAsync<List<City>>("City/Get-All");
            foreach (var element in cities)
            {
                Console.WriteLine(element.GetString());
            }
        }

        public async Task FindByID(int id)
        {
            City city = await myclient.GetFromJsonAsync<City>($"City/FindById/{id}");
            Console.WriteLine(city.GetString());
        }


        public async Task Add(City city)
        {
            city.City_ID = default(int);

            HttpResponseMessage response = await myclient.PostAsJsonAsync("City/Add", city);
            Console.WriteLine(
                $"{(response.IsSuccessStatusCode ? "Success" : "Error")} - {response.StatusCode}");
        }

        public async Task Update(City city)
        {
            using StringContent jsonContent = new(
                JsonSerializer.Serialize(city),
                Encoding.UTF8,
                "application/json");

            using HttpResponseMessage response = await myclient.PatchAsync("City/Update", jsonContent);

            response.EnsureSuccessStatusCode();
            Console.WriteLine(
                $"{(response.IsSuccessStatusCode ? "Success" : "Error")} - {response.StatusCode}");
        }

        public async Task Delete(City city)
        {
            using HttpResponseMessage response = await myclient.DeleteAsync($"City/Delete/{city.City_ID}");

            response.EnsureSuccessStatusCode();

            Console.WriteLine($"{(response.IsSuccessStatusCode ? "Success" : "Error")} - {response.StatusCode}");

        }

        public async Task GetMostStores(City city)
        {
            int id = city.City_ID;
            var response = await myclient.GetFromJsonAsync<Company>($"City/{id}/MostStores");
            
            Console.WriteLine($"The company with the most stores in the given city: {response.Name}");
        }

        public async Task GetListCountries()
        {
            var result = await myclient.GetFromJsonAsync<List<string>>("City/List-Countries");
            foreach(string element in result)
            {
                Console.WriteLine(element);
            }
        }

        public async Task GetListCompanies(City city)
        {
            List<Company> result = await myclient.GetFromJsonAsync<List<Company>>($"City/{city.City_ID}/List-Companies");
            foreach(Company company in result)
            {
                Console.WriteLine(company.GetString());
            }

        }
    }
}
