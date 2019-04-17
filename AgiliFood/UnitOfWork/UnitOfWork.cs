using AgiliFood.Interfaces;
using AgiliFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgiliFood.UnitOfWork
{
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


        public IRepositorio<Cep> Cep
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

        public IRepositorio<Cidade> Cidade
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
        public IRepositorio<ContasReceber> ContasReceber
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

        public IRepositorio<Estado> Estado
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

        public IRepositorio<Fornecedor> Fornecedor
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

        public IRepositorio<Funcionario> Funcionario
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

        public IRepositorio<ItensCardapio> ItensCardapio
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

        public IRepositorio<ItensPedido> ItensPedido
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

        public IRepositorio<Pais> Pais
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

        public IRepositorio<Pedido> Pedido
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

        public IRepositorio<Produto> Produto
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

        public IRepositorio<Usuario> Usuario
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