namespace MSPAccounting.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RemoveEndDateFromAppointment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Appointments", "Client_ID", c => c.Int());
            CreateIndex("dbo.Appointments", "Client_ID");
            AddForeignKey("dbo.Appointments", "Client_ID", "dbo.Clients", "ID");
            DropColumn("dbo.Appointments", "BeginDate");
            DropColumn("dbo.Appointments", "EndDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Appointments", "BeginDate", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Appointments", "Client_ID", "dbo.Clients");
            DropIndex("dbo.Appointments", new[] { "Client_ID" });
            DropColumn("dbo.Appointments", "Client_ID");
            DropColumn("dbo.Appointments", "Date");
        }
    }
}
