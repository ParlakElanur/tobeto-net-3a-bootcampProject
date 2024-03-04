using Business.CrossCuttingConcerns.Rules;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class ApplicantBusinessRules : BaseBusinessRules
    {
        private readonly IApplicantRepository _applicantRepository;
        public ApplicantBusinessRules(IApplicantRepository applicantRepository) 
        { 
            _applicantRepository = applicantRepository;
        }

    }
}
