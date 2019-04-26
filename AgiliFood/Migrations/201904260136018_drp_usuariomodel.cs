namespace AgiliFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class drp_usuariomodel : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.UsuarioViewModels");
        }
        
        public override void Down()
        {
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
            
        }
    }
}
