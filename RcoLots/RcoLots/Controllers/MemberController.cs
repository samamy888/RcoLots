using Microsoft.AspNetCore.Mvc;
using RcoLots.Service;

namespace RcoLots.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MemberController : Controller
    {
        private readonly DBService _dbService;

        public MemberController(DBService dbService)
        {
            _dbService = dbService;
        }
        [HttpGet]
        public async Task<IActionResult> GetMember()
        {
            return Ok(await _dbService.GetMember());
        }
        [HttpPost("{name}")]
        public async Task<IActionResult> AddMember(string name)
        {
            return Ok(await _dbService.AddMember(name));
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveMember(string id)
        {
            return Ok(await _dbService.RemoveMember(id));
        }
    }
}
