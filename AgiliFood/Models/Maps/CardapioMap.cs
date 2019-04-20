using System.Data.Entity.ModelConfiguration;

namespace AgiliFood.Models.Maps
{
    /// <summary>
    /// Classe de mapeamento do modelo Cardapio
    /// </summary>
    /// <remarks>
    /// Autor:  Luiz Fernando
    /// Data:   17/04/2019
    /// 
    /// Alteração:  Setado o tipo dos dados nas propriedades para evitar criar algum tipo que não seja desejado
    /// Autor:  Luiz Fernando
    /// Data:   20/04/2019
    /// 
    /// </remarks>
    public class CardapioMap : EntityTypeConfiguration<Cardapio>
    {
        public CardapioMap()
        {
            ToTable("Cardapio");

            HasKey(x=>x.Id);
            Property(x => x.Id).HasColumnName("id").HasColumnType("uniqueidentifier");

            Property(x => x.Codigo).HasColumnName("codigo").HasColumnType("nchar").HasMaxLength(10).IsRequired();
            Property(x => x.Descricao).HasColumnName("descricao").HasColumnType("nchar").HasMaxLength(30).IsRequired();
            Property(x => x.Cadastro).HasColumnName("cadastro").HasColumnType("datetime").IsRequired();
            Property(x => x.TimesTamp).HasColumnName("timestamp").HasColumnType("datetime").IsRequired();

            Property(x => x.Id_Fornecedor).HasColumnName("id_fornecedor").HasColumnType("uniqueidentifier").IsRequired();
            HasRequired(x => x.Fornecedor).WithMany().HasForeignKey(x => x.Id_Fornecedor).WillCascadeOnDelete(false);
        }
    }
}