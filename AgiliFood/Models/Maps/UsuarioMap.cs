using System.Data.Entity.ModelConfiguration;

namespace AgiliFood.Models.Maps
{
    /// <summary>
    /// Classe de mapeamento do dominio usuario
    /// </summary>
    /// <remarks>
    /// Autor:  Luiz Fernando
    /// Data:   20/04/2019
    /// </remarks>
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("Usuario");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("id").HasColumnType("uniqueidentifier");

            Property(x => x.Nome).HasColumnName("nome").HasColumnType("nchar").HasMaxLength(100).IsRequired();
            Property(x => x.Login).HasColumnName("login").HasColumnType("nchar").HasMaxLength(100).IsRequired();
            Property(x => x.Email).HasColumnName("email").HasColumnType("nchar").HasMaxLength(100).IsRequired();
            Property(x => x.Senha).HasColumnName("senha").HasColumnType("nvarchar").HasMaxLength(4000).IsRequired();
            Property(x => x.Tipo).HasColumnName("tipo").HasColumnType("numeric").IsRequired();
            Property(x => x.Cadastro).HasColumnName("cadastro").HasColumnType("datetime").IsRequired();

            //fk funcionario
            Property(x => x.Id_Funcionario).HasColumnName("id_funcionario").HasColumnType("uniqueidentifier").IsRequired();
            HasRequired(x => x.Funcionario).WithMany().HasForeignKey(x => x.Id_Funcionario).WillCascadeOnDelete(false);

        }
    }
}