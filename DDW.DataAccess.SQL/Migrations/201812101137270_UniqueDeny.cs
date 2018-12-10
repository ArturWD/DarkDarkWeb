namespace DDW.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UniqueDeny : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Category", new[] { "CategoryName" });
            DropIndex("dbo.Keyword", new[] { "KeywordName" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Keyword", "KeywordName", unique: true);
            CreateIndex("dbo.Category", "CategoryName", unique: true);
        }
    }
}
