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
        public BootcampBusinessRules(IBootcampRepository bootcampRepository)
        {
            _bootcampRepository = bootcampRepository;
        }
        public async Task CheckIfBootcampNameNotExists(string bootcampName)
        {
            var isExists = await _bootcampRepository.GetAsync(b => b.Name == bootcampName);
            if (isExists is not null)
                throw new BusinessException("Bootcamp name already exists");
        }
        public async Task CheckIfBootcampNotExists(int id)
        {
            var isExists = await _bootcampRepository.GetAsync(b => b.Id == id);
            if (isExists is null)
                throw new BusinessException("Id does not exists");
        }
    }
}
