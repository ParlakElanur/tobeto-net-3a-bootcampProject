using AutoMapper;
using Business.Abstracts;
using Business.Requests.BootcampState;
using Business.Responses.BootcampState;
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
    public class BootcampStateManager : IBootcampStateService
    {
        private readonly IBootcampStateRepository _bootcampStateRepository;
        private readonly IMapper _mapper;
        private readonly BootcampStateBusinessRules _rules;
        public BootcampStateManager(IBootcampStateRepository bootcampStateRepository, IMapper mapper, BootcampStateBusinessRules rules)
        {
            _bootcampStateRepository = bootcampStateRepository;
            _mapper = mapper;
            _rules = rules;
        }
        public async Task<IDataResult<GetByIdBootcampStateResponse>> GetAsync(int id)
        {
            await _rules.CheckIfBootcampStateIdNotExists(id);
            BootcampState bootcampState = await _bootcampStateRepository.GetAsync(b => b.Id == id);
            GetByIdBootcampStateResponse bootcampStateResponse = _mapper.Map<GetByIdBootcampStateResponse>(bootcampState);

            return new SuccessDataResult<GetByIdBootcampStateResponse>(bootcampStateResponse, "Received successfully");
        }
        public async Task<IDataResult<CreateBootcampStateResponse>> AddAsync(CreateBootcampStateRequest request)
        {
            await _rules.CheckIfBootcampStateNameNotExists(request.Name.TrimStart());
            BootcampState bootcampState = _mapper.Map<BootcampState>(request);
            await _bootcampStateRepository.AddAsync(bootcampState);

            CreateBootcampStateResponse bootcampStateResponse = _mapper.Map<CreateBootcampStateResponse>(bootcampState);
            return new SuccessDataResult<CreateBootcampStateResponse>(bootcampStateResponse, "Added successfully");
        }
        public async Task<IDataResult<UpdateBootcampStateResponse>> UpdateAsync(UpdateBootcampStateRequest request)
        {
            await _rules.CheckIfBootcampStateIdNotExists(request.Id);
            //BootcampState bootcampState = _mapper.Map<BootcampState>(request);
            BootcampState bootcampState = await _bootcampStateRepository.GetAsync(b => b.Id == request.Id);
            bootcampState.Name = request.Name;
            await _bootcampStateRepository.UpdateAsync(bootcampState);

            UpdateBootcampStateResponse bootcampStateResponse = _mapper.Map<UpdateBootcampStateResponse>(bootcampState);
            return new SuccessDataResult<UpdateBootcampStateResponse>(bootcampStateResponse, "Updated successfully");
        }
        public async Task<IResult> DeleteAsync(DeleteBootcampStateRequest request)
        {
            await _rules.CheckIfBootcampStateIdNotExists(request.Id);
            BootcampState bootcampState = await _bootcampStateRepository.GetAsync(b => b.Id == request.Id);
            await _bootcampStateRepository.DeleteAsync(bootcampState);

            return new SuccessResult("Deleted successfully");
        }
        public async Task<IDataResult<List<GetAllBootcampStateResponse>>> GetAllAsync()
        {
            List<BootcampState> bootcampStates = await _bootcampStateRepository.GetAllAsync();
            List<GetAllBootcampStateResponse> getAllBootcampStates = _mapper.Map<List<GetAllBootcampStateResponse>>(bootcampStates);

            return new SuccessDataResult<List<GetAllBootcampStateResponse>>(getAllBootcampStates, "Listed successfully");
        }
        public async Task<GetByIdBootcampStateResponse> GetById(int id)
        {
            BootcampState bootcampState = await _bootcampStateRepository.GetAsync(b => b.Id == id);
            GetByIdBootcampStateResponse bootcampStateResponse = _mapper.Map<GetByIdBootcampStateResponse>(bootcampState);

            return bootcampStateResponse;
        }
    }
}
