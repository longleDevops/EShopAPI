using ApplicationCore.IServices;
using Authentication.API.Entities;
using Authentication.API.Models;
using AuthenticationAPI.Entities;
using AuthenticationAPI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController:ControllerBase
{
    private readonly IAuthenticationServices<ApplicationUser> _authenticationServices;
    public AuthenticationController(IAuthenticationServices<ApplicationUser> authenticationServices)
    {
        _authenticationServices = authenticationServices;
    }

    [HttpPost("admin-register")]
    public async Task<IActionResult> AdminRegister()
    {
        return Ok("");
    }
    
    [AllowAnonymous]
    [HttpPost("customer-register")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerRegisterModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CustomerRegister([FromBody]CustomerRegisterModel registerModel)
    {
       
            var response = await _authenticationServices.CustomerRegister(registerModel);
            if (response.isSuccessful)
            {
                return Ok("Account Created");
            }
            else
            {
                return BadRequest(response.errors.ToString());
            }
    }
    
    [AllowAnonymous]
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login([FromBody] LoginModel request)
    {
        try
        {
            var responseToken = await _authenticationServices.Login(request);
            var response = new
            {
                Token = responseToken
            };
            return Ok(response);

        }
        catch (Exception ex)
        {
            ErrorResponse errorResponse = new(ex);
            return BadRequest(errorResponse);
        }

    }
    
}