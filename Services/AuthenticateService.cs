using CelebiWebApi.Data;
using CelebiWebApi.DTOs;
using CelebiWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CelebiWebApi.Services
{
    public interface IAuthenticateService
    {
        Task<LoginResponse?> Authenticate(LoginRequest loginModel);
    }
    public class AuthenticateService : IAuthenticateService
    {
        private readonly CelebiDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public AuthenticateService(CelebiDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<LoginResponse?> Authenticate(LoginRequest loginModel)
        {
            var _user = await _dbContext.Uye.Where(u => u.TC == loginModel.Email && u.Tel1 == loginModel.Password).FirstOrDefaultAsync();
            if (_user == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, _user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            var response = new LoginResponse { Token = tokenString };

            return response;
        }
    }
}
