using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEC77C_ADT_2022_23_1.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
