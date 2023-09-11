using backend.Helpers;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp;

namespace backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly UserDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly Authentication authentication;
        public LoginController(UserDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            authentication = new(configuration);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Login(AuthUser request)
        {
            //TODO password hash BCript?
            var user = await _context.IdsUsers.FindAsync(request.UserName);

            SingleString response = new();            

            if (user == null) 
            {
                response.Data = "Wrong login or password.";
                return Unauthorized(response);
            }

            var userData = await _context.Users.FindAsync(user.Id);

            if (userData == null)
            {
                response.Data = "Wrong login or password.";
                return Unauthorized(response);
            }

            if (userData.Password != request.Password)
            {
                response.Data = "Wrong login or password.";
                return Unauthorized(response);
            }

            LoginResponse loginResponse = new();
            loginResponse.JWT = authentication.GetJWT(user.Id);
            loginResponse.Role = userData.Role;

            /*
             The HTTP 201 Created success status response code indicates that the request has succeeded and has led to the creation of a resource.
            The new resource, or a description and link to the new resource,
            is effectively created before the response is sent back and the newly created items are returned in the body of the message,
            located at either the URL of the request,
            or at the URL in the value of the Location header.
             */
            return Created("", loginResponse);
        }        
    }
}
