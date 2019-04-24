namespace AgiliFood.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificacao_pais : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Pais", name: "numero", newName: "nome");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Pais", name: "nome", newName: "numero");
        }
    }
}
