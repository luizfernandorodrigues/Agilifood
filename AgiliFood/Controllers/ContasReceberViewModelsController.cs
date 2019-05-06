using AgiliFood.Models.ModeloVisao;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AgiliFood.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class ContasReceberViewModelsController : Controller
    {
        #region Propriedades
        private readonly UnitOfWork.UnitOfWork uow;
        #endregion

        #region Construtores
        public ContasReceberViewModelsController()
        {
            uow = new UnitOfWork.UnitOfWork();
        }

        public ContasReceberViewModelsController(UnitOfWork.UnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }
        #endregion

        #region Metodos Publicos Actions
        // GET: ContasReceberViewModels
        public ActionResult Index()
        {
            try
            {
                IEnumerable<ContasReceberViewModel> lista = Mapper.Map<IEnumerable<ContasReceberViewModel>>(uow.ContasReceberRepositorio.GetTudo());
                return View(lista);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um erro!\n {0}", ex.Message);
                return View();
            }
        }

        #endregion
    }
}
