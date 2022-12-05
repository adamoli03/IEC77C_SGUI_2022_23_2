using IEC77C_ADT_2022_23_1.Data;
using IEC77C_ADT_2022_23_1.Repository;
using IEC77C_ADT_2022_23_1.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IEC77C_ADT_2022_23_1.Models;

namespace IEC77C_ADT_2022_23_1.Endpoint.Data.Services
{
    public class CityService
    {
        CompanyContext _context;
        ICityLogic _logic;

        public CityService(CompanyContext context)
        {
            _context = context;
            StoreRepository storerepo = new StoreRepository(context);
            CompanyRepository comprepo = new CompanyRepository(context);
            CityRepository cityrepo = new CityRepository(context);

            _logic = new CityLogic(cityrepo, storerepo, comprepo);

        }

        public void Add(City city)
        {
            _logic.Add(city);
        }

        public List<City> GetAll()
        {
            return (List<City>)_logic.GetAll();
        }
        public City FindByID(int id)
        {
            return (City)_logic.FindById(id);
        }
        public void Update(City city)
        {
            _logic.Update(city);
        }
        public void Delete(City city)
        {
            _logic.Delete(city);
        }
        public string MostStores(int id)
        {
            return _logic.MostStores(id);
        }

        public List<string> ListCountries()
        {
            return _logic.ListCountries();
        }

        public List<Company> ListCompanies(City city)
        {
            return _logic.ListCompanies(city);
        }
    }
}
