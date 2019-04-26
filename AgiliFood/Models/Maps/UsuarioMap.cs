using System.Data.Entity.ModelConfiguration;

namespace AgiliFood.Models.Maps
{
    /// <summary>
    /// Classe de mapeamento do dominio usuario
    /// </summary>
    /// <remarks>
    /// Autor:  Luiz Fernando
    /// Data:   20/04/2019
    /// 
    /// Alteração:  Removido coluna Tipo e adicionado coluna Adm
    /// Autor:  Luiz Fernando
    /// Data:   23/04/2019
    /// 
    /// Alteração:  Removido coluna Data de cadastro, nomeFuncionario e idFuncionario visto que não seria necesario
    /// Autor:  Luiz Fernando
    /// Data:   25/04/2019
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
            Property(x => x.Adm).HasColumnName("adm").HasColumnType("bit").IsRequired();
        }
    }
}