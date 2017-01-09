namespace CommunityNetPortoAngular.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Languages", "Value", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Languages", "Value");
        }
    }
}
