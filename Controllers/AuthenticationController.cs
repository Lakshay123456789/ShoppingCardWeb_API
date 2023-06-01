using BusinessLayer.Resportiory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ModelDataLogic.Model;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShoppingCardWebApI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAccountRespository _accountRepository;
        private readonly IConfiguration _configuration;
        private readonly IGenericRepository<ApplicationUser> _UserRepository;

        public AuthenticationController(IAccountRespository accountRepository, UserManager<ApplicationUser> userManager, IGenericRepository<ApplicationUser> UserRepository, IConfiguration configuration)
        {
            _accountRepository = accountRepository;
            _userManager = userManager;
            _configuration = configuration;
            _UserRepository = UserRepository;
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(UserRegistrationDto model)
        {

            var userExists = await _userManager.FindByNameAsync(model.Email);
            if (userExists != null)
                return Ok("user is Already exist");
            var result = await _accountRepository.CreateUserAsync(model);
            if (result.Succeeded)
            {
                return Ok("User created successfully");
            }
            return NotFound();

        }
        [HttpPost]
        [Route("login")]
        //public async Task<IActionResult> Login(UserLoginDto model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await _userManager.FindByNameAsync(model.Email);
        //        var result = await _accountRepository.PasswordSignInAsync(model);
        //        if (result.Succeeded && user != null)
        //        {
        //            var userRoles = await _userManager.GetRolesAsync(user);
        //            var authClaims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name, user.UserName),
        //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //        };

        //            foreach (var userRole in userRoles)
        //            {
        //                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
        //            }

        //           var token = GetToken(authClaims);


        //            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);


        //            return Ok(jwtToken);
        //        }
        //        return Unauthorized();
        //    }
        //    return NotFound();
        //}

        public async Task<IActionResult> Login(UserLoginDto model)
        {
            var result = await _accountRepository.Login(model);
            if (result != null)
            {
                if (result.IsSuccess) { return Ok(result); }
                return Unauthorized();
            }
            return Unauthorized();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var result = await _UserRepository.GetAll();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("There is no user");
        }
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
