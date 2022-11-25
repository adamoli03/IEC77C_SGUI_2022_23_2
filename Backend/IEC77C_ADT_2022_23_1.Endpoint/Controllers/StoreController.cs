using IEC77C_ADT_2022_23_1.Endpoint.Data.Services;
using IEC77C_ADT_2022_23_1.Models;
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
        [HttpGet("store/get-all-stores")]
        public IActionResult GetAllStores()
        {
            var AllStores = _service.GetAllStore();
            return Ok(AllStores);
        }
        [HttpGet("Store/find-by-id/{id}")]
        public IActionResult FindStoreByID(int id)
        {
            var store = _service.FindByID(id);
            return Ok(store);
        }

        [HttpPost("store/Add")]
        public IActionResult AddStore([FromBody]Store store)
        {
            _service.AddStore(store);
            return Ok();
        }

        [HttpPut("Store/Put")]
        public IActionResult UpdateStore([FromBody]Store store)
        {
            _service.UpdateStore(store);
            return Ok();
        }

        [HttpDelete("Store/Delete")]
        public IActionResult DeleteStore([FromBody]Store store)
        {
            _service.DeleteStore(store);
            return Ok();
        }
    }
}
