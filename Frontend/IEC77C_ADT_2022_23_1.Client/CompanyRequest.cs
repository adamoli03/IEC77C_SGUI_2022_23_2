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
        
        protected Company InputCompany()
        {
            Company company = new Company();
            Console.WriteLine("Company name: ");
            company.Name = Console.ReadLine();
            Console.WriteLine("Networth: ");
            company.networth = int.Parse(Console.ReadLine());
            return company;
        }

        public async Task GetAll()
        {

            List<Company> companies = await myclient.GetFromJsonAsync<List<Company>>("Company/Get-All");
            foreach (var element in companies)
            {
                Console.WriteLine(element.GetString());
            }
        }

        public async Task FindByID()
        {
            Console.WriteLine("ID: ");
            int id = int.Parse(Console.ReadLine());
            Company company = await myclient.GetFromJsonAsync<Company>($"Company/FindById/{id}");
            Console.WriteLine(company.GetString());
        }


        public async Task Add()
        {
            Company company = InputCompany();

            HttpResponseMessage response = await myclient.PostAsJsonAsync("Company/Add", company);
            Console.WriteLine(
                $"{(response.IsSuccessStatusCode ? "Success" : "Error")} - {response.StatusCode}");
        }

        public async Task Update()
        {
            Company company = InputCompany();
            Console.WriteLine("Company ID:");
            company.Company_ID = int.Parse(Console.ReadLine());

            using StringContent jsonContent = new(
                JsonSerializer.Serialize(company),
                Encoding.UTF8,
                "application/json");

            using HttpResponseMessage response = await myclient.PatchAsync("Company/Update", jsonContent);

            response.EnsureSuccessStatusCode();
            Console.WriteLine(
                $"{(response.IsSuccessStatusCode ? "Success" : "Error")} - {response.StatusCode}");
        }

        public async Task Delete()
        {
            Console.WriteLine("Company ID: ");
            int id = int.Parse(Console.ReadLine());
            using HttpResponseMessage response = await myclient.DeleteAsync($"Company/Delete/{id}");

            response.EnsureSuccessStatusCode();

            Console.WriteLine($"{(response.IsSuccessStatusCode ? "Success" : "Error")} - {response.StatusCode}");

        }

        public async Task GetCityCount()
        {
            Console.WriteLine("Company Name:");
            string name = Console.ReadLine();
            var result = await myclient.GetFromJsonAsync<int>($"Company/{name}/CityCount");
            Console.WriteLine($"The company is present in {result} cities");
        }
    }
}
