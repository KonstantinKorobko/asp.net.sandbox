using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
            //string id = User.FindFirstValue(ClaimTypes.Name);
            return _context.Users;
        }

        [HttpPost]
        [Route("api/User/getuser")]
        public async Task<ActionResult<User>> GetById()
        {
            //Guid guid;
            Guid.TryParse(User.FindFirstValue(ClaimTypes.Name), out Guid guid);
            AppUser appUser = await _context.Users.FindAsync(guid);

            if (appUser == null)
            {
                return NotFound();
            }

            User user = new(appUser);

            return Created("", user);
        }

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
