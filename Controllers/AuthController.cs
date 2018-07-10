using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using StockApp.MyData;
using StockApp.MyModels;
using StockApp1.API.MyData;

namespace StockApp.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string pwd)
        {
            username = username.ToLower();

            if( await _repo.UserExists(username))
                return BadRequest("User name already taken");

            var userToCreate = new Userlogin
            {
                Username = username
            };

            var createUser = await _repo.Register(userToCreate, pwd);
            return StatusCode(201);
        }
    }
}