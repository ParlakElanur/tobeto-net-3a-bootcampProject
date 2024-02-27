using Business.Requests.Application;
using Business.Responses.Application;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IApplicationService
    {
        Task<IDataResult<GetByIdApplicationResponse>> GetAsync(int id);
        Task<IDataResult<CreateApplicationResponse>> AddAsync(CreateApplicationRequest request);
        Task<IDataResult<UpdateApplicationResponse>> UpdateAsync(UpdateApplicationRequest request);
        Task<IResult> DeleteAsync(DeleteApplicationRequest request);
        Task<IDataResult<List<GetAllApplicationResponse>>> GetAllAsync();
    }
}
