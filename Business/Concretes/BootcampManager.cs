using AutoMapper;
using Business.Abstracts;
using Business.Requests.Bootcamp;
using Business.Responses.Application;
using Business.Responses.Bootcamp;
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
        public async Task<GetByIdBootcampResponse> GetAsync(int id)
        {
            Bootcamp bootcamp = await _bootcampRepository.GetAsync(b => b.Id == id);
            GetByIdBootcampResponse bootcampResponse = _mapper.Map<GetByIdBootcampResponse>(bootcamp);

            return bootcampResponse;
        }
        public async Task<CreateBootcampResponse> AddAsync(CreateBootcampRequest request)
        {
            Bootcamp bootcamp = _mapper.Map<Bootcamp>(request);
            bootcamp.CreatedDate = DateTime.UtcNow;
            await _bootcampRepository.AddAsync(bootcamp);

            CreateBootcampResponse bootcampResponse = _mapper.Map<CreateBootcampResponse>(bootcamp);
            return bootcampResponse;
        }
        public async Task<UpdateBootcampResponse> UpdateAsync(UpdateBootrcampRequest request)
        {
            Bootcamp bootcamp = _mapper.Map<Bootcamp>(request);
            bootcamp.UpdatedDate = DateTime.UtcNow;
            await _bootcampRepository.UpdateAsync(bootcamp);

            UpdateBootcampResponse bootcampResponse = _mapper.Map<UpdateBootcampResponse>(bootcamp);
            return bootcampResponse;
        }
        public Task<DeleteBootcampResponse> DeleteAsync(DeleteBootcampRequest request)
        {
            throw new NotImplementedException();
        }
        public Task<List<GetAllBootcampResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
