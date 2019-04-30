using AutoMapper;
using AgiliFood.Models;
using AgiliFood.Models.ModeloVisao;
using System.Web.Mvc;
using System;
using AgiliFood.Utilitarios;
using System.Web.Security;

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
    }
}