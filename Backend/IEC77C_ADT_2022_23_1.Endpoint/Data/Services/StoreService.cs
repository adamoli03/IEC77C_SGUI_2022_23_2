using IEC77C_ADT_2022_23_1.Data;
using IEC77C_ADT_2022_23_1.Repository;
using IEC77C_ADT_2022_23_1.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEC77C_ADT_2022_23_1.Endpoint.Data.Services
{
    public class StoreService
    {
        private CompanyContext _context;
        private StoreLogic _logic;

        public StoreService(CompanyContext context)
        {
            _context = context;
            StoreRepository storerepo = new StoreRepository(context);

            _logic = new StoreLogic(storerepo);
        }
    }
}
