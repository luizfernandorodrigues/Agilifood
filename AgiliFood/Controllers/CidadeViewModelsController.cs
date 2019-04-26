using AgiliFood.Models;
using AgiliFood.Models.ModeloVisao;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace AgiliFood.Controllers
{
    public class CidadeViewModelsController : Controller
    {
        #region Propriedades
        private readonly UnitOfWork.UnitOfWork uow;
        #endregion

        #region Construtores
        public CidadeViewModelsController()
        {
            uow = new UnitOfWork.UnitOfWork();
        }
        public CidadeViewModelsController(UnitOfWork.UnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }
        #endregion;

        #region Metodos Publicos Actions
        // GET: CidadeViewModels
        public ActionResult Index()
        {
            try
            {
                IEnumerable<CidadeViewModel> lista = Mapper.Map<IEnumerable<CidadeViewModel>>(uow.CidadeRepositorio.GetTudo());
                return View(lista);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um erro na busca!\n {0}", ex.Message);
                return View();
            }
        }

        // GET: CidadeViewModels/Details/5
        public ActionResult Details(Guid? id)
        {
            CidadeViewModel cidadeViewModel = null;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                cidadeViewModel = Mapper.Map<CidadeViewModel>(uow.CidadeRepositorio.Get(x => x.Id == id));
                return View(cidadeViewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um Erro! \n {0}", ex.Message);
                if (cidadeViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(cidadeViewModel);
            }
        }

        // GET: CidadeViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CidadeViewModels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,NomeEstado")] CidadeViewModel cidadeViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Cidade cidade = new Cidade();
                    cidadeViewModel.Id = Guid.NewGuid();
                    cidade = Mapper.Map<Cidade>(cidadeViewModel);
                    uow.CidadeRepositorio.Adcionar(cidade);
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
            return View(cidadeViewModel);
        }

        // GET: CidadeViewModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            CidadeViewModel cidadeViewModel = null;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                cidadeViewModel = Mapper.Map<CidadeViewModel>(uow.CidadeRepositorio.Get(x => x.Id == id));
                return View(cidadeViewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um erro!\n {0}", ex.Message);
                if (cidadeViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(cidadeViewModel);
            }
        }

        // POST: CidadeViewModels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,NomeEstado")] CidadeViewModel cidadeViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Cidade cidade = new Cidade();
                    cidade = Mapper.Map<Cidade>(cidadeViewModel);
                    uow.CidadeRepositorio.Atualizar(cidade);
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
            return View(cidadeViewModel);
        }

        // GET: CidadeViewModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            CidadeViewModel cidadeViewModel = null;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                cidadeViewModel = Mapper.Map<CidadeViewModel>(uow.CidadeRepositorio.Get(x => x.Id == id));
                return View(cidadeViewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um erro!\n {0}", ex.Message);
                if (cidadeViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(cidadeViewModel);
            }
        }

        // POST: CidadeViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            try
            {
                Cidade cidade = new Cidade();
                cidade = uow.CidadeRepositorio.Get(x => x.Id == id);
                uow.CidadeRepositorio.Deletar(cidade);
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
