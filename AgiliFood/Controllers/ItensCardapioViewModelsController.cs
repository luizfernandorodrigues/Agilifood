using AgiliFood.Models;
using AgiliFood.Models.ModeloVisao;
using AutoMapper;
using System;
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
        public ActionResult Index()
        {
            try
            {
                return View(uow.ItensCardapioRepositorio.GetTudo());
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um erro!\n {0}", ex.Message);
                return View();
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
        }

        // GET: ItensCardapioViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItensCardapioViewModels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Valor,Id_Produto,NomeProduto,Id_Cardapio,DescricaoCardapio")] ItensCardapioViewModel itensCardapioViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ItensCardapio itensCardapio = new ItensCardapio();
                    itensCardapioViewModel.Id = Guid.NewGuid();
                    itensCardapio = Mapper.Map<ItensCardapio>(itensCardapioViewModel);
                    uow.ItensCardapioRepositorio.Adcionar(itensCardapio);
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
            return View(itensCardapioViewModel);
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
            #endregion
        }
    }
}