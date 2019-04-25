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
    public class PedidoViewModelsController : Controller
    {
        #region Propriedades
        private readonly UnitOfWork.UnitOfWork uow;
        #endregion

        #region Construtores
        public PedidoViewModelsController()
        {
            uow = new UnitOfWork.UnitOfWork();
        }

        public PedidoViewModelsController(UnitOfWork.UnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }
        #endregion

        #region Metodos Publicos Actions

        // GET: PedidoViewModels
        public ActionResult Index()
        {
            try
            {
                return View(uow.PedidoRepositorio.GetTudo());
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um erro!\n {0}", ex.Message);
                return View();
            };
        }

        // GET: PedidoViewModels/Details/5
        public ActionResult Details(Guid? id)
        {
            PedidoViewModel pedidoViewModel = null;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                pedidoViewModel = Mapper.Map<PedidoViewModel>(uow.PedidoRepositorio.Get(x => x.Id == id));
                return View(pedidoViewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um Erro! \n {0}", ex.Message);
                if (pedidoViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(pedidoViewModel);
            }
        }

        // GET: PedidoViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PedidoViewModels/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Emissao,Total,Id_Funcionario,NomeFuncionario,Id_Cardapio,DescricaoCardapio")] PedidoViewModel pedidoViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Pedido pedido = new Pedido();
                    pedidoViewModel.Id = Guid.NewGuid();
                    pedido = Mapper.Map<Pedido>(pedidoViewModel);
                    uow.PedidoRepositorio.Adcionar(pedido);
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
            return View(pedidoViewModel);
        }

        // GET: PedidoViewModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            PedidoViewModel pedidoViewModel = null;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                pedidoViewModel = Mapper.Map<PedidoViewModel>(uow.PedidoRepositorio.Get(x => x.Id == id));
                return View(pedidoViewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um erro!\n {0}", ex.Message);
                if (pedidoViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(pedidoViewModel);
            }
        }

        // POST: PedidoViewModels/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Emissao,Total,Id_Funcionario,NomeFuncionario,Id_Cardapio,DescricaoCardapio")] PedidoViewModel pedidoViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Pedido pedido = new Pedido();
                    pedido = Mapper.Map<Pedido>(pedidoViewModel);
                    uow.PedidoRepositorio.Atualizar(pedido);
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
            return View(pedidoViewModel);
        }

        // GET: PedidoViewModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            PedidoViewModel pedidoViewModel = null;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                pedidoViewModel = Mapper.Map<PedidoViewModel>(uow.PedidoRepositorio.Get(x => x.Id == id));
                return View(pedidoViewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um erro!\n {0}", ex.Message);
                if (pedidoViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(pedidoViewModel);
            }
        }

        // POST: PedidoViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            try
            {
                Pedido pedido = new Pedido();
                pedido = uow.PedidoRepositorio.Get(x => x.Id == id);
                uow.PedidoRepositorio.Deletar(pedido);
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
