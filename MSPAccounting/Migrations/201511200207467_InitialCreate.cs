namespace MSPAccounting.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BeginDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ContactInfo_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ContactInfoes", t => t.ContactInfo_ID)
                .Index(t => t.ContactInfo_ID);
            
            CreateTable(
                "dbo.ContactInfoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Phone = c.String(),
                        Email = c.String(),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Earnings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Ammount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Client_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clients", t => t.Client_ID)
                .Index(t => t.Client_ID);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Ammount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Comments = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Earnings", "Client_ID", "dbo.Clients");
            DropForeignKey("dbo.Clients", "ContactInfo_ID", "dbo.ContactInfoes");
            DropIndex("dbo.Earnings", new[] { "Client_ID" });
            DropIndex("dbo.Clients", new[] { "ContactInfo_ID" });
            DropTable("dbo.Expenses");
            DropTable("dbo.Earnings");
            DropTable("dbo.ContactInfoes");
            DropTable("dbo.Clients");
            DropTable("dbo.Appointments");
        }
    }
}
