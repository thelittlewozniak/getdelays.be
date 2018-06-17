namespace getdelays.be.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRepaetAttribute : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FollowedConnections", "repeat", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FollowedConnections", "repeat");
        }
    }
}
