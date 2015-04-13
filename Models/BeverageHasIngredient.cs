using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CafeInternational.Models
{
    public class BeverageHasIngredient
    {
        private const int MAX_AMOUNT = 500;
        private const int ML2OZ = 30;

        [JsonIgnore]
        public int ID { get; set; }

        [JsonIgnore]
        public int BeverageID { get; set; }

        [JsonIgnore]
        public int IngredientID { get; set; }

        /// <summary>
        /// The ordering.
        /// </summary>
        public int Position { get; set; }
        /// <summary>
        /// The amount of this ingredient in ml.
        /// </summary>
        [Range(1, MAX_AMOUNT), Display(Name="amount (ml)")]
        public int AmountMl { get; set; }

        /// <summary>
        /// Helper function to get the amount in ounces.
        /// </summary>
        [Display(Name="amount (oz)")]
        public int AmountOz
        {
            get { return AmountMl/ML2OZ ; }
//            set { AmountMl = value > 1 ? value*ML2OZ : 1; }  // Ristretto is 0.75oz, but this is an int.
        }

        [JsonIgnore] 
        public virtual Beverage Beverage { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}