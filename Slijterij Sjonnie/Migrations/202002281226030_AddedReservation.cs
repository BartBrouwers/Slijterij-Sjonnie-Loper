namespace Slijterij_Sjonnie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedReservation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reserverings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false),
                        Aantal = c.Int(nullable: false),
                        Datum = c.DateTime(nullable: false),
                        Whisky_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Whiskies", t => t.Whisky_Id, cascadeDelete: true)
                .Index(t => t.Whisky_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reserverings", "Whisky_Id", "dbo.Whiskies");
            DropIndex("dbo.Reserverings", new[] { "Whisky_Id" });
            DropTable("dbo.Reserverings");
        }
    }
}
