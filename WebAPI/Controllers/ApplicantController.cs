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
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService _applicantService;

        public ApplicantController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }
        [HttpGet("id")]
        public async Task<IDataResult<GetByIdApplicantResponse>> GetAsync(int id)
        {
            return await _applicantService.GetAsync(id);
        }
        [HttpPost]
        public async Task<IDataResult<CreateApplicantResponse>> AddAsync(CreateApplicantRequest request)
        {
            return await _applicantService.AddAsync(request);
        }
        [HttpPut]
        public async Task<IDataResult<UpdateApplicantResponse>> UpdateAsync(UpdateApplicantRequest request)
        {
            return await _applicantService.UpdateAsync(request);
        }
        [HttpDelete] 
        public async Task<IDataResult<DeleteApplicantResponse>> DeleteAsync(DeleteApplicantRequest request)
        {
            return await _applicantService.DeleteAsync(request);
        }

        [HttpGet]
        public async Task<IDataResult<List<GetAllApplicantResponse>>> GetAll()
        {
            return await _applicantService.GetAllAsync();
        }

    }
}
