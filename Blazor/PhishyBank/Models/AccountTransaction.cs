using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace PhishyBank.Models
{
    public class AccountTransaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string AccountIdSource { get; set; }
        public string AccountIdTarget { get; set; }
        public uint Amount { get; set; }
        public string Currency { get; set; }
        public string? Remarks { get; set; }
        public string State { get; set; }
        [DefaultValue("CURRENT_TIMESTAMP")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }
        [DefaultValue("CURRENT_TIMESTAMP")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateUpdated { get; set; }
        [Column(TypeName = "json")]
        public string? Metadata { get; set; }
    }
}