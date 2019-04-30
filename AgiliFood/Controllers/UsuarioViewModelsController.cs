using AgiliFood.Models;
using AgiliFood.Models.ModeloVisao;
using AutoMapper;
using System;
using System.Net;
using System.Web.Mvc;

namespace AgiliFood.Controllers
{
    public class UsuarioViewModelsController : Controller
    {
        #region Propriedades
        private readonly UnitOfWork.UnitOfWork uow;
        #endregion

        #region Construtores
        public UsuarioViewModelsController()
        {
            uow = new UnitOfWork.UnitOfWork();
        }

        public UsuarioViewModelsController(UnitOfWork.UnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }
        #endregion

        #region Metodos Publicos Actions
        // GET: UsuarioViewModels
        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            try
            {
                return View(uow.UsuarioRepositorio.GetTudo());
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um erro!\n {0}", ex.Message);
                return View();
            }

        }

        // GET: UsuarioViewModels/Details/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Details(Guid? id)
        {
            UsuarioViewModel usuarioViewModel = null;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                usuarioViewModel = Mapper.Map<UsuarioViewModel>(uow.UsuarioRepositorio.Get(x => x.Id == id));
                return View(usuarioViewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um Erro! \n {0}", ex.Message);
                if (usuarioViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(usuarioViewModel);
            }
        }

        // GET: UsuarioViewModels/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Create([Bind(Include = "Id,Nome,Login,Email,Senha,Adm,Cadastro,Id_Funcionario,NomeFuncionario")] UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Usuario usuario = new Usuario();
                    usuarioViewModel.Id = Guid.NewGuid();
                    usuario = Mapper.Map<Usuario>(usuarioViewModel);
                    uow.UsuarioRepositorio.Adcionar(usuario);
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
            return View(usuarioViewModel);
        }

        // GET: UsuarioViewModels/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(Guid? id)
        {
            UsuarioViewModel usuarioViewModel = null;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                usuarioViewModel = Mapper.Map<UsuarioViewModel>(uow.UsuarioRepositorio.Get(x => x.Id == id));
                return View(usuarioViewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um erro!\n {0}", ex.Message);
                if (usuarioViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(usuarioViewModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit([Bind(Include = "Id,Nome,Login,Email,Senha,Adm,Cadastro,Id_Funcionario,NomeFuncionario")] UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Usuario usuario = new Usuario();
                    usuario = Mapper.Map<Usuario>(usuarioViewModel);
                    uow.UsuarioRepositorio.Atualizar(usuario);
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
            return View(usuarioViewModel);
        }

        // GET: UsuarioViewModels/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(Guid? id)
        {
            UsuarioViewModel usuarioViewModel = null;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                usuarioViewModel = Mapper.Map<UsuarioViewModel>(uow.UsuarioRepositorio.Get(x => x.Id == id));
                return View(usuarioViewModel);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um erro!\n {0}", ex.Message);
                if (usuarioViewModel == null)
                {
                    return HttpNotFound();
                }
                return View(usuarioViewModel);
            }
        }

        // POST: UsuarioViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario = uow.UsuarioRepositorio.Get(x => x.Id == id);
                uow.UsuarioRepositorio.Deletar(usuario);
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
