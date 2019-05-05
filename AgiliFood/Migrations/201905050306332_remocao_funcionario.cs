namespace AgiliFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remocao_funcionario : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Funcionario", "id_cep", "dbo.Cep");
            DropForeignKey("dbo.ContasReceber", "id_funcionario", "dbo.Funcionario");
            DropForeignKey("dbo.Pedido", "id_funcionario", "dbo.Funcionario");
            DropIndex("dbo.ContasReceber", new[] { "id_funcionario" });
            DropIndex("dbo.Funcionario", new[] { "id_cep" });
            DropIndex("dbo.Pedido", new[] { "id_funcionario" });
            AddColumn("dbo.ContasReceber", "id_usuario", c => c.Guid(nullable: false));
            AddColumn("dbo.Pedido", "id_usuario", c => c.Guid(nullable: false));
            CreateIndex("dbo.ContasReceber", "id_usuario");
            CreateIndex("dbo.Pedido", "id_usuario");
            AddForeignKey("dbo.Pedido", "id_usuario", "dbo.Usuario", "id");
            AddForeignKey("dbo.ContasReceber", "id_usuario", "dbo.Usuario", "id");
            DropColumn("dbo.ContasReceber", "id_funcionario");
            DropColumn("dbo.Pedido", "id_funcionario");
            DropTable("dbo.Funcionario");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Funcionario",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        nome = c.String(nullable: false, maxLength: 100, fixedLength: true),
                        endereco = c.String(nullable: false, maxLength: 100, fixedLength: true),
                        numeroEndereco = c.String(maxLength: 20, fixedLength: true),
                        bairro = c.String(nullable: false, maxLength: 80, fixedLength: true),
                        fone = c.String(nullable: false, maxLength: 11, fixedLength: true),
                        cpf = c.String(maxLength: 11, fixedLength: true),
                        id_cep = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Pedido", "id_funcionario", c => c.Guid(nullable: false));
            AddColumn("dbo.ContasReceber", "id_funcionario", c => c.Guid(nullable: false));
            DropForeignKey("dbo.ContasReceber", "id_usuario", "dbo.Usuario");
            DropForeignKey("dbo.Pedido", "id_usuario", "dbo.Usuario");
            DropIndex("dbo.Pedido", new[] { "id_usuario" });
            DropIndex("dbo.ContasReceber", new[] { "id_usuario" });
            DropColumn("dbo.Pedido", "id_usuario");
            DropColumn("dbo.ContasReceber", "id_usuario");
            CreateIndex("dbo.Pedido", "id_funcionario");
            CreateIndex("dbo.Funcionario", "id_cep");
            CreateIndex("dbo.ContasReceber", "id_funcionario");
            AddForeignKey("dbo.Pedido", "id_funcionario", "dbo.Funcionario", "id");
            AddForeignKey("dbo.ContasReceber", "id_funcionario", "dbo.Funcionario", "id");
            AddForeignKey("dbo.Funcionario", "id_cep", "dbo.Cep", "id");
        }
    }
}
