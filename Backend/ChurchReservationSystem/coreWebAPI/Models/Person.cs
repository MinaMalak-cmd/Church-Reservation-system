using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace coreWebAPI.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime registerationDate { get; set; }
        public DateTime reservationDate { get; set; }
        public string telephoneNumber { get; set; }
        //public bool IsComplete { get; set; }
        public int MassId { get; set; }
        public Mass Mass { get; set; }
    }
}
