using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CafeInternational.Properties;

namespace CafeInternational.Models
{

    /// <summary>
    /// The beverage object. E.g. Cappucino.
    /// </summary>
    public class Beverage
    {
        private const int MAX_STRENGTH = 10;

        public int ID { get; set; }

        /// <summary>
        /// The name of the beverage.
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// The URL part.
        /// </summary>
        public String Slug { get; set; }

        /// <summary>
        /// The strength
        /// </summary>
        [Range(1, MAX_STRENGTH)]
        public int? Strength { get; set; }
        public String Comment { get; set; }
        public int CupID { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}