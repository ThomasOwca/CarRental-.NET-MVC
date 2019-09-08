namespace CarRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Added", c => c.DateTime(nullable: false));
            AddColumn("dbo.Cars", "IsRemoved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "IsRemoved");
            DropColumn("dbo.Cars", "Added");
        }
    }
}
