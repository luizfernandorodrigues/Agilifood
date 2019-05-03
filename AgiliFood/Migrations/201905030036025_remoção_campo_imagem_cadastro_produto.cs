namespace AgiliFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remoção_campo_imagem_cadastro_produto : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Produto", "imagem");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produto", "imagem", c => c.Binary(storeType: "image"));
        }
    }
}
