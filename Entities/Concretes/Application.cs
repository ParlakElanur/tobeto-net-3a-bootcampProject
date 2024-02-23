using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Application:BaseEntity<int>
    {
        public int ApplicantId { get; set; }
        public int BootcampId { get; set; }
        public int ApplicationStateId { get; set; }

        public Application()
        {

        }
        public Application(int applicantId, int bootcampId, int applicationStateId)
        {
            ApplicantId = applicantId;
            BootcampId = bootcampId;
            ApplicationStateId = applicationStateId;
        }
        public Applicant Applicant { get; set; }
        public Bootcamp Bootcamp { get; set; }
        public ApplicationState ApplicationState { get; set; }

    }
}
