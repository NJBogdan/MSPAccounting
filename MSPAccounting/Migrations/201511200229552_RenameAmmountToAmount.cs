namespace MSPAccounting.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RenameAmmountToAmount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Earnings", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Expenses", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Earnings", "Ammount");
            DropColumn("dbo.Expenses", "Ammount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Expenses", "Ammount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Earnings", "Ammount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Expenses", "Amount");
            DropColumn("dbo.Earnings", "Amount");
        }
    }
}
