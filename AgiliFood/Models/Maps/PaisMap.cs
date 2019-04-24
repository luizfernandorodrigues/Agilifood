using System.Data.Entity.ModelConfiguration;

namespace AgiliFood.Models.Maps
{
    /// <summary>
    /// Classe de mapeamento do modelo pais
    /// </summary>
    /// <remarks>
    /// Autor:  Luiz Fernando
    /// Data:   17/04/2019
    /// 
    /// Alteração:  Setado o tipo dos dados nas propriedades para evitar criar algum tipo que não seja desejado
    /// Autor:  Luiz Fernando
    /// Data:   20/04/2019
    /// </remarks>
    public class PaisMap : EntityTypeConfiguration<Pais>
    {
        public PaisMap()
        {
            ToTable("Pais");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("id").HasColumnType("uniqueidentifier");

            Property(x => x.Nome).HasColumnName("nome").HasColumnType("nchar").HasMaxLength(100).IsRequired();
            Property(x => x.Codigo).HasColumnName("codigo").HasColumnType("nchar").HasMaxLength(10).IsOptional();
            Property(x => x.TimesTamp).HasColumnName("timestamp").HasColumnType("datetime").IsRequired();
        }
    }
}