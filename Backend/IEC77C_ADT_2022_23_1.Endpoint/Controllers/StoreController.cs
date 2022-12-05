using IEC77C_ADT_2022_23_1.Endpoint.Data.Services;
using IEC77C_ADT_2022_23_1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEC77C_ADT_2022_23_1.Endpoint.Controllers
{
    [ApiController]
    public class StoreController : ControllerBase
    {
        public StoreService _service;

        public StoreController(StoreService service)
        {
            _service = service;
        }
        [HttpGet("Store/Get-All")]
        public IActionResult GetAllStores()
        {
            var AllStores = _service.GetAllStore();
            return Ok(AllStores);
        }
        [HttpGet("Store/FindById/{id}")]
        public IActionResult FindStoreByID(int id)
        {
            var store = _service.FindByID(id);
            return Ok(store);
        }

        [HttpPost("Store/Add")]
        public IActionResult AddStore([FromBody]Store store)
        {
            _service.AddStore(store);
            return Ok();
        }

        [HttpPatch("Store/Update")]
        public IActionResult UpdateStore([FromBody]Store store)
        {
            _service.UpdateStore(store);
            return Ok();
        }

        [HttpDelete("Store/Delete/{id}")]
        public IActionResult DeleteStore(int id)
        {
            _service.DeleteStore(new Store { Store_ID = id });
            return Ok();
        }

        [HttpGet("Store/{id}/Total-Size")]
        public IActionResult TotalSize(int id)
        {
            int size = _service.TotalSize(id);
            return Ok(size);
        }
    }
}
