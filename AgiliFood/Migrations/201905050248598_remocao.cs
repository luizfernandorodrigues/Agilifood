namespace AgiliFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remocao : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ItensPedido", "id_pedido", "dbo.Pedido");
            DropIndex("dbo.ItensPedido", new[] { "id_pedido" });
            DropTable("dbo.ItensPedido");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ItensPedido",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        quantidade = c.Int(nullable: false),
                        total = c.Decimal(nullable: false, precision: 18, scale: 2, storeType: "numeric"),
                        id_pedido = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateIndex("dbo.ItensPedido", "id_pedido");
            AddForeignKey("dbo.ItensPedido", "id_pedido", "dbo.Pedido", "id");
        }
    }
}
