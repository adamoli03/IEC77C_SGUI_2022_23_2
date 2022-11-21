using System;
using IEC77C_ADT_2022_23_1.Repository;
using IEC77C_ADT_2022_23_1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace IEC77C_ADT_2022_23_1.Logic
{
    public class CityLogic
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

        protected string MostStoresProcess(int CityID) //Param: City ID, returns name of the store with the most stores in given city
        {
            var CompanyCounts = storerepo.GetAll().Where(c => c.City_ID == CityID).GroupBy(x => x.Company_ID).Select(comp => new
            {
                Key = comp.Key,
                Count = comp.Count()
            }).OrderByDescending(o => o.Count); //Groups Companies by key and Count, Descending by count (First element will have the most stores
            int CompID = CompanyCounts.Select(x => x.Key).First(); //Returns ID of the company with the most stores 
            return companyrepo.GetAll().Where(x => x.Company_ID == CompID).Select(c => c.Name).First();
        }

        protected int NameToID(string CityName) //Param: city name, returns ID of the gives city
        {
            return cityrepo.GetAll().Where(x => x.City_Name == CityName).Select(c => c.City_ID).First();
        }
        
        public string MostStores(object input)
        {
            string cityname = null;
            Type t = input.GetType();
            if (t is string) 
            {
                var CityID = this.NameToID(input as string);
                cityname = MostStoresProcess(CityID);

            }
            else if(t is int)
            {
                cityname = MostStoresProcess((int)input);
            }
            else
            {
                throw new IndexOutOfRangeException("Wrong input type");
            }
            return cityname;
        }
    }
}
