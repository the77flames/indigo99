using Indigo99.DomainObjects;
using Indigo99.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indigo99.Data
{
    public interface INewsRepository : IGenericRepository<News> 
    {
        List<News> GetAllByDate(DateTime date);
       
    }
}
