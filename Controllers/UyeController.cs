using CelebiWebApi.DTOs;
using CelebiWebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CelebiWebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UyeController : ControllerBase
    {
        private readonly IUyeService _uyeService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UyeController(IUyeService uyeService, IHttpContextAccessor httpContextAccessor)
        {
            _uyeService = uyeService;
            _httpContextAccessor = httpContextAccessor;

        }
        
        [HttpGet("info")]
        public async Task<ActionResult<UyeInfo>> GetUyeInfo()
        {
            var authenticatedUserId = Convert.ToInt32(_httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier));

            var uyeInfo = await _uyeService.GetUyeInfo(authenticatedUserId);
            if (uyeInfo == null)
            {
                return NotFound();
            }
            return Ok(uyeInfo);
        }

        [HttpGet("paket")]
        public async Task<ActionResult<IEnumerable<UyePaketDTO?>>> GetUyePaket()
        {
            var authenticatedUserId = Convert.ToInt32(_httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier));

            var _paketler = await _uyeService.GetUyePaket(authenticatedUserId);
            if (_paketler == null) return NotFound();
            else
            {
                return Ok(_paketler);
            }

        }

        [HttpGet("tahsilat")]
        public async Task<ActionResult<IEnumerable<UyeAidatDTO?>>> GetUyeTahsilat()
        {
            var authenticatedUserId = Convert.ToInt32(_httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier));

            var _paketler = await _uyeService.GetUyeTahsilat(authenticatedUserId);
            if (_paketler == null) return NotFound();
            else
            {
                return Ok(_paketler);
            }

        }


    }
}
