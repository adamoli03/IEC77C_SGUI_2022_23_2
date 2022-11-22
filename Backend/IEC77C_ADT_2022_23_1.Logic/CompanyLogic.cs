using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IEC77C_ADT_2022_23_1.Repository;
using IEC77C_ADT_2022_23_1.Models;


namespace IEC77C_ADT_2022_23_1.Logic
{
    public interface ICompanyLogic
    {
        public IList<Company> GetAll();
        public void Update(Company company);
        public void Add(Company company);
        public void Delete(Company company);
        public Company FindById(int ID);

        public int CityCount(string company);
    }
    public class CompanyLogic : ICompanyLogic
    {
        ICompanyRepository companyrepo;
        IStoreRepository storerepo;

        public CompanyLogic(ICompanyRepository companyrepo, IStoreRepository storerepo)
        {
            this.companyrepo = companyrepo;
            this.storerepo = storerepo;
        }

        public IList<Company> GetAll()
        {
            return companyrepo.GetAll().ToList();
        }

        public void Add(Company entity)
        {
            companyrepo.Add(entity);
        }

        public void Update(Company entity)
        {
            companyrepo.Update(entity);
        }

        public void Delete(Company entity)
        {
            companyrepo.Delete(entity);
        }

        public Company FindById(int ID)
        {
            return companyrepo.FindById(ID);
        }

        public int CityCount(string company) //Param: name of company, returns the amount of cities the company has stores in
        {
            int compid = companyrepo.GetAll().Where(x => x.Name == company).Select(comp => comp.Company_ID).First();

            int q1 = storerepo.GetAll().Where(c => c.Company_ID == compid).GroupBy(x => x.City_ID).Select(g => new
            {
                Company_ID = g.Key
            }).Count();

            return q1;
        }

    }
}
