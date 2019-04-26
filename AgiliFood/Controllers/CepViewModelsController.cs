using AgiliFood.Models;
using AgiliFood.Models.ModeloVisao;
using AutoMapper;
using System;
using System.Net;
using System.Web.Mvc;

namespace AgiliFood.Controllers
{
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
                return View(uow.CepRepositorio.GetTudo());
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
                TempData["mensagem"] = string.Format("Ocorreu um Erro! \n {0}", ex.Message);
                if (cepViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(cepViewModel);
            }
        }

        // GET: CepViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cep,NomeCidade")] CepViewModel cepViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Cep cep = new Cep();
                    cepViewModel.Id = Guid.NewGuid();
                    cep = Mapper.Map<Cep>(cepViewModel);
                    uow.CepRepositorio.Adcionar(cep);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cep,NomeCidade")] CepViewModel cepViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Cep cep = new Cep();
                    cep = Mapper.Map<Cep>(cepViewModel);
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
