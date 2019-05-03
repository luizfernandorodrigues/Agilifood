using System.Data.Entity.ModelConfiguration;

namespace AgiliFood.Models.Maps
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            ToTable("Produto");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("id");

            Property(x => x.Codigo).HasColumnName("codigo").HasMaxLength(20).IsRequired();
            Property(x => x.Descricao).HasColumnName("descricao").HasMaxLength(100).IsRequired();
            Property(x => x.TimesTamp).HasColumnName("timestamp").IsRequired();
            Property(x => x.Preco).HasColumnName("preco").HasColumnType("numeric").IsRequired();
        }
    }
}