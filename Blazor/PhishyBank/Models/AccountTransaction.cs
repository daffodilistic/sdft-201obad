using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace PhishyBank.Models
{
    public class AccountTransaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string AccountIdSource { get; set; } = null!;
        public string AccountIdTarget { get; set; } = null!;
        public uint Amount { get; set; }
        public string Currency { get; set; } = null!;
        public string? Remarks { get; set; }
        public string State { get; set; } = null!;
        [DefaultValue("CURRENT_TIMESTAMP")]
        public DateTimeOffset DateCreatedUtc { get; set; }
        [DefaultValue("CURRENT_TIMESTAMP")]
        public DateTimeOffset DateUpdatedUtc { get; set; }
        [Column(TypeName = "json")]
        public string? Metadata { get; set; }
    }
}