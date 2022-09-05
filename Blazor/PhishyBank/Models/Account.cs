using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhishyBank.Models
{
    public class Account
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; } = null!;
        [DefaultValue("CURRENT_TIMESTAMP")]
        public DateTimeOffset DateCreatedUtc { get; set; }
    }
}