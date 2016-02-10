namespace MSPAccounting.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddedStateToContactInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactInfoes", "State_ID", c => c.Int());
            CreateIndex("dbo.ContactInfoes", "State_ID");
            AddForeignKey("dbo.ContactInfoes", "State_ID", "dbo.States", "ID");
            DropColumn("dbo.ContactInfoes", "State");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContactInfoes", "State", c => c.String());
            DropForeignKey("dbo.ContactInfoes", "State_ID", "dbo.States");
            DropIndex("dbo.ContactInfoes", new[] { "State_ID" });
            DropColumn("dbo.ContactInfoes", "State_ID");
        }
    }
}
