using AutoMapper;
using Business.Abstracts;
using Business.Requests.Instructor;
using Business.Responses.Instructor;
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
    public class InstructorManager : IInstructorService
    {
        private readonly IInstructorRepository _intructorRepository;
        private readonly IMapper _mapper;
        public InstructorManager(IInstructorRepository instructorRepository, IMapper mapper)
        {
            _intructorRepository = instructorRepository;
            _mapper = mapper;
        }
        public async Task<IDataResult<GetByIdInstructorResponse>> GetAsync(int id)
        {
            Instructor instructor = await _intructorRepository.GetAsync(i => i.Id == id);
            GetByIdInstructorResponse instructorResponse = _mapper.Map<GetByIdInstructorResponse>(instructor);

            return new SuccessDataResult<GetByIdInstructorResponse>(instructorResponse, "Received successfully");
        }
        public async Task<IDataResult<CreateInstructorResponse>> AddAsync(CreateInstructorRequest request)
        {
            Instructor instructor = _mapper.Map<Instructor>(request);
            instructor.CreatedDate = DateTime.UtcNow;
            await _intructorRepository.AddAsync(instructor);

            CreateInstructorResponse instructorResponse = _mapper.Map<CreateInstructorResponse>(instructor);
            return new SuccessDataResult<CreateInstructorResponse>(instructorResponse, "Added successfully");
        }
        public async Task<IDataResult<UpdateInstructorResponse>> UpdateAsync(UpdateInstructorRequest request)
        {
            Instructor instructor = _mapper.Map<Instructor>(request);
            instructor.UpdatedDate = DateTime.UtcNow;
            await _intructorRepository.UpdateAsync(instructor);

            UpdateInstructorResponse instructorResponse = _mapper.Map<UpdateInstructorResponse>(instructor);
            return new SuccessDataResult<UpdateInstructorResponse>(instructorResponse, "Updated successfully");
        }
        public async Task<IResult> DeleteAsync(DeleteInstructorRequest request)
        {
            Instructor instructor = await _intructorRepository.GetAsync(i => i.Id == request.Id);
            instructor.DeletedDate = DateTime.Now;
           await _intructorRepository.DeleteAsync(instructor);
            
            return new SuccessResult("Deleted successfully");
        }
        public async Task<IDataResult<List<GetAllInstructorResponse>>> GetAllAsync()
        {
            List<Instructor> instructors = await _intructorRepository.GetAllAsync();
            List<GetAllInstructorResponse> getAllInstructors = _mapper.Map<List<GetAllInstructorResponse>>(instructors);

            return new SuccessDataResult<List<GetAllInstructorResponse>>(getAllInstructors, "Listed successfully");
        }
    }
}
