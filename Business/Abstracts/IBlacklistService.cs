using Business.Requests.Blacklist;
using Business.Responses.Blacklist;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IBlacklistService
    {
        Task<IDataResult<GetByIdBlacklistResponse>> GetAsync(int id);
        Task<IDataResult<CreateBlacklistResponse>> AddAsync(CreateBlacklistRequest request);
        Task<IDataResult<UpdateBlacklistResponse>> UpdateAsync(UpdateBlacklistRequest request);
        Task<IResult> DeleteAsync(DeleteBlacklistRequest request);
        Task<IDataResult<List<GetAllBlacklistResponse>>> GetAllAsync();
    }
}
