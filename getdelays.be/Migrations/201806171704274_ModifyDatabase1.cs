namespace getdelays.be.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyDatabase1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FollowedConnections", "idUser");
            DropColumn("dbo.FollowedStations", "idUser");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FollowedStations", "idUser", c => c.Int(nullable: false));
            AddColumn("dbo.FollowedConnections", "idUser", c => c.Int(nullable: false));
        }
    }
}
