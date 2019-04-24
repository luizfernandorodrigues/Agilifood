using AgiliFood.Interfaces;
using AgiliFood.Models;
using System;

namespace AgiliFood.UnitOfWork
{
    /// <summary>
    /// Alteração no nome das propriedades
    /// Autor:  Luiz Fernando
    /// Data:   23/04/2019
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region propriedades
        private Contexto _contexto = null;

        private Repositorio<Cardapio> cardapioRepositorio = null;
        private Repositorio<Cep> cepRepositorio = null;
        private Repositorio<Cidade> cidadeRepositorio = null;
        private Repositorio<ContasReceber> contasReceberRepositorio = null;
        private Repositorio<Estado> estadoRepositorio = null;
        private Repositorio<Fornecedor> fornecedorRepositorio = null;
        private Repositorio<Funcionario> funcionarioRepositorio = null;
        private Repositorio<ItensCardapio> itensCardapioRepositorio = null;
        private Repositorio<ItensPedido> itensPedidoRepositorio = null;
        private Repositorio<Pais> paisRepositorio = null;
        private Repositorio<Pedido> pedidoRepositorio = null;
        private Repositorio<Produto> produtoRepositorio = null;
        private Repositorio<Usuario> usuarioRepositorio = null;
        #endregion

        #region construtor
        public UnitOfWork()
        {
            _contexto = new Contexto();
        }
        #endregion


        public IRepositorio<Cardapio> CardapiorRepositorio
        {
            get
            {
                if (cardapioRepositorio == null)
                {
                    cardapioRepositorio = new Repositorio<Cardapio>(_contexto);
                }
                return cardapioRepositorio;
            }
        }


        public IRepositorio<Cep> CepRepositorio
        {
            get
            {
                if (cepRepositorio == null)
                {
                    cepRepositorio = new Repositorio<Cep>(_contexto);
                }
                return cepRepositorio;
            }
        }

        public IRepositorio<Cidade> CidadeRepositorio
        {
            get
            {
                if (cidadeRepositorio == null)
                {
                    cidadeRepositorio = new Repositorio<Cidade>(_contexto);
                }
                return cidadeRepositorio;
            }
        }
        public IRepositorio<ContasReceber> ContasReceberRepositorio
        {
            get
            {
                if (contasReceberRepositorio == null)
                {
                    contasReceberRepositorio = new Repositorio<ContasReceber>(_contexto);
                }
                return contasReceberRepositorio;
            }
        }

        public IRepositorio<Estado> EstadoRepositorio
        {
            get
            {
                if (estadoRepositorio == null)
                {
                    estadoRepositorio = new Repositorio<Estado>(_contexto);
                }
                return estadoRepositorio;
            }
        }

        public IRepositorio<Fornecedor> FornecedorRepositorio
        {
            get
            {
                if (fornecedorRepositorio == null)
                {
                    fornecedorRepositorio = new Repositorio<Fornecedor>(_contexto);
                }
                return fornecedorRepositorio;
            }
        }

        public IRepositorio<Funcionario> FuncionarioRepositorio
        {
            get
            {
                if (funcionarioRepositorio == null)
                {
                    funcionarioRepositorio = new Repositorio<Funcionario>(_contexto);
                }
                return funcionarioRepositorio;
            }
        }

        public IRepositorio<ItensCardapio> ItensCardapioRepositorio
        {
            get
            {
                if (itensCardapioRepositorio == null)
                {
                    itensCardapioRepositorio = new Repositorio<ItensCardapio>(_contexto);
                }
                return itensCardapioRepositorio;
            }
        }

        public IRepositorio<ItensPedido> ItensPedidoRepositorio
        {
            get
            {
                if (itensPedidoRepositorio == null)
                {
                    itensPedidoRepositorio = new Repositorio<ItensPedido>(_contexto);
                }
                return itensPedidoRepositorio;
            }
        }

        public IRepositorio<Pais> PaisRepositorio
        {
            get
            {
                if (paisRepositorio == null)
                {
                    paisRepositorio = new Repositorio<Pais>(_contexto);
                }
                return paisRepositorio;
            }
        }

        public IRepositorio<Pedido> PedidoRepositorio
        {
            get
            {
                if (pedidoRepositorio == null)
                {
                    pedidoRepositorio = new Repositorio<Pedido>(_contexto);
                }
                return pedidoRepositorio;
            }
        }

        public IRepositorio<Produto> ProdutoRepositorio
        {
            get
            {
                if (produtoRepositorio == null)
                {
                    produtoRepositorio = new Repositorio<Produto>(_contexto);
                }
                return produtoRepositorio;
            }
        }

        public IRepositorio<Usuario> UsuarioRepositorio
        {
            get
            {
                if (usuarioRepositorio == null)
                {
                    usuarioRepositorio = new Repositorio<Usuario>(_contexto);
                }
                return usuarioRepositorio;
            }
        }

        public void Commit()
        {
            _contexto.SaveChanges();
        }

        private bool dispose = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!dispose)
            {
                if (disposing)
                {
                    _contexto.Dispose();
                }
            }
            dispose = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}