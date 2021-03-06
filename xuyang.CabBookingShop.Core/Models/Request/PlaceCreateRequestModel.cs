using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xuyang.CabBookingShop.Core.Models.Request
{
    public class PlaceCreateRequestModel
    {
        [Required]
        [StringLength(30)]
        public string PlaceName { get; set; }
    }
}
