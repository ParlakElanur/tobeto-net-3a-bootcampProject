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
    public class InstructorBusinessRules : BaseBusinessRules
    {
        private readonly IInstructorRepository _instructorRepository;
        public InstructorBusinessRules(IInstructorRepository instructorRepository) 
        {
            _instructorRepository = instructorRepository;
        }
        public async Task CheckIfInstructorIdNotExists(int id)
        {
            var isExists = await _instructorRepository.GetAsync(a => a.Id == id);
            if (isExists is null)
                throw new BusinessException("InstructorId does not exists");
        }
    }
}
