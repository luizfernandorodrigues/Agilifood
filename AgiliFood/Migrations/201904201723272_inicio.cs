namespace AgiliFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cardapio",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        codigo = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        descricao = c.String(nullable: false, maxLength: 30, fixedLength: true),
                        cadastro = c.DateTime(nullable: false),
                        timestamp = c.DateTime(nullable: false),
                        id_fornecedor = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Fornecedor", t => t.id_fornecedor)
                .Index(t => t.id_fornecedor);
            
            CreateTable(
                "dbo.Fornecedor",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        razaoSocial = c.String(nullable: false, maxLength: 200, fixedLength: true),
                        fantasia = c.String(maxLength: 100, fixedLength: true),
                        logradouro = c.String(nullable: false, maxLength: 100, fixedLength: true),
                        numeroEndereco = c.String(maxLength: 10, fixedLength: true),
                        bairro = c.String(nullable: false, maxLength: 100, fixedLength: true),
                        fone = c.String(maxLength: 11, fixedLength: true),
                        cnpj = c.String(nullable: false, maxLength: 14, fixedLength: true),
                        email = c.String(maxLength: 80, fixedLength: true),
                        cadastro = c.DateTime(nullable: false),
                        timestamp = c.DateTime(nullable: false),
                        id_cep = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Cep", t => t.id_cep)
                .Index(t => t.id_cep);
            
            CreateTable(
                "dbo.Cep",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        cep = c.String(nullable: false, maxLength: 8, fixedLength: true),
                        timestamp = c.DateTime(nullable: false),
                        id_cidade = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Cidade", t => t.id_cidade)
                .Index(t => t.id_cidade);
            
            CreateTable(
                "dbo.Cidade",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        nome = c.String(nullable: false, maxLength: 100, fixedLength: true),
                        timestamp = c.DateTime(nullable: false),
                        id_estado = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Estado", t => t.id_estado)
                .Index(t => t.id_estado);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        nome = c.String(nullable: false, maxLength: 50, fixedLength: true),
                        sigla = c.String(nullable: false, maxLength: 2, fixedLength: true),
                        timestamp = c.DateTime(nullable: false),
                        id_pais = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Pais", t => t.id_pais)
                .Index(t => t.id_pais);
            
            CreateTable(
                "dbo.Pais",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        codigo = c.String(maxLength: 10, fixedLength: true),
                        numero = c.String(nullable: false, maxLength: 100, fixedLength: true),
                        timestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ContasReceber",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        emissao = c.DateTime(nullable: false),
                        valor = c.Decimal(nullable: false, precision: 18, scale: 2, storeType: "numeric"),
                        valorPago = c.Decimal(nullable: false, precision: 18, scale: 2, storeType: "numeric"),
                        quitado = c.Boolean(nullable: false),
                        id_funcionario = c.Guid(nullable: false),
                        id_pedido = c.Guid(nullable: false),
                        id_fornecedor = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Fornecedor", t => t.id_fornecedor)
                .ForeignKey("dbo.Funcionario", t => t.id_funcionario)
                .ForeignKey("dbo.Pedido", t => t.id_pedido)
                .Index(t => t.id_funcionario)
                .Index(t => t.id_pedido)
                .Index(t => t.id_fornecedor);
            
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
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Cep", t => t.id_cep)
                .Index(t => t.id_cep);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        emissao = c.DateTime(nullable: false),
                        total = c.Decimal(nullable: false, precision: 18, scale: 2, storeType: "numeric"),
                        id_funcionario = c.Guid(nullable: false),
                        id_cardapio = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Cardapio", t => t.id_cardapio)
                .ForeignKey("dbo.Funcionario", t => t.id_funcionario)
                .Index(t => t.id_funcionario)
                .Index(t => t.id_cardapio);
            
            CreateTable(
                "dbo.ItensCardapio",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        valor = c.Decimal(nullable: false, precision: 18, scale: 2, storeType: "numeric"),
                        timestamp = c.DateTime(nullable: false),
                        id_produto = c.Guid(nullable: false),
                        id_cardapio = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Cardapio", t => t.id_cardapio)
                .ForeignKey("dbo.Produto", t => t.id_produto)
                .Index(t => t.id_produto)
                .Index(t => t.id_cardapio);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        codigo = c.String(nullable: false, maxLength: 20),
                        descricao = c.String(nullable: false, maxLength: 100),
                        tipo = c.Int(nullable: false),
                        imagem = c.Binary(storeType: "image"),
                        timestamp = c.DateTime(nullable: false),
                        preco = c.Decimal(nullable: false, precision: 18, scale: 2, storeType: "numeric"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ItensPedido",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        quantidade = c.Int(nullable: false),
                        total = c.Decimal(nullable: false, precision: 18, scale: 2, storeType: "numeric"),
                        id_pedido = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Pedido", t => t.id_pedido)
                .Index(t => t.id_pedido);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        nome = c.String(nullable: false, maxLength: 100, fixedLength: true),
                        login = c.String(nullable: false, maxLength: 100, fixedLength: true),
                        email = c.String(nullable: false, maxLength: 100, fixedLength: true),
                        senha = c.String(nullable: false, maxLength: 4000),
                        tipo = c.Decimal(nullable: false, precision: 18, scale: 0, storeType: "numeric"),
                        cadastro = c.DateTime(nullable: false),
                        id_funcionario = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Funcionario", t => t.id_funcionario)
                .Index(t => t.id_funcionario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuario", "id_funcionario", "dbo.Funcionario");
            DropForeignKey("dbo.ItensPedido", "id_pedido", "dbo.Pedido");
            DropForeignKey("dbo.ItensCardapio", "id_produto", "dbo.Produto");
            DropForeignKey("dbo.ItensCardapio", "id_cardapio", "dbo.Cardapio");
            DropForeignKey("dbo.ContasReceber", "id_pedido", "dbo.Pedido");
            DropForeignKey("dbo.Pedido", "id_funcionario", "dbo.Funcionario");
            DropForeignKey("dbo.Pedido", "id_cardapio", "dbo.Cardapio");
            DropForeignKey("dbo.ContasReceber", "id_funcionario", "dbo.Funcionario");
            DropForeignKey("dbo.Funcionario", "id_cep", "dbo.Cep");
            DropForeignKey("dbo.ContasReceber", "id_fornecedor", "dbo.Fornecedor");
            DropForeignKey("dbo.Cardapio", "id_fornecedor", "dbo.Fornecedor");
            DropForeignKey("dbo.Fornecedor", "id_cep", "dbo.Cep");
            DropForeignKey("dbo.Cep", "id_cidade", "dbo.Cidade");
            DropForeignKey("dbo.Cidade", "id_estado", "dbo.Estado");
            DropForeignKey("dbo.Estado", "id_pais", "dbo.Pais");
            DropIndex("dbo.Usuario", new[] { "id_funcionario" });
            DropIndex("dbo.ItensPedido", new[] { "id_pedido" });
            DropIndex("dbo.ItensCardapio", new[] { "id_cardapio" });
            DropIndex("dbo.ItensCardapio", new[] { "id_produto" });
            DropIndex("dbo.Pedido", new[] { "id_cardapio" });
            DropIndex("dbo.Pedido", new[] { "id_funcionario" });
            DropIndex("dbo.Funcionario", new[] { "id_cep" });
            DropIndex("dbo.ContasReceber", new[] { "id_fornecedor" });
            DropIndex("dbo.ContasReceber", new[] { "id_pedido" });
            DropIndex("dbo.ContasReceber", new[] { "id_funcionario" });
            DropIndex("dbo.Estado", new[] { "id_pais" });
            DropIndex("dbo.Cidade", new[] { "id_estado" });
            DropIndex("dbo.Cep", new[] { "id_cidade" });
            DropIndex("dbo.Fornecedor", new[] { "id_cep" });
            DropIndex("dbo.Cardapio", new[] { "id_fornecedor" });
            DropTable("dbo.Usuario");
            DropTable("dbo.ItensPedido");
            DropTable("dbo.Produto");
            DropTable("dbo.ItensCardapio");
            DropTable("dbo.Pedido");
            DropTable("dbo.Funcionario");
            DropTable("dbo.ContasReceber");
            DropTable("dbo.Pais");
            DropTable("dbo.Estado");
            DropTable("dbo.Cidade");
            DropTable("dbo.Cep");
            DropTable("dbo.Fornecedor");
            DropTable("dbo.Cardapio");
        }
    }
}
