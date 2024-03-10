using AutoMapper;
using Business.Abstracts;
using Business.Constants;
using Business.Requests.Bootcamp;
using Business.Responses.Bootcamp;
using Business.Rules;
using Core.Exceptions.Types;
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
    public class BootcampManager : IBootcampService
    {
        private readonly IBootcampRepository _bootcampRepository;
        private readonly IMapper _mapper;
        private readonly BootcampBusinessRules _rules;

        public BootcampManager(IBootcampRepository bootcampRepository, IMapper mapper, BootcampBusinessRules rules)
        {
            _bootcampRepository = bootcampRepository;
            _mapper = mapper;
            _rules = rules;
        }
        public async Task<IDataResult<GetByIdBootcampResponse>> GetAsync(int id)
        {
            await _rules.CheckIfBootcampIdNotExists(id);
            Bootcamp bootcamp = await _bootcampRepository.GetAsync(b => b.Id == id);
            GetByIdBootcampResponse bootcampResponse = _mapper.Map<GetByIdBootcampResponse>(bootcamp);

            return new SuccessDataResult<GetByIdBootcampResponse>(bootcampResponse, "Received successfully");
        }
        public async Task<IDataResult<CreateBootcampResponse>> AddAsync(CreateBootcampRequest request)
        {
            await _rules.CheckIfBootcampNotExists(request.InstructorId, request.BootcampStateId);
            Bootcamp bootcamp = _mapper.Map<Bootcamp>(request);
            await _bootcampRepository.AddAsync(bootcamp);

            CreateBootcampResponse bootcampResponse = _mapper.Map<CreateBootcampResponse>(bootcamp);
            return new SuccessDataResult<CreateBootcampResponse>(bootcampResponse, BootcampMessages.BootcampAdded);
        }
        public async Task<IDataResult<UpdateBootcampResponse>> UpdateAsync(UpdateBootcampRequest request)
        {
            await _rules.CheckIfBootcampIdNotExists(request.Id);
            await _rules.CheckIfBootcampNotExists(request.InstructorId, request.BootcampStateId);
            //Bootcamp bootcamp = _mapper.Map<Bootcamp>(request);
            Bootcamp bootcamp = await _bootcampRepository.GetAsync(b => b.Id == request.Id);
            bootcamp.Name = request.Name;
            bootcamp.InstructorId = request.InstructorId;
            bootcamp.StartDate = request.StartDate;
            bootcamp.EndDate = request.EndDate;
            bootcamp.BootcampStateId = request.BootcampStateId;
            await _bootcampRepository.UpdateAsync(bootcamp);

            UpdateBootcampResponse bootcampResponse = _mapper.Map<UpdateBootcampResponse>(bootcamp);
            return new SuccessDataResult<UpdateBootcampResponse>(bootcampResponse, "Updated successfully");
        }
        public async Task<IResult> DeleteAsync(DeleteBootcampRequest request)
        {
            await _rules.CheckIfBootcampIdNotExists(request.Id);
            Bootcamp bootcamp = await _bootcampRepository.GetAsync(b => b.Id == request.Id);
            await _bootcampRepository.DeleteAsync(bootcamp);

            return new SuccessResult("Deleted successfully");
        }
        public async Task<IDataResult<List<GetAllBootcampResponse>>> GetAllAsync()
        {
            List<Bootcamp> bootcamps = await _bootcampRepository.GetAllAsync();
            List<GetAllBootcampResponse> getAllBootcamps = _mapper.Map<List<GetAllBootcampResponse>>(bootcamps);

            return new SuccessDataResult<List<GetAllBootcampResponse>>(getAllBootcamps, "Listed successfully");
        }

        public async Task<GetByIdBootcampResponse> GetById(int id)
        {
            Bootcamp bootcamp = await _bootcampRepository.GetAsync(b => b.Id == id);
            GetByIdBootcampResponse bootcampResponse = _mapper.Map<GetByIdBootcampResponse>(bootcamp);

            return bootcampResponse;
        }
    }
}
