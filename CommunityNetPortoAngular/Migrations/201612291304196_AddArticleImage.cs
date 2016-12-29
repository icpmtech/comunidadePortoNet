namespace CommunityNetPortoAngular.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddArticleImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArticleUsers", "ImageURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ArticleUsers", "ImageURL");
        }
    }
}
