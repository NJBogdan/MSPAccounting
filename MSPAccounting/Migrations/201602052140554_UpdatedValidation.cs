namespace MSPAccounting.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdatedValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Expenses", "Comments", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Expenses", "Comments", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "Name", c => c.String());
        }
    }
}
