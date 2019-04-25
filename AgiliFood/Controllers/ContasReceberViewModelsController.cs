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
    public class ContasReceberViewModelsController : Controller
    {
        private Contexto db = new Contexto();

        // GET: ContasReceberViewModels
        public ActionResult Index()
        {
            return View(db.ContasReceberViewModels.ToList());
        }

        // GET: ContasReceberViewModels/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContasReceberViewModel contasReceberViewModel = db.ContasReceberViewModels.Find(id);
            if (contasReceberViewModel == null)
            {
                return HttpNotFound();
            }
            return View(contasReceberViewModel);
        }

        // GET: ContasReceberViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContasReceberViewModels/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Emissao,Valor,ValorPago,NomeFuncionario,NumeroPedido,NomeFornecedor")] ContasReceberViewModel contasReceberViewModel)
        {
            if (ModelState.IsValid)
            {
                contasReceberViewModel.Id = Guid.NewGuid();
                db.ContasReceberViewModels.Add(contasReceberViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contasReceberViewModel);
        }

        // GET: ContasReceberViewModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContasReceberViewModel contasReceberViewModel = db.ContasReceberViewModels.Find(id);
            if (contasReceberViewModel == null)
            {
                return HttpNotFound();
            }
            return View(contasReceberViewModel);
        }

        // POST: ContasReceberViewModels/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Emissao,Valor,ValorPago,NomeFuncionario,NumeroPedido,NomeFornecedor")] ContasReceberViewModel contasReceberViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contasReceberViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contasReceberViewModel);
        }

        // GET: ContasReceberViewModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContasReceberViewModel contasReceberViewModel = db.ContasReceberViewModels.Find(id);
            if (contasReceberViewModel == null)
            {
                return HttpNotFound();
            }
            return View(contasReceberViewModel);
        }

        // POST: ContasReceberViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ContasReceberViewModel contasReceberViewModel = db.ContasReceberViewModels.Find(id);
            db.ContasReceberViewModels.Remove(contasReceberViewModel);
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
