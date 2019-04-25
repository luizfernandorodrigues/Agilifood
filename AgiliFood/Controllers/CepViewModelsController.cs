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

namespace AgiliFood.Controllers
{
    public class CepViewModelsController : Controller
    {
        private Contexto db = new Contexto();

        // GET: CepViewModels
        public ActionResult Index()
        {
            return View(db.CepViewModels.ToList());
        }

        // GET: CepViewModels/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CepViewModel cepViewModel = db.CepViewModels.Find(id);
            if (cepViewModel == null)
            {
                return HttpNotFound();
            }
            return View(cepViewModel);
        }

        // GET: CepViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CepViewModels/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cep,NomeCidade")] CepViewModel cepViewModel)
        {
            if (ModelState.IsValid)
            {
                cepViewModel.Id = Guid.NewGuid();
                db.CepViewModels.Add(cepViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cepViewModel);
        }

        // GET: CepViewModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CepViewModel cepViewModel = db.CepViewModels.Find(id);
            if (cepViewModel == null)
            {
                return HttpNotFound();
            }
            return View(cepViewModel);
        }

        // POST: CepViewModels/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cep,NomeCidade")] CepViewModel cepViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cepViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cepViewModel);
        }

        // GET: CepViewModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CepViewModel cepViewModel = db.CepViewModels.Find(id);
            if (cepViewModel == null)
            {
                return HttpNotFound();
            }
            return View(cepViewModel);
        }

        // POST: CepViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CepViewModel cepViewModel = db.CepViewModels.Find(id);
            db.CepViewModels.Remove(cepViewModel);
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
