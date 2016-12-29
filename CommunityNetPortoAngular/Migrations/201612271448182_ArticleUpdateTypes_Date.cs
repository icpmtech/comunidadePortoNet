namespace CommunityNetPortoAngular.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArticleUpdateTypes_Date : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArticleUsers", "CreationDate_", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ArticleUsers", "CreationDate_");
        }
    }
}
