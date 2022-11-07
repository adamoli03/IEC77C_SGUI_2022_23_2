using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEC77C_ADT_2022_23_1.Repository
{
    public interface IRepository<T> where T : class
    {
        
        public IEnumerable<T> GetAll { get; }
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T FindById(int ID);
    }
}
