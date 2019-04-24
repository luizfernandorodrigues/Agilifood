namespace AgiliFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificacao_usuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "adm", c => c.Boolean(nullable: false));
            DropColumn("dbo.Usuario", "tipo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuario", "tipo", c => c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"));
            DropColumn("dbo.Usuario", "adm");
        }
    }
}
