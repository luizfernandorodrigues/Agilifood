using System.Data.Entity.ModelConfiguration;

namespace AgiliFood.Models.Maps
{
    /// <summary>
    /// Classe de mapeamento do dominio ItensPedido
    /// </summary>
    /// <remarks>
    /// Autor:  Luiz Fernando
    /// Data:   19/04/2019
    /// </remarks>
    public class ItensPedidoMap :EntityTypeConfiguration<ItensPedido>
    {
        public ItensPedidoMap()
        {
            ToTable("ItensPedido");

            HasKey(x=>x.Id);
            Property(x => x.Id).HasColumnName("id").HasColumnType("uniqueidentifier");

            Property(x => x.Quantidade).HasColumnName("quantidade").HasColumnType("int").IsRequired();
            Property(x => x.Total).HasColumnName("total").HasColumnType("numeric").IsRequired();

            //fk Pedido
            Property(x => x.Id_Pedido).HasColumnName("id_pedido").HasColumnType("uniqueidentifier").IsRequired();
            HasRequired(x => x.Pedido).WithMany().HasForeignKey(x => x.Id_Pedido).WillCascadeOnDelete(false);
        }
    }
}