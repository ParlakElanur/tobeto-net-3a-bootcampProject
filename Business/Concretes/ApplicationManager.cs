using AutoMapper;
using Business.Abstracts;
using Business.Requests.Application;
using Business.Responses.Application;
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

        public ApplicationManager(IApplicationRepository applicationRepository, IMapper mapper)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
        }
        public async Task<GetByIdApplicationResponse> GetAsync(int id)
        {
            Application application = await _applicationRepository.GetAsync(a => a.Id == id);
            GetByIdApplicationResponse applicationResponse = _mapper.Map<GetByIdApplicationResponse>(application);

            return applicationResponse;
        }
        public async Task<CreateApplicationResponse> AddAsync(CreateApplicationRequest request)
        {
            Application application = _mapper.Map<Application>(request);
            application.CreatedDate = DateTime.UtcNow;
            await _applicationRepository.AddAsync(application);

            CreateApplicationResponse applicationResponse = _mapper.Map<CreateApplicationResponse>(application);
            return applicationResponse;
        }
        public async Task<UpdateApplicationResponse> UpdateAsync(UpdateApplicationRequest request)
        {
            Application application = _mapper.Map<Application>(request);
            application.UpdatedDate = DateTime.UtcNow;
            await _applicationRepository.UpdateAsync(application);

            UpdateApplicationResponse applicationResponse = _mapper.Map<UpdateApplicationResponse>(application);
            return applicationResponse;
        }
        public Task<DeleteApplicationResponse> DeleteAsync(DeleteApplicationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetAllApplicationResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
