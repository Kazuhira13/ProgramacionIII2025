using Clase11.Entities;
using Clase11.Services;
using Microsoft.AspNetCore.Mvc;

namespace Clase11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IFirebaseAuthService firebaseAuthService;
        public UserController(IFirebaseAuthService firebaseAuthService) {
            this.firebaseAuthService = firebaseAuthService;
        }

        [HttpPost("/register")]
        public async Task<string> Register([FromBody]User user)
        {
            var token = await firebaseAuthService.SignUp(user.Email, user.Password);
            return token ?? "";
        }


        [HttpPost("/login")]
        public async Task<string> Login([FromBody] User user)
        {
            var token = await firebaseAuthService.Login(user.Email, user.Password);
            return token ?? "";
        }

    }
}
