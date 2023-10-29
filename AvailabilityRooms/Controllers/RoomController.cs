using AvailabilityRooms.DAL.Entities;
using AvailabilityRooms.Domain.Interfaces;
using AvailabilityRooms.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


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

            var room = await _roomService.GetRoomsByRoomNumberAsync(id, RoomNumber);

            if (room == null)
            {

                return NotFound($"Room {RoomNumber} not found");
            }


            return Ok(room);
        }
        
    }
}

