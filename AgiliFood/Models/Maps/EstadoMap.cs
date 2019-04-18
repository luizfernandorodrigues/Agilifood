using System.Data.Entity.ModelConfiguration;

namespace AgiliFood.Models.Maps
{
    /// <summary>
    /// Classe para mapear o dominio estado
    /// </summary>
    /// <remarks>
    /// Autor:  Luiz Fernando
    /// Data:   18/04/2019
    /// </remarks>
    public class EstadoMap : EntityTypeConfiguration<Estado>
    {
        public EstadoMap()
        {
            ToTable("Estado");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("id");

            Property(x => x.Nome).HasColumnName("nome").HasMaxLength(50).IsRequired();
            Property(x => x.Sigla).HasColumnName("sigla").HasMaxLength(2).IsRequired();
            Property(x => x.TimesTamp).HasColumnName("timestamp").IsRequired();

            Property(x => x.Id_Pais).HasColumnName("id_pais").IsRequired();
            HasRequired(x => x.Pais).WithMany().HasForeignKey(x => x.Id_Pais).WillCascadeOnDelete(false);
        }
    }
}