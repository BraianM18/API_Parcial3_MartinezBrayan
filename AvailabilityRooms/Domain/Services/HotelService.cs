using AvailabilityRooms.DAL;
using AvailabilityRooms.DAL.Entities;
using AvailabilityRooms.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace AvailabilityRooms.Domain.Services
{
    public class HotelService : IHotelService
    {
        private readonly DataBaseContext _context;

        public HotelService(DataBaseContext context)
        {
            _context = context;
        }

        //List hotels with their respective available rooms
        public async Task<IEnumerable<Hotel>> GetHotelAsync()
           
        {

            return await _context.Hotels
                .Include(r => r.Rooms.Where(a => a.Availability == true))
                .ToListAsync();
        }


        //Get hotel by ID with their respective available rooms

        public async Task<Hotel> GetHotelByRoomAsync(Guid id)

        {
            return await _context.Hotels
                .Include(r => r.Rooms.Where(a => a.Availability == true))
                .FirstOrDefaultAsync(h => h.Id == id);
        }

        //Obtain hotel by city with their respective available rooms
        public async Task<Hotel> GetHotelByCityAsync(string city)
        {
            return await _context.Hotels
             .Include(r => r.Rooms.Where(a => a.Availability == true))
             .FirstOrDefaultAsync(h => h.City == city);
        }


        //Modify the rating of a hotel

        public async Task<Hotel> EditHotelAsync(Guid id, int stars)
        {
            try
            {
                var hotels = await _context.Hotels.FindAsync(id);

                hotels.ModifiedDate = DateTime.Now;
                hotels.Stars = stars;
                

                _context.Hotels.Update(hotels); 
                await _context.SaveChangesAsync();

                return hotels;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        //Delete hotel and its rooms
        public async Task<Hotel> DeleteHotelAsync(Guid id)
        {
            try
            {
                
                var hotels = await _context.Hotels
                    .Include(c => c.Rooms) 
                    .FirstOrDefaultAsync(c => c.Id == id);
                if (hotels == null) return null;

                _context.Hotels.Remove(hotels);
                await _context.SaveChangesAsync();

                return hotels;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public Task<IEnumerable<Hotel>> GetHotelsAsync()
        {
            throw new NotImplementedException();
        }
    }
}

