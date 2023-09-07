using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Authorize]
    [ApiController]   
    public class UserController : ControllerBase
    {
        private readonly UserDbContext _context;
        public UserController(UserDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("api/User/getusers")]
        public ActionResult<IEnumerable<AppUser>> GetUsers()
        {
            return _context.Users;
        }

        [HttpGet("{Id:Guid}")]
        [Route("api/User")]
        public async Task<ActionResult<AppUser>> GetById(Guid id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        /*[HttpPost]
        [Route("api/User/isemail")]
        public async Task<ActionResult> IsEmail(FastEmail email)
        {
            var userEmail = await _context.IdsEmails.FindAsync(email.Email);

            if (userEmail == null)
            {
                return NotFound("E-mail not found.");
            }            

            return Ok();
        }*/

        /*[HttpPost]
        [Route("api/User/isname")]
        public async Task<ActionResult> IsUserName(FastUserName user)
        {
            var userName = await _context.IdsUsers.FindAsync(user.UserName);

            if (userName == null)
            {
                return NotFound("User name not found.");
            }

            return Ok();
        }*/

        [HttpPost]
        [AllowAnonymous]
        [Route("api/User")]
        public async Task<ActionResult> Create(AppUser user)
        {
            IdByEmail userIdByEmail = new();
            userIdByEmail.Email = user.Email;
            userIdByEmail.Id = user.Id;

            IdByUserName userIdByUserName = new();
            userIdByUserName.UserName = user.UserName;
            userIdByUserName.Id = user.Id;

            await _context.Users.AddAsync(user);
            await _context.IdsEmails.AddAsync(userIdByEmail);
            await _context.IdsUsers.AddAsync(userIdByUserName);
            await _context.SaveChangesAsync();

            var actionName = nameof(GetById);
            var routeValue = new { id = user.Id };

            SingleString responceObj = new();
            responceObj.Data = "New user successfully created.";

            return CreatedAtAction(actionName, routeValue, responceObj);
        }

        [HttpPut]
        [Route("api/User")]
        public async Task<ActionResult> Update(AppUser user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{Id:Guid}")]
        [Route("api/User")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
