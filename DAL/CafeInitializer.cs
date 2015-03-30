using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CafeInternational.Models;
using ServiceStack;

namespace CafeInternational.DAL
{
    public class CafeInitializer : System.Data.Entity.DropCreateDatabaseAlways<CafeContext>
    {
        protected override void Seed(CafeContext context)
        {
            /// http://www.asp.net/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application
            var cups = new List<Cup>
            {
                new Cup {Name="Demitasse", Slug="demitasse", SizeMl=60, LUT="{}"},
                new Cup {Name="Small cappucino cup", Slug="smallCappucino", SizeMl=90, LUT="{}" },
                new Cup {Name="Cappucino cup", Slug="cappucino", SizeMl=200, LUT="{}"}
            };
            cups.ForEach(c=> context.Cups.Add(c));
            context.SaveChanges();

            var ingredients = new List<Ingredient>
            {
                new Ingredient {Name = "espresso", Slug = "espresso"},
                new Ingredient {Name = "longer brewed espresso", Slug = "longer-brewed"},
                new Ingredient {Name = "much longer brewed espresso", Slug = "much-longer-brewed"},
                new Ingredient {Name = "steamed milk", Slug = "steamed-milk"},
                new Ingredient {Name = "cocoa powder", Slug = "cocoa-powder"},
                new Ingredient {Name = "condensed milk", Slug = "condensed-milk"},
                new Ingredient {Name = "milk foam", Slug = "milk-foam"},
                new Ingredient {Name = "warm milk", Slug = "warm-milk"},
                new Ingredient {Name = "steamed half and half", Slug = "steamed-half-half"},
                new Ingredient {Name = "scalded milk", Slug = "scalded-milk"},
                new Ingredient {Name = "French press coffee", Slug = "french-press"},
                new Ingredient {Name = "dripped coffee", Slug = "dripped"},
                new Ingredient {Name = "hot water", Slug = "hot-water"},
                new Ingredient {Name = "dripped coffee decaffeinated", Slug = "dripped-decaf"},
                new Ingredient {Name = "whipped cream", Slug = "whipped-cream"},
                new Ingredient {Name = "hot chocolate", Slug = "hot-chocolate"}
            };
            ingredients.ForEach(i=>context.Ingredients.Add(i));
            context.SaveChanges();

            var beverages = new List<Beverage>
            {
                new Beverage {Name = "Ristretto", Slug = "ristretto", Strength = 10, CupID = 1},
                new Beverage {Name = "Espresso", Slug = "espresso", Strength = 8, CupID = 1},
                new Beverage {Name = "Doppio", Slug = "doppio", Strength = 8, CupID = 1},
                new Beverage {Name = "Lungo", Slug = "lungo", Strength = 6, CupID = 1},
                new Beverage {Name = "Café crema", Slug = "cafe-crema", Strength = 5, CupID = 2},
                new Beverage
                {
                    Name = "Café Cubano",
                    Slug = "cafe-cubano",
                    Strength = 10,
                    Comment = "brewed with brown sugar",
                    CupID = 1
                },
                new Beverage {Name = "Cappucino", Slug = "cappucino", CupID = 3},
            };
            beverages.ForEach(b=>context.Beverages.Add(b));
            context.SaveChanges();


        }

    }
}