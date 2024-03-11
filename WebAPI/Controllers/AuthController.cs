using Business.Abstracts;
using Business.Requests.Applicant;
using Core.Utilities.Security.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("registerApplicant")]
        public async Task<IActionResult> Register(ApplicantForRegisterDto applicantForRegisterDto)
        {
            var result = await _authService.RegisterApplicant(applicantForRegisterDto);
            //return await HandleDataResult(result);
            return null;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var result = await _authService.Login(userForLoginDto);
            //return await HandleDataResult(result);
            return null;
        }

    }
}
