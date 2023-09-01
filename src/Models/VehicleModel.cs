using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectGotham.Models
{
    [Table("Vehicles")]
    public class VehicleModel
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid(); // Automatically generate a new GUID for each new account
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
