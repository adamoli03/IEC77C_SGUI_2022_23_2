using IEC77C_ADT_2022_23_1.Endpoint.Data.ViewModel;
using IEC77C_ADT_2022_23_1.Endpoint.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEC77C_ADT_2022_23_1.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CompaniesController : Controller
    {
        public StoresService _companiesService;

        public CompaniesController(StoresService compservice)
        {
            _companiesService = compservice;
        }

        [HttpPost("add-store")]
        public IActionResult AddBook([FromBody]StoreVM store)
        {
            _companiesService.AddStore(store);
            return Ok();
        }
    }
}
