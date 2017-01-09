namespace CommunityNetPortoAngular.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArticleRatings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        TotalRaters = c.Int(nullable: false),
                        AverageRating = c.Double(nullable: false),
                        ArticleID_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ArticleUsers", t => t.ArticleID_ID)
                .Index(t => t.ArticleID_ID);
            
            CreateTable(
                "dbo.ArticleUsers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ImageURL = c.String(),
                        Title = c.String(),
                        Header = c.String(),
                        Summary = c.String(),
                        Footer = c.String(),
                        Content = c.String(),
                        CreationDate = c.Time(nullable: false, precision: 7),
                        CreationDate_ = c.DateTime(),
                        Rating_ = c.Double(nullable: false),
                        Rating = c.Int(nullable: false),
                        Total = c.Double(nullable: false),
                        Vote = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.ArticlesDetailsDTOes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        ArticleUser_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ArticleUsers", t => t.ArticleUser_ID)
                .Index(t => t.ArticleUser_ID);
            
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Data = c.String(),
                        StartedOn = c.DateTime(),
                        Dob = c.DateTime(),
                        ResumeUser_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ResumeUsers", t => t.ResumeUser_ID)
                .Index(t => t.ResumeUser_ID);
            
            CreateTable(
                "dbo.ResumeUsers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Twitter = c.String(),
                        Phone = c.String(),
                        TagLine = c.String(),
                        PortfolioSite = c.String(),
                        Linkedin = c.String(),
                        GitHub = c.String(),
                        Name = c.String(),
                        ImageURL = c.String(),
                        CareerProfile = c.String(),
                        Profile = c.String(),
                        Rating_ = c.Double(nullable: false),
                        Rating = c.Int(nullable: false),
                        Total = c.Double(nullable: false),
                        Vote = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TagLine = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        Data = c.String(),
                        StartedOn = c.DateTime(),
                        Dob = c.DateTime(),
                        ResumeUser_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ResumeUsers", t => t.ResumeUser_ID)
                .Index(t => t.ResumeUser_ID);
            
            CreateTable(
                "dbo.Interests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        ResumeUser_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ResumeUsers", t => t.ResumeUser_ID)
                .Index(t => t.ResumeUser_ID);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        ResumeUser_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ResumeUsers", t => t.ResumeUser_ID)
                .Index(t => t.ResumeUser_ID);
            
            CreateTable(
                "dbo.Proficiencies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.String(),
                        StartedOn = c.DateTime(),
                        Dob = c.DateTime(),
                        ResumeUser_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ResumeUsers", t => t.ResumeUser_ID)
                .Index(t => t.ResumeUser_ID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Title = c.String(),
                        Link = c.String(),
                        ResumeUser_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ResumeUsers", t => t.ResumeUser_ID)
                .Index(t => t.ResumeUser_ID);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.String(),
                        ResumeUser_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ResumeUsers", t => t.ResumeUser_ID)
                .Index(t => t.ResumeUser_ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.SuggestionViewModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Message = c.String(nullable: false),
                        TypeMessage = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Skills", "ResumeUser_ID", "dbo.ResumeUsers");
            DropForeignKey("dbo.Projects", "ResumeUser_ID", "dbo.ResumeUsers");
            DropForeignKey("dbo.Proficiencies", "ResumeUser_ID", "dbo.ResumeUsers");
            DropForeignKey("dbo.Languages", "ResumeUser_ID", "dbo.ResumeUsers");
            DropForeignKey("dbo.Interests", "ResumeUser_ID", "dbo.ResumeUsers");
            DropForeignKey("dbo.Experiences", "ResumeUser_ID", "dbo.ResumeUsers");
            DropForeignKey("dbo.Educations", "ResumeUser_ID", "dbo.ResumeUsers");
            DropForeignKey("dbo.ResumeUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ArticlesDetailsDTOes", "ArticleUser_ID", "dbo.ArticleUsers");
            DropForeignKey("dbo.ArticleRatings", "ArticleID_ID", "dbo.ArticleUsers");
            DropForeignKey("dbo.ArticleUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Skills", new[] { "ResumeUser_ID" });
            DropIndex("dbo.Projects", new[] { "ResumeUser_ID" });
            DropIndex("dbo.Proficiencies", new[] { "ResumeUser_ID" });
            DropIndex("dbo.Languages", new[] { "ResumeUser_ID" });
            DropIndex("dbo.Interests", new[] { "ResumeUser_ID" });
            DropIndex("dbo.Experiences", new[] { "ResumeUser_ID" });
            DropIndex("dbo.ResumeUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Educations", new[] { "ResumeUser_ID" });
            DropIndex("dbo.ArticlesDetailsDTOes", new[] { "ArticleUser_ID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.ArticleUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ArticleRatings", new[] { "ArticleID_ID" });
            DropTable("dbo.SuggestionViewModels");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Skills");
            DropTable("dbo.Projects");
            DropTable("dbo.Proficiencies");
            DropTable("dbo.Languages");
            DropTable("dbo.Interests");
            DropTable("dbo.Experiences");
            DropTable("dbo.ResumeUsers");
            DropTable("dbo.Educations");
            DropTable("dbo.ArticlesDetailsDTOes");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ArticleUsers");
            DropTable("dbo.ArticleRatings");
        }
    }
}
