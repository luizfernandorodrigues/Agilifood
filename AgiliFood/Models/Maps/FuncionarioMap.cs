using System.Data.Entity.ModelConfiguration;

namespace AgiliFood.Models.Maps
{
    /// <summary>
    /// Classe de mapeamento do dominio funcionario
    /// </summary>
    /// <remarks>
    /// Autor:  Luiz Fernando
    /// Data:   19/04/2019
    /// </remarks>
    public class FuncionarioMap : EntityTypeConfiguration<Funcionario>
    {
        public FuncionarioMap()
        {
            ToTable("Funcionario");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("id").HasColumnType("uniqueidentifier");

            Property(x => x.Nome).HasColumnName("nome").HasColumnType("nchar").HasMaxLength(100).IsRequired();
            Property(x => x.Endereco).HasColumnName("endereco").HasColumnType("nchar").HasMaxLength(100).IsRequired();
            Property(x => x.NumeroEndereco).HasColumnName("numeroEndereco").HasColumnType("nchar").HasMaxLength(20).IsOptional();
            Property(x => x.Bairro).HasColumnName("bairro").HasColumnType("nchar").HasMaxLength(80).IsRequired();
            Property(x => x.Fone).HasColumnName("fone").HasColumnType("nchar").HasMaxLength(11).IsRequired();
            Property(x => x.Cpf).HasColumnName("cpf").HasColumnType("nchar").HasMaxLength(11).IsOptional();

            //fk cep
            Property(x => x.Id_Cep).HasColumnName("id_cep").HasColumnType("uniqueidentifier").IsRequired();
            HasRequired(x => x.Cep).WithMany().HasForeignKey(x => x.Id_Cep).WillCascadeOnDelete(false);
        }
    }
}