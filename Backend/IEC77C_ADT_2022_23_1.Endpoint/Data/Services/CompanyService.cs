using IEC77C_ADT_2022_23_1.Data;
using IEC77C_ADT_2022_23_1.Repository;
using IEC77C_ADT_2022_23_1.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEC77C_ADT_2022_23_1.Endpoint.Data.Services
{
    public class CompanyService
    {
        private CompanyContext _context;
        private CompanyLogic _logic;

        public CompanyService(CompanyContext context)
        {
            _context = context;
            CompanyRepository comprepo = new CompanyRepository(context);
            StoreRepository storerepo = new StoreRepository(context);

            _logic = new CompanyLogic(comprepo, storerepo);
        }
    }
}
