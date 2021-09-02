using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreWebAPI.Models
{
    public class Mass
    {
        //        Mass: name, max number, current seats, date, hour, duration, pIDs
        //* One to many foreign key
        public int MassId { get; set; }
        public string Name { get; set; }
        public int maxCapacity { get; set; }
        public int currentSeats { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
        public ICollection<Person> People { get; set; }
    }
}
