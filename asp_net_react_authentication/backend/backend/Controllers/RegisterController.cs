using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp;

namespace backend.Controllers
{
    [ApiController]
    public class RegisterController : Controller
    {
        private readonly UserDbContext _context;
        public RegisterController(UserDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("api/Register/isemail")]
        public async Task<ActionResult> IsEmail(FastEmail email)
        {
            var userEmail = await _context.IdsEmails.FindAsync(email.Email);

            FastEmail emailDispatch = new();

            if (userEmail == null)
            {
                emailDispatch.Email = "";
            }
            else
            {
                emailDispatch.Email = "Email already registered.";
            }

            //ToDo add email politics

            return Ok(emailDispatch);
        }

        [HttpPost]
        [Route("api/Register/isname")]
        public async Task<ActionResult> IsUserName(FastUserName user)
        {
            var userName = await _context.IdsUsers.FindAsync(user.UserName);

            FastUserName nameDispatch = new();

            if (userName == null)
            {
                nameDispatch.UserName = "";
            }
            else
            {
                nameDispatch.UserName = "User name already exists.";
            }

            //ToDo check for user name correct

            return Ok(nameDispatch);
        }

        [HttpPost]
        [Route("api/Register/ispassword")]
        public async Task<ActionResult> IsPassword(FastPassword passwordReceive)
        {
            FastPassword passwordDispatch = new();

            if (passwordReceive == null)
            {
                return BadRequest();
            }
            if (passwordReceive.Password == null)
            {
                passwordReceive.Password = "The Password field is required.";

                return BadRequest(passwordReceive);
            }            

            passwordDispatch.Password = passwordPolicy(passwordReceive.Password).Result;

            return Ok(passwordDispatch);
        }

        private async Task<string> passwordPolicy(string password)
        {
            //ToDo Hash func + password policy
            return await Task.Run(() =>
            {
                if (!string.IsNullOrEmpty(password))
                {
                    return "";
                }

                return "Password policy disagree.";
            });
        }
    }
}
