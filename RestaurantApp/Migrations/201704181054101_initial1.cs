namespace RestaurantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.food_stuff", "food_details", c => c.String(nullable: false, unicode: false));
            AddColumn("dbo.food_stuff", "preparation_time", c => c.Int(nullable: false));
            AddColumn("dbo.food_stuff", "price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.food_stuff", "price");
            DropColumn("dbo.food_stuff", "preparation_time");
            DropColumn("dbo.food_stuff", "food_details");
        }
    }
}
