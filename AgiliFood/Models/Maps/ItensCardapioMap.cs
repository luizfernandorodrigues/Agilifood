using System.Data.Entity.ModelConfiguration;

namespace AgiliFood.Models.Maps
{
    /// <summary>
    /// Classe para mapear o dominio ItensCardapio
    /// </summary>
    /// <remarks>
    /// Autor:  Luiz Fernando
    /// Data:   18/04/2019
    /// </remarks>
    public class ItensCardapioMap :EntityTypeConfiguration<ItensCardapio>
    {
        public ItensCardapioMap()
        {
            ToTable("ItensCardapio");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("id");

            Property(x => x.TimesTamp).HasColumnName("timestamp").IsRequired();
            Property(x => x.Valor).HasColumnName("valor").HasColumnType("Numeric(18,2)");
            //fk do cardapio
            Property(x => x.Id_Cardapio).HasColumnName("id_cardapio").IsRequired();
            HasRequired(x => x.Cardapio).WithMany().HasForeignKey(x => x.Id_Cardapio).WillCascadeOnDelete(false);
            //fk do produto
            Property(x => x.Id_Produto).HasColumnName("id_produto").IsRequired();
            HasRequired(x => x.Produto).WithMany().HasForeignKey(x => x.Id_Produto).WillCascadeOnDelete(false);
        }
    }
}