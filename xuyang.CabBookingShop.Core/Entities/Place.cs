using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xuyang.CabBookingShop.Core.Entities
{
    public class Place
    {
        public int PlaceId { get; set; }
        public string PlaceName { get; set; }

        // Navigation Propties
        public ICollection<BookingHistory> ToBookingHistories { get; set; }
        public ICollection<BookingHistory> FromBookingHistories { get; set; }
        public ICollection<Booking> ToBookings { get; set; }
        public ICollection<Booking> FromBookings { get; set; }
    }
}
