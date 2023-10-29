using AvailabilityRooms.DAL.Entities;

namespace AvailabilityRooms.Domain.Interfaces
{
    public interface IRoomService
    {

        Task<string> GetRoomsByRoomNumberAsync(int RoomNumber);


    }

}

