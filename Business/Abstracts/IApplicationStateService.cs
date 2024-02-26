using Business.Requests.ApplicationState;
using Business.Responses.ApplicationState;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IApplicationStateService
    {
        Task<IDataResult<GetByIdApplicationStateResponse>> GetAsync(int id);
        Task<IDataResult<CreateApplicationStateResponse>> AddAsync(CreateApplicationStateRequest request);
        Task<IDataResult<UpdateApplicationStateResponse>> UpdateAsync(UpdateApplicationStateRequest request);
        Task<IDataResult<DeleteApplicationStateResponse>> DeleteAsync(DeleteApplicationStateRequest request);
        Task<IDataResult<List<GetAllApplicationStateResponse>>> GetAllAsync();
    }
}
