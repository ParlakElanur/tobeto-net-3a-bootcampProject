using Business.Abstracts;
using Business.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
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
        public async Task CheckIfApplicantIdNotExists(int id) 
        {
            var isExists = await _applicantRepository.GetAsync(a => a.Id == id);
            if (isExists is null)
                throw new BusinessException("ApplicantId does not exists");
        }
    }
}
