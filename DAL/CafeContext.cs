﻿using System.Data.Entity;
using CafeInternational.Models;

namespace CafeInternational.DAL
{
    /// <summary>
    /// The DB configuration.
    /// </summary>
    public class CafeContext : DbContext
    {

        static CafeContext()
        {
            // Fixed "Provider not loaded" error
            // http://robsneuron.blogspot.ch/2013/11/entity-framework-upgrade-to-6.html
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public CafeContext() : base("CafeContext")
        {
           this.Configuration.LazyLoadingEnabled = false; 
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Beverage> Beverages { get; set; }
        public DbSet<Cup> Cups { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<BeverageHasIngredient> BeverageHasIngredients { get; set; }
        public DbSet<CountryHasBeverage> CountryHasBeverages { get; set; }

//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Country>()
//                .HasMany(c => c.Beverages).WithMany(b => b.Countries)
//                .Map(t=>t.MapLeftKey("CountryISO2")
//                .MapRightKey("BeverageID")
//                .ToTable("CountryHasBeverages"));
//
//            modelBuilder.Entity<Beverage>()
//                .HasMany(b => b.Ingredients).WithMany(i => i.Beverages)
//                .Map(t => t.MapLeftKey("BeverageID")
//                    .MapRightKey("IngredientID")
//                    .ToTable("BeverageHasIngredients"));
//        }

    }
}