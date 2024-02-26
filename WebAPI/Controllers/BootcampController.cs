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
    public class BootcampController : ControllerBase
    {
        private readonly IBootcampService _bootcampService;

        public BootcampController(IBootcampService bootcampService)
        {
            _bootcampService = bootcampService;
        }
        [HttpGet("id")]
        public async Task<IDataResult<GetByIdBootcampResponse>> GetAsync(int id)
        {
            return await _bootcampService.GetAsync(id);
        }
        [HttpPost]
        public async Task<IDataResult<CreateBootcampResponse>> AddAsync(CreateBootcampRequest request)
        {
            return await _bootcampService.AddAsync(request);
        }
        [HttpPut]
        public async Task<IDataResult<UpdateBootcampResponse>> UpdateAsync(UpdateBootrcampRequest request)
        {
            return await _bootcampService.UpdateAsync(request);
        }
        [HttpDelete]
        public async Task<IDataResult<DeleteBootcampResponse>> DeleteAsync(DeleteBootcampRequest request)
        {
            return await _bootcampService.DeleteAsync(request);
        }
        [HttpGet]
        public async Task<IDataResult<List<GetAllBootcampResponse>>> GetAllAsync()
        {
            return await _bootcampService.GetAllAsync();
        }
    }
}
