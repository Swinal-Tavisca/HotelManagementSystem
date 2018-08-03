﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelAPI.Models
{
    public class Status
    {
        public ApiStatus ApiStatus { get; set; }

        public int ErrorCode { get; set; }

        public string ErrorMessage { get; set; }
    }
    public enum ApiStatus
    {
        Success,
        Failure,
        Warning
    }
}