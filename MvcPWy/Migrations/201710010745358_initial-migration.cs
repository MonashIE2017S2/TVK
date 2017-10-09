namespace MvcPWy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {

            CreateTable(
                "dbo.ChildFirsts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        region = c.String(),
                        phone = c.String(),
                        type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        DETregion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sfys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        DETArea = c.String(),
                        address = c.String(),
                        email = c.String(),
                        phone = c.String(),
                        postCode = c.Int(nullable: false),
                        website = c.String(),
                        regionName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Suburbs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        postcode = c.String(),
                        name = c.String(),
                        regionName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Supports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        address = c.String(),
                        postCode = c.Int(nullable: false),
                        phone = c.String(),
                        email = c.String(),
                        webSite = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            


        }
        
        public override void Down()
        {
            
            DropTable("dbo.Supports");
            DropTable("dbo.Suburbs");
            DropTable("dbo.Sfys");
            DropTable("dbo.Regions");
            DropTable("dbo.ChildFirsts");
        }
    }
}
