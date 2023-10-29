using AvailabilityRooms.DAL.Entities;
using System.Diagnostics.Metrics;

namespace AvailabilityRooms.Domain.Interfaces
{
    public interface IHotelService
    {
        Task<IEnumerable<Hotel>> GetHotelAsync();
        //Task<Hotel> CreateHotelAsync(Hotel Hotel);
        Task<Hotel> GetHotelByRoomAsync(Guid id);
        Task<Hotel> GetHotelByCityAsync(string city);
        Task<Hotel> EditHotelAsync(Guid id, int stars);
        Task<Hotel> DeleteHotelAsync(Guid id);
    }
}
