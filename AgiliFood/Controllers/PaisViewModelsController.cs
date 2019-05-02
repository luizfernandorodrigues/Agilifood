using AgiliFood.Models;
using AgiliFood.Models.ModeloVisao;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using System.Linq;
using PagedList;

namespace AgiliFood.Controllers
{
    /// <summary>
    /// Modificado controller para somente ser acessada por administradores do sistema
    /// </summary>
    /// <remarks>
    /// Autor:  Luiz Fernando
    /// Data:   30/04/2019
    /// </remarks>

    [Authorize(Roles = "Administrador")]
    public class PaisViewModelsController : Controller
    {
        #region propriedades
        private readonly UnitOfWork.UnitOfWork uow;
        #endregion

        #region Construtores
        public PaisViewModelsController()
        {
            uow = new UnitOfWork.UnitOfWork();
        }

        public PaisViewModelsController(UnitOfWork.UnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }
        #endregion

        #region Metodos publicos
        // GET: PaisViewModels
        public ActionResult Index(int? pagina)
        {
            try
            {
                IEnumerable<PaisViewModel> lista = Mapper.Map<IEnumerable<PaisViewModel>>(uow.PaisRepositorio.GetTudo());
                lista = lista.OrderBy(x => x.Nome);
                return View(lista.ToList().ToPagedList(pagina ?? 1, 10));
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um Erro na Busca de Países:\n {0}", ex.Message);
                return View();
            }
            finally
            {
                uow.Dispose();
            }


        }

        // GET: PaisViewModels/Details/5
        public ActionResult Details(Guid? id)
        {
            PaisViewModel paisViewModel = null;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                paisViewModel = Mapper.Map<PaisViewModel>(uow.PaisRepositorio.Get(pais => pais.Id == id));
                return View(paisViewModel);
            }
            catch (Exception ex)
            {
                if (paisViewModel == null)
                {
                    return HttpNotFound();
                }
                ModelState.AddModelError("", string.Format("Ocorreu um Erro na Busca do Pais com Id = {0}\n Erro: {1}", id, ex.Message));
                return View(paisViewModel);
            }
            finally
            {
                uow.Dispose();
            }
        }

        // GET: PaisViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Nome")] PaisViewModel paisViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    paisViewModel.Id = Guid.NewGuid();
                    Pais pais = new Pais();
                    pais = Mapper.Map<Pais>(paisViewModel);
                    pais.TimesTamp = DateTime.Now;
                    uow.PaisRepositorio.Adcionar(pais);
                    uow.Commit();
                    TempData["mensagem"] = string.Format("{0} : Foi Incluido com Sucesso", pais.Nome);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", string.Format("Erro ao Cadastrar Pais:\n {0}", ex.Message));
                    IEnumerable<PaisViewModel> lista = Mapper.Map<IEnumerable<PaisViewModel>>(uow.PaisRepositorio.GetTudo());
                    ViewBag.ListaPais = lista;
                    return View();
                }
                finally
                {
                    uow.Dispose();
                }
            }
            return View(paisViewModel);
        }

        // GET: PaisViewModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaisViewModel paisViewModel = Mapper.Map<PaisViewModel>(uow.PaisRepositorio.Get(pais => pais.Id == id));
            if (paisViewModel == null)
            {
                return HttpNotFound();
            }
            return View(paisViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Nome")] PaisViewModel paisViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Pais pais = new Pais();
                    pais = Mapper.Map<Pais>(paisViewModel);
                    pais.TimesTamp = DateTime.Now;
                    uow.PaisRepositorio.Atualizar(pais);
                    uow.Commit();
                    TempData["mensagem"] = string.Format("{0} : Foi Alterado com Sucesso", pais.Nome);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["mensagem"] = string.Format("Erro ao Alterar Pais:\n {0}", ex.Message);
                    IEnumerable<PaisViewModel> lista = Mapper.Map<IEnumerable<PaisViewModel>>(uow.PaisRepositorio.GetTudo());
                    ViewBag.ListaPais = lista;
                    return View();
                }
                finally
                {
                    uow.Dispose();
                }
            }
            return View(paisViewModel);
        }

        // GET: PaisViewModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            PaisViewModel paisViewModel = null;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                paisViewModel = Mapper.Map<PaisViewModel>(uow.PaisRepositorio.Get(pais => pais.Id == id));
                return View(paisViewModel);
            }
            catch (Exception ex)
            {
                if (paisViewModel == null)
                {
                    return HttpNotFound();
                }
                ModelState.AddModelError("", string.Format("Ocorreu um Erro na Busca do Pais com Id = {0}\n Erro: {1}", id, ex.Message));
                return View(paisViewModel);
            }
            finally
            {
                uow.Dispose();
            }
        }

        // POST: PaisViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            try
            {
                Pais pais = uow.PaisRepositorio.Get(p => p.Id == id);
                uow.PaisRepositorio.Deletar(pais);
                uow.Commit();
                TempData["mensagem"] = string.Format("{0}  : foi deletado com sucesso", pais.Nome);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", string.Format("Não Foi Possivel deletar o pais:\n {0}", ex.Message));
                return View();
            }
            finally
            {
                uow.Dispose();
            }

        }
        #endregion
    }
}
