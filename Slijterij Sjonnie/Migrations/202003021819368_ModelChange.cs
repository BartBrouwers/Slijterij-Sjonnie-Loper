namespace Slijterij_Sjonnie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Etikets", "AfbeeldingPath", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Etikets", "AfbeeldingPath", c => c.String(nullable: false));
        }
    }
}
