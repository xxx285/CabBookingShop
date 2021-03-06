using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xuyang.CabBookingShop.Core.Models.Request
{
    public class HistoryUpdateRequestModel
    {
        [Required]
        public int Id { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        public DateTime? BookingDate { get; set; }
        [StringLength(5)]
        public string BookingTime { get; set; }
        public int? FromPlaceId { get; set; }
        public int? ToPlaceId { get; set; }
        [StringLength(200)]
        public string PickUpAddress { get; set; }
        [StringLength(30)]
        public string Landmark { get; set; }
        public DateTime? PickupDate { get; set; }
        [StringLength(5)]
        public string PickupTime { get; set; }
        public int? CabTypeId { get; set; }
        [StringLength(25)]
        public string ContactNo { get; set; }
        [StringLength(30)]
        public string Status { get; set; }
        [StringLength(5)]
        public string CompTime { get; set; }
        public decimal? Charge { get; set; }
        [StringLength(1000)]
        public string Feedback { get; set; }
    }
}
