using AutoMapper;
using AgiliFood.Models;
using AgiliFood.Models.ModeloVisao;
using System.Web.Mvc;
using System;
using AgiliFood.Utilitarios;
using System.Web.Security;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace AgiliFood.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            LoginViewModel loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork())
                    {
                        Usuario usuario = new Usuario();
                        usuario.Login = loginViewModel.Login;
                        usuario.Senha = loginViewModel.Senha;
                        usuario.Senha = Criptografia.Encrypt(usuario.Senha);
                        var usuarioLogado = uow.UsuarioRepositorio.Get(x => x.Login == usuario.Login && x.Senha == usuario.Senha);
                        if (usuarioLogado != null)
                        {
                            Session.Add("usuario", usuarioLogado.Nome);
                            Session.Add("id_usuario", usuarioLogado.Id);
                            FormsAuthentication.SetAuthCookie(usuario.Login, false);
                            if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                                && returnUrl.StartsWith("//") && returnUrl.StartsWith("/\\"))
                            {
                                return Redirect(returnUrl);
                            }
                            return RedirectToAction("Index", "Home", null);
                        }
                        else
                        {
                            ModelState.AddModelError("", "Senha ou Usuário Incorreto!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", string.Format("Ocorreu um erro ao Efetuar o login !\n {0}", ex.Message));
                }
            }
            return View(loginViewModel);
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Register()
        {
            UsuarioViewModel usuarioViewModel = new UsuarioViewModel();
            return View(usuarioViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult Register(UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork())
                    {
                        Usuario usuario = new Usuario();
                        usuarioViewModel.Id = Guid.NewGuid();
                        usuario = Mapper.Map<Usuario>(usuarioViewModel);
                        usuario.Senha = Criptografia.Encrypt(usuario.Senha);
                        uow.UsuarioRepositorio.Adcionar(usuario);
                        uow.Commit();
                        TempData["mensagem"] = string.Format("Registro Cadastrado com Sucesso!");
                        return RedirectToAction("Index", "Home", null);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", string.Format("Registro Falhou\n {0}", ex.Message));
                }
            }
            return View(usuarioViewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            using (UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    IEnumerable<UsuarioViewModel> lista = Mapper.Map<IEnumerable<UsuarioViewModel>>(uow.UsuarioRepositorio.GetTudo().ToList());
                    return View(lista);
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

        public ActionResult Details(Guid? id)
        {
            UsuarioViewModel usuarioViewModel = null;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    usuarioViewModel = Mapper.Map<UsuarioViewModel>(uow.UsuarioRepositorio.Get(x => x.Id == id));
                    return View(usuarioViewModel);
                }
                catch (Exception ex)
                {
                    if (usuarioViewModel == null)
                    {
                        return HttpNotFound();
                    }
                    ModelState.AddModelError("", string.Format("Ocorreu um Erro na Busca do Usuario com Id = {0}\n Erro: {1}", id, ex.Message));
                    return View(usuarioViewModel);
                }
                finally
                {
                    uow.Dispose();
                }
            }

        }

        // GET: PaisViewModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            UsuarioViewModel usuarioViewModel = null;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    usuarioViewModel = Mapper.Map<UsuarioViewModel>(uow.UsuarioRepositorio.Get(x => x.Id == id));
                    return View(usuarioViewModel);

                }
                catch (Exception ex)
                {
                    if (usuarioViewModel == null)
                    {
                        return HttpNotFound();
                    }
                    ModelState.AddModelError("", string.Format("Ocorreu um Erro {0}", ex.Message));
                    return View();
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit([Bind(Include = "Id,Nome,Login,Email,Senha,Adm,")] UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                using (UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork())
                {
                    try
                    {
                        Usuario usuario = new Usuario();
                        usuario = Mapper.Map<Usuario>(usuarioViewModel);
                        usuario.Senha = Criptografia.Encrypt(usuario.Senha);
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
                    finally
                    {
                        uow.Dispose();

                    }
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
            using (UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork())
            {
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
                finally
                {
                    uow.Dispose();
                }
            }
        }

        // POST: UsuarioViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            using (UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork())
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
                finally
                {
                    uow.Dispose();
                }
            }
        }
    }
}