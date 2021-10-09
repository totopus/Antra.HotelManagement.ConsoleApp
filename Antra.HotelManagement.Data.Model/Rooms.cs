# nullable enable
using System;
using System.Collections.Generic;
using System.Text;

namespace Antra.HotelManagement.Data.Model
{
    public class Rooms
    {
        public int Id { get; set; }
        public int? RTCode { get; set; }
        public bool? Status { get; set; }

        public RoomTypes? RoomTypes { get; set; }
        public Services? Services { get; set; }
  


    }
}
