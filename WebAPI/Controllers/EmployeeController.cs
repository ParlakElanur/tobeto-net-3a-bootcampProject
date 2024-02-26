using Business.Abstracts;
using Business.Requests.Employee;
using Business.Responses.Employee;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet("id")]
        public async Task<IDataResult<GetByIdEmployeeResponse>> GetAsync(int id)
        {
            return await _employeeService.GetAsync(id);
        }
        [HttpPost]
        public async Task<IDataResult<CreateEmployeeResponse>> AddAsync(CreateEmployeeRequest request)
        {
            return await _employeeService.AddAsync(request);
        }
        [HttpPut]
        public async Task<IDataResult<UpdateEmployeeResponse>> UpdateAsync(UpdateEmployeeRequest request)
        {
            return await _employeeService.UpdateAsync(request);
        }
        [HttpDelete]
        public async Task<IDataResult<DeleteEmployeeResponse>> DeleteAsync(DeleteEmployeeRequest request)
        {
            return await _employeeService.DeleteAsync(request);
        }
        [HttpGet]
        public async Task<IDataResult<List<GetAllEmployeeResponse>>> GetAll()
        {
            return await _employeeService.GetAllAsync();
        }
    }
}
