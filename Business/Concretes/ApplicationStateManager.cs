using AutoMapper;
using Business.Abstracts;
using Business.Requests.ApplicationState;
using Business.Responses.Application;
using Business.Responses.ApplicationState;
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
    public class ApplicationStateManager: IApplicationStateService
    {
        private readonly IApplicationStateRepository _applicationStateRepository;
        private readonly IMapper _mapper;

        public ApplicationStateManager(IApplicationStateRepository applicationStateRepository, IMapper mapper)
        {
            _applicationStateRepository = applicationStateRepository;
            _mapper = mapper;
        }
        public async Task<GetByIdApplicationStateResponse> GetAsync(int id)
        {
            ApplicationState applicationState =await _applicationStateRepository.GetAsync(a => a.Id == id);
            GetByIdApplicationStateResponse applicationStateResponse=_mapper.Map<GetByIdApplicationStateResponse>(applicationState);

            return applicationStateResponse;
        }
        public async Task<CreateApplicationStateResponse> AddAsync(CreateApplicationStateRequest request)
        {
            ApplicationState applicationState=_mapper.Map<ApplicationState>(request);
            applicationState.CreatedDate = DateTime.UtcNow;
            await _applicationStateRepository.AddAsync(applicationState);

            CreateApplicationStateResponse applicationStateResponse=_mapper.Map<CreateApplicationStateResponse>(applicationState);
            return applicationStateResponse;
        }
        public async Task<UpdateApplicationStateResponse> UpdateAsync(UpdateApplicationStateRequest request)
        {
            ApplicationState applicationState = _mapper.Map<ApplicationState>(request);
            applicationState.UpdatedDate = DateTime.UtcNow;
            await _applicationStateRepository.UpdateAsync(applicationState);

            UpdateApplicationStateResponse applicationStateResponse = _mapper.Map<UpdateApplicationStateResponse>(applicationState);
            return applicationStateResponse;
        }
        public Task<DeleteApplicationStateResponse> DeleteAsync(DeleteApplicationStateRequest request)
        {
            throw new NotImplementedException();
        }
        public Task<List<GetAllApplicationStateResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
