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
        public async Task<ActionResult> IsEmail(SingleString email)
        {
            var userEmail = await _context.IdsEmails.FindAsync(email.Data);

            SingleString emailDispatch = new();

            if (userEmail == null)
            {
                emailDispatch.Data = "Email not found.";

                return NotFound(emailDispatch);
            }

            emailDispatch.Data = "Email already registered.";

            //ToDo add email politics

            return Ok(emailDispatch);
        }

        [HttpPost]
        [Route("api/Register/isname")]
        public async Task<ActionResult> IsUserName(SingleString user)
        {
            var userName = await _context.IdsUsers.FindAsync(user.Data);

            SingleString nameDispatch = new();

            if (userName == null)
            {
                nameDispatch.Data = "User name not found.";

                return NotFound(nameDispatch);
            }

            nameDispatch.Data = "User name already exists.";

            //ToDo user name politics

            return Ok(nameDispatch);
        }

        [HttpPost]
        [Route("api/Register/isfirstmidname")]
        public async Task<ActionResult> IsFirstMidName(SingleString user)
        {
            SingleString nameDispatch = new();            

            //ToDo name politics

            return Ok(nameDispatch);
        }

        [HttpPost]
        [Route("api/Register/islastname")]
        public async Task<ActionResult> IsLastName(SingleString user)
        {
            SingleString nameDispatch = new();

            //ToDo name politics

            return Ok(nameDispatch);
        }

        [HttpPost]
        [Route("api/Register/ispassword")]
        public async Task<ActionResult> IsPassword(SingleString passwordReceive)
        {
            SingleString passwordDispatch = new();

            if (passwordReceive == null)
            {
                return BadRequest();
            }
            if (passwordReceive.Data == null)
            {
                passwordReceive.Data = "The Password field is required.";

                return BadRequest(passwordReceive);
            }

            passwordDispatch.Data = passwordPolicy(passwordReceive.Data).Result;

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
