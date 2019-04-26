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
        public ActionResult Login()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }

        public ActionResult Register()
        {
            UsuarioViewModel usuarioViewModel = new UsuarioViewModel();
            return View(usuarioViewModel);
        }

        [HttpPost]
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
                        return RedirectToAction("Login");
                    }
                }
                catch (Exception ex)
                {
                    TempData["mensagem"] = string.Format("Registro Falhou\n {0}", ex.Message);
                }
            }
            return View(usuarioViewModel);
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (UnitOfWork.UnitOfWork uow = new UnitOfWork.UnitOfWork())
                    {
                        Usuario usuario = new Usuario();
                        usuario = Mapper.Map<Usuario>(loginViewModel);
                        usuario.Senha = Criptografia.Encrypt(usuario.Senha);
                        var usuarioLogado = uow.UsuarioRepositorio.Get(x => x.Login == usuario.Login && x.Senha == usuario.Senha);
                        if (usuarioLogado != null)
                        {
                            Session.Add("usuario", usuarioLogado.Nome);
                            Session.Add("id_usuario", usuarioLogado.Id);
                            FormsAuthentication.SetAuthCookie(usuario.Nome, true);
                            return RedirectToAction("Index", "Home", null);
                        }
                        else
                        {
                            ViewBag.Mensagem = "Login Inválido, Usuário ou Senha Incorretos!";
                        }
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Mensagem = string.Format("Ocorreu um erro ao Efetuar o login !\n {0}", ex.Message);
                }
            }
            return View(loginViewModel);
        }
    }
}