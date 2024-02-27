using Business.Abstracts;
using Business.Requests.ApplicationState;
using Business.Responses.ApplicationState;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationStateController : BaseController
    {
        private readonly IApplicationStateService _applicationStateService;

        public ApplicationStateController(IApplicationStateService applicationStateService)
        {
            _applicationStateService = applicationStateService;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return HandleDataResult(await _applicationStateService.GetAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateApplicationStateRequest request)
        {
            return HandleDataResult(await _applicationStateService.AddAsync(request));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateApplicationStateRequest request)
        {
            return HandleDataResult(await _applicationStateService.UpdateAsync(request));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(DeleteApplicationStateRequest request)
        {
            return HandleResult(await _applicationStateService.DeleteAsync(request));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return HandleDataResult(await _applicationStateService.GetAllAsync());
        }
    }
}
