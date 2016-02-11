namespace MSPAccounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommentsTOearning : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Earnings", "Comments", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Earnings", "Comments");
        }
    }
}
