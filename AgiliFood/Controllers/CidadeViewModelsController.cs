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
    [Authorize(Roles = "Administrador")]
    public class CidadeViewModelsController : Controller
    {

        #region Metodos Publicos Actions
        // GET: CidadeViewModels
        public ActionResult Index()
        {
            IEnumerable<CidadeViewModel> lista = null;
            using (UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    lista = Mapper.Map<IEnumerable<CidadeViewModel>>(uow.CidadeRepositorio.GetTudo().ToList());
                }
                catch (Exception ex)
                {
                    TempData["mensagem"] = string.Format("Ocorreu um erro na busca!\n {0}", ex.Message);
                    return View();
                }
                finally
                {
                    uow.Dispose();
                }
            }
            return View(lista);

        }

        // GET: CidadeViewModels/Details/5
        public ActionResult Details(Guid? id)
        {
            CidadeViewModel cidadeViewModel = null;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork())
            {
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
                finally
                {
                    uow.Dispose();
                }
            }
        }

        // GET: CidadeViewModels/Create
        public ActionResult Create()
        {
            using (UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    List<EstadoViewModel> lista = Mapper.Map<List<EstadoViewModel>>(uow.EstadoRepositorio.GetTudo().ToList());
                    ViewBag.EstadoLista = lista;
                    return View();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", string.Format("Ocorreu um Erro na Busca dos Estados:\n {0}", ex.Message));
                    return View();
                }
                finally
                {
                    uow.Dispose();
                }
            }
        }

        // POST: CidadeViewModels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Id_Estado")] CidadeViewModel cidadeViewModel)
        {
            if (ModelState.IsValid)
            {
                using (UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork())
                {
                    try
                    {
                        Cidade cidade = new Cidade();
                        cidade = Mapper.Map<Cidade>(cidadeViewModel);
                        cidade.Id = Guid.NewGuid();
                        cidade.TimesTamp = DateTime.Now;
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
                    finally
                    {
                        uow.Dispose();
                    }
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

            using (UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    cidadeViewModel = Mapper.Map<CidadeViewModel>(uow.CidadeRepositorio.Get(x => x.Id == id));
                    List<EstadoViewModel> lista = Mapper.Map<List<EstadoViewModel>>(uow.EstadoRepositorio.GetTudo().ToList());
                    ViewBag.EstadoLista = lista;
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
                finally
                {
                    uow.Dispose();
                }
            }
        }

        // POST: CidadeViewModels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Id_Estado")] CidadeViewModel cidadeViewModel)
        {
            if (ModelState.IsValid)
            {
                using (UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork())
                {
                    try
                    {
                        Cidade cidade = new Cidade();
                        cidade = Mapper.Map<Cidade>(cidadeViewModel);
                        cidade.TimesTamp = DateTime.Now;
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
                    finally
                    {
                        uow.Dispose();
                    }
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

            using (UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork())
            {
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
                finally
                {
                    uow.Dispose();
                }
            }
        }

        // POST: CidadeViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            using (UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork())
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
                finally
                {
                    uow.Dispose();
                }
            }

        }
        #endregion
    }
}
