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
    public class FornecedorViewModelsController : Controller
    {
        #region Propriedades
        private readonly UnitOfWork.UnitOfWork uow;
        #endregion

        #region Construtores
        public FornecedorViewModelsController()
        {
            uow = new UnitOfWork.UnitOfWork();
        }

        public FornecedorViewModelsController(UnitOfWork.UnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }
        #endregion

        #region Metodos Publicos Actions
        // GET: FornecedorViewModels
        public ActionResult Index()
        {

            using (UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    IEnumerable<FornecedorViewModel> lista = Mapper.Map<IEnumerable<FornecedorViewModel>>(uow.FornecedorRepositorio.GetTudo().ToList());
                    return View(lista);
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
            
        }

        // GET: FornecedorViewModels/Details/5
        public ActionResult Details(Guid? id)
        {
            FornecedorViewModel fornecedorViewModel = null;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                fornecedorViewModel = Mapper.Map<FornecedorViewModel>(uow.FornecedorRepositorio.Get(x => x.Id == id));
                return View(fornecedorViewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um Erro! \n {0}", ex.Message);
                if (fornecedorViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(fornecedorViewModel);
            }
            finally
            {
                uow.Dispose();
            }
        }

        // GET: FornecedorViewModels/Create
        public ActionResult Create()
        {
            try
            {
                IEnumerable<CepViewModel> lista = Mapper.Map<IEnumerable<CepViewModel>>(uow.CepRepositorio.GetTudo());
                ViewBag.CepLista = lista;
                return View();
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um Erro {0}", ex.Message);
            }
            finally
            {
                uow.Dispose();
            }
            return View();
        }

        // POST: FornecedorViewModels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RazaoSocial,Fantasia,Logradouro,NumeroEndereco,Bairro,Fone,Cnpj,Email,Cadastro,Id_Cep")] FornecedorViewModel fornecedorViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Fornecedor fornecedor = new Fornecedor();
                    fornecedor = Mapper.Map<Fornecedor>(fornecedorViewModel);
                    fornecedor.Id = Guid.NewGuid();
                    fornecedor.TimesTamp = DateTime.Now;
                    uow.FornecedorRepositorio.Adcionar(fornecedor);
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
            return View(fornecedorViewModel);
        }

        // GET: FornecedorViewModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            FornecedorViewModel fornecedorViewModel = null;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                fornecedorViewModel = Mapper.Map<FornecedorViewModel>(uow.FornecedorRepositorio.Get(x => x.Id == id));
                IEnumerable<CepViewModel> lista = Mapper.Map<IEnumerable<CepViewModel>>(uow.CepRepositorio.GetTudo());
                ViewBag.CepLista = lista;
                return View(fornecedorViewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um erro!\n {0}", ex.Message);
                if (fornecedorViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(fornecedorViewModel);
            }
            finally
            {
                uow.Dispose();
            }
        }

        // POST: FornecedorViewModels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RazaoSocial,Fantasia,Logradouro,NumeroEndereco,Bairro,Fone,Cnpj,Email,Cadastro,Id_Cep")] FornecedorViewModel fornecedorViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Fornecedor fornecedor = new Fornecedor();
                    fornecedor = Mapper.Map<Fornecedor>(fornecedorViewModel);
                    fornecedor.TimesTamp = DateTime.Now;
                    uow.FornecedorRepositorio.Atualizar(fornecedor);
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
            return View(fornecedorViewModel);
        }

        // GET: FornecedorViewModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            FornecedorViewModel fornecedorViewModel = null;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                fornecedorViewModel = Mapper.Map<FornecedorViewModel>(uow.FornecedorRepositorio.Get(x => x.Id == id));
                return View(fornecedorViewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um erro!\n {0}", ex.Message);
                if (fornecedorViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(fornecedorViewModel);
            }
            finally
            {
                uow.Dispose();
            }
        }

        // POST: FornecedorViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            try
            {
                Fornecedor fornecedor = new Fornecedor();
                fornecedor = uow.FornecedorRepositorio.Get(x => x.Id == id);
                uow.FornecedorRepositorio.Deletar(fornecedor);
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
        #endregion
    }
}
