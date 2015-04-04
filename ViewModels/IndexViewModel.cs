using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using CafeInternational.Models;

namespace CafeInternational.ViewModels
{
    public class IndexViewModel
    {
        // Stores the selected value from the drop down box.
        [Required]
        public String CountryISO2 { get; set; }

        // Contains the list of countries.
        public SelectList CountriesSelect { get; set; }

        public String Countries { get; set; }

        public void SetCountries(Country[] values)
        {
            var collection = from c in values select new { c.ISO2, c.Name, c.BeverageID, c.IsMetric };
            Countries = Json.Encode(collection);
        }
    }
}
