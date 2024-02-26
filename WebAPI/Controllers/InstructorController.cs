using Business.Abstracts;
using Business.Requests.Instructor;
using Business.Responses.Instructor;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorService _instructorService;
        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }
        [HttpGet("id")]
        public async Task<IDataResult<GetByIdInstructorResponse>> GetAsync(int id)
        {
            return await _instructorService.GetAsync(id);
        }
        [HttpPost]
        public async Task<IDataResult<CreateInstructorResponse>> AddAsync(CreateInstructorRequest request)
        {
            return await _instructorService.AddAsync(request);
        }
        [HttpPut]
        public async Task<IDataResult<UpdateInstructorResponse>> UpdateAsync(UpdateInstructorRequest request)
        {
            return await _instructorService.UpdateAsync(request);
        }
        [HttpDelete]
        public async Task<IDataResult<DeleteInstructorResponse>> DeleteAsync(DeleteInstructorRequest request)
        {
            return await _instructorService.DeleteAsync(request);
        }
        [HttpGet] 
        public async Task<IDataResult<List<GetAllInstructorResponse>>> GetAllAsync()
        {
            return await _instructorService.GetAllAsync();
        }
    }
}
