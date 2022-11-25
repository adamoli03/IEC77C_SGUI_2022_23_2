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
    public class CompanyService
    {
        private CompanyContext _context;
        private CompanyLogic _logic;

        public CompanyService(CompanyContext context)
        {
            _context = context;
            CompanyRepository comprepo = new CompanyRepository(context);
            StoreRepository storerepo = new StoreRepository(context);

            _logic = new CompanyLogic(comprepo, storerepo);
        }

        public void Add(Company company)
        {
            _logic.Add(company);
        }

        public List<Company> GetAll()
        {
            return (List<Company>)_logic.GetAll();
        }
        public Company FindByID(int id)
        {
            return (Company)_logic.FindById(id);
        }
        public void Update(Company company)
        {
            _logic.Update(company);
        }
        public void Delete(Company company)
        {
            _logic.Delete(company);
        }
    }
}
