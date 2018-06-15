namespace getdelays.be.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Confiuration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FollowedConnections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        departure = c.String(),
                        arrival = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        idUser = c.Int(nullable: false),
                        user_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.user_Id)
                .Index(t => t.user_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        email = c.String(),
                        password = c.String(),
                        name = c.String(),
                        surname = c.String(),
                        phoneNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FollowedStations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        stationName = c.String(),
                        MyProperty = c.Int(nullable: false),
                        idUser = c.Int(nullable: false),
                        user_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.user_Id)
                .Index(t => t.user_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FollowedStations", "user_Id", "dbo.Users");
            DropForeignKey("dbo.FollowedConnections", "user_Id", "dbo.Users");
            DropIndex("dbo.FollowedStations", new[] { "user_Id" });
            DropIndex("dbo.FollowedConnections", new[] { "user_Id" });
            DropTable("dbo.FollowedStations");
            DropTable("dbo.Users");
            DropTable("dbo.FollowedConnections");
        }
    }
}
