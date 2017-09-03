using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CellCrud.Models;
using CellCrud.DAL;

namespace CellCrud.Controllers
{
    public class CelularController : Controller
    {
        private CellContext db = new CellContext();

        // GET: /Celular/
        public ActionResult Index()
        {
            return View(db.Celulares.ToList());
        }

        // GET: /Celular/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Celular celular = db.Celulares.Find(id);
            if (celular == null)
            {
                return HttpNotFound();
            }
            return View(celular);
        }

        // GET: /Celular/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Celular/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CelularID,MarcaID,OSID,Operadora,Costo,NombreCliente")] Celular celular)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Celulares.Add(celular);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(celular);
        }

        // GET: /Celular/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Celular celular = db.Celulares.Find(id);
            if (celular == null)
            {
                return HttpNotFound();
            }
            return View(celular);
        }

        // POST: /Celular/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CelularID,MarcaID,OSID,Operadora,Costo,NombreCliente")] Celular celular)
        {
            if (ModelState.IsValid)
            {
                db.Entry(celular).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(celular);
        }

        // GET: /Celular/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Celular celular = db.Celulares.Find(id);
            if (celular == null)
            {
                return HttpNotFound();
            }
            return View(celular);
        }

        // POST: /Celular/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Celular celular = db.Celulares.Find(id);
                db.Celulares.Remove(celular);
                db.SaveChanges();
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
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
