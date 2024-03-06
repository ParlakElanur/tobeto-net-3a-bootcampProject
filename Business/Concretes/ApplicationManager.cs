using AutoMapper;
using Business.Abstracts;
using Business.Requests.Application;
using Business.Responses.Application;
using Business.Rules;
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
    public class ApplicationManager : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationBusinessRules _rules;
        public ApplicationManager(IApplicationRepository applicationRepository, IMapper mapper, ApplicationBusinessRules rules)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
            _rules = rules;
        }
        public async Task<IDataResult<GetByIdApplicationResponse>> GetAsync(int id)
        {
            await _rules.CheckIfApplicationIdNotExists(id);
            Application application = await _applicationRepository.GetAsync(a => a.Id == id);
            GetByIdApplicationResponse applicationResponse = _mapper.Map<GetByIdApplicationResponse>(application);

            return new SuccessDataResult<GetByIdApplicationResponse>(applicationResponse, "Received successfully");
        }
        public async Task<IDataResult<CreateApplicationResponse>> AddAsync(CreateApplicationRequest request)
        {
            await _rules.CheckApplicationNotExists(request.ApplicantId, request.BootcampId, request.ApplicationStateId);
            Application application = _mapper.Map<Application>(request);
            await _applicationRepository.AddAsync(application);

            CreateApplicationResponse applicationResponse = _mapper.Map<CreateApplicationResponse>(application);
            return new SuccessDataResult<CreateApplicationResponse>(applicationResponse, "Added successfully");
        }
        public async Task<IDataResult<UpdateApplicationResponse>> UpdateAsync(UpdateApplicationRequest request)
        {
            await _rules.CheckIfApplicationIdNotExists(request.Id);
            //Application application = _mapper.Map<Application>(request);
            Application application = await _applicationRepository.GetAsync(a => a.Id == request.Id);
            application.ApplicantId = request.ApplicantId;
            application.BootcampId = request.BootcampId;
            application.ApplicationStateId = request.ApplicationStateId;
            await _applicationRepository.UpdateAsync(application);

            UpdateApplicationResponse applicationResponse = _mapper.Map<UpdateApplicationResponse>(application);
            return new SuccessDataResult<UpdateApplicationResponse>(applicationResponse, "Updated successfully");
        }
        public async Task<IResult> DeleteAsync(DeleteApplicationRequest request)
        {
            await _rules.CheckIfApplicationIdNotExists(request.Id);
            Application application = await _applicationRepository.GetAsync(a => a.Id == request.Id);
            await _applicationRepository.DeleteAsync(application);

            return new SuccessResult("Deleted successfully");
        }
        public async Task<IDataResult<List<GetAllApplicationResponse>>> GetAllAsync()
        {
            List<Application> applications = await _applicationRepository.GetAllAsync();
            List<GetAllApplicationResponse> getAllApplications = _mapper.Map<List<GetAllApplicationResponse>>(applications);

            return new SuccessDataResult<List<GetAllApplicationResponse>>(getAllApplications, "Listed successfully");
        }
    }
}
