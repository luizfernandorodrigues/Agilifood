using AgiliFood.Models;
using AgiliFood.Models.ModeloVisao;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AgiliFood.Controllers
{
    [Authorize]
    public class CepViewModelsController : Controller
    {
        #region Propriedades
        private readonly UnitOfWork.UnitOfWork uow;
        #endregion

        #region Construtores
        public CepViewModelsController()
        {
            uow = new UnitOfWork.UnitOfWork();
        }

        public CepViewModelsController(UnitOfWork.UnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }
        #endregion

        #region Metodos Publicos Actions
        // GET: CepViewModels
        public ActionResult Index()
        {
            try
            {
                IEnumerable<CepViewModel> lista = Mapper.Map<IEnumerable<CepViewModel>>(uow.CepRepositorio.GetTudo().ToList());
                return View(lista);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um erro!\n {0}", ex.Message);
                return View();
            }
        }

        // GET: CepViewModels/Details/5
        public ActionResult Details(Guid? id)
        {
            CepViewModel cepViewModel = null;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                cepViewModel = Mapper.Map<CepViewModel>(uow.CepRepositorio.Get(x => x.Id == id));
                return View(cepViewModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", string.Format("Ocorreu um Erro! \n {0}", ex.Message));
                if (cepViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(cepViewModel);
            }
            finally
            {
                uow.Dispose();
            }
        }

        // GET: CepViewModels/Create
        public ActionResult Create()
        {
            try
            {
                IEnumerable<CidadeViewModel> lista = Mapper.Map<IEnumerable<CidadeViewModel>>(uow.CidadeRepositorio.GetTudo().ToList());
                ViewBag.CidadeLista = lista;
                return View();
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um Erro Na busca De Cidades\n {0}", ex.Message);
                return View();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,_Cep,Id_Cidade")] CepViewModel cepViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Cep cep = new Cep();
                    cep = Mapper.Map<Cep>(cepViewModel);
                    cep.Id = Guid.NewGuid();
                    cep.TimesTamp = DateTime.Now;
                    uow.CepRepositorio.Adcionar(cep);
                    uow.Commit();
                    TempData["mensagem"] = string.Format("Registro Cadastrado com Sucesso!");
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", string.Format("Não Foi Possivel Gravar o Registro!\n {0}", ex.Message));
                    return View();
                }
            }
            return View(cepViewModel);
        }

        // GET: CepViewModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            CepViewModel cepViewModel = null;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                cepViewModel = Mapper.Map<CepViewModel>(uow.CepRepositorio.Get(x => x.Id == id));
                IEnumerable<CidadeViewModel> lista = Mapper.Map<IEnumerable<CidadeViewModel>>(uow.CidadeRepositorio.GetTudo().ToList());
                ViewBag.CidadeLista = lista;
                return View(cepViewModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", string.Format("Ocorreu um erro!\n {0}", ex.Message));
                if (cepViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(cepViewModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,_Cep,Id_Cidade")] CepViewModel cepViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Cep cep = new Cep();
                    cep = Mapper.Map<Cep>(cepViewModel);
                    cep.TimesTamp = DateTime.Now;
                    uow.CepRepositorio.Atualizar(cep);
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
            return View(cepViewModel);
        }

        // GET: CepViewModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            CepViewModel cepViewModel = null;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                cepViewModel = Mapper.Map<CepViewModel>(uow.CepRepositorio.Get(x => x.Id == id));
                return View(cepViewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um erro!\n {0}", ex.Message);
                if (cepViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(cepViewModel);
            }
        }

        // POST: CepViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            try
            {
                Cep cep = new Cep();
                cep = uow.CepRepositorio.Get(x => x.Id == id);
                uow.CepRepositorio.Deletar(cep);
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
