using coreWebAPI.Data.IRepositories;
using coreWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreWebAPI.Data.IMass
{
    public interface IMass : IRepository<Mass>
    {
        bool AreSeatsAvail(Mass mass);
    }
}
