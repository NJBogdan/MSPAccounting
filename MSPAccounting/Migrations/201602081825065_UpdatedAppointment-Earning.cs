namespace MSPAccounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedAppointmentEarning : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Earnings", "Appointment_ID", c => c.Int());
            AddColumn("dbo.Expenses", "Appointment_ID", c => c.Int());
            AlterColumn("dbo.Appointments", "Location", c => c.String(nullable: false));
            CreateIndex("dbo.Earnings", "Appointment_ID");
            CreateIndex("dbo.Expenses", "Appointment_ID");
            AddForeignKey("dbo.Earnings", "Appointment_ID", "dbo.Appointments", "ID");
            AddForeignKey("dbo.Expenses", "Appointment_ID", "dbo.Appointments", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenses", "Appointment_ID", "dbo.Appointments");
            DropForeignKey("dbo.Earnings", "Appointment_ID", "dbo.Appointments");
            DropIndex("dbo.Expenses", new[] { "Appointment_ID" });
            DropIndex("dbo.Earnings", new[] { "Appointment_ID" });
            AlterColumn("dbo.Appointments", "Location", c => c.String());
            DropColumn("dbo.Expenses", "Appointment_ID");
            DropColumn("dbo.Earnings", "Appointment_ID");
        }
    }
}
