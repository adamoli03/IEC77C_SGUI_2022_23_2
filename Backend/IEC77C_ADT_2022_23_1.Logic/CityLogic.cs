using System;
using IEC77C_ADT_2022_23_1.Repository;
using IEC77C_ADT_2022_23_1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace IEC77C_ADT_2022_23_1.Logic
{
    public interface ICityLogic
    {
        public IList<City> GetAll();
        public void Update(City city);
        public void Add(City city);
        public void Delete(City city);
        public City FindById(int id);
        public string MostStores(object input);
    }
    public class CityLogic : ICityLogic
    {
        ICityRepository cityrepo;
        IStoreRepository storerepo;
        ICompanyRepository companyrepo;
        public CityLogic(ICityRepository cityrepo, IStoreRepository storerepo, ICompanyRepository companyrepo)
        {
            this.cityrepo = cityrepo;
            this.storerepo = storerepo;
            this.companyrepo = companyrepo;
        }
        public IList<City> GetAll()
        {
            return cityrepo.GetAll().ToList();
        }

        public void Update(City city)
        {
            cityrepo.Update(city);
        }

        public void Add(City city)
        {
            cityrepo.Add(city);
        }

        public void Delete(City entity)
        {
            cityrepo.Delete(entity);
        }

        public City FindById(int ID)
        {
            return cityrepo.FindById(ID);
        }

        //NON-CRUD METHODS -TODO

        protected string MostStoresProcess(int CityID) //Param: City ID, returns name of the company with the most stores in given city
        {
            var CompanyCounts = storerepo.GetAll().Where(c => c.City_ID == CityID).GroupBy(x => x.Company_ID).Select(comp => new
            {
                Key = comp.Key,
                Count = comp.Count()
            }).OrderByDescending(o => o.Count); //Groups Companies by key and Count, Descending by count (First element will have the most stores
            int CompID = CompanyCounts.Select(x => x.Key).First(); //Returns ID of the company with the most stores 
            return companyrepo.GetAll().Where(x => x.Company_ID == CompID).Select(c => c.Name).First();
        }

        protected int NameToID(string CityName) //Param: city name, returns ID of the given city
        {
            int cityid = cityrepo.GetAll().Where(x => x.City_Name == CityName).Select(c => c.City_ID).First();
            return cityid;
        }

        public IList<City> ListCompanies(City city) //Lists companies who have stores in the given city
        {
            var companyIDs = storerepo.GetAll().Where(q => q.City_ID == city.City_ID).GroupBy(m => m.Company_ID).Select(c => c.Key);
            List<Company> result = new List<Company>();
            foreach (var element in companyIDs)
            {
                Company temp = companyrepo.FindById(element);
                result.Add(temp);
            }
            return (IList<City>)result;

        }

        public List<string> ListCountries() //Lists countries present in database
        {
            var result = cityrepo.GetAll().GroupBy(g => g.Country).Select(c => c.Key).ToList();

            return result;

        }
        public string MostStores(object cityidentifier) //Did it this way instead of overloading for fun purposes
        {
            string cityname = null;
            
            if (cityidentifier.GetType() == typeof(string)) 
            {
                int CityID = this.NameToID(cityidentifier as string);
                cityname = MostStoresProcess(CityID);

            }
            else if(cityidentifier.GetType() == typeof(int))
            {
                cityname = MostStoresProcess((int)cityidentifier);
            }
            else
            {
                throw new IndexOutOfRangeException("Wrong input type");
            }
            return cityname;
        }
    }
}
