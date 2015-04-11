namespace Xamarin.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Universities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        WebSite = c.String(nullable: false),
                        ContactEmail = c.String(),
                        Logo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ambassadors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(),
                        LastName = c.String(nullable: false),
                        City = c.String(nullable: false),
                        StateRegion = c.String(),
                        Country = c.String(nullable: false),
                        ContactEmail = c.String(nullable: false),
                        TwitterHandle = c.String(nullable: false),
                        FacebookName = c.Long(nullable: false),
                        LinkedInName = c.Long(nullable: false),
                        Blog = c.String(),
                        IsCertified = c.Boolean(nullable: false),
                        PhotoUri = c.String(),
                        EventPage = c.String(nullable: false),
                        Biography = c.String(nullable: false),
                        GpsCoordinates = c.String(),
                        UniversityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Universities", t => t.UniversityId, cascadeDelete: true)
                .Index(t => t.UniversityId);
            
            CreateTable(
                "dbo.XamarinLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ambassadors", "UniversityId", "dbo.Universities");
            DropIndex("dbo.Ambassadors", new[] { "UniversityId" });
            DropTable("dbo.XamarinLogins");
            DropTable("dbo.Ambassadors");
            DropTable("dbo.Universities");
        }
    }
}
