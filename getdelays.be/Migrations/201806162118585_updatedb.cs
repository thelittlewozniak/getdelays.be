namespace getdelays.be.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        dayName = c.String(),
                        followedConnection_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FollowedConnections", t => t.followedConnection_Id)
                .Index(t => t.followedConnection_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Days", "followedConnection_Id", "dbo.FollowedConnections");
            DropIndex("dbo.Days", new[] { "followedConnection_Id" });
            DropTable("dbo.Days");
        }
    }
}
