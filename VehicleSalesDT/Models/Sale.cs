using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VehicleSalesDT.Models
{
    public class Sale
    {
        public int? SaleId { get; set; }

        [Display(Name = "Date")]
        public DateTime? SaleDate { get; set; }

        public int? DealerNumber { get; set; }

        [Display(Name = "CustomerName")]
        public string CustomerName { get; set; }

        [Display(Name = "DealershipName")]
        public string DealershipName { get; set; }

        [Display(Name = "Vehicle")]
        public string Vehicle { get; set; }

        public decimal? Price { get; set; }

    }
}