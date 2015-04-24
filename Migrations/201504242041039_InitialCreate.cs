namespace CafeInternational.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BeverageHasIngredients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BeverageID = c.Int(nullable: false),
                        IngredientID = c.Int(nullable: false),
                        Position = c.Int(nullable: false),
                        AmountMl = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Beverages", t => t.BeverageID, cascadeDelete: true)
                .ForeignKey("dbo.Ingredients", t => t.IngredientID, cascadeDelete: true)
                .Index(t => t.BeverageID)
                .Index(t => t.IngredientID);
            
            CreateTable(
                "dbo.Beverages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Slug = c.String(),
                        Strength = c.Int(),
                        Comment = c.String(),
                        CupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CountryHasBeverages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BeverageID = c.Int(nullable: false),
                        CountryISO2 = c.String(maxLength: 2),
                        Popularity = c.Int(nullable: false),
                        Name = c.String(),
                        Language = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Beverages", t => t.BeverageID, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.CountryISO2)
                .Index(t => t.BeverageID)
                .Index(t => t.CountryISO2);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        ISO2 = c.String(nullable: false, maxLength: 2),
                        Name = c.String(),
                        BeverageID = c.Int(),
                        IsMetric = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ISO2)
                .ForeignKey("dbo.Beverages", t => t.BeverageID)
                .Index(t => t.BeverageID);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Slug = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Cups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Slug = c.String(nullable: false, maxLength: 15),
                        SizeMl = c.Int(nullable: false),
                        LUT = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BeverageHasIngredients", "IngredientID", "dbo.Ingredients");
            DropForeignKey("dbo.BeverageHasIngredients", "BeverageID", "dbo.Beverages");
            DropForeignKey("dbo.CountryHasBeverages", "CountryISO2", "dbo.Countries");
            DropForeignKey("dbo.Countries", "BeverageID", "dbo.Beverages");
            DropForeignKey("dbo.CountryHasBeverages", "BeverageID", "dbo.Beverages");
            DropIndex("dbo.Countries", new[] { "BeverageID" });
            DropIndex("dbo.CountryHasBeverages", new[] { "CountryISO2" });
            DropIndex("dbo.CountryHasBeverages", new[] { "BeverageID" });
            DropIndex("dbo.BeverageHasIngredients", new[] { "IngredientID" });
            DropIndex("dbo.BeverageHasIngredients", new[] { "BeverageID" });
            DropTable("dbo.Cups");
            DropTable("dbo.Ingredients");
            DropTable("dbo.Countries");
            DropTable("dbo.CountryHasBeverages");
            DropTable("dbo.Beverages");
            DropTable("dbo.BeverageHasIngredients");
        }
    }
}
