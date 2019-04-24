using AgiliFood.Models;
using AgiliFood.Models.ModeloVisao;
using AutoMapper;

namespace AgiliFood.AutoMapper
{
    /// <summary>
    /// Classe responsavel por realizar o mapeamentos dos dominios com as viewmodels
    /// </summary>
    /// <remarks>
    /// Autor:  Luiz Fernando
    /// Data:   23/04/2019
    /// </remarks>
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PaisViewModel, Pais>();
            CreateMap<CardapioViewModel, Cardapio>();
            CreateMap<CepViewModel, Cep>();
            CreateMap<CidadeViewModel, Cidade>();
            CreateMap<ContasReceberViewModel, ContasReceber>();
            CreateMap<EstadoViewModel, Estado>();
            CreateMap<FornecedorViewModel, Fornecedor>();
            CreateMap<FuncionarioViewModel, Funcionario>();
            CreateMap<ItensCardapioViewModel, ItensCardapio>();
            CreateMap<ItensPedidoViewModel, ItensPedido>();
            CreateMap<PedidoViewModel, Pedido>();
            CreateMap<ProdutoViewModel, Produto>();
            CreateMap<UsuarioViewModel, Usuario>();
        }
    }
}