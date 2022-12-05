using IEC77C_ADT_2022_23_1.Data;
using IEC77C_ADT_2022_23_1.Endpoint.Data.Services;
using IEC77C_ADT_2022_23_1.Logic;
using IEC77C_ADT_2022_23_1.Models;
using IEC77C_ADT_2022_23_1.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEC77C_ADT_2022_23_1.Endpoint.Controllers
{
    public class CompanyController : Controller
    {
        private CompanyContext _context;
        private CompanyService _service;

        public CompanyController(CompanyContext context)
        {
            _context = context;
            _service = new CompanyService(context);
        }

        

        [HttpGet("Company/FindById/{id}")]
        public IActionResult FindByID(int id)
        {
            Company comp =_service.FindByID(id);
            return Ok(comp);
        }

        [HttpGet("Company/Get-All")]
        public IActionResult GetAllCompany()
        {
            List<Company> complist = (List<Company>)_service.GetAll();
            return Ok(complist);
        }

        [HttpPost("Company/Add")]
        public IActionResult AddCompany([FromBody]Company company)
        {
            _service.Add(company);
            return Ok();
        }
        [HttpPatch("Company/Update")]
        public IActionResult UpdateCompany([FromBody]Company comp)
        {
            _service.Update(comp);
            return Ok();
        }

        [HttpDelete("Company/Delete")]
        public IActionResult DeleteCompany([FromBody]Company comp)
        {
            _service.Delete(comp);
            return Ok();
        }
        [HttpGet("Company/{Company_Name}/CityCount")]
        public IActionResult CityCount(string Company_Name)
        {
            int count = _service.CityCount(Company_Name);
            
            return Ok(count);
        }
        
    }
}
