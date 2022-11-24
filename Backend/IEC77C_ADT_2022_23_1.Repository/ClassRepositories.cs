using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IEC77C_ADT_2022_23_1.Models;
using Microsoft.EntityFrameworkCore;

namespace IEC77C_ADT_2022_23_1.Repository
{
    


    public class StoreRepository : Repository<Store>, IStoreRepository
    {
        public StoreRepository(DbContext context) : base(context) { }
    }
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(DbContext context) : base(context) { }
    }

    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(DbContext context) : base(context) { }
    }
}
