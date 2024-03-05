using Business.Requests.Bootcamp;
using Business.Responses.Bootcamp;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IBootcampService
    {
        Task<IDataResult<GetByIdBootcampResponse>> GetAsync(int id);
        Task<IDataResult<CreateBootcampResponse>> AddAsync(CreateBootcampRequest request);
        Task<IDataResult<UpdateBootcampResponse>> UpdateAsync(UpdateBootcampRequest request);
        Task<IResult> DeleteAsync(DeleteBootcampRequest request);
        Task<IDataResult<List<GetAllBootcampResponse>>> GetAllAsync();
        Task<GetByIdBootcampResponse> GetById(int id);
    }
}
