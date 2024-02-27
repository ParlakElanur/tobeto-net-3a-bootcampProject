using Business.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetAsync(int id)
        {
           return HandleDataResult(await _userService.GetAsync(id));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return HandleDataResult(await _userService.GetAllAsync());
        }
    }
}
