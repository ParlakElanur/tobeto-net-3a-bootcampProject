using Business.Requests.BootcampState;
using Business.Responses.BootcampState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IBootcampStateService
    {
        Task<GetByIdBootcampStateResponse> GetAsync(int id);
        Task<CreateBootcampStateResponse> AddAsync(CreateBootcampStateRequest request);
        Task<UpdateBootcampStateResponse> UpdateAsync(UpdateBootcampStateRequest request);
        Task<DeleteBootcampStateResponse> DeleteAsync(DeleteBootcampStateRequest request);
        Task<List<GetAllBootcampStateResponse>> GetAllAsync();
    }
}
