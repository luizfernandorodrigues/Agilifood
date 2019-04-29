using AgiliFood.Models;
using AgiliFood.Models.ModeloVisao;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace AgiliFood.Controllers
{
    public class EstadoViewModelsController : Controller
    {
        #region Propriedades
        private readonly UnitOfWork.UnitOfWork uow;
        #endregion

        #region Construtores
        public EstadoViewModelsController()
        {
            uow = new UnitOfWork.UnitOfWork();
        }

        public EstadoViewModelsController(UnitOfWork.UnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }
        #endregion

        #region Metodos Publicos Actions
        // GET: EstadoViewModels
        public ActionResult Index()
        {
            try
            {
                IEnumerable<PaisViewModel> lista = Mapper.Map<IEnumerable<PaisViewModel>>(uow.EstadoRepositorio.GetTudo());
                return View(lista);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um Erro na Busca dos Estados:\n {0}", ex.Message);
                return View();
            }
        }

        // GET: EstadoViewModels/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoViewModel estadoViewModel = Mapper.Map<EstadoViewModel>(uow.EstadoRepositorio.Get(x => x.Id == id));
            if (estadoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(estadoViewModel);
        }

        // GET: EstadoViewModels/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.ListaPais = new SelectList(uow.PaisRepositorio.GetTudo(), "id", "nome");
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um Erro ao Buscar os Paises! \n {0}", ex.Message);
            }


            return View();
        }

        // POST: EstadoViewModels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Sigla,NomePais")] EstadoViewModel estadoViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    estadoViewModel.Id = Guid.NewGuid();
                    Estado estado = new Estado();
                    estado = Mapper.Map<Estado>(estadoViewModel);
                    uow.EstadoRepositorio.Adcionar(estado);
                    uow.Commit();
                    TempData["mensagem"] = string.Format("Estado {0} cadastrado com Sucesso!", estado.Nome);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["mensagem"] = string.Format("Não foi possivel cadastrar o estado: {0}: \n {1}", estadoViewModel.Nome, ex.Message);
                    return View(estadoViewModel);
                }
            }

            return View(estadoViewModel);
        }

        // GET: EstadoViewModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoViewModel estadoViewModel = Mapper.Map<EstadoViewModel>(uow.EstadoRepositorio.Get(x => x.Id == id));
            if (estadoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(estadoViewModel);
        }

        // POST: EstadoViewModels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Sigla,NomePais")] EstadoViewModel estadoViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Estado estado = new Estado();
                    estado = Mapper.Map<Estado>(estadoViewModel);
                    estado.TimesTamp = DateTime.Now;
                    uow.EstadoRepositorio.Atualizar(estado);
                    uow.Commit();
                    TempData["mensagem"] = string.Format("Registro Alterado com Sucesso");
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["mensagem"] = string.Format("Não Foi Possivel Alterar o Registro {0}: \n {1}", estadoViewModel.Nome, ex.Message);
                    return View(estadoViewModel);
                }
            }
            return View(estadoViewModel);
        }

        // GET: EstadoViewModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            EstadoViewModel estadoViewModel = null;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                estadoViewModel = Mapper.Map<EstadoViewModel>(uow.EstadoRepositorio.Get(x => x.Id == id));
                return View(estadoViewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um Erro:\n {0}", ex.Message);
                if (estadoViewModel == null)
                {
                    return HttpNotFound();
                }
            }
            return View(estadoViewModel);
        }

        // POST: EstadoViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Estado estado = null;
            try
            {
                estado = uow.EstadoRepositorio.Get(x => x.Id == id);
                uow.EstadoRepositorio.Deletar(estado);
                uow.Commit();
                TempData["mensagem"] = string.Format("O Registro {0} Foi excluido com Sucesso!", estado.Nome);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um Erro ao Excluir o registro {0}: \n {1}", estado.Nome, ex.Message);
                return RedirectToAction("Index");
            }
        }
        #endregion
    }
}
