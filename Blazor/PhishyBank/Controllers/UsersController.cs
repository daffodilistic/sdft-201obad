using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PhishyBank.Models;
using PhishyBank.Data;
using System.Text.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PhishyBank.Server.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> logger;
        // private readonly IServiceProvider provider;
        private readonly BankContext context;

        public UsersController(ILogger<UsersController> logger, IDbContextFactory<BankContext> contextFactory)
        {
            // this.provider = provider;
            this.logger = logger;
            this.context = contextFactory.CreateDbContext();
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpGet("{id}/transactions")]
        public async Task<ActionResult<IEnumerable<AccountTransaction>>> GetTransactions(int id)
        {
            var transactions = await context.AccountTransactions
            .Where(t => t.UserId == id)
            .Take(30)
            .ToListAsync();

            if (transactions == null)
            {
                return NotFound();
            }

            return transactions;
        }
    }
}