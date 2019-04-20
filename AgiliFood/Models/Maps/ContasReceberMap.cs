using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace AgiliFood.Models.Maps
{
    /// <summary>
    /// Classe de mapeamento do dominio contas a receber
    /// </summary>
    /// <remarks>
    /// Autor:  Luiz Fernando
    /// Data:   19/04/2019
    /// 
    /// Alteração:  Setado o tipo dos dados nas propriedades para evitar criar algum tipo que não seja desejado
    /// Autor:  Luiz Fernando
    /// Data:   20/04/2019
    /// </remarks>
    public class ContasReceberMap : EntityTypeConfiguration<ContasReceber>
    {
        public ContasReceberMap()
        {
            ToTable("ContasReceber");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("id").HasColumnType("uniqueidentifier");
            
            Property(x => x.Emissao).HasColumnName("emissao").IsRequired();
            Property(x => x.Valor).HasColumnName("valor").HasColumnType("numeric").IsRequired().HasPrecision(18,2);
            Property(x => x.ValorPago).HasColumnName("valorPago").HasColumnType("numeric").HasPrecision(18,2).IsRequired();
            Property(x => x.Quitado).HasColumnName("quitado").HasColumnType("bit").IsRequired();

            //fk funcionario
            Property(x => x.Id_Funcionario).HasColumnName("id_funcionario").HasColumnType("uniqueidentifier").IsRequired();
            HasRequired(x => x.Funcionario).WithMany().HasForeignKey(x => x.Id_Funcionario).WillCascadeOnDelete(false);

            //fk pedido
            Property(x => x.Id_Pedido).HasColumnName("id_pedido").HasColumnType("uniqueidentifier").IsRequired();
            HasRequired(x => x.Pedido).WithMany().HasForeignKey(x => x.Id_Pedido).WillCascadeOnDelete(false);

            //fk fornecedor
            Property(x => x.Id_Fornecedor).HasColumnName("id_fornecedor").HasColumnType("uniqueidentifier").IsRequired();
            HasRequired(x => x.Fornecedor).WithMany().HasForeignKey(x => x.Id_Fornecedor).WillCascadeOnDelete(false);
        }
    }
}