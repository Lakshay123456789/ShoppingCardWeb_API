using Microsoft.AspNetCore.Identity;
using ModelDataLogic.Model;

namespace BusinessLayer.Resportiory
{
    public interface IAccountRespository
    {
        Task<IdentityResult> CreateUserAsync(UserRegistrationDto request);
        Task<SignInResult> PasswordSignInAsync(UserLoginDto login);
        Task<LoginResModel> Login(UserLoginDto model);
    }
}