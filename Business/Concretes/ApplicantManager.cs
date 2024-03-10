using AutoMapper;
using Business.Abstracts;
using Business.Requests.Applicant;
using Business.Responses.Applicant;
using Business.Rules;
using Core.Aspect.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
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
        private readonly ApplicantBusinessRules _rules;

        public ApplicantManager(IApplicantRepository applicantRepository, IMapper mapper, ApplicantBusinessRules rules)
        {
            _applicantRepository = applicantRepository;
            _mapper = mapper;
            _rules = rules;
        }
        public async Task<IDataResult<GetByIdApplicantResponse>> GetAsync(int id)
        {
            await _rules.CheckIfApplicantIdNotExists(id);
            Applicant applicant = await _applicantRepository.GetAsync(a => a.Id == id);
            GetByIdApplicantResponse applicantResponse = _mapper.Map<GetByIdApplicantResponse>(applicant);

            return new SuccessDataResult<GetByIdApplicantResponse>(applicantResponse, "Received successfully");
        }
        [LogAspect(typeof(MssqlLogger))]
        public async Task<IDataResult<CreateApplicantResponse>> AddAsync(CreateApplicantRequest request)
        {
            Applicant applicant = _mapper.Map<Applicant>(request);
            await _applicantRepository.AddAsync(applicant);
            CreateApplicantResponse applicantResponse = _mapper.Map<CreateApplicantResponse>(applicant);

            return new SuccessDataResult<CreateApplicantResponse>(applicantResponse, "Added successfully");
        }
        public async Task<IDataResult<UpdateApplicantResponse>> UpdateAsync(UpdateApplicantRequest request)
        {
            await _rules.CheckIfApplicantIdNotExists(request.Id);

            //Applicant applicant = _mapper.Map<Applicant>(request);
            Applicant applicant = await _applicantRepository.GetAsync(a => a.Id == request.Id);
            applicant.UserName = request.UserName;
            applicant.FirstName = request.FirstName;
            applicant.LastName = request.LastName;
            applicant.DateOfBirth = request.DateOfBirth;
            applicant.Email = request.Email;
            applicant.Password = request.Password;
            applicant.About = request.About;
            await _applicantRepository.UpdateAsync(applicant);

            UpdateApplicantResponse applicantResponse = _mapper.Map<UpdateApplicantResponse>(applicant);
            return new SuccessDataResult<UpdateApplicantResponse>(applicantResponse, "Updated successfully");
        }
        public async Task<IResult> DeleteAsync(DeleteApplicantRequest request)
        {
            await _rules.CheckIfApplicantIdNotExists(request.Id);
            Applicant applicant = await _applicantRepository.GetAsync(a => a.Id == request.Id);
            await _applicantRepository.DeleteAsync(applicant);

            return new SuccessResult("Deleted successfully");
        }
        [LogAspect(typeof(MongoDbLogger))]
        public async Task<IDataResult<List<GetAllApplicantResponse>>> GetAllAsync()
        {
            List<Applicant> applicants = await _applicantRepository.GetAllAsync();
            List<GetAllApplicantResponse> getAllApplicants = _mapper.Map<List<GetAllApplicantResponse>>(applicants);

            return new SuccessDataResult<List<GetAllApplicantResponse>>(getAllApplicants, "Listed successfully");
        }
        public async Task<GetByIdApplicantResponse> GetById(int id)
        {
            Applicant applicant = await _applicantRepository.GetAsync(a => a.Id == id);
            GetByIdApplicantResponse applicantResponse = _mapper.Map<GetByIdApplicantResponse>(applicant);

            return applicantResponse;
        }
    }
}
