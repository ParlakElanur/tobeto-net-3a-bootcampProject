using AutoMapper;
using Business.Abstracts;
using Business.Requests.Bootcamp;
using Business.Responses.Application;
using Business.Responses.Bootcamp;
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

        public BootcampManager(IBootcampRepository bootcampRepository, IMapper mapper)
        {
            _bootcampRepository = bootcampRepository;
            _mapper = mapper;
        }
        public async Task<IDataResult<GetByIdBootcampResponse>> GetAsync(int id)
        {
            Bootcamp bootcamp = await _bootcampRepository.GetAsync(b => b.Id == id);
            GetByIdBootcampResponse bootcampResponse = _mapper.Map<GetByIdBootcampResponse>(bootcamp);

            return new SuccessDataResult<GetByIdBootcampResponse>(bootcampResponse, "Received successfully");
        }
        public async Task<IDataResult<CreateBootcampResponse>> AddAsync(CreateBootcampRequest request)
        {
            Bootcamp bootcamp = _mapper.Map<Bootcamp>(request);
            bootcamp.CreatedDate = DateTime.UtcNow;
            await _bootcampRepository.AddAsync(bootcamp);

            CreateBootcampResponse bootcampResponse = _mapper.Map<CreateBootcampResponse>(bootcamp);
            return new SuccessDataResult<CreateBootcampResponse>(bootcampResponse, "Added successfully");
        }
        public async Task<IDataResult<UpdateBootcampResponse>> UpdateAsync(UpdateBootrcampRequest request)
        {
            Bootcamp bootcamp = _mapper.Map<Bootcamp>(request);
            bootcamp.UpdatedDate = DateTime.UtcNow;
            await _bootcampRepository.UpdateAsync(bootcamp);

            UpdateBootcampResponse bootcampResponse = _mapper.Map<UpdateBootcampResponse>(bootcamp);
            return new SuccessDataResult<UpdateBootcampResponse>(bootcampResponse, "Updated successfully");
        }
        public async Task<IResult> DeleteAsync(DeleteBootcampRequest request)
        {
            Bootcamp bootcamp = await _bootcampRepository.GetAsync(b => b.Id == request.Id);
            bootcamp.DeletedDate = DateTime.UtcNow;
            await _bootcampRepository.DeleteAsync(bootcamp);

            return new SuccessResult("Deleted successfully");
        }
        public async Task<IDataResult<List<GetAllBootcampResponse>>> GetAllAsync()
        {
            List<Bootcamp> bootcamps = await _bootcampRepository.GetAllAsync();
            List<GetAllBootcampResponse> getAllBootcamps = _mapper.Map<List<GetAllBootcampResponse>>(bootcamps);

            return new SuccessDataResult<List<GetAllBootcampResponse>>(getAllBootcamps, "Listed successfully");
        }
    }
}
