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
    public class FornecedorViewModelsController : Controller
    {
        private Contexto db = new Contexto();

        // GET: FornecedorViewModels
        public ActionResult Index()
        {
            return View(db.FornecedorViewModels.ToList());
        }

        // GET: FornecedorViewModels/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorViewModel fornecedorViewModel = db.FornecedorViewModels.Find(id);
            if (fornecedorViewModel == null)
            {
                return HttpNotFound();
            }
            return View(fornecedorViewModel);
        }

        // GET: FornecedorViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FornecedorViewModels/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RazaoSocial,Fantasia,Logradouro,NumeroEndereco,Bairro,Fone,Cnpj,Email,Cadastro,Id_Cep,Cep")] FornecedorViewModel fornecedorViewModel)
        {
            if (ModelState.IsValid)
            {
                fornecedorViewModel.Id = Guid.NewGuid();
                db.FornecedorViewModels.Add(fornecedorViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fornecedorViewModel);
        }

        // GET: FornecedorViewModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorViewModel fornecedorViewModel = db.FornecedorViewModels.Find(id);
            if (fornecedorViewModel == null)
            {
                return HttpNotFound();
            }
            return View(fornecedorViewModel);
        }

        // POST: FornecedorViewModels/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RazaoSocial,Fantasia,Logradouro,NumeroEndereco,Bairro,Fone,Cnpj,Email,Cadastro,Id_Cep,Cep")] FornecedorViewModel fornecedorViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fornecedorViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fornecedorViewModel);
        }

        // GET: FornecedorViewModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorViewModel fornecedorViewModel = db.FornecedorViewModels.Find(id);
            if (fornecedorViewModel == null)
            {
                return HttpNotFound();
            }
            return View(fornecedorViewModel);
        }

        // POST: FornecedorViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            FornecedorViewModel fornecedorViewModel = db.FornecedorViewModels.Find(id);
            db.FornecedorViewModels.Remove(fornecedorViewModel);
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
