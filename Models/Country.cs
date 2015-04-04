using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace CafeInternational.Models
{
    public class Country
    {
        /// <summary>
        /// Country code in ISO format.
        /// </summary>
        [Key, StringLength(2, MinimumLength=2)]
        public String ISO2 { get; set; }

        /// <summary>
        /// The name of the country.
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// An optional default beverage.
        /// </summary>
        [DisplayFormat(NullDisplayText = "No default beverage")]
        public int? BeverageID { get; set; }

        /// <summary>
        /// Does the country use the metric or imperial system?
        /// </summary>
        public Boolean IsMetric { get; set; }

        /// <summary>
        /// A reference to the Beverage model.
        /// </summary>
        [JsonIgnore] 
        [Display(Name="Default beverage")]
        public virtual Beverage Beverage { get; set; }

        /// <summary>
        /// A list of beverages for this country.
        /// </summary>
        public virtual ICollection<CountryHasBeverage> Beverages { get; set; } 

    }
}