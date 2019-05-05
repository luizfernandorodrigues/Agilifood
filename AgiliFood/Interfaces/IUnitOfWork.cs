using AgiliFood.Models;

namespace AgiliFood.Interfaces
{
    /// <summary>
    /// Alteração no nome dos atributos
    /// Autor:  Luiz Fernando
    /// Data:   23/04/2019
    /// </summary>
    interface IUnitOfWork
    {
        IRepositorio<Cardapio> CardapiorRepositorio { get; }
        IRepositorio<Cep> CepRepositorio { get; }
        IRepositorio<Cidade> CidadeRepositorio { get; }
        IRepositorio<ContasReceber> ContasReceberRepositorio { get; }
        IRepositorio<Estado> EstadoRepositorio { get; }
        IRepositorio<Fornecedor> FornecedorRepositorio { get; }
        IRepositorio<ItensCardapio> ItensCardapioRepositorio { get; }
        IRepositorio<Pais> PaisRepositorio { get; }
        IRepositorio<Pedido> PedidoRepositorio { get; }
        IRepositorio<Produto> ProdutoRepositorio { get; }
        IRepositorio<Usuario> UsuarioRepositorio { get; }

        void Commit();
    }
}
