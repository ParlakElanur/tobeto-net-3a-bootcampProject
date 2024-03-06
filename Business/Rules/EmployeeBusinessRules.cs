using Core.CrossCuttingConcerns.Rules;
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
    public class EmployeeBusinessRules : BaseBusinessRules
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeBusinessRules(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task CheckIfEmployeeIdNotExists(int id) 
        {
            var isExists = await _employeeRepository.GetAsync(a => a.Id == id);
            if (isExists is null)
                throw new BusinessException("EmployeeId does not exists");
        }
    }
}
