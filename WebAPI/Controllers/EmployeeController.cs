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
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return HandleDataResult(await _employeeService.GetAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateEmployeeRequest request)
        {
            return HandleDataResult(await _employeeService.AddAsync(request));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateEmployeeRequest request)
        {
            return HandleDataResult(await _employeeService.UpdateAsync(request));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(DeleteEmployeeRequest request)
        {
            return HandleResult(await _employeeService.DeleteAsync(request));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return HandleDataResult(await _employeeService.GetAllAsync());
        }
    }
}
