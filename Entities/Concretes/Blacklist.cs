using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Blacklist : BaseEntity<int>
    {
        public string Reason { get; set; }
        public DateTime Date { get; set; }
        public int ApplicantId { get; set; }

        public Blacklist()
        {
            Applicants = new HashSet<Applicant>();
        }
        public Blacklist(string reason, DateTime date, int applicantId)
        {
            Reason = reason;
            Date = date;
            ApplicantId = applicantId;
        }
        public ICollection<Applicant> Applicants { get; set; }
    }
}
