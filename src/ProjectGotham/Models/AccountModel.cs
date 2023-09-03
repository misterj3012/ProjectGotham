using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectGotham.Models
{
    [Table("Accounts")]
    public class AccountModel
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid(); // Automatically generate a new GUID for each new account

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string EMail { get; set; }

        [Required]
        [MaxLength(255)] // You might want to adjust this length based on your password hashing method
        public string Password { get; set; } // Store hashed passwords, never plain text!

        [Required]
        public DateTime CreationDate { get; set; } = DateTime.UtcNow; // Set default value to current UTC time

        public DateTime? LastLogin { get; set; } // Nullable, as there might not be a last login yet

        [MaxLength(50)] // IPv6 addresses can be up to 45 characters, so 50 should be safe
        public string IP { get; set; }

        public bool Activated { get; set; } = false; // Default to true if you want accounts to be activated by default

        public bool Banned { get; set; } = false; // Default to false, assuming new accounts aren't banned
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public virtual ICollection<CharacterModel> Characters { get; set; } = new List<CharacterModel>();
    }
}
