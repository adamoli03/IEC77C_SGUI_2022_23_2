﻿using IEC77C_ADT_2022_23_1.Data;
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
    public class CityController : Controller
    {
        CompanyContext _context;
        CityLogic _logic;

        public CityController(CompanyContext context)
        {
            _context = context;
            _context = context;
            CompanyRepository comprep = new CompanyRepository(context);
            StoreRepository storerep = new StoreRepository(context);
            CityRepository cityrep = new CityRepository(context);

            _logic = new CityLogic(cityrep, storerep, comprep);
        }
        

        [HttpGet("City/Get-All")]
        public IActionResult GetAll()
        {
            List<City> citylist = (List<City>)_logic.GetAll();
            return Ok(citylist);
        }
        [HttpGet("City/FindById/{id}")]
        public IActionResult FindByID(int id)
        {
            var city = _logic.FindById(id);
            return Ok(city);
        }

        [HttpPost("City/Add")]
        public IActionResult AddCity([FromBody]City city)
        {
            _logic.Add(city);
            return Ok();
        }
        [HttpPatch("City/Update")]
        public IActionResult UpdateCity([FromBody]City city)
        {
            _logic.Update(city);
            return Ok();
        }
        [HttpDelete("City/Delete")]
        public IActionResult DeleteCity([FromBody]City city)
        {
            _logic.Delete(city);
            return Ok();
        }
    }
}
