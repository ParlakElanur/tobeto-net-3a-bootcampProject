using AutoMapper;
using Business.Abstracts;
using Business.Requests.BootcampState;
using Business.Responses.BootcampState;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class BootcampStateManager: IBootcampStateService
    {
        private readonly IBootcampStateRepository _bootcampStateRepository;
        private readonly IMapper _mapper;

        public BootcampStateManager(IBootcampStateRepository bootcampStateRepository, IMapper mapper)
        {
            _bootcampStateRepository = bootcampStateRepository;
            _mapper = mapper;
        }
        public async Task<GetByIdBootcampStateResponse> GetAsync(int id)
        {
            BootcampState bootcampState =await _bootcampStateRepository.GetAsync(b => b.Id == id);
            GetByIdBootcampStateResponse bootcampStateResponse = _mapper.Map<GetByIdBootcampStateResponse>(bootcampState);

            return bootcampStateResponse;
        }
        public async Task<CreateBootcampStateResponse> AddAsync(CreateBootcampStateRequest request)
        {
            BootcampState bootcampState=_mapper.Map<BootcampState>(request);
            bootcampState.CreatedDate = DateTime.UtcNow;
            await _bootcampStateRepository.AddAsync(bootcampState);

            CreateBootcampStateResponse bootcampStateResponse = _mapper.Map<CreateBootcampStateResponse>(bootcampState);
            return bootcampStateResponse;
        }
        public async Task<UpdateBootcampStateResponse> UpdateAsync(UpdateBootcampStateRequest request)
        {
            BootcampState bootcampState = _mapper.Map<BootcampState>(request);
            bootcampState.UpdatedDate= DateTime.UtcNow;
           await _bootcampStateRepository.UpdateAsync(bootcampState);

            UpdateBootcampStateResponse bootcampStateResponse = _mapper.Map<UpdateBootcampStateResponse>(bootcampState);
            return bootcampStateResponse;
        }
        public Task<DeleteBootcampStateResponse> DeleteAsync(DeleteBootcampStateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetAllBootcampStateResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        } 
    }
}
