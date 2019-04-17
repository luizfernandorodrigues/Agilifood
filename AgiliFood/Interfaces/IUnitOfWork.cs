using AgiliFood.Models;

namespace AgiliFood.Interfaces
{
    interface IUnitOfWork
    {
        IRepositorio<Cardapio> CardapiorRepositorio { get; }
        IRepositorio<Cep> Cep { get; }
        IRepositorio<Cidade> Cidade { get; }
        IRepositorio<ContasReceber> ContasReceber { get; }
        IRepositorio<Estado> Estado { get; }
        IRepositorio<Fornecedor> Fornecedor { get; }
        IRepositorio<Funcionario> Funcionario { get; }
        IRepositorio<ItensCardapio> ItensCardapio { get; }
        IRepositorio<ItensPedido> ItensPedido { get; }
        IRepositorio<Pais> Pais { get; }
        IRepositorio<Pedido> Pedido { get; }
        IRepositorio<Produto> Produto { get; }
        IRepositorio<Usuario> Usuario { get; }

        void Commit();
    }
}
