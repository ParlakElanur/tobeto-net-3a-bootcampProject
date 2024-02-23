using Business.Requests.Bootcamp;
using Business.Responses.Bootcamp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IBootcampService
    {
        Task<GetByIdBootcampResponse> GetAsync(int id);
        Task<CreateBootcampResponse> AddAsync(CreateBootcampRequest request);
        Task<UpdateBootcampResponse> UpdateAsync(UpdateBootrcampRequest request);
        Task<DeleteBootcampResponse> DeleteAsync(DeleteBootcampRequest request);
        Task<List<GetAllBootcampResponse>> GetAllAsync();
    }
}
