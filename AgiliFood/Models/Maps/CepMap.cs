using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;

namespace AgiliFood.Models.Maps
{
    /// <summary>
    /// Classe de mapeamento do modelo cep
    /// </summary>
    /// <remarks>
    /// Autor:  Luiz Fernando
    /// Data:   17/04/2019
    /// </remarks>
    public class CepMap : EntityTypeConfiguration<Cep>
    {
        public CepMap()
        {
            ToTable("Cep");

            HasKey(cep => cep.Id);
            Property(cep => cep.Id).HasColumnName("id");

            Property(cep => cep._Cep).HasColumnName("cep").HasMaxLength(8).IsRequired();
            Property(cep => cep.TimesTamp).HasColumnName("timestamp").IsRequired();

            Property(cep => cep.Id_Cidade).HasColumnName("id_cidade").IsRequired();
            HasRequired(cep => cep.Cidade).WithMany().HasForeignKey(cep => cep.Id_Cidade).WillCascadeOnDelete(false);
        }
    }
}