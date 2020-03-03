namespace Slijterij_Sjonnie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Etikets", "Prijs", c => c.Double(nullable: false));
            AddColumn("dbo.Etikets", "AfbeeldingPath", c => c.String(nullable: false));
            AddColumn("dbo.Whiskies", "Leeftijd", c => c.DateTime(nullable: false));
            DropColumn("dbo.Etikets", "Leeftijd");
            DropColumn("dbo.Etikets", "Afbeelding");
            DropColumn("dbo.Whiskies", "Prijs");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Whiskies", "Prijs", c => c.Double(nullable: false));
            AddColumn("dbo.Etikets", "Afbeelding", c => c.Binary(nullable: false));
            AddColumn("dbo.Etikets", "Leeftijd", c => c.Int(nullable: false));
            DropColumn("dbo.Whiskies", "Leeftijd");
            DropColumn("dbo.Etikets", "AfbeeldingPath");
            DropColumn("dbo.Etikets", "Prijs");
        }
    }
}
