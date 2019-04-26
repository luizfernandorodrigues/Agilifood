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
    public class FuncionarioViewModelsController : Controller
    {
        #region Propriedades
        private readonly UnitOfWork.UnitOfWork uow;
        #endregion

        #region Construtores
        public FuncionarioViewModelsController()
        {
            uow = new UnitOfWork.UnitOfWork();
        }

        public FuncionarioViewModelsController(UnitOfWork.UnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }
        #endregion

        #region Metodos Publicos Actions
        // GET: FuncionarioViewModels
        public ActionResult Index()
        {
            try
            {
                return View(uow.FuncionarioRepositorio.GetTudo());
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um erro!\n {0}", ex.Message);
                return View();
            }
        }

        // GET: FuncionarioViewModels/Details/5
        public ActionResult Details(Guid? id)
        {
            FuncionarioViewModel funcionarioViewModel = null;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                funcionarioViewModel = Mapper.Map<FuncionarioViewModel>(uow.FuncionarioRepositorio.Get(x => x.Id == id));
                return View(funcionarioViewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um Erro! \n {0}", ex.Message);
                if (funcionarioViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(funcionarioViewModel);
            }
        }

        // GET: FuncionarioViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FuncionarioViewModels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Endereco,NumeroEndereco,Bairro,Fone,Cpf,Id_Cep,Cep")] FuncionarioViewModel funcionarioViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Funcionario funcionario = new Funcionario();
                    funcionarioViewModel.Id = Guid.NewGuid();
                    funcionario = Mapper.Map<Funcionario>(funcionarioViewModel);
                    uow.FuncionarioRepositorio.Adcionar(funcionario);
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
            return View(funcionarioViewModel);
        }

        // GET: FuncionarioViewModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            FuncionarioViewModel funcionarioViewModel = null;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                funcionarioViewModel = Mapper.Map<FuncionarioViewModel>(uow.FuncionarioRepositorio.Get(x => x.Id == id));
                return View(funcionarioViewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um erro!\n {0}", ex.Message);
                if (funcionarioViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(funcionarioViewModel);
            }
        }

        // POST: FuncionarioViewModels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Endereco,NumeroEndereco,Bairro,Fone,Cpf,Id_Cep,Cep")] FuncionarioViewModel funcionarioViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Funcionario funcionario = new Funcionario();
                    funcionario = Mapper.Map<Funcionario>(funcionarioViewModel);
                    uow.FuncionarioRepositorio.Atualizar(funcionario);
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
            return View(funcionarioViewModel);
        }

        // GET: FuncionarioViewModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            FuncionarioViewModel funcionarioViewModel = null;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                funcionarioViewModel = Mapper.Map<FuncionarioViewModel>(uow.FuncionarioRepositorio.Get(x => x.Id == id));
                return View(funcionarioViewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um erro!\n {0}", ex.Message);
                if (funcionarioViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(funcionarioViewModel);
            }
        }

        // POST: FuncionarioViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            try
            {
                Funcionario funcionario = new Funcionario();
                funcionario = uow.FuncionarioRepositorio.Get(x => x.Id == id);
                uow.FuncionarioRepositorio.Deletar(funcionario);
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
