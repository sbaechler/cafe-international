using System.Data.Entity;
using CafeInternational.Models;

namespace CafeInternational.DAL
{
    /// <summary>
    /// The DB configuration.
    /// </summary>
    public class CafeContext : DbContext
    {

        public CafeContext() : base("CafeContext")
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Beverage> Beverages { get; set; }
        public DbSet<Cup> Cups { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasMany(c => c.Beverages).WithMany(b => b.Countries)
                .Map(t=>t.MapLeftKey("CountryISO2")
                .MapRightKey("BeverageID")
                .ToTable("CountryHasBeverages"));

            modelBuilder.Entity<Beverage>()
                .HasMany(b => b.Ingredients).WithMany(i => i.Beverages)
                .Map(t => t.MapLeftKey("BeverageID")
                    .MapRightKey("IngredientID")
                    .ToTable("BeverageHasIngredients"));
        }

    }
}