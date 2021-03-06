﻿using AgiliFood.Models;
using AgiliFood.Models.ModeloVisao;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AgiliFood.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class CardapioViewModelsController : Controller
    {
        public static Guid idPedido;

        #region Propriedades
        private readonly UnitOfWork.UnitOfWork uow;
        #endregion

        #region Construtores
        public CardapioViewModelsController()
        {
            uow = new UnitOfWork.UnitOfWork();
        }

        public CardapioViewModelsController(UnitOfWork.UnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }
        #endregion

        #region Metodos Publicos Actions

        // GET: CardapioViewModels
        public ActionResult Index()
        {
            try
            {
                IEnumerable<CardapioViewModel> lista = Mapper.Map<IEnumerable<CardapioViewModel>>(uow.CardapiorRepositorio.GetTudo());
                return View(lista);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um erro na busca!\n {0}", ex.Message);
                return View();
            }
            finally
            {
                uow.Dispose();
            }
        }

        // GET: CardapioViewModels/Details/5
        public ActionResult Details(Guid? id)
        {
            CardapioViewModel cardapioViewModel = null;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                cardapioViewModel = Mapper.Map<CardapioViewModel>(uow.CardapiorRepositorio.Get(x => x.Id == id));
                return View(cardapioViewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um Erro {0}", ex.Message);
                if (cardapioViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(cardapioViewModel);
            }
            finally
            {
                uow.Dispose();
            }

        }

        // GET: CardapioViewModels/Create
        public ActionResult Create()
        {
            try
            {
                IEnumerable<FornecedorViewModel> lista = Mapper.Map<IEnumerable<FornecedorViewModel>>(uow.FornecedorRepositorio.GetTudo().ToList());
                ViewBag.FornecedorLista = lista;
                return View();
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um Erro Na busca De Cidades\n {0}", ex.Message);
                return View();
            }
        }

        // POST: CardapioViewModels/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CardapioViewModel cardapioViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Cardapio cardapio = new Cardapio();
                    cardapio = Mapper.Map<Cardapio>(cardapioViewModel);
                    cardapio.Id = Guid.NewGuid();
                    cardapio.TimesTamp = DateTime.Now;
                    uow.CardapiorRepositorio.Adcionar(cardapio);
                    uow.Commit();
                    TempData["mensagem"] = string.Format("Registro Cadastrado com Sucesso!");
                    idPedido = cardapio.Id;
                    return Json(new { Resultado = cardapio.Id.ToString() }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    TempData["mensagem"] = string.Format("Ocorreu um erro ao Gravar o Registro!\n {0}", ex.Message);
                }
                finally
                {
                    uow.Dispose();
                }

            }
            return View(cardapioViewModel);
        }

        // GET: CardapioViewModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            CardapioViewModel cardapioViewModel = null;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                cardapioViewModel = Mapper.Map<CardapioViewModel>(uow.CardapiorRepositorio.Get(x => x.Id == id));
                return View(cardapioViewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um Erro {0}", ex.Message);
                if (cardapioViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(cardapioViewModel);
            }
            finally
            {
                uow.Dispose();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Descricao,Cadastro,Id_Fornecedor,NomeFornecedor")] CardapioViewModel cardapioViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Cardapio cardapio = new Cardapio();
                    cardapio = Mapper.Map<Cardapio>(cardapioViewModel);
                    uow.CardapiorRepositorio.Atualizar(cardapio);
                    uow.Commit();
                    TempData["mensagem"] = string.Format("Registro Alterado com Sucesso!");
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["mensagem"] = string.Format("Ocorreu um Erro ao Atualizar o Registro!\n {0}", ex.Message);
                }
                finally
                {
                    uow.Dispose();
                }
            }
            return View(cardapioViewModel);
        }

        // GET: CardapioViewModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            CardapioViewModel cardapioViewModel = null;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                cardapioViewModel = Mapper.Map<CardapioViewModel>(uow.CardapiorRepositorio.Get(x => x.Id == id));
                return View(cardapioViewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um erro !\n {0}", ex.Message);
                if (cardapioViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(cardapioViewModel);
            }
            finally
            {
                uow.Dispose();
            }

        }

        // POST: CardapioViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            try
            {
                Cardapio cardapio = uow.CardapiorRepositorio.Get(x => x.Id == id);
                uow.CardapiorRepositorio.Deletar(cardapio);
                uow.Commit();
                TempData["mensagem"] = string.Format("Registro Excluido Com sucesso");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um Erro ao excluir o Registro!\n {0}", ex.Message);
                return RedirectToAction("Index");
            }
            finally
            {
                uow.Dispose();
            }
        }
        #endregion
    }
}
