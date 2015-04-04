using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CafeInternational.Models
{
    public class Ingredient
    {
        public int ID { get; set; }

        /// <summary>
        /// The name of the ingredient. E.g. milk.
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// A safe version of the name.
        /// </summary>
        public String Slug { get; set; }

        [JsonIgnore] 
        public virtual ICollection<BeverageHasIngredient> BeverageHasIngredients { get; set; }
    }
}