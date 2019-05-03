namespace AgiliFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificação : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Produto", "tipo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produto", "tipo", c => c.Int(nullable: false));
        }
    }
}
