using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Du_Fang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDBContext _context;

        public UserController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // GET: api/User/GetUserIdByEmail?email={email}
        [HttpGet("GetUserIdByEmail")]
        public async Task<ActionResult<int>> GetUserIdByEmail(string email)
        {
            // Find the user by email
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            // Find the account using the UserId
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.UserId == user.UserId);

            if (account == null)
            {
                return NotFound("Account not found.");
            }

            // Return the AccountId
            return Ok(account.AccountId);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
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

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }

        [HttpGet("account/{userId}")]
        public async Task<ActionResult<Account>> GetAccountByUserId(int userId)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.UserId == userId);

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }
    }
}
