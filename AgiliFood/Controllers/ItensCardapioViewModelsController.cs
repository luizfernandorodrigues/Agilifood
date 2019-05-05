using AgiliFood.Models;
using AgiliFood.Models.ModeloVisao;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace AgiliFood.Controllers
{
    public class ItensCardapioViewModelsController : Controller
    {
        #region Propriedades
        private readonly UnitOfWork.UnitOfWork uow;
        #endregion

        #region Construtores
        public ItensCardapioViewModelsController()
        {
            uow = new UnitOfWork.UnitOfWork();
        }

        public ItensCardapioViewModelsController(UnitOfWork.UnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }
        #endregion

        #region Metodos Publicos Actions
        // GET: ItensCardapioViewModels
        public ActionResult ListarItens(Guid? idPedido)
        {
            if (idPedido == null)
            {
                idPedido = CardapioViewModelsController.idPedido;
            }
            try
            {
                IEnumerable<ItensCardapioViewModel> lista =
                                Mapper.Map<IEnumerable<ItensCardapioViewModel>>
                    (uow.ItensCardapioRepositorio.GetTudo(x => x.Id_Cardapio == idPedido));

                IEnumerable<ProdutoViewModel> listaProdutos =
                    Mapper.Map<IEnumerable<ProdutoViewModel>>(uow.ProdutoRepositorio.GetTudo());
                ViewBag.ProdutoLista = listaProdutos;
                ViewBag.Pedido = idPedido;

                return PartialView(lista);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um erro!\n {0}", ex.Message);
                return View();
            }
            finally
            {
                uow.Dispose();
            }

        }

        // GET: ItensCardapioViewModels/Details/5
        public ActionResult Details(Guid? id)
        {
            ItensCardapioViewModel itensCardapioViewModel = null;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                itensCardapioViewModel = Mapper.Map<ItensCardapioViewModel>(uow.ItensCardapioRepositorio.Get(x => x.Id == id));
                return View(itensCardapioViewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um Erro! \n {0}", ex.Message);
                if (itensCardapioViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(itensCardapioViewModel);
            }
            finally
            {
                uow.Dispose();
            }
        }
        // POST: ItensCardapioViewModels/Create
        public ActionResult Create(Guid id_produto, Guid id_cardapio, int quantidade)
        {
            try
            {
                ItensCardapio itensCardapio = new ItensCardapio()
                {
                    Id = Guid.NewGuid(),
                    Id_Produto = id_produto,
                    Id_Cardapio = id_cardapio,
                    Quantidade = quantidade
                };
                uow.ItensCardapioRepositorio.Adcionar(itensCardapio);
                uow.Commit();
                TempData["mensagem"] = string.Format("Registro Cadastrado com Sucesso!");
                return Json(new { Resultado = itensCardapio.Id.ToString()}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Não Foi Possivel Gravar o Registro!\n {0}", ex.Message);
                return View();
            }
            finally
            {
                uow.Dispose();
            }
        }


        // GET: ItensCardapioViewModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            ItensCardapioViewModel itensCardapioViewModel = null;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                itensCardapioViewModel = Mapper.Map<ItensCardapioViewModel>(uow.ItensCardapioRepositorio.Get(x => x.Id == id));
                return View(itensCardapioViewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um erro!\n {0}", ex.Message);
                if (itensCardapioViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(itensCardapioViewModel);
            }
            finally
            {
                uow.Dispose();
            }
        }

        // POST: ItensCardapioViewModels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Valor,Id_Produto,NomeProduto,Id_Cardapio,DescricaoCardapio")] ItensCardapioViewModel itensCardapioViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ItensCardapio itensCardapio = new ItensCardapio();
                    itensCardapio = Mapper.Map<ItensCardapio>(itensCardapioViewModel);
                    uow.ItensCardapioRepositorio.Atualizar(itensCardapio);
                    uow.Commit();
                    TempData["mensagem"] = string.Format("Registro Alterado Com Sucesso!");
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["mensagem"] = string.Format("Ocorreu ao Alterar o Registro!\n {0}", ex.Message);
                    return RedirectToAction("Index");
                }
                finally
                {
                    uow.Dispose();
                }
            }
            return View(itensCardapioViewModel);
        }

        // GET: ItensCardapioViewModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            ItensCardapioViewModel itensCardapioViewModel = null;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                itensCardapioViewModel = Mapper.Map<ItensCardapioViewModel>(uow.ItensCardapioRepositorio.Get(x => x.Id == id));
                return View(itensCardapioViewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um erro!\n {0}", ex.Message);
                if (itensCardapioViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(itensCardapioViewModel);
            }
            finally
            {
                uow.Dispose();
            }
        }

        // POST: ItensCardapioViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            try
            {
                ItensCardapio itensCardapio = new ItensCardapio();
                itensCardapio = uow.ItensCardapioRepositorio.Get(x => x.Id == id);
                uow.ItensCardapioRepositorio.Deletar(itensCardapio);
                uow.Commit();
                TempData["mensagem"] = string.Format("Registro Excluido com sucesso");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um Erro ao excluir o registro!\n {0}", ex.Message);
                return RedirectToAction("Index");
            }
            finally
            {
                uow.Dispose();
            }
            #endregion
        }
    }
}