using System;
using IEC77C_ADT_2022_23_1.Repository;
using IEC77C_ADT_2022_23_1.Models;
using System.Collections.Generic;
using System.Linq;


namespace IEC77C_ADT_2022_23_1.Logic
{
    public class CityLogic
    {
        ICityRepository cityrepo;
        public CityLogic(ICityRepository cityrepo)
        {
            this.cityrepo = cityrepo;
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
    }
}
