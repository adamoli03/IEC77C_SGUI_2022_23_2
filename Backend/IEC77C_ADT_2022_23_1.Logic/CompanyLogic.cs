using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IEC77C_ADT_2022_23_1.Repository;
using IEC77C_ADT_2022_23_1.Models;


namespace IEC77C_ADT_2022_23_1.Logic
{
    class CompanyLogic
    {
        ICompanyRepository companyrepo;

        public CompanyLogic(ICompanyRepository companyrepo)
        {
            this.companyrepo = companyrepo;
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

        public Company FindByID(int ID)
        {
            return companyrepo.FindById(ID);
        }

        //TODO: CREATE NON CRUD METHODS
    }
}
