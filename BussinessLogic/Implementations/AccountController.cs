using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Model.DatabaseModels;
using WebApp.Model.ViewModels;
using WebApp.Model;
using WebApp.Services.Interfaces;

namespace WebApp.BussinessLogic.Implementations
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly ITokenService _tokenService;

        public AccountController(ApplicationContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserViewModel>> Register(UserViewModel UserViewModel)
        {
            if (await UserExists(UserViewModel.Username)) return BadRequest("Error");
            var hmac = new HMACSHA512();

            var user = new User
            {
                UserName = UserViewModel.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(UserViewModel.Password)),
                PasswordSalt = hmac.Key,

            };

            _context.appUsers.Add(user);
            await _context.SaveChangesAsync();

            return new UserViewModel
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }

        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserViewModel>> Login(UserViewModel UserViewModel)
        {
            var user = await _context.Users
                .SingleOrDefaultAsync(x => x.UserName == UserViewModel.Username);

            if (user == null) return Unauthorized("Invalid Username");

            var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(UserViewModel.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password");
            }

            return new UserViewModel
            {
                Username = user.Username,
                Token = _tokenService.CreateToken(user)
            };

        }

    }
}
