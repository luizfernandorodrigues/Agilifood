using System.Data.Entity.ModelConfiguration;

namespace AgiliFood.Models.Maps
{
    /// <summary>
    /// Classe para mapear o dominio ItensCardapio
    /// </summary>
    /// <remarks>
    /// Autor:  Luiz Fernando
    /// Data:   18/04/2019
    /// 
    /// Alteração:  Setado o tipo dos dados nas propriedades para evitar criar algum tipo que não seja desejado
    /// Autor:  Luiz Fernando
    /// Data:   20/04/2019
    /// </remarks>
    public class ItensCardapioMap :EntityTypeConfiguration<ItensCardapio>
    {
        public ItensCardapioMap()
        {
            ToTable("ItensCardapio");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("id").HasColumnType("uniqueidentifier");

            Property(x=>x.Quantidade).HasColumnName("quantidade").HasColumnType("int").IsRequired();

            //fk do cardapio
            Property(x => x.Id_Cardapio).HasColumnName("id_cardapio").HasColumnType("uniqueidentifier").IsRequired();
            HasRequired(x => x.Cardapio).WithMany().HasForeignKey(x => x.Id_Cardapio).WillCascadeOnDelete(false);
            //fk do produto
            Property(x => x.Id_Produto).HasColumnName("id_produto").HasColumnType("uniqueidentifier").IsRequired();
            HasRequired(x => x.Produto).WithMany().HasForeignKey(x => x.Id_Produto).WillCascadeOnDelete(false);
        }
    }
}