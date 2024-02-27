using Business.Abstracts;
using Business.Requests.Applicant;
using Business.Responses.Applicant;
using Core.Utilities.Results;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : BaseController
    {
        private readonly IApplicantService _applicantService;

        public ApplicantController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return HandleDataResult(await _applicantService.GetAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateApplicantRequest request)
        {
            return HandleDataResult(await _applicantService.AddAsync(request));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateApplicantRequest request)
        {
            return HandleDataResult(await _applicantService.UpdateAsync(request));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(DeleteApplicantRequest request)
        {
            return HandleResult(await _applicantService.DeleteAsync(request));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return HandleDataResult(await _applicantService.GetAllAsync());
        }
    }
}
