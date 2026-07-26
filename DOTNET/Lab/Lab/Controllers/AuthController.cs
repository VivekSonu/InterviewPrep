//using Lab.Data;
//using Lab.Models;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.IdentityModel.Tokens;
//using Org.BouncyCastle.Crypto.Generators;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace Lab.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AuthController(AppDbContext context) : ControllerBase
//    {

//        [HttpPost("register")]
//        public async Task<IActionResult> Register(RegisterDto dto)
//        {
//            var user = new User
//            {
//                Name = dto.Username,
//                PasswordHash = "" //BCrypt(dto.Password)
//            };

//            context.Users.Add(user);
//            await context.SaveChangesAsync();

//            return Ok("User created");
//        }


//        [HttpPost("login")]
//        public IActionResult Login(LoginDto dto)
//        {
//            var user = _context.Users.FirstOrDefault(u => u.Username == dto.Username);

//            if (user == null || !BCrypt.Verify(dto.Password, user.PasswordHash))
//                return Unauthorized();

//            var claims = new[]
//            {
//        new Claim(ClaimTypes.Name, user.Username),
//        new Claim(ClaimTypes.Role, user.Role)
//    };

//            var key = new SymmetricSecurityKey(
//                Encoding.UTF8.GetBytes(_config["Jwt:Key"])
//            );

//            var token = new JwtSecurityToken(
//                issuer: _config["Jwt:Issuer"],
//                claims: claims,
//                expires: DateTime.UtcNow.AddMinutes(30),
//                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
//            );

//            return Ok(new
//            {
//                token = new JwtSecurityTokenHandler().WriteToken(token)
//            });
//        }


//        [Authorize(Roles = "Admin")]
//        [HttpGet("admin-data")]
//        public IActionResult GetAdminData()
//        {
//            return Ok("Admin only data");
//        }



//        [HttpPost("refresh")]
//        public IActionResult Refresh(TokenDto dto)
//        {
//            var user = _context.Users
//                .FirstOrDefault(u => u.RefreshToken == dto.RefreshToken);

//            if (user == null || user.RefreshTokenExpiryTime < DateTime.UtcNow)
//                return Unauthorized();

//            var newAccessToken = GenerateJwt(user);

//            return Ok(new { token = newAccessToken });
//        }

//    }
//}
