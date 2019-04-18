using System.Data.Entity.ModelConfiguration;

namespace AgiliFood.Models.Maps
{
    /// <summary>
    /// Classe de mapeamento do modelo cidade
    /// </summary>
    /// <remarks>
    /// Autor:  Luiz Fernando
    /// Data:   17/04/2019
    /// </remarks>
    public class CidadeMap : EntityTypeConfiguration<Cidade>
    {
        public CidadeMap()
        {
            ToTable("Cidade");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("id");

            Property(x => x.Nome).HasColumnName("nome").HasMaxLength(100).IsRequired();
            Property(x => x.TimesTamp).HasColumnName("timestamp").IsRequired();

            Property(x => x.Id_Estado).HasColumnName("id_estado").IsRequired();
            HasRequired(x => x.Estado).WithMany().HasForeignKey(x=>x.Id_Estado).WillCascadeOnDelete(false);
        }
    }
}