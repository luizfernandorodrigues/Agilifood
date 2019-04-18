using System.Data.Entity.ModelConfiguration;

namespace AgiliFood.Models.Maps
{
    /// <summary>
    /// Classe de mapeamento do modelo pais
    /// </summary>
    /// <remarks>
    /// Autor:  Luiz Fernando
    /// Data:   17/04/2019
    /// </remarks>
    public class PaisMap : EntityTypeConfiguration<Pais>
    {
        public PaisMap()
        {
            ToTable("Pais");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("id");

            Property(x => x.Nome).HasColumnName("numero").HasMaxLength(100).IsRequired();
            Property(x => x.Codigo).HasColumnName("codigo").HasMaxLength(10).IsOptional();
            Property(x => x.TimesTamp).HasColumnName("timestamp").IsRequired();
        }
    }
}