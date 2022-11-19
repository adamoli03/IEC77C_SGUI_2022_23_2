using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IEC77C_ADT_2022_23_1.Models;

namespace IEC77C_ADT_2022_23_1.Repository
{
    public interface IStoreRepository : IRepository<Store> { }
    public interface ICityRepository : IRepository<City> { }
    public interface ICompanyInterface : IRepository<Company> { }
}
