using Business.Requests.Instructor;
using Business.Responses.Instructor;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IInstructorService
    {
        Task<IDataResult<GetByIdInstructorResponse>> GetAsync(int id);
        Task<IDataResult<CreateInstructorResponse>> AddAsync(CreateInstructorRequest request);
        Task<IDataResult<UpdateInstructorResponse>> UpdateAsync(UpdateInstructorRequest request);
        Task<IDataResult<DeleteInstructorResponse>> DeleteAsync(DeleteInstructorRequest request);
        Task<IDataResult<List<GetAllInstructorResponse>>> GetAllAsync();
    }
}
