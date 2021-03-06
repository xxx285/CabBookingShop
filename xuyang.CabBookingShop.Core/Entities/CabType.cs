using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xuyang.CabBookingShop.Core.Entities
{
    public class CabType
    {
        public int CabTypeId { get; set; }
        public string CabTypeName { get; set; }

        // Navigation Propties
        public ICollection<BookingHistory> BookingHistories { get; set; }
        public ICollection<Booking> Bookings { get; set; }

    }
}
