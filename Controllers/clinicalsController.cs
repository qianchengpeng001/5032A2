using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _20S2_5032_A2_4.Models;

namespace _20S2_5032_A2_4.Controllers
{
    public class clinicalsController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: clinicals
        public ActionResult Index()
        {
            var clinicalSet = db.clinicalSet.Include(c => c.patient).Include(c => c.doctor);
            return View(clinicalSet.ToList());
        }

        // GET: clinicals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clinical clinical = db.clinicalSet.Find(id);
            if (clinical == null)
            {
                return HttpNotFound();
            }
            return View(clinical);
        }

        // GET: clinicals/Create
        public ActionResult Create()
        {
            ViewBag.patientId = new SelectList(db.patientSet, "Id", "f_name");
            ViewBag.doctorId = new SelectList(db.doctorSet, "Id", "f_name");
            return View();
        }

        // POST: clinicals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,patientId,doctorId")] clinical clinical)
        {
            if (ModelState.IsValid)
            {
                db.clinicalSet.Add(clinical);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.patientId = new SelectList(db.patientSet, "Id", "f_name", clinical.patientId);
            ViewBag.doctorId = new SelectList(db.doctorSet, "Id", "f_name", clinical.doctorId);
            return View(clinical);
        }

        // GET: clinicals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clinical clinical = db.clinicalSet.Find(id);
            if (clinical == null)
            {
                return HttpNotFound();
            }
            ViewBag.patientId = new SelectList(db.patientSet, "Id", "f_name", clinical.patientId);
            ViewBag.doctorId = new SelectList(db.doctorSet, "Id", "f_name", clinical.doctorId);
            return View(clinical);
        }

        // POST: clinicals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,patientId,doctorId")] clinical clinical)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clinical).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.patientId = new SelectList(db.patientSet, "Id", "f_name", clinical.patientId);
            ViewBag.doctorId = new SelectList(db.doctorSet, "Id", "f_name", clinical.doctorId);
            return View(clinical);
        }

        // GET: clinicals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clinical clinical = db.clinicalSet.Find(id);
            if (clinical == null)
            {
                return HttpNotFound();
            }
            return View(clinical);
        }

        // POST: clinicals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            clinical clinical = db.clinicalSet.Find(id);
            db.clinicalSet.Remove(clinical);
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
