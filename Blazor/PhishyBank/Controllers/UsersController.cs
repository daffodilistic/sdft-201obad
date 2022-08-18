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
        private readonly IDbContextFactory<BankContext> contextFactory;

        public UsersController(ILogger<UsersController> logger, IDbContextFactory<BankContext> contextFactory)
        {
            // this.provider = provider;
            this.logger = logger;
            this.contextFactory = contextFactory;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            using (var context = contextFactory.CreateDbContext())
            {
                return await context.Users.ToListAsync();
            }
        }
    }
}