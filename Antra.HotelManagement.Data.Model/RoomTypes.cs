# nullable enable
using System;
using System.Collections.Generic;
using System.Text;

namespace Antra.HotelManagement.Data.Model
{
    public class RoomTypes
    {
        public int Id { get; set; }
        public string? RTDesc { get; set; }
        public decimal? Rent { get; set; }

    }
}
