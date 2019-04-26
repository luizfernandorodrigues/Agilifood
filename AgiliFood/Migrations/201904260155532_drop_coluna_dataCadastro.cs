namespace AgiliFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class drop_coluna_dataCadastro : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Usuario", "cadastro");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuario", "cadastro", c => c.DateTime(nullable: false));
        }
    }
}
