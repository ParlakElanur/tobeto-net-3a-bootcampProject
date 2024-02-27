using Business.Abstracts;
using Business.Requests.Application;
using Business.Responses.Application;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : BaseController
    {
        private readonly IApplicationService _applicationService;
        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return HandleDataResult(await _applicationService.GetAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateApplicationRequest request)
        {
            return HandleResult(await _applicationService.AddAsync(request));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateApplicationRequest request)
        {
            return HandleResult(await _applicationService.UpdateAsync(request));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(DeleteApplicationRequest request)
        {
            return HandleResult(await _applicationService.DeleteAsync(request));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return HandleResult(await _applicationService.GetAllAsync());
        }
    }
}
