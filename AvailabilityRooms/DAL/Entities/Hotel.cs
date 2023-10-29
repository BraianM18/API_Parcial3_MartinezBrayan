using System.ComponentModel.DataAnnotations;

namespace AvailabilityRooms.DAL.Entities
{
    public class Hotel : AuditBase
    {

        [Key]
        [Required]
        public Guid Id { get; set; }

        [Display(Name = "Hotel")] 
        [MaxLength(50, ErrorMessage = "El campo {1} debe tener máximo {1} caracteres")] 
        [Required(ErrorMessage = "¡El campo {1} es obligatorio!")]
        public string Name { get; set; }

        [Display(Name = "Dirección")]
        [MaxLength(50, ErrorMessage = "El campo {2} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "¡El campo {2} es obligatorio!")]
        public string Address { get; set; }

        [Display(Name = "Telefono")]
        [MaxLength(10, ErrorMessage = "El campo {3} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "¡El campo {3} es obligatorio!")]
        public int Phone { get; set; }

        [Display(Name = "Estrellas")]
        [MaxLength(50, ErrorMessage = "El campo {4} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "¡El campo {4} es obligatorio!")]
        public int Stars { get; set; }

        [Display(Name = "Ciudad")] 
        [MaxLength(50, ErrorMessage = "El campo {5} debe tener máximo {1} caracteres")] 
        [Required(ErrorMessage = "¡El campo {5} es obligatorio!")]
        public string City { get; set; }

        [Display(Name = "Habitaciones")]

        //Relationship with Rooms
        public List<Room>? Rooms { get; set; }
    }
}
