using Business.Abstracts;
using Business.Responses.User;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("id")]
        public async Task<IDataResult<GetByIdUserResponse>> GetAsync(int id)
        {
           return await _userService.GetAsync(id);
        }
        [HttpGet]
        public async Task<IDataResult<List<GetAllUserResponse>>> GetAllAsync()
        {
            return await _userService.GetAllAsync();
        }
    }
}
