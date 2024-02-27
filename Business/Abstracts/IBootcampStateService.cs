using Business.Requests.BootcampState;
using Business.Responses.BootcampState;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IBootcampStateService
    {
        Task<IDataResult<GetByIdBootcampStateResponse>> GetAsync(int id);
        Task<IDataResult<CreateBootcampStateResponse>> AddAsync(CreateBootcampStateRequest request);
        Task<IDataResult<UpdateBootcampStateResponse>> UpdateAsync(UpdateBootcampStateRequest request);
        Task<IResult> DeleteAsync(DeleteBootcampStateRequest request);
        Task<IDataResult<List<GetAllBootcampStateResponse>>> GetAllAsync();
    }
}
