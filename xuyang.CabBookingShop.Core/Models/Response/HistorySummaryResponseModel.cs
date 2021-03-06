﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xuyang.CabBookingShop.Core.Models.Response
{
    public class HistorySummaryResponseModel
    {
        public int Id { get; set; }
        public int? FromPlaceId { get; set; }
        public DateTime? BookingDate { get; set; }
        public int? ToPlaceId { get; set; }
        public int? CabTypeId { get; set; }
        public string CompTime { get; set; }

        public PlaceResponseModel ToPlace { get; set; }
        public PlaceResponseModel FromPlace { get; set; }
        public CabTypeResponseModel CabType { get; set; }
    }
}
