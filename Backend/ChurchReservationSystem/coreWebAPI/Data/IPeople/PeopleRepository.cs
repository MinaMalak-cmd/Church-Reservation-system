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
        protected DbSet<Person> DbS;
        public PeopleRepository(ReservationContext ReservationContext):
            base(ReservationContext)
        {
            this.DbS = ReservationContext.People;  
        }
        public  bool isAdmin(Person person)
        {
            //return DbSet.Any(e => e.Name == "admin" & e.telephoneNumber == "3494855958589");
            //return _context.People.Any(e => e.Id == id);
            if (person.Name == "admin" && person.telephoneNumber == "3494855958589") return true;
           return false;
        }
        public override async Task<Person> Post(Person person)
        {

            person.Mass = await this.ReservationContext.Masses.FindAsync(person.MassId);
            person.Mass.currentSeats -= 1;
            //var Mass = person.Mass;
            this.ReservationContext.Entry(person).State = EntityState.Modified;
            await this.ReservationContext.SaveChangesAsync();
            return  person;
        }
       
        public  bool IsExisted(int id)
        {
            return DbS.Any(e => e.Id == id);
        }
    }
}
