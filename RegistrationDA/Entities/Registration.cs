using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistrationDA.Entities
{
    public class Registration
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string? Name { get; set; }

        [Column(TypeName = "string")]
        public string? Email { get; set; }

        public double PhoneNumber { get; set; }

        [Column(TypeName = "string")]
        public string? City { get; set; }

        public int PinCode { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime RegisteredDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }
    }
}
