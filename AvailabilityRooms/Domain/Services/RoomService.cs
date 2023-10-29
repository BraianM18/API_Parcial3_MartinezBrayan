using AvailabilityRooms.DAL;
using AvailabilityRooms.DAL.Entities;
using AvailabilityRooms.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace AvailabilityRooms.Domain.Services
{
    public class RoomService : IRoomService
    {
        private readonly DataBaseContext _context;

        public RoomService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<string> GetRoomsByRoomNumberAsync(int RoomNumber)
        {

            var room = await _context.Rooms
                .FirstOrDefaultAsync(rn => rn.Number == RoomNumber);
            var hotel = await _context.Hotels
                .FirstOrDefaultAsync(h => h.Id == room.HotelId);

            if (!room.Availability) return "Room " + room.Number + " of the " + hotel.Name + " already booked ";
            else return room.ToString();
        }



    }
}
