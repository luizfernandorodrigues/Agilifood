using AgiliFood.Models;
using AgiliFood.Models.ModeloVisao;
using AutoMapper;
using System;
using System.Net;
using System.Web.Mvc;

namespace AgiliFood.Controllers
{
    public class ContasReceberViewModelsController : Controller
    {
        #region Propriedades
        private readonly UnitOfWork.UnitOfWork uow;
        #endregion

        #region Construtores
        public ContasReceberViewModelsController()
        {
            uow = new UnitOfWork.UnitOfWork();
        }

        public ContasReceberViewModelsController(UnitOfWork.UnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }
        #endregion

        #region Metodos Publicos Actions
        // GET: ContasReceberViewModels
        public ActionResult Index()
        {
            try
            {
                return View(uow.ContasReceberRepositorio.GetTudo());
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um erro!\n {0}", ex.Message);
                return View();
            }
        }

        // GET: ContasReceberViewModels/Details/5
        public ActionResult Details(Guid? id)
        {
            ContasReceberViewModel contasReceberViewModel = null;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                contasReceberViewModel = Mapper.Map<ContasReceberViewModel>(uow.ContasReceberRepositorio.Get(x => x.Id == id));
                return View(contasReceberViewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um Erro! \n {0}", ex.Message);
                if (contasReceberViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(contasReceberViewModel);
            }
        }

        // GET: ContasReceberViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContasReceberViewModels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Emissao,Valor,ValorPago,NomeFuncionario,NumeroPedido,NomeFornecedor")] ContasReceberViewModel contasReceberViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ContasReceber contasReceber = new ContasReceber();
                    contasReceberViewModel.Id = Guid.NewGuid();
                    contasReceber = Mapper.Map<ContasReceber>(contasReceberViewModel);
                    uow.ContasReceberRepositorio.Adcionar(contasReceber);
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
            return View(contasReceberViewModel);
        }

        // GET: ContasReceberViewModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            ContasReceberViewModel contasReceberViewModel = null;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                contasReceberViewModel = Mapper.Map<ContasReceberViewModel>(uow.ContasReceberRepositorio.Get(x => x.Id == id));
                return View(contasReceberViewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um erro!\n {0}", ex.Message);
                if (contasReceberViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(contasReceberViewModel);
            }
        }

        // POST: ContasReceberViewModels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Emissao,Valor,ValorPago,NomeFuncionario,NumeroPedido,NomeFornecedor")] ContasReceberViewModel contasReceberViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ContasReceber contasReceber = new ContasReceber();
                    contasReceber = Mapper.Map<ContasReceber>(contasReceberViewModel);
                    uow.ContasReceberRepositorio.Atualizar(contasReceber);
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
            return View(contasReceberViewModel);
        }

        // GET: ContasReceberViewModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            ContasReceberViewModel contasReceberViewModel = null;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                contasReceberViewModel = Mapper.Map<ContasReceberViewModel>(uow.ContasReceberRepositorio.Get(x => x.Id == id));
                return View(contasReceberViewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um erro!\n {0}", ex.Message);
                if (contasReceberViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(contasReceberViewModel);
            }
        }

        // POST: ContasReceberViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            try
            {
                ContasReceber contasReceber = new ContasReceber();
                contasReceber = uow.ContasReceberRepositorio.Get(x => x.Id == id);
                uow.ContasReceberRepositorio.Deletar(contasReceber);
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
