using AutoMapper;
using Business.Requests.Applicant;
using Business.Requests.Employee;
using Business.Requests.Instructor;
using Business.Responses.Applicant;
using Business.Responses.Employee;
using Business.Responses.Instructor;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Applicant
            CreateMap<Applicant, GetByIdApplicantResponse>().ReverseMap();

            CreateMap<CreateApplicantRequest, Applicant>().ReverseMap();
            CreateMap<Applicant, CreateApplicantResponse>().ReverseMap();

            CreateMap<UpdateApplicantRequest, Applicant>().ReverseMap();
            CreateMap<Applicant, UpdateApplicantResponse>().ReverseMap();

            CreateMap<Applicant,DeleteApplicantResponse>().ReverseMap();

            CreateMap<Applicant, GetAllApplicantResponse>().ReverseMap();

            //Employee
            CreateMap<Employee, GetByIdEmployeeResponse>().ReverseMap();

            CreateMap<CreateEmployeeRequest, Employee>().ReverseMap();
            CreateMap<Employee, CreateEmployeeResponse>().ReverseMap();

            CreateMap<UpdateEmployeeRequest, Employee>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeResponse>().ReverseMap();

            CreateMap<Employee, DeleteEmployeeResponse>().ReverseMap();

            CreateMap<Employee, GetAllEmployeeResponse>().ReverseMap();

            //Instructor
            CreateMap<Instructor, GetByIdInstructorResponse>().ReverseMap();

            CreateMap<CreateInstructorRequest, Instructor>().ReverseMap();
            CreateMap<Instructor, CreateInstructorResponse>().ReverseMap();

            CreateMap<UpdateInstructorRequest, Instructor>().ReverseMap();
            CreateMap<Instructor, UpdateInstructorResponse>().ReverseMap();

            CreateMap<Instructor,DeleteInstructorResponse>().ReverseMap();

            CreateMap<Instructor, GetAllInstructorResponse>().ReverseMap();

        }
    }
}
