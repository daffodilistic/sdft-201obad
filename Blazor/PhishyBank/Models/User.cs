using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhishyBank.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Name { get; set; }
    }
}