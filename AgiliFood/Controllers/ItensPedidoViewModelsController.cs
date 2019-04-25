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
    public class ItensPedidoViewModelsController : Controller
    {
        private Contexto db = new Contexto();

        // GET: ItensPedidoViewModels
        public ActionResult Index()
        {
            return View(db.ItensPedidoViewModels.ToList());
        }

        // GET: ItensPedidoViewModels/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItensPedidoViewModel itensPedidoViewModel = db.ItensPedidoViewModels.Find(id);
            if (itensPedidoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(itensPedidoViewModel);
        }

        // GET: ItensPedidoViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItensPedidoViewModels/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Quantidade,Total,Id_Pedido")] ItensPedidoViewModel itensPedidoViewModel)
        {
            if (ModelState.IsValid)
            {
                itensPedidoViewModel.Id = Guid.NewGuid();
                db.ItensPedidoViewModels.Add(itensPedidoViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(itensPedidoViewModel);
        }

        // GET: ItensPedidoViewModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItensPedidoViewModel itensPedidoViewModel = db.ItensPedidoViewModels.Find(id);
            if (itensPedidoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(itensPedidoViewModel);
        }

        // POST: ItensPedidoViewModels/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Quantidade,Total,Id_Pedido")] ItensPedidoViewModel itensPedidoViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itensPedidoViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(itensPedidoViewModel);
        }

        // GET: ItensPedidoViewModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItensPedidoViewModel itensPedidoViewModel = db.ItensPedidoViewModels.Find(id);
            if (itensPedidoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(itensPedidoViewModel);
        }

        // POST: ItensPedidoViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ItensPedidoViewModel itensPedidoViewModel = db.ItensPedidoViewModels.Find(id);
            db.ItensPedidoViewModels.Remove(itensPedidoViewModel);
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
