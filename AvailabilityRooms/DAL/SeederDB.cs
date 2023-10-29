using System.Diagnostics.Metrics;
using AvailabilityRooms.DAL.Entities;

namespace AvailabilityRooms.DAL
{
    public class SeederDB
    {
        private readonly DataBaseContext _context;

        public SeederDB(DataBaseContext context)
        {
            _context = context;
        }



        public async Task SeederAsync()
        {

            await _context.Database.EnsureCreatedAsync();


            await FillHotelsAsync();

            await _context.SaveChangesAsync();
        }

        #region Private Methos
        private async Task FillHotelsAsync()
        {


            if (!_context.Hotels.Any())
            {

                _context.Hotels.Add(new Hotel
                {
                    CreatedDate = DateTime.Now,
                    Name = "NH Cali Royal",
                    Address = "Carrera 26cc # 34 -45",
                    Phone = 423453254,
                    Stars = 3,
                    City = "Cali",

                    Rooms = new List<Room>()
                    {
                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = 01,
                            MaxGuests = 2,
                            Availability = false,
                        },

                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = 09,
                            MaxGuests = 4,
                            Availability = true,
                        },

                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = 11,
                            MaxGuests = 3,
                            Availability = false,
                        },

                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = 23,
                            MaxGuests = 5,
                            Availability = true,
                        }


                    }
                }); ;


                _context.Hotels.Add(new Hotel
                {
                    CreatedDate = DateTime.Now,
                    Name = "GHL Corales de Indias",
                    Address = "Calle 2a # 20 -12",
                    Phone = 423453254,
                    Stars = 3,
                    City = "Cartagena",
                    Rooms = new List<Room>()
                    {
                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = 02,
                            MaxGuests = 2,
                            Availability = true,
                        },

                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = 08,
                            MaxGuests = 4,
                            Availability = true,
                        },

                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = 10,
                            MaxGuests = 3,
                            Availability = false,
                        },

                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = 09,
                            MaxGuests = 5,
                            Availability = true,
                        }
                    }
                });

                _context.Hotels.Add(new Hotel
                {
                    CreatedDate = DateTime.Now,

                    Name = "Titón",
                    Address = "Transversal 42 # 103 - 22",
                    Phone = 423453254,
                    Stars = 4,
                    City = "Bogotá",
                    Rooms = new List<Room>()
                    {
                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = 04,
                            MaxGuests = 2,
                            Availability = false,
                        },

                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = 07,
                            MaxGuests = 4,
                            Availability = true,
                        },

                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = 09,
                            MaxGuests = 3,
                            Availability = false,
                        },

                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = 11,
                            MaxGuests = 5,
                            Availability = true,
                        }
                    }
                });
            }
        }
    }

    #endregion
}
