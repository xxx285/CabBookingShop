using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xuyang.CabBookingShop.Core.Models.Request
{
    public class CabTypeUpdateRequestModel
    {
        [Required]
        public int CabTypeId { get; set; }

        [Required]
        [StringLength(30)]
        public string CabTypeName { get; set; }
    }
}
