﻿using AgiliFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgiliFood.Negocio
{
    public class GeraContasReceber
    {
        /// <summary>
        /// Metodo responsavel por gerar o contas a receber do funcionario
        /// </summary>
        /// <remarks>
        /// Autor:  Luiz Fernando
        /// Data:   29/04/2019
        /// </remarks>
        /// <param name="pedido">Recebe o pedido e gera o financeiro do mesmo</param>
        /// <returns>true se deu certo e false caso tenha dado algum erro</returns>
        ///        
        public bool GerarContasReceber(Pedido pedido)
        {
            bool retorno = false;
            try
            {
                using (UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork())
                {
                    //recupero o id do fornecedor
                    Guid idFornecedor = uow.CardapiorRepositorio.Get(x=>x.Id == pedido.Id_Cardapio).Id_Fornecedor;
                    ContasReceber contasReceber = new ContasReceber
                    {
                        Id = Guid.NewGuid(),
                        Emissao = DateTime.Now,
                        Id_Pedido = pedido.Id,
                        Id_Fornecedor = idFornecedor,
                        Id_Usuario = pedido.Id_Usuario,
                        Quitado = false,
                        ValorPago = 0,
                        Valor = pedido.Total
                    };

                    uow.ContasReceberRepositorio.Adcionar(contasReceber);
                    uow.Commit();
                    retorno = true;
                    return retorno;
                }
            }
            catch (Exception ex)
            {
                
                retorno = false;
                return retorno;
            }
        }
    }
}