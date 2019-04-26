using System;
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
    public class FornecedorViewModelsController : Controller
    {
        #region Propriedades
        private readonly UnitOfWork.UnitOfWork uow;
        #endregion

        #region Construtores
        public FornecedorViewModelsController()
        {
            uow = new UnitOfWork.UnitOfWork();
        }

        public FornecedorViewModelsController(UnitOfWork.UnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }
        #endregion

        #region Metodos Publicos Actions
        // GET: FornecedorViewModels
        public ActionResult Index()
        {
            try
            {
                return View(uow.FornecedorRepositorio.GetTudo());
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um erro!\n {0}", ex.Message);
                return View();
            }
        }

        // GET: FornecedorViewModels/Details/5
        public ActionResult Details(Guid? id)
        {
            FornecedorViewModel fornecedorViewModel = null;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                fornecedorViewModel = Mapper.Map<FornecedorViewModel>(uow.FornecedorRepositorio.Get(x => x.Id == id));
                return View(fornecedorViewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um Erro! \n {0}", ex.Message);
                if (fornecedorViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(fornecedorViewModel);
            }
        }

        // GET: FornecedorViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FornecedorViewModels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RazaoSocial,Fantasia,Logradouro,NumeroEndereco,Bairro,Fone,Cnpj,Email,Cadastro,Id_Cep,Cep")] FornecedorViewModel fornecedorViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Fornecedor fornecedor = new Fornecedor();
                    fornecedorViewModel.Id = Guid.NewGuid();
                    fornecedor = Mapper.Map<Fornecedor>(fornecedorViewModel);
                    uow.FornecedorRepositorio.Adcionar(fornecedor);
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
            return View(fornecedorViewModel);
        }

        // GET: FornecedorViewModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            FornecedorViewModel fornecedorViewModel = null;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                fornecedorViewModel = Mapper.Map<FornecedorViewModel>(uow.FornecedorRepositorio.Get(x => x.Id == id));
                return View(fornecedorViewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um erro!\n {0}", ex.Message);
                if (fornecedorViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(fornecedorViewModel);
            }
        }

        // POST: FornecedorViewModels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RazaoSocial,Fantasia,Logradouro,NumeroEndereco,Bairro,Fone,Cnpj,Email,Cadastro,Id_Cep,Cep")] FornecedorViewModel fornecedorViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Fornecedor fornecedor = new Fornecedor();
                    fornecedor = Mapper.Map<Fornecedor>(fornecedorViewModel);
                    uow.FornecedorRepositorio.Atualizar(fornecedor);
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
            return View(fornecedorViewModel);
        }

        // GET: FornecedorViewModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            FornecedorViewModel fornecedorViewModel = null;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                fornecedorViewModel = Mapper.Map<FornecedorViewModel>(uow.FornecedorRepositorio.Get(x => x.Id == id));
                return View(fornecedorViewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um erro!\n {0}", ex.Message);
                if (fornecedorViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(fornecedorViewModel);
            }
        }

        // POST: FornecedorViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            try
            {
                Fornecedor fornecedor = new Fornecedor();
                fornecedor = uow.FornecedorRepositorio.Get(x => x.Id == id);
                uow.FornecedorRepositorio.Deletar(fornecedor);
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
