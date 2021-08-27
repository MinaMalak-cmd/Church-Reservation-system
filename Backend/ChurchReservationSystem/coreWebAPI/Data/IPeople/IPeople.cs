using coreWebAPI.Data.IRepositories;
using coreWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreWebAPI.Data.IPeople
{
    public interface  IPeople : IRepository<Person>
    {
        bool IsExisted(int id);
        bool isAdmin(Person person);
    }
}
