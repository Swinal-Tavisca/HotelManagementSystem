using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelAPI.Models
{
    public class APIResponse
    {
        public List<HotelModel> hotels { get; set; }

        public Status Status { get; set; }
    }
}