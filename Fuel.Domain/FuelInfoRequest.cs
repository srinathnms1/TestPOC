﻿namespace Fuel.Domain
{
    using System;

    public class FuelInfoRequest
    {
        public int? DriverId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
