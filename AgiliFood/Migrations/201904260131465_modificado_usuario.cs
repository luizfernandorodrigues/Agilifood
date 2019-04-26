namespace AgiliFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificado_usuario : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Usuario", "id_funcionario", "dbo.Funcionario");
            DropIndex("dbo.Usuario", new[] { "id_funcionario" });
            CreateTable(
                "dbo.UsuarioViewModels",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Login = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        Senha = c.String(nullable: false),
                        Adm = c.Boolean(nullable: false),
                        Cadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Usuario", "id_funcionario");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuario", "id_funcionario", c => c.Guid(nullable: false));
            DropTable("dbo.UsuarioViewModels");
            CreateIndex("dbo.Usuario", "id_funcionario");
            AddForeignKey("dbo.Usuario", "id_funcionario", "dbo.Funcionario", "id");
        }
    }
}
