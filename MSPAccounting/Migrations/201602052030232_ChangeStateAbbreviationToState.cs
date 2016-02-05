namespace MSPAccounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeStateAbbreviationToState : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.StateAbbreviations", newName: "States");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.States", newName: "StateAbbreviations");
        }
    }
}
