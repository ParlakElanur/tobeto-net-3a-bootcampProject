using AutoMapper;
using Business.Abstracts;
using Business.Requests.Applicant;
using Business.Responses.Applicant;
using Core.Utilities.Results;
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
        public async Task<IDataResult<GetByIdApplicantResponse>> GetAsync(int id)
        {
            Applicant applicant = await _applicantRepository.GetAsync(a => a.Id == id);
            GetByIdApplicantResponse applicantResponse = _mapper.Map<GetByIdApplicantResponse>(applicant);

            return new SuccessDataResult<GetByIdApplicantResponse>(applicantResponse);
        }
        public async Task<IDataResult<CreateApplicantResponse>> AddAsync(CreateApplicantRequest request)
        {
            Applicant applicant = _mapper.Map<Applicant>(request);
            applicant.CreatedDate = DateTime.UtcNow;
            await _applicantRepository.AddAsync(applicant);

            CreateApplicantResponse applicantResponse = _mapper.Map<CreateApplicantResponse>(applicant);

            return new SuccessDataResult<CreateApplicantResponse>(applicantResponse);
        }
        public async Task<IDataResult<UpdateApplicantResponse>> UpdateAsync(UpdateApplicantRequest request)
        {
            Applicant applicant = _mapper.Map<Applicant>(request);
            applicant.UpdatedDate = DateTime.UtcNow;
            await _applicantRepository.UpdateAsync(applicant);

            UpdateApplicantResponse applicantResponse = _mapper.Map<UpdateApplicantResponse>(applicant);
            return new SuccessDataResult<UpdateApplicantResponse>(applicantResponse);
        }
        public async Task<IDataResult<DeleteApplicantResponse>> DeleteAsync(DeleteApplicantRequest request)
        {
            Applicant applicant = await _applicantRepository.GetAsync(a => a.Id == request.Id);
            applicant.DeletedDate = DateTime.UtcNow;
            await _applicantRepository.DeleteAsync(applicant);

            DeleteApplicantResponse applicantResponse = _mapper.Map<DeleteApplicantResponse>(applicant);

            return new SuccessDataResult<DeleteApplicantResponse>(applicantResponse);
        }

        public async Task<IDataResult<List<GetAllApplicantResponse>>> GetAllAsync()
        {
            List<Applicant> applicants = await _applicantRepository.GetAllAsync();
            List<GetAllApplicantResponse> getAllApplicants = _mapper.Map<List<GetAllApplicantResponse>>(applicants);

            return new SuccessDataResult<List<GetAllApplicantResponse>>(getAllApplicants);
        }

    }
}
