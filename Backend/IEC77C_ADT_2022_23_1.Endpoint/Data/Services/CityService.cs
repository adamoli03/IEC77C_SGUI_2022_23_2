using IEC77C_ADT_2022_23_1.Data;
using IEC77C_ADT_2022_23_1.Repository;
using IEC77C_ADT_2022_23_1.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEC77C_ADT_2022_23_1.Endpoint.Data.Services
{
    public class CityService
    {
        CompanyContext _context;
        CityLogic _logic;

        public CityService(CompanyContext context)
        {
            _context = context;
            StoreRepository storerepo = new StoreRepository(context);
            CompanyRepository comprepo = new CompanyRepository(context);
            CityRepository cityrepo = new CityRepository(context);

            _logic = new CityLogic(cityrepo, storerepo, comprepo);

        }
    }
}
