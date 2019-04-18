using System.Data.Entity.ModelConfiguration;

namespace AgiliFood.Models.Maps
{
    /// <summary>
    /// Classe para mapear o dominio fornecedor
    /// </summary>
    /// <remarks>
    /// Autor:  Luiz Fernando
    /// Data:   18/04/2019
    /// </remarks>
    public class FornecedorMap : EntityTypeConfiguration<Fornecedor>
    {
        public FornecedorMap()
        {
            ToTable("Fornecedor");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("id");

            Property(x => x.RazaoSocial).HasColumnName("razaoSocial").HasMaxLength(200).IsRequired();
            Property(x => x.Fantasia).HasColumnName("fantasia").HasMaxLength(100).IsOptional();
            Property(x => x.Logradouro).HasColumnName("logradouro").HasMaxLength(100).IsRequired();
            Property(x => x.NumeroEndereco).HasColumnName("numeroEndereco").HasMaxLength(10).IsOptional();
            Property(x => x.Bairro).HasColumnName("bairro").HasMaxLength(100).IsRequired();
            Property(x => x.Fone).HasColumnName("fone").HasMaxLength(11).IsOptional();
            Property(x => x.Cnpj).HasColumnName("cnpj").HasMaxLength(14).IsRequired();
            Property(x => x.Email).HasColumnName("email").HasMaxLength(80).IsOptional();
            Property(x => x.Cadastro).HasColumnName("cadastro").IsRequired();
            Property(x => x.TimesTamp).HasColumnName("timestamp").IsRequired();

            Property(x => x.Id_Cep).HasColumnName("id_cep").IsRequired();
            HasRequired(x => x.Cep).WithMany().HasForeignKey(x => x.Id_Cep).WillCascadeOnDelete(false);
        }
    }
}