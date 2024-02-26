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
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;
        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        [HttpGet("id")]
        public async Task<IDataResult<GetByIdApplicationResponse>> GetAsync(int id)
        {
            return await _applicationService.GetAsync(id);
        }
        [HttpPost]
        public async Task<IDataResult<CreateApplicationResponse>> AddAsync(CreateApplicationRequest request)
        {
            return await _applicationService.AddAsync(request);
        }
        [HttpPut]
        public async Task<IDataResult<UpdateApplicationResponse>> UpdateAsync(UpdateApplicationRequest request)
        {
            return await _applicationService.UpdateAsync(request);
        }
        [HttpDelete]
        public async Task<IDataResult<DeleteApplicationResponse>> DeleteAsync(DeleteApplicationRequest request) 
        {
            return await _applicationService.DeleteAsync(request);
        }
        [HttpGet]
        public async Task<IDataResult<List<GetAllApplicationResponse>>> GetAllAsync()
        {
            return await _applicationService.GetAllAsync();
        }
    }
}
