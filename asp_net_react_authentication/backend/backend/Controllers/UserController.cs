using backend.Models;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    [ApiController]    
    //[ProducesResponseType(StatusCodes.Status201Created)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class UserController : ControllerBase
    {
        private readonly UserDbContext _context;
        public UserController(UserDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/User")]
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

        [HttpPost]
        [Route("api/User/isemail")]
        public async Task<ActionResult> IsEmail(FastEmail email)
        {
            var userEmail = await _context.IdsEmails.FindAsync(email.Email);

            if (userEmail == null)
            {
                return NotFound("E-mail not found.");
            }            

            return Ok();
        }

        [HttpPost]
        [Route("api/User/isname")]
        public async Task<ActionResult> IsUserName(FastUserName user)
        {
            var userName = await _context.IdsUsers.FindAsync(user.UserName);

            if (userName == null)
            {
                return NotFound("User name not found.");
            }

            return Ok();
        }

        [HttpPost]
        [Route("api/User")]
        public async Task<ActionResult> Create(AppUser user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
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
