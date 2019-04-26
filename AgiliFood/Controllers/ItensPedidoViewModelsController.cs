using AgiliFood.Models;
using AgiliFood.Models.ModeloVisao;
using AutoMapper;
using System;
using System.Net;
using System.Web.Mvc;

namespace AgiliFood.Controllers
{
    public class ItensPedidoViewModelsController : Controller
    {
        #region Propriedades
        private readonly UnitOfWork.UnitOfWork uow;
        #endregion

        #region Construtores
        public ItensPedidoViewModelsController()
        {
            uow = new UnitOfWork.UnitOfWork();
        }

        public ItensPedidoViewModelsController(UnitOfWork.UnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }
        #endregion

        #region Metodos Publicos actions
        // GET: ItensPedidoViewModels
        public ActionResult Index()
        {
            try
            {
                return View(uow.ItensPedidoRepositorio.GetTudo());
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um erro!\n {0}", ex.Message);
                return View();
            }
        }

        // GET: ItensPedidoViewModels/Details/5
        public ActionResult Details(Guid? id)
        {
            ItensPedidoViewModel itensPedidoViewModel = null;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                itensPedidoViewModel = Mapper.Map<ItensPedidoViewModel>(uow.ItensPedidoRepositorio.Get(x => x.Id == id));
                return View(itensPedidoViewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um Erro! \n {0}", ex.Message);
                if (itensPedidoViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(itensPedidoViewModel);
            }
        }

        // GET: ItensPedidoViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItensPedidoViewModels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Quantidade,Total,Id_Pedido")] ItensPedidoViewModel itensPedidoViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ItensPedido itensPedido = new ItensPedido();
                    itensPedidoViewModel.Id = Guid.NewGuid();
                    itensPedido = Mapper.Map<ItensPedido>(itensPedidoViewModel);
                    uow.ItensPedidoRepositorio.Adcionar(itensPedido);
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
            return View(itensPedidoViewModel);
        }

        // GET: ItensPedidoViewModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            ItensPedidoViewModel itensPedidoViewModel = null;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                itensPedidoViewModel = Mapper.Map<ItensPedidoViewModel>(uow.ItensPedidoRepositorio.Get(x => x.Id == id));
                return View(itensPedidoViewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um erro!\n {0}", ex.Message);
                if (itensPedidoViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(itensPedidoViewModel);
            }
        }

        // POST: ItensPedidoViewModels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Quantidade,Total,Id_Pedido")] ItensPedidoViewModel itensPedidoViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ItensPedido itensPedido = new ItensPedido();
                    itensPedido = Mapper.Map<ItensPedido>(itensPedidoViewModel);
                    uow.ItensPedidoRepositorio.Atualizar(itensPedido);
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
            return View(itensPedidoViewModel);
        }

        // GET: ItensPedidoViewModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            ItensPedidoViewModel itensPedidoViewModel = null;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                itensPedidoViewModel = Mapper.Map<ItensPedidoViewModel>(uow.ItensPedidoRepositorio.Get(x => x.Id == id));
                return View(itensPedidoViewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um erro!\n {0}", ex.Message);
                if (itensPedidoViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(itensPedidoViewModel);
            }
        }

        // POST: ItensPedidoViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            try
            {
                ItensPedido itensPedido = new ItensPedido();
                itensPedido = uow.ItensPedidoRepositorio.Get(x => x.Id == id);
                uow.ItensPedidoRepositorio.Deletar(itensPedido);
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
