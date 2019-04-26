using AutoMapper;
using AgiliFood.Models;
using AgiliFood.Models.ModeloVisao;
using System.Web.Mvc;
using System;
using AgiliFood.Utilitarios;

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
        //[HttpPost]
        //public ActionResult Login (LoginViewModel loginViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {

        //        }
        //        catch ()
        //        {

        //        }
        //    }
        //}
    }
}