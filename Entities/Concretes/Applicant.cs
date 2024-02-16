using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Applicant : User
    {
        public int InstructorId { get; set; }
        public string About { get; set; }

        public Instructor Instructor { get; set; }
    }
}
