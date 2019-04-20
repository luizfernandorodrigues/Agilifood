using System.Data.Entity.ModelConfiguration;

namespace AgiliFood.Models.Maps
{
    /// <summary>
    /// Classe para mapear o dominio fornecedor
    /// </summary>
    /// <remarks>
    /// Autor:  Luiz Fernando
    /// Data:   18/04/2019
    /// 
    /// Alteração:  Setado o tipo dos dados nas propriedades para evitar criar algum tipo que não seja desejado
    /// Autor:  Luiz Fernando
    /// Data:   20/04/2019
    /// </remarks>
    public class FornecedorMap : EntityTypeConfiguration<Fornecedor>
    {
        public FornecedorMap()
        {
            ToTable("Fornecedor");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("id").HasColumnType("uniqueidentifier");

            Property(x => x.RazaoSocial).HasColumnName("razaoSocial").HasColumnType("nchar").HasMaxLength(200).IsRequired();
            Property(x => x.Fantasia).HasColumnName("fantasia").HasColumnType("nchar").HasMaxLength(100).IsOptional();
            Property(x => x.Logradouro).HasColumnName("logradouro").HasColumnType("nchar").HasMaxLength(100).IsRequired();
            Property(x => x.NumeroEndereco).HasColumnName("numeroEndereco").HasColumnType("nchar").HasMaxLength(10).IsOptional();
            Property(x => x.Bairro).HasColumnName("bairro").HasColumnType("nchar").HasMaxLength(100).IsRequired();
            Property(x => x.Fone).HasColumnName("fone").HasColumnType("nchar").HasMaxLength(11).IsOptional();
            Property(x => x.Cnpj).HasColumnName("cnpj").HasColumnType("nchar").HasMaxLength(14).IsRequired();
            Property(x => x.Email).HasColumnName("email").HasColumnType("nchar").HasMaxLength(80).IsOptional();
            Property(x => x.Cadastro).HasColumnName("cadastro").HasColumnType("datetime").IsRequired();
            Property(x => x.TimesTamp).HasColumnName("timestamp").HasColumnType("datetime").IsRequired();

            Property(x => x.Id_Cep).HasColumnName("id_cep").HasColumnType("uniqueidentifier").IsRequired();
            HasRequired(x => x.Cep).WithMany().HasForeignKey(x => x.Id_Cep).WillCascadeOnDelete(false);
        }
    }
}