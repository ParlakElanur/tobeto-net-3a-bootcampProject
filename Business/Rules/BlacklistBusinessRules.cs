using Business.Abstracts;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class BlacklistBusinessRules : BaseBusinessRules
    {
        private readonly IBlacklistRepository _blacklistRepository;
        private readonly IApplicantService _applicantService;
        public BlacklistBusinessRules(IBlacklistRepository blacklistRepository,IApplicantService applicantService)
        {
            _blacklistRepository = blacklistRepository;
            _applicantService = applicantService;
        }
        public async Task CheckIfBlacklistIdNotExists(int id)
        {
            var isExists = await _blacklistRepository.GetAsync(b => b.Id == id);
            if (isExists is null)
                throw new BusinessException("BlacklistId does not exists");
        }
        public async Task CheckIfApplicantNotExists(int id) 
        {
            var isExists = await _applicantService.GetById(id);
            if (isExists is null)
                throw new BusinessException("ApplicantId does not exists");
        }
    }
}
