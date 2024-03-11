using Business.Responses.User;
using Core.Utilities.Results;
using Core.Utilities.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IUserService
    {
        Task<IDataResult<GetByIdUserResponse>> GetAsync(int id);
        Task<IDataResult<List<GetAllUserResponse>>> GetAllAsync();
        Task<DataResult<User>> GetByMailAsync(string email); 
    }
}
