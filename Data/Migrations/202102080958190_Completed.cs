namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Completed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ToDo", "Completed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ToDo", "Completed");
        }
    }
}
