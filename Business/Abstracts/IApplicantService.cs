using Business.Requests.Applicant;
using Business.Responses.Applicant;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IApplicantService
    {
        Task<IDataResult<GetByIdApplicantResponse>> GetAsync(int id);
        Task<IDataResult<CreateApplicantResponse>> AddAsync(CreateApplicantRequest request);
        Task<IDataResult<UpdateApplicantResponse>> UpdateAsync(UpdateApplicantRequest request);
        Task<IResult> DeleteAsync(DeleteApplicantRequest request);
        Task<IDataResult<List<GetAllApplicantResponse>>> GetAllAsync();
        Task<GetByIdApplicantResponse> GetById(int id);

    }
}
