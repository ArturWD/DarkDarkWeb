namespace DDW.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Resource",
                c => new
                    {
                        ResourceId = c.Int(nullable: false, identity: true),
                        ResourceName = c.String(nullable: false, maxLength: 255),
                        URL = c.String(nullable: false),
                        RefreshDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        Contacts = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResourceId)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Keyword",
                c => new
                    {
                        KeywordId = c.Int(nullable: false, identity: true),
                        KeywordName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.KeywordId);
            
            CreateTable(
                "dbo.ResourceKeywords",
                c => new
                    {
                        ResourceId = c.Int(nullable: false),
                        KeywordId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ResourceId, t.KeywordId })
                .ForeignKey("dbo.Resource", t => t.ResourceId, cascadeDelete: true)
                .ForeignKey("dbo.Keyword", t => t.KeywordId, cascadeDelete: true)
                .Index(t => t.ResourceId)
                .Index(t => t.KeywordId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResourceKeywords", "KeywordId", "dbo.Keyword");
            DropForeignKey("dbo.ResourceKeywords", "ResourceId", "dbo.Resource");
            DropForeignKey("dbo.Resource", "CategoryId", "dbo.Category");
            DropIndex("dbo.ResourceKeywords", new[] { "KeywordId" });
            DropIndex("dbo.ResourceKeywords", new[] { "ResourceId" });
            DropIndex("dbo.Resource", new[] { "CategoryId" });
            DropTable("dbo.ResourceKeywords");
            DropTable("dbo.Keyword");
            DropTable("dbo.Resource");
            DropTable("dbo.Category");
        }
    }
}
