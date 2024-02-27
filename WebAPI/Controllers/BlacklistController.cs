using Business.Abstracts;
using Business.Requests.Blacklist;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlacklistController : BaseController
    {
        private readonly IBlacklistService _blacklistService;
        public BlacklistController(IBlacklistService blacklistService)
        {
            _blacklistService = blacklistService;
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return HandleDataResult(await _blacklistService.GetAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateBlacklistRequest request)
        {
            return HandleDataResult(await _blacklistService.AddAsync(request));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateBlacklistRequest request)
        {
            return HandleDataResult(await _blacklistService.UpdateAsync(request));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(DeleteBlacklistRequest request)
        {
            return HandleResult(await _blacklistService.DeleteAsync(request));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return HandleDataResult(await _blacklistService.GetAllAsync());
        }
    }
}
