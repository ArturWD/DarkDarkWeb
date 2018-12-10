namespace DDW.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Unique : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Category", "CategoryName", unique: true);
            CreateIndex("dbo.Keyword", "KeywordName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Keyword", new[] { "KeywordName" });
            DropIndex("dbo.Category", new[] { "CategoryName" });
        }
    }
}
