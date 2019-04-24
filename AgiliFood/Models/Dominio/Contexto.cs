using AgiliFood.Models.Maps;
using System.Data.Entity;

namespace AgiliFood.Models
{
    public partial class Contexto : DbContext
    {
        public Contexto()
                    : base("EFConnectionString") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CardapioMap());
            modelBuilder.Configurations.Add(new CepMap());
            modelBuilder.Configurations.Add(new CidadeMap());
            modelBuilder.Configurations.Add(new ContasReceberMap());
            modelBuilder.Configurations.Add(new EstadoMap());
            modelBuilder.Configurations.Add(new FornecedorMap());
            modelBuilder.Configurations.Add(new FuncionarioMap());
            modelBuilder.Configurations.Add(new ItensCardapioMap());
            modelBuilder.Configurations.Add(new ItensPedidoMap());
            modelBuilder.Configurations.Add(new PaisMap());
            modelBuilder.Configurations.Add(new ProdutoMap());
            modelBuilder.Configurations.Add(new PedidoMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
        }

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

    }
}