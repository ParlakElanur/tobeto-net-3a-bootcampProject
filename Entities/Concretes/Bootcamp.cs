using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Bootcamp:BaseEntity<int>
    {
        public string Name { get; set; }
        public int InstructorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int BootcampStateId { get; set; }

        public Bootcamp()
        {
            Applications = new HashSet<Application>();
        }
        public Bootcamp(string name, int ınstructorId, DateTime startDate, DateTime endDate, int bootcampStateId)
        {
            Name = name;
            InstructorId = ınstructorId;
            StartDate = startDate;
            EndDate = endDate;
            BootcampStateId = bootcampStateId;
        }
        public ICollection<Application> Applications { get; set; }
        public Instructor Instructor { get; set; }
        public BootcampState BootcampState { get; set; }    
    }
}
