using PhishyBank.Models;

namespace PhishyBank.Data;

public class LoginResult
{
    public string? JwtToken { get; set; }
    public bool Success { get; set; } = false;
}
