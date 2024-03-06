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
    public class ApplicationStateBusinessRules : BaseBusinessRules
    {
        private readonly IApplicationStateRepository _applicationStateRepository;
        public ApplicationStateBusinessRules(IApplicationStateRepository applicationStateRepository)
        {
            _applicationStateRepository = applicationStateRepository;
        }
        public async Task CheckIfApplicationStateIdNotExists(int id)
        {
            var isExists =await _applicationStateRepository.GetAsync(a => a.Id == id);
            if(isExists is null)
                throw new BusinessException("ApplicationStateId does not exists");
        }
        public async Task CheckIfApplicationStateNameNotExists(string applicationStateName)
        {
            var isExists = await _applicationStateRepository.GetAsync(a =>a.Name==applicationStateName);
            if (isExists is not null)
                throw new BusinessException("ApplicationStateName already exists");
        }
    }
}
