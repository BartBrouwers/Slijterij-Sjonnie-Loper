namespace Slijterij_Sjonnie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WhiskyModelUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Whiskies", "Etiket_Id", "dbo.Etikets");
            DropIndex("dbo.Whiskies", new[] { "Etiket_Id" });
            AlterColumn("dbo.Whiskies", "Etiket_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Whiskies", "Etiket_Id");
            AddForeignKey("dbo.Whiskies", "Etiket_Id", "dbo.Etikets", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Whiskies", "Etiket_Id", "dbo.Etikets");
            DropIndex("dbo.Whiskies", new[] { "Etiket_Id" });
            AlterColumn("dbo.Whiskies", "Etiket_Id", c => c.Int());
            CreateIndex("dbo.Whiskies", "Etiket_Id");
            AddForeignKey("dbo.Whiskies", "Etiket_Id", "dbo.Etikets", "Id");
        }
    }
}
