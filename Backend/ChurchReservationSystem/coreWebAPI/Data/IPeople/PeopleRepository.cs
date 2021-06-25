using coreWebAPI.Data.IRepositories;
using coreWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreWebAPI.Data.IPeople
{
    public class PeopleRepository : Repository<Person>, IPeople
    {
        //protected DbSet<Person> DbS;
        public PeopleRepository(ReservationContext ReservationContext):
            base(ReservationContext)
        {
            this.DbSet = ReservationContext.People;  
        }
        public  bool isAdmin(Person person)
        {
            return DbSet.Any(e => e.Name == "admin" & e.telephoneNumber == "3494855958589");
            //return _context.People.Any(e => e.Id == id);

        }

        public  bool IsExisted(int id)
        {
            return  DbSet.Any(e => e.Id == id);
        }
    }
}
