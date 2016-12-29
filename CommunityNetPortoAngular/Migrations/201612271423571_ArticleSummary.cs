namespace CommunityNetPortoAngular.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArticleSummary : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArticleUsers", "Summary", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ArticleUsers", "Summary");
        }
    }
}
