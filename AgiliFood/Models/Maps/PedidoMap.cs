using System.Data.Entity.ModelConfiguration;

namespace AgiliFood.Models.Maps
{
    /// <summary>
    /// Classe de mapeamento do dominio pedido
    /// </summary>
    /// <remarks>
    /// Autor:  Luiz Fernando
    /// Data:   19/04/2019
    /// </remarks>
    public class PedidoMap : EntityTypeConfiguration<Pedido>
    {
        public PedidoMap()
        {
            ToTable("Pedido");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("id").HasColumnType("uniqueidentifier");

            Property(x => x.Emissao).HasColumnName("emissao").HasColumnType("DateTime").IsRequired();
            Property(x => x.Total).HasColumnName("total").HasColumnType("numeric").IsRequired();

            //fk do funcionario
            Property(x => x.Id_Usuario).HasColumnName("id_usuario").HasColumnType("uniqueidentifier").IsRequired();
            HasRequired(x => x.Usuario).WithMany().HasForeignKey(x => x.Id_Usuario).WillCascadeOnDelete(false);

            Property(x => x.Id_Cardapio).HasColumnName("id_cardapio").HasColumnType("uniqueidentifier").IsRequired();
            HasRequired(x => x.Cardapio).WithMany().HasForeignKey(x => x.Id_Cardapio).WillCascadeOnDelete(false);
        }
    }
}