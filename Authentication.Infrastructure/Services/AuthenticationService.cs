using ApplicationCore.IServices;
using Authentication.API.Entities;
using AuthenticationAPI.Entities;
using AuthenticationAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AuthenticationAPI.Services;

public class AuthenticationService:IAuthenticationServices<ApplicationUser>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<Role> _roleManager;
    private readonly IConfiguration _configuration;
    public AuthenticationService(UserManager<ApplicationUser> userManager,RoleManager<Role> roleManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
    }

    public async Task<(bool isSuccessful, List<IdentityError> errors)> CustomerRegister(CustomerRegisterModel request)
    {
        var userByEmail = await _userManager.FindByEmailAsync(request.Email);
        if (userByEmail is not null)
        {
            throw new ArgumentException($"User with email {request.Email} already exists.");
        }

        // Find the role, if 'Customer' role not exists, create a new one and add it to role manager
        var roleFind = _roleManager.FindByNameAsync(request.Role);

        if (roleFind.Result is null)
        {
            Role role = new()
            {
                Id = Guid.NewGuid(),
                Name = request.Role
            };

            // Save in Role table
            await _roleManager.CreateAsync(role);
        }

        ApplicationUser user = new()
        {
            Email = request.Email,
            UserName = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            PhoneNumber = request.PhoneNumber,
            PhoneNumberConfirmed = true,
            DateOfBirth = request.DateOfBirth,
            SecurityStamp = Guid.NewGuid().ToString(),
            EmailConfirmed = true,
            TwoFactorEnabled = false,
            LockoutEnabled = false,
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            throw new ArgumentException($"Unable to register user {request.Email} errors: {GetErrorsText(result.Errors)}");
        }
        var userData = await _userManager.FindByEmailAsync(request.Email);

        await _userManager.AddToRoleAsync(userData, request.Role);
        
        return (true, null)!;

    }
    
    public async Task<(bool isSuccessful, List<IdentityError> errors)> AdminRegister(RegisterModel registerModel)
    {
        // check whether user exists
        var userByEmail = await _userManager.FindByEmailAsync(registerModel.Email);
        if (userByEmail != null)
        {
            throw new ArgumentException($"User with email {registerModel.Email} already exists.");
        }

        var currentRole = await _roleManager.FindByNameAsync(registerModel.Role);
        if (currentRole == null)
        {
            Role role = new()
            {
                Id = Guid.NewGuid(),
                Name = registerModel.Role
            };
            
            // Save role 
            await _roleManager.CreateAsync(role);
        }
        ApplicationUser user = new()
        {
            Email = registerModel.Email,
            UserName = registerModel.Email,
            FirstName = registerModel.FirstName,
            LastName = registerModel.LastName,
            PhoneNumber = registerModel.PhoneNumber,
            PhoneNumberConfirmed = true,
            DateOfBirth = registerModel.DateOfBirth,
            SecurityStamp = Guid.NewGuid().ToString(),
            EmailConfirmed = true,
            TwoFactorEnabled = false,
            LockoutEnabled = false,
        };

        var result = await _userManager.CreateAsync(user, registerModel.Password);

        if (!result.Succeeded)
        {
            throw new ArgumentException($"Unable to register user {registerModel.Email} errors: {GetErrorsText(result.Errors)}");
        }
                

        var userData = await _userManager.FindByEmailAsync(registerModel.Email);

        //Save in UserRole Table
        await _userManager.AddToRoleAsync(userData, registerModel.Role);


        return (true, null)!;
        
        
        

    }
    private string GetErrorsText(IEnumerable<IdentityError> errors)
    {
        return string.Join(", ", errors.Select(error => error.Description).ToArray());
    }
    public async Task<string> Login(LoginModel loginModel)
    {
        var user = await _userManager.FindByEmailAsync(loginModel.Email);

        if (user == null || await _userManager.CheckPasswordAsync(user,loginModel.Password))
        {
            throw new ArgumentException($"Unable to authenticate user {loginModel.Email}");
        }

        return "sdf";
    }
}