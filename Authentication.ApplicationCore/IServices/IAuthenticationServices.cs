using Authentication.API.Entities;
using AuthenticationAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace ApplicationCore.IServices;

public interface IAuthenticationServices<T>
{
    Task<(bool isSuccessful, List<IdentityError> errors)> CustomerRegister(CustomerRegisterModel registerModel);
    Task<(bool isSuccessful, List<IdentityError> errors)> AdminRegister(RegisterModel registerModel);
    Task<string> Login(LoginModel loginModel);
}