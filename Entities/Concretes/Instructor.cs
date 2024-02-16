using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Instructor : User
    {
        public Instructor()
        {
            Applicants = new HashSet<Applicant>();
        }
        public string CompanyName { get; set; }
        public ICollection<Applicant> Applicants { get; set; }
    }
}
