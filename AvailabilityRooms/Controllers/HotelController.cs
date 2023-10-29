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

        //En un controlador los métodos cambian de nombre, y realmente se llaman ACCIONES (ACTIONS) - Si es una API, se denomina ENDPOINT.
        //Todo Endpoint retorna un ActionResult, significa que retorna el resultado de una ACCIÓN.

        [HttpGet, ActionName("Get")]
        [Route("Get")] //Aquí concateno la URL inicial: URL = api/countries/get
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotelAsync()

        {
            var hotels = await _hotelService.GetHotelAsync(); //Aquí estoy yendo a mi capa de Domain para traerme la lista de países

            //El método Any() significa si hay al menos un elemento.
            //El Método !Any() significa si no hay absoluta/ nada.
            if (hotels == null || !hotels.Any())
            {
                return NotFound(); //NotFound = 404 Http Status Code
            }

            return Ok(hotels); //Ok = 200 Http Status Code
        }

        //[HttpPost, ActionName("Create")]
        //[Route("Create")]
        //public async Task<ActionResult> CreateCountryAsync(Country country)
        //{
        //    try
        //    {
        //        var createdCountry = await _countryService.CreateCountryAsync(country);

        //        if (createdCountry == null)
        //        {
        //            return NotFound(); //NotFound = 404 Http Status Code
        //        }

        //        return Ok(createdCountry); //Retorne un 200 y el objeto Country
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.Message.Contains("duplicate"))
        //        {
        //            return Conflict(String.Format("El país {0} ya existe.", country.Name)); //Confilct = 409 Http Status Code Error
        //        }

        //        return Conflict(ex.Message);
        //    }
        //}

        [HttpGet, ActionName("Get")]
        [Route("GetHotelByRoom/{id}")] //URL: api/countries/get
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
