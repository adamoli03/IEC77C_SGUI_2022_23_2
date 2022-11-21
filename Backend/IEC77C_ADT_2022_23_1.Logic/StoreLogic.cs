using System;
using IEC77C_ADT_2022_23_1.Repository;
using IEC77C_ADT_2022_23_1.Models;
using System.Collections.Generic;
using System.Linq;


namespace IEC77C_ADT_2022_23_1.Logic
{
    public class StoreLogic
    {
        IStoreRepository storerepo;
        public StoreLogic(IStoreRepository storerepo)
        {
            this.storerepo = storerepo;
        }
        public IList<Store> GetAll()
        {
            return storerepo.GetAll().ToList();
        }

        public void Update(Store entity)
        {
            storerepo.Update(entity);
        }

        public void Add(Store entity)
        {
            storerepo.Add(entity);
        }

        public void Delete(Store entity)
        {
            storerepo.Delete(entity);
        }

        public Store FindById(int ID)
        {
            return storerepo.FindById(ID);
        }

        public int TotalSize(int CompanyID)
        {
            return storerepo.GetAll().Where(x => x.Company_ID == CompanyID).Sum(x => x.Size);

        }
    }
}
