using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectGotham.Models
{
    [Table("Characters")]
    public class CharacterModel
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();
        public Guid AccountID { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string MiddleName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public virtual AccountModel Account { get; set; }
    }
}
