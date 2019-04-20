using System.Data.Entity.ModelConfiguration;

namespace AgiliFood.Models.Maps
{
    /// <summary>
    /// Classe de mapeamento do modelo cidade
    /// </summary>
    /// <remarks>
    /// Autor:  Luiz Fernando
    /// Data:   17/04/2019
    /// 
    /// Alteração:  Setado o tipo dos dados nas propriedades para evitar criar algum tipo que não seja desejado
    /// Autor:  Luiz Fernando
    /// Data:   20/04/2019
    /// </remarks>
    public class CidadeMap : EntityTypeConfiguration<Cidade>
    {
        public CidadeMap()
        {
            ToTable("Cidade");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("id").HasColumnType("uniqueidentifier");

            Property(x => x.Nome).HasColumnName("nome").HasColumnType("nchar").HasMaxLength(100).IsRequired();
            Property(x => x.TimesTamp).HasColumnName("timestamp").HasColumnType("datetime").IsRequired();

            Property(x => x.Id_Estado).HasColumnName("id_estado").HasColumnType("uniqueidentifier").IsRequired();
            HasRequired(x => x.Estado).WithMany().HasForeignKey(x=>x.Id_Estado).WillCascadeOnDelete(false);
        }
    }
}