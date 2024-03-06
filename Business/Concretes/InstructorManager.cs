using AutoMapper;
using Business.Abstracts;
using Business.Requests.Instructor;
using Business.Responses.Instructor;
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
    public class InstructorManager : IInstructorService
    {
        private readonly IInstructorRepository _intructorRepository;
        private readonly IMapper _mapper;
        private readonly InstructorBusinessRules _rules;
        public InstructorManager(IInstructorRepository instructorRepository, IMapper mapper, InstructorBusinessRules rules)
        {
            _intructorRepository = instructorRepository;
            _mapper = mapper;
            _rules = rules;
        }
        public async Task<IDataResult<GetByIdInstructorResponse>> GetAsync(int id)
        {
            await _rules.CheckIfInstructorIdNotExists(id);
            Instructor instructor = await _intructorRepository.GetAsync(i => i.Id == id);
            GetByIdInstructorResponse instructorResponse = _mapper.Map<GetByIdInstructorResponse>(instructor);

            return new SuccessDataResult<GetByIdInstructorResponse>(instructorResponse, "Received successfully");
        }
        public async Task<IDataResult<CreateInstructorResponse>> AddAsync(CreateInstructorRequest request)
        {
            Instructor instructor = _mapper.Map<Instructor>(request);
            await _intructorRepository.AddAsync(instructor);

            CreateInstructorResponse instructorResponse = _mapper.Map<CreateInstructorResponse>(instructor);
            return new SuccessDataResult<CreateInstructorResponse>(instructorResponse, "Added successfully");
        }
        public async Task<IDataResult<UpdateInstructorResponse>> UpdateAsync(UpdateInstructorRequest request)
        {
            await _rules.CheckIfInstructorIdNotExists(request.Id);
            //Instructor instructor = _mapper.Map<Instructor>(request);
            Instructor instructor = await _intructorRepository.GetAsync(i => i.Id == request.Id);
            instructor.UserName = request.UserName;
            instructor.FirstName = request.FirstName;
            instructor.LastName = request.LastName;
            instructor.DateOfBirth = request.DateOfBirth;
            instructor.Email = request.Email;
            instructor.Password = request.Password;
            instructor.CompanyName=request.CompanyName;
            await _intructorRepository.UpdateAsync(instructor);

            UpdateInstructorResponse instructorResponse = _mapper.Map<UpdateInstructorResponse>(instructor);
            return new SuccessDataResult<UpdateInstructorResponse>(instructorResponse, "Updated successfully");
        }
        public async Task<IResult> DeleteAsync(DeleteInstructorRequest request)
        {
            await _rules.CheckIfInstructorIdNotExists(request.Id);
            Instructor instructor = await _intructorRepository.GetAsync(i => i.Id == request.Id);
            await _intructorRepository.DeleteAsync(instructor);

            return new SuccessResult("Deleted successfully");
        }
        public async Task<IDataResult<List<GetAllInstructorResponse>>> GetAllAsync()
        {
            List<Instructor> instructors = await _intructorRepository.GetAllAsync();
            List<GetAllInstructorResponse> getAllInstructors = _mapper.Map<List<GetAllInstructorResponse>>(instructors);

            return new SuccessDataResult<List<GetAllInstructorResponse>>(getAllInstructors, "Listed successfully");
        }
        public async Task<GetByIdInstructorResponse> GetById(int id)
        {
            Instructor instructor = await _intructorRepository.GetAsync(i => i.Id == id);
            GetByIdInstructorResponse instructorResponse = _mapper.Map<GetByIdInstructorResponse>(instructor);

            return instructorResponse;
        }
    }
}
