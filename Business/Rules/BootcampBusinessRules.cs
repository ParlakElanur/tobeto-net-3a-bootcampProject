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
    public class BootcampBusinessRules : BaseBusinessRules
    {
        private readonly IBootcampRepository _bootcampRepository;
        private readonly IInstructorService _instructorService;
        private readonly IBootcampStateService _bootcampStateService;
        public BootcampBusinessRules(IBootcampRepository bootcampRepository, IInstructorService instructorService, IBootcampStateService bootcampStateService)
        {
            _bootcampRepository = bootcampRepository;
            _instructorService = instructorService;
            _bootcampStateService = bootcampStateService;
        }
        public async Task CheckIfBootcampIdNotExists(int id)
        {
            var isExists = await _bootcampRepository.GetAsync(b => b.Id == id);
            if (isExists is null)
                throw new BusinessException("BootcampId does not exists");
        }
        private async Task CheckIfInstructorNotExists(int id)
        {
            var isExists = await _instructorService.GetById(id);
            if (isExists is null)
                throw new BusinessException("InstructorId does not exists");
        }
        private async Task CheckIfBootcampStateNotExists(int id)
        {
            var isExists = await _bootcampStateService.GetById(id);
            if (isExists is null)
                throw new BusinessException("BootcampStateId does not exists");
        }
        public async Task CheckIfBootcampNotExists(int instructorId, int bootcampStateId)
        {
            await CheckIfInstructorNotExists(instructorId);
            await CheckIfBootcampStateNotExists(bootcampStateId);
        }
    }
}
