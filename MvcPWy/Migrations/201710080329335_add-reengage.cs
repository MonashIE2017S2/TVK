namespace MvcPWy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addreengage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReEngages",
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
                        type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ReEngages");
        }
    }
}
