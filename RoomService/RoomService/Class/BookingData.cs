using SQLite;
using System;

namespace RoomService.Class
{
    public class BookingData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string ItemName { get; set; }
        public DateTime BookingTime { get; set; }
        public double Quantity { get; set; }
    }
}
