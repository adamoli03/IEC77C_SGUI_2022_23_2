using IEC77C_ADT_2022_23_1.Data;
using IEC77C_ADT_2022_23_1.Endpoint.Data.ViewModel;
using IEC77C_ADT_2022_23_1.Logic;
using IEC77C_ADT_2022_23_1.Repository;
using IEC77C_ADT_2022_23_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEC77C_ADT_2022_23_1.Endpoint.Services
{
    public class StoresService
    {
        private CompanyContext _context;

        private StoreLogic _logic;
        
        public StoresService(CompanyContext context)
        {
            _context = context;
            StoreRepository storerepo = new StoreRepository(context);

            _logic = new StoreLogic(storerepo);
        }

        public void AddStore(StoreVM store)
        {
            _logic.Add(store);
        }
    }
}
