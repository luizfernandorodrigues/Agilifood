using System.Data.Entity.ModelConfiguration;

namespace AgiliFood.Models.Maps
{
    /// <summary>
    /// Classe para mapear o dominio estado
    /// </summary>
    /// <remarks>
    /// Autor:  Luiz Fernando
    /// Data:   18/04/2019
    /// 
    /// Alteração:  Setado o tipo dos dados nas propriedades para evitar criar algum tipo que não seja desejado
    /// Autor:  Luiz Fernando
    /// Data:   20/04/2019
    /// </remarks>
    public class EstadoMap : EntityTypeConfiguration<Estado>
    {
        public EstadoMap()
        {
            ToTable("Estado");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("id").HasColumnType("uniqueidentifier");

            Property(x => x.Nome).HasColumnName("nome").HasColumnType("nchar").HasMaxLength(50).IsRequired();
            Property(x => x.Sigla).HasColumnName("sigla").HasColumnType("nchar").HasMaxLength(2).IsRequired();
            Property(x => x.TimesTamp).HasColumnName("timestamp").HasColumnType("datetime").IsRequired();

            Property(x => x.Id_Pais).HasColumnName("id_pais").HasColumnType("uniqueidentifier").IsRequired();
            HasRequired(x => x.Pais).WithMany().HasForeignKey(x => x.Id_Pais).WillCascadeOnDelete(false);
        }
    }
}