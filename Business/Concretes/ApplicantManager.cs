using AutoMapper;
using Business.Abstracts;
using Business.Requests.Applicant;
using Business.Responses.Applicant;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ApplicantManager : IApplicantService
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IMapper _mapper;

        public ApplicantManager(IApplicantRepository applicantRepository, IMapper mapper)
        {
            _applicantRepository = applicantRepository;
            _mapper = mapper;
        }
        public async Task<GetByIdApplicantResponse> GetAsync(int id)
        {
            Applicant applicant = await _applicantRepository.GetAsync(a => a.Id == id);
            GetByIdApplicantResponse applicantResponse = _mapper.Map<GetByIdApplicantResponse>(applicant);

            return applicantResponse;
        }
        public async Task<CreateApplicantResponse> AddAsync(CreateApplicantRequest request)
        {
            Applicant applicant = _mapper.Map<Applicant>(request);
            applicant.CreatedDate = DateTime.UtcNow;
            await _applicantRepository.AddAsync(applicant);

            CreateApplicantResponse applicantResponse = _mapper.Map<CreateApplicantResponse>(applicant);

            return applicantResponse;
        }
        public async Task<UpdateApplicantResponse> UpdateAsync(UpdateApplicantRequest request)
        {
            Applicant applicant = _mapper.Map<Applicant>(request);
            applicant.UpdatedDate = DateTime.UtcNow;
            await _applicantRepository.UpdateAsync(applicant);

            UpdateApplicantResponse applicantResponse = _mapper.Map<UpdateApplicantResponse>(applicant);
            return applicantResponse;
        }
        public async Task<DeleteApplicantResponse> DeleteAsync(DeleteApplicantRequest request)
        {
            Applicant applicant = await _applicantRepository.GetAsync(a => a.Id == request.Id);
            applicant.DeletedDate = DateTime.UtcNow;
            await _applicantRepository.DeleteAsync(applicant);

            DeleteApplicantResponse applicantResponse = _mapper.Map<DeleteApplicantResponse>(applicant);

            return applicantResponse;
        }

        public async Task<List<GetAllApplicantResponse>> GetAllAsync()
        {
            List<Applicant> applicants = await _applicantRepository.GetAllAsync();
            List<GetAllApplicantResponse> getAllApplicants = _mapper.Map<List<GetAllApplicantResponse>>(applicants);

            return getAllApplicants;
        }

    }
}
