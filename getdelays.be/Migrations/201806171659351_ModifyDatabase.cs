namespace getdelays.be.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyDatabase : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FollowedStations", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FollowedStations", "MyProperty", c => c.Int(nullable: false));
        }
    }
}
