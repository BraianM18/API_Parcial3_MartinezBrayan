using AvailabilityRooms.DAL.Entities;
using AvailabilityRooms.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace AvailabilityRooms.Controllers
{
    [ApiController]
    [Route("room/[controller]")]
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet, ActionName("Get")]
        [Route("Get")]
        public async Task<ActionResult<Room>> GetRoomsByRoomNumberAsync(Guid id, int RoomNumber)
        {
            // Lógica para obtener la habitación por el número de habitación.
            var room = await _roomService.GetRoomsByRoomNumberAsync(id, RoomNumber);

            if (room == null)
            {
                // Si la habitación no se encuentra, devolver un NotFound.
                return NotFound($"Room {RoomNumber} not found");
            }

            // Si se encuentra la habitación, devolverla como un OkResult.
            return Ok(room);
        }
    }
}

