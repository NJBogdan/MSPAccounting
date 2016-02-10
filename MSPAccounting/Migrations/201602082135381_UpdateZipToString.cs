namespace MSPAccounting.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdateZipToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ContactInfoes", "Zip", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ContactInfoes", "Zip", c => c.Int(nullable: false));
        }
    }
}
