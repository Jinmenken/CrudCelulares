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
    public class OSController : Controller
    {
        private CellContext db = new CellContext();

        // GET: /OS/
        public ActionResult Index()
        {
            return View(db.OpSys.ToList());
        }

        // GET: /OS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OS os = db.OpSys.Find(id);
            if (os == null)
            {
                return HttpNotFound();
            }
            return View(os);
        }

        // GET: /OS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /OS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="OSID,Nombre")] OS os)
        {
            if (ModelState.IsValid)
            {
                db.OpSys.Add(os);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(os);
        }

        // GET: /OS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OS os = db.OpSys.Find(id);
            if (os == null)
            {
                return HttpNotFound();
            }
            return View(os);
        }

        // POST: /OS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="OSID,Nombre")] OS os)
        {
            if (ModelState.IsValid)
            {
                db.Entry(os).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(os);
        }

        // GET: /OS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OS os = db.OpSys.Find(id);
            if (os == null)
            {
                return HttpNotFound();
            }
            return View(os);
        }

        // POST: /OS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OS os = db.OpSys.Find(id);
            db.OpSys.Remove(os);
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
