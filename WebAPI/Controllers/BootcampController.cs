using Business.Abstracts;
using Business.Requests.Application;
using Business.Requests.Bootcamp;
using Business.Responses.Application;
using Business.Responses.Bootcamp;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BootcampController : BaseController
    {
        private readonly IBootcampService _bootcampService;

        public BootcampController(IBootcampService bootcampService)
        {
            _bootcampService = bootcampService;
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return HandleDataResult(await _bootcampService.GetAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateBootcampRequest request)
        {
            return HandleDataResult(await _bootcampService.AddAsync(request));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateBootrcampRequest request)
        {
            return HandleDataResult(await _bootcampService.UpdateAsync(request));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(DeleteBootcampRequest request)
        {
            return HandleResult(await _bootcampService.DeleteAsync(request));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return HandleDataResult(await _bootcampService.GetAllAsync());
        }
    }
}
