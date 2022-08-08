using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PhishyBank.Models;
using PhishyBank.Data;
using System.Text.Json;

namespace PhishyBank.Server.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LoginValidationController : ControllerBase
    {
        private readonly ILogger<LoginValidationController> logger;
        private readonly IServiceProvider provider;
        private readonly IDbContextFactory<BankContext> contextFactory;

        public LoginValidationController(IServiceProvider provider, ILogger<LoginValidationController> logger, IDbContextFactory<BankContext> contextFactory)
        {
            this.provider = provider;
            this.logger = logger;
            this.contextFactory = contextFactory;
        }

        // static readonly string[] scopeRequiredByApi = new[] { "API.Access" };

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            await Task.Delay(1); // To make the compiler happy
            return Unauthorized(new { message = "Unauthorized access" });
        }

        [HttpPost]
        public async Task<IActionResult> Post(User loginUser)
        {
            // HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);
            // Console.WriteLine("Processing POST");

            await Task.Delay(1); // To make the compiler happy

            try
            {
                if (string.IsNullOrEmpty(loginUser.Email))
                {
                    ModelState.AddModelError(nameof(loginUser.Email),
                        "Email is required");
                }
                if (string.IsNullOrEmpty(loginUser.Password))
                {
                    ModelState.AddModelError(nameof(loginUser.Password),
                        "Password is required");
                }

                if (ModelState.ErrorCount == 0)
                {
                    using (var context = contextFactory.CreateDbContext())
                    {
                        var user = context.Users.Where(u => u.Email == loginUser.Email && u.Password == loginUser.Password);
                        // logger.LogInformation("User is " + JsonSerializer.Serialize(user));
                        if (user.Count() == 0)
                        {
                            logger.LogWarning("[{0}] User not found", this.GetType().Name);
                            ModelState.AddModelError("Validation",
                                "Invalid email and/or password");
                        }
                        else
                        {
                            logger.LogInformation("[{0}] User found", this.GetType().Name);
                            return Ok(ModelState);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Validation Error: {Message}", ex.Message);
            }

            return BadRequest(ModelState);
        }
    }
}