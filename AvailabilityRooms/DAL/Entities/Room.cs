using System.ComponentModel.DataAnnotations;

namespace AvailabilityRooms.DAL.Entities
{
    public class Room : AuditBase
    {

        

        [Display(Name = "Número de habitación")]
        [MaxLength(50, ErrorMessage = "El campo {1} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "¡El campo {1} es obligatorio!")]
        public int Number { get; set; }

        [Display(Name = "Capacidad máxima de la habitación")]
        [MaxLength(6 , ErrorMessage = "El campo {2} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "¡El campo {2} es obligatorio!")]
        public int MaxGuests { get; set; }

        [Display(Name = "Disponibilidad")]
        public bool Availability { get; set; } = false;

        [Display(Name = "Id Hotel")]
        public Guid HotelId { get; set; } //Foreign key to relate to Hotel
        public Hotel hotel { get; set; }
    }
}
