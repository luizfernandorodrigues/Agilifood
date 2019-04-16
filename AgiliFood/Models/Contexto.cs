using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AgiliFood.Models
{
    public partial class Contexto : DbContext
    {
        public Contexto()
                    : base("EFConnectionString") { }

        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Cidade> Cidade { get; set; }
        public virtual DbSet<Cep> Cep { get; set; }
        public virtual DbSet<Cardapio> Cardapio { get; set; }
        public virtual DbSet<ContasReceber> ContasReceber { get; set; }
        public virtual DbSet<Fornecedor> Fornecedor { get; set; }
        public virtual DbSet<Funcionario> Funcionario { get; set; }
        public virtual DbSet<ItensCardapio> ItensCardapio { get; set; }
        public virtual DbSet<ItensPedido> ItensPedido { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

    }
}