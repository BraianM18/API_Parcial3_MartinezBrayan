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

        //Listar
        public async Task<IEnumerable<Hotel>> GetHotelAsync()
           
        {

            return await _context.Hotels
                .Include(r => r.Rooms.Where(a => a.Availability == true))
                .ToListAsync();
        }

        //public async Task<Hotel> CreateCountryAsync(Hotel hotel)
        //{
        //    try
        //    {
        //        hotel.Id = Guid.NewGuid(); //Así se asigna automáticamente un ID a un nuevo registro
        //        hotel.CreatedDate = DateTime.Now;

        //        _context.Hotels.Add(hotel); //Aquí estoy creando el objeto Country en el contexto de mi BD
        //        await _context.SaveChangesAsync(); //Aquí ya estoy yendo a la BD para hacer el INSERT en la tabla Countries

        //        return hotel;
        //    }
        //    catch (DbUpdateException dbUpdateException)
        //    {
        //        //Esta exceptión me captura un mensaje cuando el país YA EXISTE (Duplicados)
        //        throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message); //Coallesences Notation --> ??
        //    }
        //}

        //Obtener hotel por ID con sus respectivas habitaciones

        public async Task<Hotel> GetHotelByRoomAsync(Guid id)

        {
            //var hotels = await _context.Hotels.Include(h => h.Rooms.Where(r => r.Availability == true)).ToListAsync();
            return await _context.Hotels
                .Include(r => r.Rooms.Where(a => a.Availability == true))
                .FirstOrDefaultAsync(h => h.Id == id);
        }

        //Obtener hotel por Ciudad con sus respectivas habitaciones disponibles
        public async Task<Hotel> GetHotelByCityAsync(string city)
        {
            return await _context.Hotels
             .Include(r => r.Rooms.Where(a => a.Availability == true))
             .FirstOrDefaultAsync(h => h.City == city);
        }


        //Modificar la calificacion de un hotel

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

        //Eliminar hotel y sus habitaciones
        public async Task<Hotel> DeleteHotelAsync(Guid id)
        {
            try
            {
                
                var hotels = await _context.Hotels
                    .Include(c => c.Rooms) //Cascade removing
                    .FirstOrDefaultAsync(c => c.Id == id);
                if (hotels == null) return null; //Si el país no existe, entonces me retorna un NULL

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

