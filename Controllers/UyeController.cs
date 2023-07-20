using CelebiWebApi.DTOs;
using CelebiWebApi.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CelebiWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UyeController : ControllerBase
    {
        private readonly IUyeService _uyeService;

        public UyeController(IUyeService uyeService)
        {
            _uyeService = uyeService;
        }

        [HttpGet("info/{id}")]
        public async Task<ActionResult<UyeInfo>> GetUyeInfo(int id)
        {
            var uyeInfo = await _uyeService.GetUyeInfo(id);
            if (uyeInfo == null)
            {
                return NotFound();
            }
            return Ok(uyeInfo);
        }

        [HttpGet("paket/{id}")]
        public async Task<ActionResult<IEnumerable<UyePaketDTO?>>> GetUyePaket(int id)
        {
            var _paketler = await _uyeService.GetUyePaket(id);
            if (_paketler == null) return NotFound();
            else
            {
                return Ok(_paketler);
            }

        }


    }
}
