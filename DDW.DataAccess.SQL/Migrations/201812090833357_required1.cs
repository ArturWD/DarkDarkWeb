namespace DDW.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class required1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Resource", "ResourceName", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Resource", "ResourceName", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
