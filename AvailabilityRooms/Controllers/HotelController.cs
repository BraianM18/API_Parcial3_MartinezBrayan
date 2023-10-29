using AvailabilityRooms.DAL.Entities;
using AvailabilityRooms.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace AvailabilityRooms.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : Controller
    {
        
        private readonly IHotelService _hotelService;
        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        

        [HttpGet, ActionName("Get")]
        [Route("Get")] 
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotelAsync()

        {
            var hotels = await _hotelService.GetHotelAsync();

           
            if (hotels == null || !hotels.Any())
            {
                return NotFound(); //NotFound = 404 Http Status Code
            }

            return Ok(hotels); //Ok = 200 Http Status Code
        }


        [HttpGet, ActionName("Get")]
        [Route("GetHotelByRoom/{id}")] 
        public async Task<ActionResult<Hotel>> GetHotelByRoomAsync(Guid id)

        {
            if (id == null) return BadRequest("Id es requerido!");

            var hotel = await _hotelService.GetHotelByRoomAsync(id);

            if (hotel == null) return NotFound(); // 404

            return Ok(hotel); // 200
        }

        [HttpGet, ActionName("Get")]
        [Route("GetHotelByCity/{city}")] //URL: api/countries/get
        public async Task<ActionResult<Hotel>> GetHotelByCityAsync(string city)

        {
            if (city == null) return BadRequest("Nombre del país requerido!");

            var hotel = await _hotelService.GetHotelByCityAsync(city);

            if (hotel == null) return NotFound(); // 404

            return Ok(hotel); // 200
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Hotel>> EditHotelAsync(Guid id, int stars)
                  
        {
            try
            {
                var editedHotel = await _hotelService.EditHotelAsync(id, stars);
                return Ok(editedHotel);
            }
            catch (Exception ex)
            {
               
                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Hotel>> DeleteHotelAsync(Guid id)

        {
            if (id == null) return BadRequest("Id es requerido!");

            var deletedHotel = await _hotelService.DeleteHotelAsync(id);

            if (deletedHotel == null) return NotFound("Hotel no encontrado!");

            return Ok(deletedHotel);
        }
    }
}
