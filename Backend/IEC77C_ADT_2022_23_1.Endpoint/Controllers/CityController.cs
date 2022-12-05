using IEC77C_ADT_2022_23_1.Data;
using IEC77C_ADT_2022_23_1.Endpoint.Data.Services;
using IEC77C_ADT_2022_23_1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEC77C_ADT_2022_23_1.Endpoint.Controllers
{

    public class CityController : Controller
    {
        CompanyContext _context;
        CityService _service;

        public CityController(CompanyContext context)
        {
            _context = context;
            _context = context;

            _service = new CityService(context);
        }
        

        [HttpGet("City/Get-All")]
        public IActionResult GetAll()
        {
            List<City> citylist = (List<City>)_service.GetAll();
            return Ok(citylist);
        }
        [HttpGet("City/FindById/{id}")]
        public IActionResult FindByID(int id)
        {
            var city = _service.FindByID(id);
            return Ok(city);
        }

        [HttpPost("City/Add")]
        public IActionResult AddCity([FromBody]City city)
        {
            _service.Add(city);
            return Ok();
        }
        [HttpPatch("City/Update")]
        public IActionResult UpdateCity([FromBody]City city)
        {
            _service.Update(city);
            return Ok();
        }
        [HttpDelete("City/Delete/{id}")]
        public IActionResult DeleteCity(int id)
        {
            _service.Delete(new City {City_ID = id});
            return Ok();
        }

       //Non-CRUD

        [HttpGet("City/{id}/MostStores")]
        public IActionResult MostStores(int id)
        {
            string result =_service.MostStores(id);
            Company temp = new Company { Name = result };
            return Ok(temp);
        }
        [HttpGet("City/List-Countries")]
        public IActionResult ListCountries()
        {
            var result = _service.ListCountries();
            return Ok(result);
        }

        [HttpGet("City/{id}/List-Companies")]
        public IActionResult ListCompanies(int id)
        {
            var result = _service.ListCompanies(new City 
            {City_ID = id });
            return Ok(result);
        }



    }
}
