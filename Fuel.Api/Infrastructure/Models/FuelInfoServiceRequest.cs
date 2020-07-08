namespace Fuel.Api.Infrastructure.Models
{
    using Fuel.Api.Infrastructure.Models.Binders;
    using Fuel.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    [ModelBinder(BinderType = typeof(FuelInfoModelBinder))]
    public class FuelInfoServiceRequest
    {
        [Required]
        public string DriverId { get; set; }

        [DateValidator(ErrorMessage ="From Date error")]
        public string FromDate { get; set; }

        public string ToDate { get; set; }
    }

    public class DateValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var test = DateTime.TryParseExact(value.ToString(), Constants.DateFormat, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime result);
            
            return test;
        }
    }
}
