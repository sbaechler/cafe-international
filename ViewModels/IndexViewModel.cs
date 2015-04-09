using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using CafeInternational.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;

namespace CafeInternational.ViewModels
{
    public class IndexViewModel
    {
        // Stores the selected value from the drop down box.

        public String Countries { get; set; }
        public String Cups { get; set; }

        public void SetCountries(Country[] values)
        {
            var collection = from c in values select new { c.ISO2, c.Name, c.BeverageID, c.IsMetric };
            Countries = Json.Encode(collection);
        }

        public void SetCups(Cup[] values)
        {
            var collection = from c in values select new {c.ID, c.Name, c.SizeMl, c.GetLUT};
            Cups = Json.Encode(collection);
        }

    }
}
