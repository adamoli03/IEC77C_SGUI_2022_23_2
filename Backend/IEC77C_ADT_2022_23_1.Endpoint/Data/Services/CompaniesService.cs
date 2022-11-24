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
    public class StoreService
    {
        private CompanyContext _context;

        private StoreLogic _storelogic;
        private CompanyLogic _companylogic;
        private CityLogic _citylogic;



        public StoreService(CompanyContext context)
        {
            _context = context;
            StoreRepository storerepo = new StoreRepository(context);
            CompanyRepository comprepo = new CompanyRepository(context);
            CityRepository cityrepo = new CityRepository(context);

            _storelogic = new StoreLogic(storerepo);
            _companylogic = new CompanyLogic(comprepo, storerepo);
            _citylogic = new CityLogic(cityrepo, storerepo, comprepo);
        }

        public void AddStore(StoreVM store)
        {
            _storelogic.Add(store);
        }
    }
}
