using AutoMapper;
using Business.Abstracts;
using Business.Requests.Application;
using Business.Responses.Application;
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

        public ApplicationManager(IApplicationRepository applicationRepository, IMapper mapper)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
        }
        public async Task<IDataResult<GetByIdApplicationResponse>> GetAsync(int id)
        {
            Application application = await _applicationRepository.GetAsync(a => a.Id == id);
            GetByIdApplicationResponse applicationResponse = _mapper.Map<GetByIdApplicationResponse>(application);

            return new SuccessDataResult<GetByIdApplicationResponse>(applicationResponse, "Received successfully");
        }
        public async Task<IDataResult<CreateApplicationResponse>> AddAsync(CreateApplicationRequest request)
        {
            Application application = _mapper.Map<Application>(request);
            application.CreatedDate = DateTime.UtcNow;
            await _applicationRepository.AddAsync(application);

            CreateApplicationResponse applicationResponse = _mapper.Map<CreateApplicationResponse>(application);
            return new SuccessDataResult<CreateApplicationResponse>(applicationResponse, "Added successfully");
        }
        public async Task<IDataResult<UpdateApplicationResponse>> UpdateAsync(UpdateApplicationRequest request)
        {
            Application application = _mapper.Map<Application>(request);
            application.UpdatedDate = DateTime.UtcNow;
            await _applicationRepository.UpdateAsync(application);

            UpdateApplicationResponse applicationResponse = _mapper.Map<UpdateApplicationResponse>(application);
            return new SuccessDataResult<UpdateApplicationResponse>(applicationResponse, "Updated successfully");
        }
        public async Task<IResult> DeleteAsync(DeleteApplicationRequest request)
        {
            Application application = await _applicationRepository.GetAsync(a => a.Id == request.Id);
            application.DeletedDate = DateTime.UtcNow;
            await _applicationRepository.DeleteAsync(application);

            return new SuccessResult("Deleted successfully");
        }

        public async Task<IDataResult<List<GetAllApplicationResponse>>> GetAllAsync()
        {
            List<Application> applications =await _applicationRepository.GetAllAsync();
            List<GetAllApplicationResponse> getAllApplications =_mapper.Map<List<GetAllApplicationResponse>>(applications);

            return new SuccessDataResult<List<GetAllApplicationResponse>>(getAllApplications, "Listed successfully");
        }
    }
}
