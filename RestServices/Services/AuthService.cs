using RestaurantAppBE.DataAccess.DTOs;
using RestaurantAppBE.RestServices.Services.Interfaces;
using FitnessAppRestaurantAppBE.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace RestaurantAppBE.RestServices.Services
{
    public class AuthService: IAuthService
    {
        IConfiguration _configuration;
        IUserService _userService;

        public AuthService(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        public async Task<string> AuthToken(UserDto user)
        {
            if (user == null || user.Email == null || user.Password == null)
            {
                return null;
            }

            var userData = await _userService.GetUser(user);
            if (userData is null)
            {
                return null;
            }
            var jwt = _configuration.GetSection("Jwt").Get<JwtContent>();
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("Id", userData.UserId.ToString()),
                new Claim("Name", userData.Name),
                new Claim("Password", userData.Password)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                                jwt.Issuer,
                                jwt.Audience,
                                claims,
                                expires: DateTime.Now.AddMinutes(30),
                                signingCredentials: signIn
                            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
