using System.Data.Entity.ModelConfiguration;

namespace AgiliFood.Models.Maps
{
    /// <summary>
    /// Classe de mapeamento do modelo Cardapio
    /// </summary>
    /// <remarks>
    /// Autor:  Luiz Fernando
    /// Data:   17/04/2019
    /// </remarks>
    public class CardapioMap : EntityTypeConfiguration<Cardapio>
    {
        public CardapioMap()
        {
            ToTable("Cardapio");

            HasKey(x=>x.Id);
            Property(x => x.Id).HasColumnName("id");

            Property(x => x.Codigo).HasColumnName("codigo").HasMaxLength(10).IsRequired();
            Property(x => x.Descricao).HasColumnName("descricao").HasMaxLength(30).IsRequired();
            Property(x => x.Cadastro).HasColumnName("cadastro").IsRequired();
            Property(x => x.TimesTamp).HasColumnName("timestamp").IsRequired();

            Property(x => x.Id_Fornecedor).HasColumnName("id_fornecedor").IsRequired();
            HasRequired(x => x.Fornecedor).WithMany().HasForeignKey(x => x.Id_Fornecedor).WillCascadeOnDelete(false);
        }
    }
}