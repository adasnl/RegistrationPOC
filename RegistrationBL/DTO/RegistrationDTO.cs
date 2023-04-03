using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Registration.BusinessLayer.DTO
{
    public class RegistrationDTO
    {
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
