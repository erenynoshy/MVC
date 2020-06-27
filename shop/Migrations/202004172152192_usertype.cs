namespace shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usertype : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderData",
                c => new
                    {
                        UserID = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        ProductID = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        Time = c.DateTime(),
                        Status = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => new { t.UserID, t.ProductID });
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductID = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        Title = c.String(maxLength: 50),
                        Price = c.String(maxLength: 50),
                        Category = c.String(maxLength: 50),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Decimal(nullable: false, precision: 18, scale: 0, identity: true, storeType: "numeric"),
                        UserName = c.String(maxLength: 50),
                        Password = c.String(),
                        Address = c.String(),
                        userType = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
            DropTable("dbo.Product");
            DropTable("dbo.OrderData");
        }
    }
}
