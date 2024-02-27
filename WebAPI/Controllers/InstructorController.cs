using Business.Abstracts;
using Business.Requests.Instructor;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : BaseController
    {
        private readonly IInstructorService _instructorService;
        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return HandleDataResult(await _instructorService.GetAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateInstructorRequest request)
        {
            return HandleDataResult(await _instructorService.AddAsync(request));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateInstructorRequest request)
        {
            return HandleDataResult(await _instructorService.UpdateAsync(request));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(DeleteInstructorRequest request)
        {
            return HandleResult(await _instructorService.DeleteAsync(request));
        }
        [HttpGet] 
        public async Task<IActionResult> GetAllAsync()
        {
            return HandleDataResult(await _instructorService.GetAllAsync());
        }
    }
}
