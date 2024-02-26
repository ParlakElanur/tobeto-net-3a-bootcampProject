using AutoMapper;
using Business.Abstracts;
using Business.Requests.ApplicationState;
using Business.Responses.ApplicationState;
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

        public ApplicationStateManager(IApplicationStateRepository applicationStateRepository, IMapper mapper)
        {
            _applicationStateRepository = applicationStateRepository;
            _mapper = mapper;
        }
        public async Task<IDataResult<GetByIdApplicationStateResponse>> GetAsync(int id)
        {
            ApplicationState applicationState = await _applicationStateRepository.GetAsync(a => a.Id == id);
            GetByIdApplicationStateResponse applicationStateResponse = _mapper.Map<GetByIdApplicationStateResponse>(applicationState);

            return new SuccessDataResult<GetByIdApplicationStateResponse>(applicationStateResponse);
        }
        public async Task<IDataResult<CreateApplicationStateResponse>> AddAsync(CreateApplicationStateRequest request)
        {
            ApplicationState applicationState = _mapper.Map<ApplicationState>(request);
            applicationState.CreatedDate = DateTime.UtcNow;
            await _applicationStateRepository.AddAsync(applicationState);

            CreateApplicationStateResponse applicationStateResponse = _mapper.Map<CreateApplicationStateResponse>(applicationState);
            return new SuccessDataResult<CreateApplicationStateResponse>(applicationStateResponse);
        }
        public async Task<IDataResult<UpdateApplicationStateResponse>> UpdateAsync(UpdateApplicationStateRequest request)
        {
            ApplicationState applicationState = _mapper.Map<ApplicationState>(request);
            applicationState.UpdatedDate = DateTime.UtcNow;
            await _applicationStateRepository.UpdateAsync(applicationState);

            UpdateApplicationStateResponse applicationStateResponse = _mapper.Map<UpdateApplicationStateResponse>(applicationState);
            return new SuccessDataResult<UpdateApplicationStateResponse>(applicationStateResponse);
        }
        public async Task<IDataResult<DeleteApplicationStateResponse>> DeleteAsync(DeleteApplicationStateRequest request)
        {
            ApplicationState applicationState = await _applicationStateRepository.GetAsync(a => a.Id == request.Id);
            applicationState.DeletedDate = DateTime.UtcNow;
            await _applicationStateRepository.DeleteAsync(applicationState);

            DeleteApplicationStateResponse applicationStateResponse = _mapper.Map<DeleteApplicationStateResponse>(applicationState);
            return new SuccessDataResult<DeleteApplicationStateResponse>(applicationStateResponse);
        }
        public async Task<IDataResult<List<GetAllApplicationStateResponse>>> GetAllAsync()
        {
            List<ApplicationState> applicationStates=await _applicationStateRepository.GetAllAsync();
            List<GetAllApplicationStateResponse> getAllApplicationStates=_mapper.Map<List<GetAllApplicationStateResponse>>(applicationStates);

            return new SuccessDataResult<List<GetAllApplicationStateResponse>>(getAllApplicationStates);
        }
    }
}
