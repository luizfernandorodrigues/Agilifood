using System.Data.Entity.ModelConfiguration;

namespace AgiliFood.Models.Maps
{
    /// <summary>
    /// Classe de mapeamento do modelo cep
    /// </summary>
    /// <remarks>
    /// Autor:  Luiz Fernando
    /// Data:   17/04/2019
    /// 
    ///Alteração:  Setado o tipo dos dados nas propriedades para evitar criar algum tipo que não seja desejado
    /// Autor:  Luiz Fernando
    /// Data:   20/04/2019
    /// </remarks>
    public class CepMap : EntityTypeConfiguration<Cep>
    {
        public CepMap()
        {
            ToTable("Cep");

            HasKey(cep => cep.Id);
            Property(cep => cep.Id).HasColumnName("id").HasColumnType("uniqueidentifier");

            Property(cep => cep._Cep).HasColumnName("cep").HasColumnType("nchar").HasMaxLength(8).IsRequired();
            Property(cep => cep.TimesTamp).HasColumnName("timestamp").HasColumnType("datetime").IsRequired();

            Property(cep => cep.Id_Cidade).HasColumnName("id_cidade").HasColumnType("uniqueidentifier").IsRequired();
            HasRequired(cep => cep.Cidade).WithMany().HasForeignKey(cep => cep.Id_Cidade).WillCascadeOnDelete(false);
        }
    }
}