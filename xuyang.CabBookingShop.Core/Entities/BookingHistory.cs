using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xuyang.CabBookingShop.Core.Entities
{
    public class BookingHistory
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime? BookingDate { get; set; }
        public string BookingTime { get; set; }
        public int? FromPlaceId { get; set; }
        public int? ToPlaceId { get; set; }
        public string PickUpAddress { get; set; }
        public string Landmark { get; set; }
        public DateTime? PickupDate { get; set; }
        public string PickupTime { get; set; }
        public int? CabTypeId { get; set; }
        public string ContactNo { get; set; }
        public string Status { get; set; }
        public string CompTime { get; set; }
        public decimal? Charge { get; set; }
        public string Feedback { get; set; }

        // Navigation Propties
        public Place ToPlace { get; set; }
        public Place FromPlace { get; set; }
        public CabType CabType { get; set; }
    }
}
