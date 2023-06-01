using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ModelDataLogic.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Resportiory
{
    public class AccountRespository : IAccountRespository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager; private readonly IConfiguration _config;

        public AccountRespository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config=config;
        }
        public async Task<IdentityResult> CreateUserAsync(UserRegistrationDto request)
        {
            var user = new ApplicationUser
            {
                FirstName=request.FirstName,
                LastName=request.LastName,
                UserName = request.Email,
                NormalizedUserName = request.Email,
                Email = request.Email,
                EmailConfirmed = true,



            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
            }
            return result;
        }

        public async Task<SignInResult> PasswordSignInAsync(UserLoginDto login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, login.RememberMe, false);
            return result;
        }

        public async Task<LoginResModel> Login(UserLoginDto model)
        {
            var user = await _userManager.FindByNameAsync(model.Email);

            if (user == null)
            {
                return new LoginResModel()
                {
                    IsSuccess = false
                };
            }
            var PasswordValid = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!PasswordValid)
            {
                return new LoginResModel()
                {
                    IsSuccess = false
                };
            }
            var userRoles = await _userManager.GetRolesAsync(user);
            var tokenHendeler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this._config.GetSection("JWT")["Key"]);

            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                };
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(authClaims),
                Expires = System.DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHendeler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHendeler.WriteToken(token);
            return new LoginResModel()
            {
                IsSuccess = true,
                Token = encryptedToken,
                Username = user.UserName,
                Role = userRoles[0]
            };
        }
    }
}
