using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace CafeInternational.Models
{

    /// <summary>
    /// The containment of the beverage. A cup or a glass.
    /// </summary>
    public class Cup
    {
        private const int MAX_SIZE = 300; //ml
        public int ID { get; set; }

        /// <summary>
        /// The name of the containment.
        /// </summary>
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// A slug field for use in frontend code.
        /// </summary>
        [Required, StringLength(15)]
        public string Slug { get; set; }

        /// <summary>
        /// The size in ml.
        /// </summary>
        [Required, Range(1, MAX_SIZE)]
        public int SizeMl { get; set; }
        
        /// <summary>
        /// The lookup table for the frontend rendering.
        /// </summary>
        [Required]
        public string LUT { get; set; }

    }
}