namespace MSPAccounting.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddStateAbbreviation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StateAbbreviations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Abbreviation = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StateAbbreviations");
        }
    }
}
