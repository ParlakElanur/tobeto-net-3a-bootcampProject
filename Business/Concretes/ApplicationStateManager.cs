using AutoMapper;
using Business.Abstracts;
using Business.Requests.ApplicationState;
using Business.Responses.ApplicationState;
using Business.Rules;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Concretes.Repositories;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ApplicationStateManager : IApplicationStateService
    {
        private readonly IApplicationStateRepository _applicationStateRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationStateBusinessRules _rules;
        public ApplicationStateManager(IApplicationStateRepository applicationStateRepository, IMapper mapper, ApplicationStateBusinessRules rules)
        {
            _applicationStateRepository = applicationStateRepository;
            _mapper = mapper;
            _rules = rules;
        }
        public async Task<IDataResult<GetByIdApplicationStateResponse>> GetAsync(int id)
        {
            await _rules.CheckIfApplicationStateIdNotExists(id);
            ApplicationState applicationState = await _applicationStateRepository.GetAsync(a => a.Id == id);
            GetByIdApplicationStateResponse applicationStateResponse = _mapper.Map<GetByIdApplicationStateResponse>(applicationState);

            return new SuccessDataResult<GetByIdApplicationStateResponse>(applicationStateResponse, "Received successfully");
        }
        public async Task<IDataResult<CreateApplicationStateResponse>> AddAsync(CreateApplicationStateRequest request)
        {
            await _rules.CheckIfApplicationStateNameNotExists(request.Name);
            ApplicationState applicationState = _mapper.Map<ApplicationState>(request);
            applicationState.CreatedDate = DateTime.UtcNow;
            await _applicationStateRepository.AddAsync(applicationState);

            CreateApplicationStateResponse applicationStateResponse = _mapper.Map<CreateApplicationStateResponse>(applicationState);
            return new SuccessDataResult<CreateApplicationStateResponse>(applicationStateResponse, "Added successfully");
        }
        public async Task<IDataResult<UpdateApplicationStateResponse>> UpdateAsync(UpdateApplicationStateRequest request)
        {
            await _rules.CheckIfApplicationStateIdNotExists(request.Id);
            ApplicationState applicationState = _mapper.Map<ApplicationState>(request);
            applicationState.UpdatedDate = DateTime.UtcNow;
            await _applicationStateRepository.UpdateAsync(applicationState);

            UpdateApplicationStateResponse applicationStateResponse = _mapper.Map<UpdateApplicationStateResponse>(applicationState);
            return new SuccessDataResult<UpdateApplicationStateResponse>(applicationStateResponse, "Updated successfully");
        }
        public async Task<IResult> DeleteAsync(DeleteApplicationStateRequest request)
        {
            await _rules.CheckIfApplicationStateIdNotExists(request.Id);
            ApplicationState applicationState = await _applicationStateRepository.GetAsync(a => a.Id == request.Id);
            applicationState.DeletedDate = DateTime.UtcNow;
            await _applicationStateRepository.DeleteAsync(applicationState);

            return new SuccessResult("Deleted successfully");
        }
        public async Task<IDataResult<List<GetAllApplicationStateResponse>>> GetAllAsync()
        {
            List<ApplicationState> applicationStates = await _applicationStateRepository.GetAllAsync();
            List<GetAllApplicationStateResponse> getAllApplicationStates = _mapper.Map<List<GetAllApplicationStateResponse>>(applicationStates);

            return new SuccessDataResult<List<GetAllApplicationStateResponse>>(getAllApplicationStates, "Listed successfully");
        }

        public async Task<GetByIdApplicationStateResponse> GetById(int id)
        {
            ApplicationState applicationState = await _applicationStateRepository.GetAsync(a => a.Id == id);
            GetByIdApplicationStateResponse applicationStateResponse = _mapper.Map<GetByIdApplicationStateResponse>(applicationState);

            return applicationStateResponse;
        }
    }
}
