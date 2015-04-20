using System.Collections.Generic;
using System.Linq;
using CafeInternational.Models;


namespace CafeInternational.DAL
{
    public class CafeInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CafeContext>
    {
        protected override void Seed(CafeContext context)
        {
            // http://www.asp.net/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application
            var cups = new List<Cup>
            {
                new Cup {Name="Demitasse", Slug="demitasse", SizeMl=90, LUT="[[20, 29, 1.45], [30, 43, 1.4], [60, 78, 1.16],[90, 104, 0.866]]" },
                new Cup {Name="Small cappucino cup", Slug="smallCappucino", SizeMl=150, LUT="[[150, 110, 0.73]]" },
                new Cup {Name="Cappucino cup", Slug="cappucino", SizeMl=200, LUT="[[30, 41, 1.36], [60, 58, 0.567], [90, 70, 0.4], [180, 136, 0.733], [200, 150, 0.733]]"},
                new Cup {Name="Glass demitasse", Slug="glass-demitasse", SizeMl=90, LUT="[[30, 49, 1.63], [60, 96, 1.56], [90, 131, 1.16]]"}
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
                new Ingredient {Name = "hot chocolate", Slug = "hot-chocolate"},
                new Ingredient {Name = "spiced black tea", Slug = "spiced-tea"}
            };
            ingredients.ForEach(i=>context.Ingredients.Add(i));
            context.SaveChanges();

            var beverages = new List<Beverage>
            {
                new Beverage {Name = "Ristretto", Slug = "ristretto", Strength = 10, CupID = cups.Single(c=>c.Slug=="demitasse").ID},
                new Beverage {Name = "Espresso", Slug = "espresso", Strength = 8, CupID = cups.Single(c=>c.Slug=="demitasse").ID},
                new Beverage {Name = "Doppio", Slug = "doppio", Strength = 8, CupID = cups.Single(c=>c.Slug=="demitasse").ID},
                new Beverage {Name = "Lungo", Slug = "lungo", Strength = 6, CupID = cups.Single(c=>c.Slug=="demitasse").ID},
                new Beverage {Name = "Café crema", Slug = "cafe-crema", Strength = 5,CupID = cups.Single(c=>c.Slug=="smallCappucino").ID},
                new Beverage {Name="Espressino", Slug="espressino", CupID = cups.Single(c=>c.Slug=="glass-demitasse").ID},
                new Beverage
                {
                    Name = "Café Cubano",
                    Slug = "cafe-cubano",
                    Strength = 10,
                    Comment = "brewed with brown sugar",
                    CupID = 1
                },
                new Beverage {Name="Bonbón", Slug="bonbon", CupID = cups.Single(c=>c.Slug=="glass-demitasse").ID},
                new Beverage {Name="Macchiato", Slug="macchiato", CupID = cups.Single(c=>c.Slug=="demitasse").ID},
                new Beverage {Name="Piccolo latte", Slug="piccolo-latte", CupID = cups.Single(c=>c.Slug=="glass-demitasse").ID},
                new Beverage {Name = "Cappucino", Slug = "cappucino", CupID = cups.Single(c=>c.Slug=="cappucino").ID},
                new Beverage {Name="Flat white", Slug="flat-white", CupID = cups.Single(c=>c.Slug=="cappucino").ID},
                new Beverage {Name="Café au lait", Slug="cafe-au-lait", CupID = cups.Single(c=>c.Slug=="cappucino").ID},
                new Beverage {Name="Chai latte", Slug="chai-latte", CupID = cups.Single(c=>c.Slug=="cappucino").ID},
                new Beverage {Name="Breve", Slug="breve", CupID = cups.Single(c=>c.Slug=="cappucino").ID},
                new Beverage {Name="Red eye", Slug="red-eye", CupID = cups.Single(c=>c.Slug=="cappucino").ID},
                new Beverage {Name="Black eye", Slug="black-eye", CupID = cups.Single(c=>c.Slug=="cappucino").ID},
                new Beverage {Name="Dead eye", Slug="dead-eye", CupID = cups.Single(c=>c.Slug=="cappucino").ID},
                new Beverage {Name="Lazy eye", Slug="lazy-eye", CupID = cups.Single(c=>c.Slug=="cappucino").ID},
                new Beverage {Name="Americano", Slug="americano", CupID = cups.Single(c=>c.Slug=="cappucino").ID},
                new Beverage {Name="Long black", Slug="long-black", CupID = cups.Single(c=>c.Slug=="cappucino").ID},
            };
            beverages.ForEach(b=>context.Beverages.Add(b));
            context.SaveChanges();

            // Create the countries
            var countries = new List<Country>
            {
                new Country {ISO2 = "CH", Name = "Switzerland", BeverageID = beverages.Single(b=>b.Slug=="cafe-crema").ID, IsMetric = true},
                new Country {ISO2 = "DE", Name = "Germany", IsMetric = true},
                new Country {ISO2 = "FR", Name = "France", BeverageID = beverages.Single(b=>b.Slug=="cafe-crema").ID, IsMetric = true},
                new Country {ISO2 = "IT", Name = "Italia", BeverageID = beverages.Single(b=>b.Slug=="espresso").ID, IsMetric = true},
                new Country {ISO2 = "AT", Name = "Austria", IsMetric = true},
                new Country {ISO2 = "US", Name = "USA", BeverageID = beverages.Single(b=>b.Slug=="cafe-crema").ID, IsMetric = true},
            };
            countries.ForEach(c => context.Countries.Add(c));
            context.SaveChanges();


            // Create the beverages.
            var ingredientsForBeverage = new List<BeverageHasIngredient>
            {
                new BeverageHasIngredient
                {
                    Position = 1,
                    AmountMl = 20,
                    BeverageID = beverages.Single(b => b.Slug == "ristretto").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "espresso").ID
                },                              
                new BeverageHasIngredient
                {
                    Position = 1,
                    AmountMl = 30,
                    BeverageID = beverages.Single(b => b.Slug == "espresso").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "espresso").ID
                },
                new BeverageHasIngredient
                {
                    Position = 1,
                    AmountMl = 60,
                    BeverageID = beverages.Single(b => b.Slug == "doppio").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "espresso").ID
                },
                new BeverageHasIngredient
                {
                    Position = 1,
                    AmountMl = 90,
                    BeverageID = beverages.Single(b => b.Slug == "lungo").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "longer-brewed").ID
                },                
                new BeverageHasIngredient
                {
                    Position = 1,
                    AmountMl = 150,
                    BeverageID = beverages.Single(b => b.Slug == "cafe-crema").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "much-longer-brewed").ID
                },                
                // Espressino
                new BeverageHasIngredient
                {
                    Position = 1,
                    AmountMl = 30,
                    BeverageID = beverages.Single(b => b.Slug == "espressino").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "espresso").ID
                },
                new BeverageHasIngredient
                {
                    Position = 2,
                    AmountMl = 30,
                    BeverageID = beverages.Single(b => b.Slug == "espressino").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "steamed-milk").ID
                },
                new BeverageHasIngredient
                {
                    Position = 3,
                    AmountMl = 5,
                    BeverageID = beverages.Single(b => b.Slug == "espressino").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "cocoa-powder").ID
                },
                // Cubano
                new BeverageHasIngredient
                {
                    Position = 1,
                    AmountMl = 30,
                    BeverageID = beverages.Single(b => b.Slug == "cafe-cubano").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "espresso").ID
                },  // Bonbon
                new BeverageHasIngredient
                {
                    Position = 1,
                    AmountMl = 30,
                    BeverageID = beverages.Single(b => b.Slug == "bonbon").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "condensed-milk").ID
                },
                new BeverageHasIngredient
                {
                    Position = 2,
                    AmountMl = 30,
                    BeverageID = beverages.Single(b => b.Slug == "bonbon").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "espresso").ID
                },                
                // Macchiato
                new BeverageHasIngredient
                {
                    Position = 1,
                    AmountMl = 30,
                    BeverageID = beverages.Single(b => b.Slug == "macchiato").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "espresso").ID
                },
                new BeverageHasIngredient
                {
                    Position = 2,
                    AmountMl = 8,
                    BeverageID = beverages.Single(b => b.Slug == "macchiato").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "milk-foam").ID
                },

                // Piccolo latte
                new BeverageHasIngredient
                {
                    Position = 1,
                    AmountMl = 20,
                    BeverageID = beverages.Single(b => b.Slug == "piccolo-latte").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "espresso").ID
                },
                new BeverageHasIngredient
                {
                    Position = 2,
                    AmountMl = 60,
                    BeverageID = beverages.Single(b => b.Slug == "piccolo-latte").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "steamed-milk").ID
                },                
                new BeverageHasIngredient
                {
                    Position = 3,
                    AmountMl = 6,
                    BeverageID = beverages.Single(b => b.Slug == "piccolo-latte").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "milk-foam").ID
                },

                // Cappucino
                new BeverageHasIngredient
                {
                    Position = 1,
                    AmountMl = 60,
                    BeverageID = beverages.Single(b => b.Slug == "cappucino").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "espresso").ID
                },
                new BeverageHasIngredient
                {
                    Position = 2,
                    AmountMl = 60,
                    BeverageID = beverages.Single(b => b.Slug == "cappucino").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "steamed-milk").ID
                },
                new BeverageHasIngredient
                {
                    Position = 3,
                    AmountMl = 60,
                    BeverageID = beverages.Single(b => b.Slug == "cappucino").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "milk-foam").ID
                },

                // Flat white
                new BeverageHasIngredient
                {
                    Position = 1,
                    AmountMl = 60,
                    BeverageID = beverages.Single(b => b.Slug == "flat-white").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "espresso").ID
                },
                new BeverageHasIngredient
                {
                    Position = 2,
                    AmountMl = 120,
                    BeverageID = beverages.Single(b => b.Slug == "flat-white").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "steamed-milk").ID
                },                

                // Cafe au lait
                new BeverageHasIngredient
                {
                    Position = 1,
                    AmountMl = 90,
                    BeverageID = beverages.Single(b => b.Slug == "cafe-au-lait").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "french-press").ID
                },
                new BeverageHasIngredient
                {
                    Position = 2,
                    AmountMl = 90,
                    BeverageID = beverages.Single(b => b.Slug == "cafe-au-lait").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "scalded-milk").ID
                },    

                // Chai latte
                new BeverageHasIngredient
                {
                    Position = 1,
                    AmountMl = 90,
                    BeverageID = beverages.Single(b => b.Slug == "chai-latte").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "spiced-tea").ID
                },
                new BeverageHasIngredient
                {
                    Position = 2,
                    AmountMl = 90,
                    BeverageID = beverages.Single(b => b.Slug == "chai-latte").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "steamed-milk").ID
                },   
                new BeverageHasIngredient
                {
                    Position = 3,
                    AmountMl = 20,
                    BeverageID = beverages.Single(b => b.Slug == "chai-latte").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "milk-foam").ID
                },

                // Breve
                new BeverageHasIngredient
                {
                    Position = 1,
                    AmountMl = 60,
                    BeverageID = beverages.Single(b => b.Slug == "breve").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "espresso").ID
                },
                new BeverageHasIngredient
                {
                    Position = 2,
                    AmountMl = 60,
                    BeverageID = beverages.Single(b => b.Slug == "breve").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "steamed-half-half").ID
                },
                new BeverageHasIngredient
                {
                    Position = 3,
                    AmountMl = 10,
                    BeverageID = beverages.Single(b => b.Slug == "breve").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "milk-foam").ID
                },

                // Red eye
                new BeverageHasIngredient
                {
                    Position = 1,
                    AmountMl = 30,
                    BeverageID = beverages.Single(b => b.Slug == "red-eye").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "espresso").ID
                },
                new BeverageHasIngredient
                {
                    Position = 2,
                    AmountMl = 120,
                    BeverageID = beverages.Single(b => b.Slug == "red-eye").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "dripped").ID
                },  

                // Black eye
                new BeverageHasIngredient
                {
                    Position = 1,
                    AmountMl = 60,
                    BeverageID = beverages.Single(b => b.Slug == "black-eye").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "espresso").ID
                },
                new BeverageHasIngredient
                {
                    Position = 2,
                    AmountMl = 120,
                    BeverageID = beverages.Single(b => b.Slug == "black-eye").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "dripped").ID
                },  

                // Dead eye
                new BeverageHasIngredient
                {
                    Position = 1,
                    AmountMl = 90,
                    BeverageID = beverages.Single(b => b.Slug == "dead-eye").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "espresso").ID
                },
                new BeverageHasIngredient
                {
                    Position = 2,
                    AmountMl = 90,
                    BeverageID = beverages.Single(b => b.Slug == "dead-eye").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "dripped").ID
                },  
                // Lazy eye
                new BeverageHasIngredient
                {
                    Position = 1,
                    AmountMl = 60,
                    BeverageID = beverages.Single(b => b.Slug == "lazy-eye").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "espresso").ID
                },
                new BeverageHasIngredient
                {
                    Position = 2,
                    AmountMl = 120,
                    BeverageID = beverages.Single(b => b.Slug == "lazy-eye").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "dripped-decaf").ID
                },  

                // Americano
                new BeverageHasIngredient
                {
                    Position = 1,
                    AmountMl = 60,
                    BeverageID = beverages.Single(b => b.Slug == "americano").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "espresso").ID
                },
                new BeverageHasIngredient
                {
                    Position = 2,
                    AmountMl = 120,
                    BeverageID = beverages.Single(b => b.Slug == "americano").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "hot-water").ID
                }, 

                // Long-Black
                new BeverageHasIngredient
                {
                    Position = 1,
                    AmountMl = 120,
                    BeverageID = beverages.Single(b => b.Slug == "long-black").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "hot-water").ID
                },
                new BeverageHasIngredient
                {
                    Position = 2,
                    AmountMl = 60,
                    BeverageID = beverages.Single(b => b.Slug == "long-black").ID,
                    IngredientID = ingredients.Single(i => i.Slug == "espresso").ID
                }
            };
            ingredientsForBeverage.ForEach(i => context.BeverageHasIngredients.Add(i));
            context.SaveChanges();


            // Add beverages for countries
            var countriesHaveBeverages = new List<CountryHasBeverage>
            {
                new CountryHasBeverage
                {
                    CountryISO2 = "CH", Popularity = 5,
                    BeverageID = beverages.Single(b => b.Slug == "cafe-crema").ID,
                    Name = "Café Crème",
                    Language = "fr-ch"
                },
                new CountryHasBeverage
                {
                    CountryISO2 = "CH", Popularity = 5,
                    BeverageID = beverages.Single(b => b.Slug == "cafe-crema").ID,
                    Name = "Kaffi Crème",
                    Language = "de-ch"
                },
                new CountryHasBeverage
                {
                    CountryISO2 = "CH", Popularity = 5,
                    BeverageID = beverages.Single(b => b.Slug == "espresso").ID,
                    Name = "Espresso",
                    Language = "de-ch"
                },
                new CountryHasBeverage
                {
                    CountryISO2 = "CH", Popularity = 5,
                    BeverageID = beverages.Single(b => b.Slug == "espresso").ID,
                    Name = "Espresso",
                    Language = "fr-ch"
                },
                new CountryHasBeverage
                {
                    CountryISO2 = "CH", Popularity = 3,
                    BeverageID = beverages.Single(b => b.Slug == "cappucino").ID,
                    Name = "Cappucino",
                    Language = "de-ch"
                },
                new CountryHasBeverage
                {
                    CountryISO2 = "CH", Popularity = 3,
                    BeverageID = beverages.Single(b => b.Slug == "cappucino").ID,
                    Name = "Cappucino",
                    Language = "fr-ch"
                },
                new CountryHasBeverage
                {
                    CountryISO2 = "CH", Popularity = 1,
                    BeverageID = beverages.Single(b => b.Slug == "ristretto").ID,
                    Name = "Ristretto",
                    Language = "de-ch"
                },
                new CountryHasBeverage
                {
                    CountryISO2 = "CH", Popularity = 1,
                    BeverageID = beverages.Single(b => b.Slug == "ristretto").ID,
                    Name = "Ristretto",
                    Language = "fr-ch"
                }
            };
            countriesHaveBeverages.ForEach(c=>context.CountryHasBeverages.Add(c));
            context.SaveChanges();

        }

    }
}