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
    class CompanyRequest
    {
        static HttpClient myclient;
        public CompanyRequest(HttpClient client)
        {
            myclient = client;
        }

        public async Task GetAll()
        {

            List<Company> companies = await myclient.GetFromJsonAsync<List<Company>>("Company/Get-All");
            foreach (var element in companies)
            {
                Console.WriteLine(element.GetString());
            }
        }

        public async Task FindByID(Company comp)
        {
            int id = comp.Company_ID;
            Company company = await myclient.GetFromJsonAsync<Company>($"Company/FindById/{id}");
            Console.WriteLine(company.GetString());
        }


        public async Task Add(Company company)
        {
            company.Company_ID = default(int);

            HttpResponseMessage response = await myclient.PostAsJsonAsync("Company/Add", company);
            Console.WriteLine(
                $"{(response.IsSuccessStatusCode ? "Success" : "Error")} - {response.StatusCode}");
        }

        public async Task Update(Company company)
        {
            using StringContent jsonContent = new(
                JsonSerializer.Serialize(company),
                Encoding.UTF8,
                "application/json");

            using HttpResponseMessage response = await myclient.PatchAsync("Company/Update", jsonContent);

            response.EnsureSuccessStatusCode();
            Console.WriteLine(
                $"{(response.IsSuccessStatusCode ? "Success" : "Error")} - {response.StatusCode}");
        }

        public async Task Delete(Company company)
        {
            using HttpResponseMessage response = await myclient.DeleteAsync($"Company/Delete/{company.Company_ID}");

            response.EnsureSuccessStatusCode();

            Console.WriteLine($"{(response.IsSuccessStatusCode ? "Success" : "Error")} - {response.StatusCode}");

        }

        public async Task GetCityCount(Company company)
        {
            var result = await myclient.GetFromJsonAsync<int>($"Company/{company.Name}/CityCount");
            Console.WriteLine($"The company is present in {result} cities");
        }
    }
}
