namespace AgiliFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificação_itens_cardapio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItensCardapio", "quantidade", c => c.Int(nullable: false));
            DropColumn("dbo.ItensCardapio", "valor");
            DropColumn("dbo.ItensCardapio", "timestamp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ItensCardapio", "timestamp", c => c.DateTime(nullable: false));
            AddColumn("dbo.ItensCardapio", "valor", c => c.Decimal(nullable: false, precision: 18, scale: 2, storeType: "numeric"));
            DropColumn("dbo.ItensCardapio", "quantidade");
        }
    }
}
