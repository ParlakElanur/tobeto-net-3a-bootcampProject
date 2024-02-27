using Business.Abstracts;
using Business.Requests.Application;
using Business.Requests.BootcampState;
using Business.Responses.Application;
using Business.Responses.BootcampState;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BootcampStateController : BaseController
    {
        private readonly IBootcampStateService _bootcampStateService;

        public BootcampStateController(IBootcampStateService bootcampStateService)
        {
            _bootcampStateService = bootcampStateService;
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return HandleDataResult(await _bootcampStateService.GetAsync(id));            
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateBootcampStateRequest request)
        {
            return HandleDataResult(await _bootcampStateService.AddAsync(request));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateBootcampStateRequest request)
        {
            return HandleDataResult(await _bootcampStateService.UpdateAsync(request));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(DeleteBootcampStateRequest request)
        {
            return HandleResult(await _bootcampStateService.DeleteAsync(request));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return HandleDataResult(await _bootcampStateService.GetAllAsync());
        }
    }
}
