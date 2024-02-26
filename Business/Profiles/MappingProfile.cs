using AutoMapper;
using Business.Requests.Applicant;
using Business.Requests.Application;
using Business.Requests.ApplicationState;
using Business.Requests.Bootcamp;
using Business.Requests.BootcampState;
using Business.Requests.Employee;
using Business.Requests.Instructor;
using Business.Responses.Applicant;
using Business.Responses.Application;
using Business.Responses.ApplicationState;
using Business.Responses.Bootcamp;
using Business.Responses.BootcampState;
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

            //Application
            CreateMap<Application, GetByIdApplicationResponse>().ReverseMap();

            CreateMap<CreateApplicationRequest, Application>().ReverseMap();
            CreateMap<Application, CreateApplicationResponse>().ReverseMap();

            CreateMap<UpdateApplicationRequest, Application>().ReverseMap();
            CreateMap<Application, UpdateApplicationResponse>().ReverseMap();

            CreateMap<Application, DeleteApplicationResponse>().ReverseMap();

            CreateMap<Application, GetAllApplicationResponse>().ReverseMap();

            //ApplicationState
            CreateMap<ApplicationState, GetByIdApplicationResponse>().ReverseMap();

            CreateMap<CreateApplicationStateRequest, ApplicationState>().ReverseMap();
            CreateMap<ApplicationState, CreateApplicationStateResponse>().ReverseMap();

            CreateMap<UpdateApplicationStateRequest, ApplicationState>().ReverseMap();
            CreateMap<ApplicationState, UpdateApplicationStateResponse>().ReverseMap();

            CreateMap<ApplicationState, DeleteApplicationStateResponse>().ReverseMap();

            CreateMap<ApplicationState, GetAllApplicationStateResponse>().ReverseMap();

            //Bootcamp
            CreateMap<Bootcamp, GetByIdBootcampResponse>().ReverseMap();

            CreateMap<CreateBootcampRequest, Bootcamp>().ReverseMap();
            CreateMap<Bootcamp, CreateBootcampResponse>().ReverseMap();

            CreateMap<UpdateBootrcampRequest, Bootcamp>().ReverseMap();
            CreateMap<Bootcamp, UpdateBootcampResponse>().ReverseMap();

            CreateMap<Bootcamp, DeleteBootcampResponse>().ReverseMap();

            CreateMap<Bootcamp, GetAllBootcampResponse>().ReverseMap();

            //BootcampState
            CreateMap<BootcampState, GetByIdBootcampStateResponse>().ReverseMap();

            CreateMap<CreateBootcampStateRequest, BootcampState>().ReverseMap();
            CreateMap<BootcampState, CreateBootcampStateResponse>().ReverseMap();

            CreateMap<UpdateBootcampStateRequest, BootcampState>().ReverseMap();
            CreateMap<BootcampState, UpdateBootcampStateResponse>().ReverseMap();

            CreateMap<BootcampState, DeleteBootcampStateResponse>().ReverseMap();

            CreateMap<BootcampState, GetAllBootcampStateResponse>().ReverseMap();

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
