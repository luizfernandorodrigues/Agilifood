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
    public class FuncionarioViewModelsController : Controller
    {
        private Contexto db = new Contexto();

        // GET: FuncionarioViewModels
        public ActionResult Index()
        {
            return View(db.FuncionarioViewModels.ToList());
        }

        // GET: FuncionarioViewModels/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FuncionarioViewModel funcionarioViewModel = db.FuncionarioViewModels.Find(id);
            if (funcionarioViewModel == null)
            {
                return HttpNotFound();
            }
            return View(funcionarioViewModel);
        }

        // GET: FuncionarioViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FuncionarioViewModels/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Endereco,NumeroEndereco,Bairro,Fone,Cpf,Id_Cep,Cep")] FuncionarioViewModel funcionarioViewModel)
        {
            if (ModelState.IsValid)
            {
                funcionarioViewModel.Id = Guid.NewGuid();
                db.FuncionarioViewModels.Add(funcionarioViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(funcionarioViewModel);
        }

        // GET: FuncionarioViewModels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FuncionarioViewModel funcionarioViewModel = db.FuncionarioViewModels.Find(id);
            if (funcionarioViewModel == null)
            {
                return HttpNotFound();
            }
            return View(funcionarioViewModel);
        }

        // POST: FuncionarioViewModels/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Endereco,NumeroEndereco,Bairro,Fone,Cpf,Id_Cep,Cep")] FuncionarioViewModel funcionarioViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funcionarioViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(funcionarioViewModel);
        }

        // GET: FuncionarioViewModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FuncionarioViewModel funcionarioViewModel = db.FuncionarioViewModels.Find(id);
            if (funcionarioViewModel == null)
            {
                return HttpNotFound();
            }
            return View(funcionarioViewModel);
        }

        // POST: FuncionarioViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            FuncionarioViewModel funcionarioViewModel = db.FuncionarioViewModels.Find(id);
            db.FuncionarioViewModels.Remove(funcionarioViewModel);
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
