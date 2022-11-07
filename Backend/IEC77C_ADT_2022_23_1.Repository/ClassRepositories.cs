using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IEC77C_ADT_2022_23_1.Models;
using Microsoft.EntityFrameworkCore;

namespace IEC77C_ADT_2022_23_1.Repository
{
    class StoreRepository : Repository<Store>
    {
        public StoreRepository(DbContext context) : base(context)
        {
        }
    }
}
