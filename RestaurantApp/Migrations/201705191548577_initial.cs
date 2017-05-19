namespace RestaurantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.food_stuff",
                c => new
                    {
                        id_food = c.Int(nullable: false, identity: true),
                        food_name = c.String(nullable: false, unicode: false),
                        food_weight = c.Int(nullable: false),
                        food_details = c.String(nullable: false, unicode: false),
                        preparation_time = c.Int(nullable: false),
                        price = c.Double(nullable: false),
                        image = c.Binary(),
                    })
                .PrimaryKey(t => t.id_food);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        id_order = c.Int(nullable: false, identity: true),
                        order_date = c.DateTime(nullable: false, precision: 0),
                        status = c.String(nullable: false, unicode: false),
                        Table_IdTable = c.Int(),
                        User_IdUser = c.Int(),
                    })
                .PrimaryKey(t => t.id_order)
                .ForeignKey("dbo.table", t => t.Table_IdTable)
                .ForeignKey("dbo.User", t => t.User_IdUser)
                .Index(t => t.Table_IdTable)
                .Index(t => t.User_IdUser);
            
            CreateTable(
                "dbo.table",
                c => new
                    {
                        id_table = c.Int(nullable: false, identity: true),
                        seats_number = c.Int(nullable: false),
                        status = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.id_table);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        id_user = c.Int(nullable: false, identity: true),
                        first_name = c.String(nullable: false, unicode: false),
                        last_name = c.String(nullable: false, unicode: false),
                        user_name = c.String(nullable: false, unicode: false),
                        password = c.String(nullable: false, unicode: false),
                        Role_IdRole = c.Int(),
                    })
                .PrimaryKey(t => t.id_user)
                .ForeignKey("dbo.Role", t => t.Role_IdRole)
                .Index(t => t.Role_IdRole);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        id_role = c.Int(nullable: false, identity: true),
                        user_role = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.id_role);
            
            CreateTable(
                "dbo.OrderFoodStuffs",
                c => new
                    {
                        Order_IdOrder = c.Int(nullable: false),
                        FoodStuff_IdFood = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_IdOrder, t.FoodStuff_IdFood })
                .ForeignKey("dbo.Order", t => t.Order_IdOrder, cascadeDelete: true)
                .ForeignKey("dbo.food_stuff", t => t.FoodStuff_IdFood, cascadeDelete: true)
                .Index(t => t.Order_IdOrder)
                .Index(t => t.FoodStuff_IdFood);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "User_IdUser", "dbo.User");
            DropForeignKey("dbo.User", "Role_IdRole", "dbo.Role");
            DropForeignKey("dbo.Order", "Table_IdTable", "dbo.table");
            DropForeignKey("dbo.OrderFoodStuffs", "FoodStuff_IdFood", "dbo.food_stuff");
            DropForeignKey("dbo.OrderFoodStuffs", "Order_IdOrder", "dbo.Order");
            DropIndex("dbo.Order", new[] { "User_IdUser" });
            DropIndex("dbo.User", new[] { "Role_IdRole" });
            DropIndex("dbo.Order", new[] { "Table_IdTable" });
            DropIndex("dbo.OrderFoodStuffs", new[] { "FoodStuff_IdFood" });
            DropIndex("dbo.OrderFoodStuffs", new[] { "Order_IdOrder" });
            DropTable("dbo.OrderFoodStuffs");
            DropTable("dbo.Role");
            DropTable("dbo.User");
            DropTable("dbo.table");
            DropTable("dbo.Order");
            DropTable("dbo.food_stuff");
        }
    }
}
