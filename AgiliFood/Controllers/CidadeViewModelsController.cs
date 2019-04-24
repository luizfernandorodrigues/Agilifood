using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AgiliFood.Models;
using AgiliFood.Models.ModeloVisao;
using AutoMapper;

namespace AgiliFood.Controllers
{
    public class CidadeViewModelsController : Controller
    {
        private readonly UnitOfWork.UnitOfWork uow;

        public CidadeViewModelsController()
        {
            uow = new UnitOfWork.UnitOfWork();
        }
        public CidadeViewModelsController(UnitOfWork.UnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }
        // GET: CidadeViewModels
        public ActionResult Index()
        {
            try
            {
                IEnumerable<CidadeViewModel> lista = Mapper.Map<IEnumerable<CidadeViewModel>>(uow.CidadeRepositorio.GetTudo());
                return View(lista);
            }
            catch (Exception ex)
            {
                TempData["mensagem"] = string.Format("Ocorreu um erro na busca!\n {0}", ex.Message);
                return View();
            }
        }

        // GET: CidadeViewModels/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CidadeViewModel cidadeViewModel = db.CidadeViewModels.Find(id);
            if (cidadeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(cidadeViewModel);
        }

        // GET: CidadeViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CidadeViewModels/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,NomeEstado")] CidadeViewModel cidadeViewModel)
        {
            if (ModelState.IsValid)
            {
                cidadeViewModel.Id = Guid.NewGuid();
                db.CidadeViewModels.Add(cidadeViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cidadeViewModel);
        }

        // GET: CidadeViewModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CidadeViewModel cidadeViewModel = db.CidadeViewModels.Find(id);
            if (cidadeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(cidadeViewModel);
        }

        // POST: CidadeViewModels/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,NomeEstado")] CidadeViewModel cidadeViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cidadeViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cidadeViewModel);
        }

        // GET: CidadeViewModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CidadeViewModel cidadeViewModel = db.CidadeViewModels.Find(id);
            if (cidadeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(cidadeViewModel);
        }

        // POST: CidadeViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CidadeViewModel cidadeViewModel = db.CidadeViewModels.Find(id);
            db.CidadeViewModels.Remove(cidadeViewModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
