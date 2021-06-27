using coreWebAPI.Data.IRepositories;
using coreWebAPI.Models;
using coreWebAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreWebAPI.Data.IMass
{
    public class MassRepository : Repository<Mass>, IMass
    {
        protected DbSet<Mass> DbS;
        public MassRepository(ReservationContext reservationContext)
        :base(reservationContext)
        {
            this.DbS = reservationContext.Masses;   
        }
        public bool AreSeatsAvail(Mass mass)
        {
            if (mass.maxCapacity == mass.currentSeats) return false;
            return true;
        }
    }
}
