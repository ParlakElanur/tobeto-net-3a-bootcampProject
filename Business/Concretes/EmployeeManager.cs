using AutoMapper;
using Business.Abstracts;
using Business.Requests.Employee;
using Business.Responses.Employee;
using Business.Rules;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly EmployeeBusinessRules _rules;
        public EmployeeManager(IEmployeeRepository employeeRepository, IMapper mapper, EmployeeBusinessRules rules)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _rules = rules;
        }
        public async Task<IDataResult<GetByIdEmployeeResponse>> GetAsync(int id)
        {
            await _rules.CheckIfEmployeeIdNotExists(id);
            Employee employee = await _employeeRepository.GetAsync(e => e.Id == id);
            GetByIdEmployeeResponse employeeResponse = _mapper.Map<GetByIdEmployeeResponse>(employee);

            return new SuccessDataResult<GetByIdEmployeeResponse>(employeeResponse, "Received successfully");
        }
        public async Task<IDataResult<CreateEmployeeResponse>> AddAsync(CreateEmployeeRequest request)
        {
            Employee employee = _mapper.Map<Employee>(request);
            employee.CreatedDate = DateTime.UtcNow;
            await _employeeRepository.AddAsync(employee);

            CreateEmployeeResponse employeeResponse = _mapper.Map<CreateEmployeeResponse>(employee);
            return new SuccessDataResult<CreateEmployeeResponse>(employeeResponse, "Added successfully");
        }
        public async Task<IDataResult<UpdateEmployeeResponse>> UpdateAsync(UpdateEmployeeRequest request)
        {
            await _rules.CheckIfEmployeeIdNotExists(request.Id);
            Employee employee = _mapper.Map<Employee>(request);
            employee.UpdatedDate = DateTime.Now;
            await _employeeRepository.UpdateAsync(employee);

            UpdateEmployeeResponse employeeResponse = _mapper.Map<UpdateEmployeeResponse>(employee);
            return new SuccessDataResult<UpdateEmployeeResponse>(employeeResponse, "Updated successfully");
        }
        public async Task<IResult> DeleteAsync(DeleteEmployeeRequest request)
        {
            await _rules.CheckIfEmployeeIdNotExists(request.Id);
            Employee employee = await _employeeRepository.GetAsync(e => e.Id == request.Id);
            employee.DeletedDate = DateTime.Now;
            await _employeeRepository.DeleteAsync(employee);

            return new SuccessResult("Deleted successfully");
        }
        public async Task<IDataResult<List<GetAllEmployeeResponse>>> GetAllAsync()
        {
            List<Employee> employees = await _employeeRepository.GetAllAsync();
            List<GetAllEmployeeResponse> getAllEmployees = _mapper.Map<List<GetAllEmployeeResponse>>(employees);

            return new SuccessDataResult<List<GetAllEmployeeResponse>>(getAllEmployees, "Listed successfully");
        }
    }
}
