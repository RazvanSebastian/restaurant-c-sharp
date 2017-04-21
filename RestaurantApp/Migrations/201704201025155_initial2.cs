namespace RestaurantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.food_stuff", "image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.food_stuff", "image");
        }
    }
}
