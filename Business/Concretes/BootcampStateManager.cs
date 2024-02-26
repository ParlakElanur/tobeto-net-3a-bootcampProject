using AutoMapper;
using Business.Abstracts;
using Business.Requests.BootcampState;
using Business.Responses.BootcampState;
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
    public class BootcampStateManager : IBootcampStateService
    {
        private readonly IBootcampStateRepository _bootcampStateRepository;
        private readonly IMapper _mapper;

        public BootcampStateManager(IBootcampStateRepository bootcampStateRepository, IMapper mapper)
        {
            _bootcampStateRepository = bootcampStateRepository;
            _mapper = mapper;
        }
        public async Task<IDataResult<GetByIdBootcampStateResponse>> GetAsync(int id)
        {
            BootcampState bootcampState = await _bootcampStateRepository.GetAsync(b => b.Id == id);
            GetByIdBootcampStateResponse bootcampStateResponse = _mapper.Map<GetByIdBootcampStateResponse>(bootcampState);

            return new SuccessDataResult<GetByIdBootcampStateResponse>(bootcampStateResponse);
        }
        public async Task<IDataResult<CreateBootcampStateResponse>> AddAsync(CreateBootcampStateRequest request)
        {
            BootcampState bootcampState = _mapper.Map<BootcampState>(request);
            bootcampState.CreatedDate = DateTime.UtcNow;
            await _bootcampStateRepository.AddAsync(bootcampState);

            CreateBootcampStateResponse bootcampStateResponse = _mapper.Map<CreateBootcampStateResponse>(bootcampState);
            return new SuccessDataResult<CreateBootcampStateResponse>(bootcampStateResponse);
        }
        public async Task<IDataResult<UpdateBootcampStateResponse>> UpdateAsync(UpdateBootcampStateRequest request)
        {
            BootcampState bootcampState = _mapper.Map<BootcampState>(request);
            bootcampState.UpdatedDate = DateTime.UtcNow;
            await _bootcampStateRepository.UpdateAsync(bootcampState);

            UpdateBootcampStateResponse bootcampStateResponse = _mapper.Map<UpdateBootcampStateResponse>(bootcampState);
            return new SuccessDataResult<UpdateBootcampStateResponse>(bootcampStateResponse);
        }
        public async Task<IDataResult<DeleteBootcampStateResponse>> DeleteAsync(DeleteBootcampStateRequest request)
        {
            BootcampState bootcampState = await _bootcampStateRepository.GetAsync(b => b.Id == request.Id);
            bootcampState.DeletedDate = DateTime.UtcNow;
            await _bootcampStateRepository.DeleteAsync(bootcampState);

            DeleteBootcampStateResponse bootcampStateResponse = _mapper.Map<DeleteBootcampStateResponse>(bootcampState);
            return new SuccessDataResult<DeleteBootcampStateResponse>(bootcampStateResponse);
        }
        public async Task<IDataResult<List<GetAllBootcampStateResponse>>> GetAllAsync()
        {
            List<BootcampState> bootcampStates =await _bootcampStateRepository.GetAllAsync();
            List<GetAllBootcampStateResponse> getAllBootcampStates=_mapper.Map<List<GetAllBootcampStateResponse>>(bootcampStates);

            return new SuccessDataResult<List<GetAllBootcampStateResponse>>(getAllBootcampStates);
        }
    }
}
