using IEC77C_ADT_2022_23_1.Endpoint.Data.Services;
using IEC77C_ADT_2022_23_1.Endpoint.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEC77C_ADT_2022_23_1.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        public StoreService _service;

        public StoreController(StoreService service)
        {
            _service = service;
        }
        [HttpGet("get-store-stores")]
        public IActionResult GetAllStores()
        {
            var AllStores = _service.GetAllStore();
            return Ok(AllStores);
        }


        [HttpPost("add-store")]
        public IActionResult AddStore([FromBody]StoreVM store)
        {
            _service.AddStore(store);
            return Ok();
        }
    }
}
