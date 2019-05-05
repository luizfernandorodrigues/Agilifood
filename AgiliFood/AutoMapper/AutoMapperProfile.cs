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
    /// 
    /// Alteração: Adicionado o mapeamento inverso do domain para a viewModel
    /// Autor:  Luiz Fernando
    /// Data:   01/05/2019
    /// </remarks>
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PaisViewModel, Pais>();
            CreateMap<Pais, PaisViewModel>();

            CreateMap<CardapioViewModel, Cardapio>();
            CreateMap<Cardapio, CardapioViewModel>();

            CreateMap<CepViewModel, Cep>();
            CreateMap<Cep, CepViewModel>();

            CreateMap<CidadeViewModel, Cidade>();
            CreateMap<Cidade, CidadeViewModel>();

            CreateMap<ContasReceberViewModel, ContasReceber>();
            CreateMap<ContasReceber, ContasReceberViewModel>();

            CreateMap<EstadoViewModel, Estado>();
            CreateMap<Estado, EstadoViewModel>();

            CreateMap<FornecedorViewModel, Fornecedor>();
            CreateMap<Fornecedor, FornecedorViewModel>();

         
            CreateMap<ItensCardapioViewModel, ItensCardapio>();
            CreateMap<ItensCardapio, ItensCardapioViewModel>();


            CreateMap<PedidoViewModel, Pedido>();
            CreateMap<Pedido, PedidoViewModel>();

            CreateMap<ProdutoViewModel, Produto>();
            CreateMap<Produto, ProdutoViewModel>();

            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<UsuarioViewModel, Usuario>();
        }
    }
}