﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AgiliFood.Models;
using AgiliFood.Models.ModeloVisao;
using AutoMapper;

namespace AgiliFood.Controllers
{
    public class ProdutoViewModelsController : Controller
    {
        #region Propriedades
        private readonly UnitOfWork.UnitOfWork uow;
        #endregion

        #region Construtores
        public ProdutoViewModelsController()
        {
            uow = new UnitOfWork.UnitOfWork();
        }

        public ProdutoViewModelsController(UnitOfWork.UnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }
        #endregion

        #region Metodos Publicos Actions
        // GET: ProdutoViewModels
        public ActionResult Index()
        {
            try
            {
                return View(uow.ProdutoRepositorio.GetTudo());
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um erro!\n {0}", ex.Message);
                return View();
            }
        }

        // GET: ProdutoViewModels/Details/5
        public ActionResult Details(Guid? id)
        {
            ProdutoViewModel produtoViewModel = null;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                produtoViewModel = Mapper.Map<ProdutoViewModel>(uow.ProdutoRepositorio.Get(x => x.Id == id));
                return View(produtoViewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um Erro! \n {0}", ex.Message);
                if (produtoViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(produtoViewModel);
            }
        }

        // GET: ProdutoViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProdutoViewModels/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Descricao,Tipo,Imagem,Preco")] ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Produto produto = new Produto();
                    produtoViewModel.Id = Guid.NewGuid();
                    produto = Mapper.Map<Produto>(produtoViewModel);
                    uow.ProdutoRepositorio.Adcionar(produto);
                    uow.Commit();
                    TempData["mensagem"] = string.Format("Registro Cadastrado com Sucesso!");
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["mensagem"] = string.Format("Não Foi Possivel Gravar o Registro!\n {0}", ex.Message);
                    return View();
                }
            }
            return View(produtoViewModel);
        }

        // GET: ProdutoViewModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            ProdutoViewModel produtoViewModel = null;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                produtoViewModel = Mapper.Map<ProdutoViewModel>(uow.ProdutoRepositorio.Get(x => x.Id == id));
                return View(produtoViewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um erro!\n {0}", ex.Message);
                if (produtoViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(produtoViewModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Descricao,Tipo,Imagem,Preco")] ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Produto produto = new Produto();
                    produto = Mapper.Map<Produto>(produtoViewModel);
                    uow.ProdutoRepositorio.Atualizar(produto);
                    uow.Commit();
                    TempData["mensagem"] = string.Format("Registro Alterado Com Sucesso!");
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["mensagem"] = string.Format("Ocorreu ao Alterar o Registro!\n {0}", ex.Message);
                    return RedirectToAction("Index");
                }
            }
            return View(produtoViewModel);
        }

        // GET: ProdutoViewModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            ProdutoViewModel produtoViewModel = null;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                produtoViewModel = Mapper.Map<ProdutoViewModel>(uow.ProdutoRepositorio.Get(x => x.Id == id));
                return View(produtoViewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um erro!\n {0}", ex.Message);
                if (produtoViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(produtoViewModel);
            }
        }

        // POST: ProdutoViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            try
            {
                Produto produto = new Produto();
                produto = uow.ProdutoRepositorio.Get(x => x.Id == id);
                uow.ProdutoRepositorio.Deletar(produto);
                uow.Commit();
                TempData["mensagem"] = string.Format("Registro Excluido com sucesso");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um Erro ao excluir o registro!\n {0}", ex.Message);
                return RedirectToAction("Index");
            }
        }
#endregion
    }
}
