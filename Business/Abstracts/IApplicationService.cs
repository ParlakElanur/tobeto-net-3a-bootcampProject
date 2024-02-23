using Business.Requests.Application;
using Business.Responses.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IApplicationService
    {
        Task<GetByIdApplicationResponse> GetAsync(int id);
        Task<CreateApplicationResponse> AddAsync(CreateApplicationRequest request);
        Task<UpdateApplicationResponse> UpdateAsync(UpdateApplicationRequest request);
        Task<DeleteApplicationResponse> DeleteAsync(DeleteApplicationRequest request);
        Task<List<GetAllApplicationResponse>> GetAllAsync();
    }
}
