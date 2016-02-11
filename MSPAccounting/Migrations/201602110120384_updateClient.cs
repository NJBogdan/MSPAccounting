namespace MSPAccounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateClient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Expenses", "Client_ID", c => c.Int());
            CreateIndex("dbo.Expenses", "Client_ID");
            AddForeignKey("dbo.Expenses", "Client_ID", "dbo.Clients", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenses", "Client_ID", "dbo.Clients");
            DropIndex("dbo.Expenses", new[] { "Client_ID" });
            DropColumn("dbo.Expenses", "Client_ID");
        }
    }
}
