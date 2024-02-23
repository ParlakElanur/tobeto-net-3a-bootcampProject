using Business.Requests.ApplicationState;
using Business.Responses.ApplicationState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IApplicationStateService
    {
        Task<GetByIdApplicationStateResponse> GetAsync(int id);
        Task<CreateApplicationStateResponse> AddAsync(CreateApplicationStateRequest request);
        Task<UpdateApplicationStateResponse> UpdateAsync(UpdateApplicationStateRequest request);
        Task<DeleteApplicationStateResponse> DeleteAsync(DeleteApplicationStateRequest request);
        Task<List<GetAllApplicationStateResponse>> GetAllAsync();
    }
}
