namespace ShopeShoesApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOutShoeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OutShoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        Gender = c.String(),
                        IfThereIsHeel = c.Boolean(nullable: false),
                        IfThereIsInStock = c.Boolean(nullable: false),
                        Size = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OutShoes");
        }
    }
}
