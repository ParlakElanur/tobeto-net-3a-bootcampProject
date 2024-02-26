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
    public class BootcampStateController : ControllerBase
    {
        private readonly IBootcampStateService _bootcampStateService;

        public BootcampStateController(IBootcampStateService bootcampStateService)
        {
            _bootcampStateService = bootcampStateService;
        }
        [HttpGet("id")]
        public async Task<IDataResult<GetByIdBootcampStateResponse>> GetAsync(int id)
        {
            return await _bootcampStateService.GetAsync(id);
        }
        [HttpPost]
        public async Task<IDataResult<CreateBootcampStateResponse>> AddAsync(CreateBootcampStateRequest request)
        {
            return await _bootcampStateService.AddAsync(request);
        }
        [HttpPut]
        public async Task<IDataResult<UpdateBootcampStateResponse>> UpdateAsync(UpdateBootcampStateRequest request)
        {
            return await _bootcampStateService.UpdateAsync(request);
        }
        [HttpDelete]
        public async Task<IDataResult<DeleteBootcampStateResponse>> DeleteAsync(DeleteBootcampStateRequest request)
        {
            return await _bootcampStateService.DeleteAsync(request);
        }
        [HttpGet]
        public async Task<IDataResult<List<GetAllBootcampStateResponse>>> GetAllAsync()
        {
            return await _bootcampStateService.GetAllAsync();
        }
    }
}
