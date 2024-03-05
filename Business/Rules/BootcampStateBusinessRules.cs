using Business.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;
using DataAccess.Concretes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class BootcampStateBusinessRules : BaseBusinessRules
    {
        private readonly IBootcampStateRepository _bootcampStateRepository;
        public BootcampStateBusinessRules(IBootcampStateRepository bootcampStateRepository)
        {
            _bootcampStateRepository = bootcampStateRepository;
        }
        public async Task CheckIfBootcampStateIdNotExists(int id) 
        {
            var isExists = await _bootcampStateRepository.GetAsync(a => a.Id == id);
            if (isExists is null)
                throw new BusinessException("BootcampStateId does not exists");
        }
        public async Task CheckIfBootcampStateNameNotExists(string bootcampStateName)
        {
            var isExists = await _bootcampStateRepository.GetAsync(a => a.Name == bootcampStateName);
            if (isExists is not null)
                throw new BusinessException("BootcampStateName already exists");
        }
    }
}
