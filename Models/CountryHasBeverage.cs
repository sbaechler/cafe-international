using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CafeInternational.Models
{
    public class CountryHasBeverage
    {
        public int ID { get; set; }

        public int BeverageID { get; set; }

        [StringLength(2, MinimumLength=2)]
        public String CountryISO2 { get; set; }

        [Range(0, 5)]
        public int Popularity { get; set; }

        public String Name { get; set; }

        [RegularExpression(@"^[a-z]{2}(-[a-z]{2,6})?$"), StringLength(10)]
        public String Language { get; set; }
    }
}