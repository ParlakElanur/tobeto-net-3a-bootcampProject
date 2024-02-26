using Business.Requests.Employee;
using Business.Responses.Employee;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IEmployeeService
    {
        Task<IDataResult<GetByIdEmployeeResponse>> GetAsync(int id);
        Task<IDataResult<CreateEmployeeResponse>> AddAsync(CreateEmployeeRequest request);
        Task<IDataResult<UpdateEmployeeResponse>> UpdateAsync(UpdateEmployeeRequest request);
        Task<IDataResult<DeleteEmployeeResponse>> DeleteAsync(DeleteEmployeeRequest request);
        Task<IDataResult<List<GetAllEmployeeResponse>>> GetAllAsync();
    }
}
