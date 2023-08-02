using CelebiWebApi.Models;
using CelebiWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CelebiWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticateController : Controller
    {
        private readonly IAuthenticateService _authenticateService;

        public AuthenticateController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [HttpPost]
        public async Task<ActionResult<LoginResponse>> Authenticate(LoginRequest loginRequest)
        {
            var loginResponse = await _authenticateService.Authenticate(loginRequest);
            if (loginResponse == null) return Unauthorized();
          
            return Ok(loginResponse);
        }
    }
}
