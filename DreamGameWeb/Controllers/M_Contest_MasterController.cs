using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DreamGameWeb.Models;

namespace DreamGameWeb.Controllers
{
    public class M_Contest_MasterController : Controller
    {
        private DreamGameEntities db = new DreamGameEntities();

        // GET: M_Contest_Master
        public ActionResult Index()
        {
            var m_Contest_Master = db.M_Contest_Master.Include(m => m.T_User_Contest);
            return View(m_Contest_Master.ToList());
        }

        // GET: M_Contest_Master/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_Contest_Master m_Contest_Master = db.M_Contest_Master.Find(id);
            if (m_Contest_Master == null)
            {
                return HttpNotFound();
            }
            return View(m_Contest_Master);
        }

        // GET: M_Contest_Master/Create
        public ActionResult Create()
        {
            ViewBag.Contest_ID = new SelectList(db.T_User_Contest, "Contest_Id", "Contest_Description");
            return View();
        }

        // POST: M_Contest_Master/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Contest_ID,Contest__Code,Contest_Desc,Banner_Image_Path,Bit_Amount,Max_People,Promo_Code,Promo_Code_Values,CreatedBy,ModifiedBy,CreatedDate,ModifiedDate,Active")] M_Contest_Master m_Contest_Master)
        {
            if (ModelState.IsValid)
            {
                db.M_Contest_Master.Add(m_Contest_Master);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Contest_ID = new SelectList(db.T_User_Contest, "Contest_Id", "Contest_Description", m_Contest_Master.Contest_ID);
            return View(m_Contest_Master);
        }

        // GET: M_Contest_Master/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_Contest_Master m_Contest_Master = db.M_Contest_Master.Find(id);
            if (m_Contest_Master == null)
            {
                return HttpNotFound();
            }
            ViewBag.Contest_ID = new SelectList(db.T_User_Contest, "Contest_Id", "Contest_Description", m_Contest_Master.Contest_ID);
            return View(m_Contest_Master);
        }

        // POST: M_Contest_Master/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Contest_ID,Contest__Code,Contest_Desc,Banner_Image_Path,Bit_Amount,Max_People,Promo_Code,Promo_Code_Values,CreatedBy,ModifiedBy,CreatedDate,ModifiedDate,Active")] M_Contest_Master m_Contest_Master)
        {
            if (ModelState.IsValid)
            {
                db.Entry(m_Contest_Master).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Contest_ID = new SelectList(db.T_User_Contest, "Contest_Id", "Contest_Description", m_Contest_Master.Contest_ID);
            return View(m_Contest_Master);
        }

        // GET: M_Contest_Master/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_Contest_Master m_Contest_Master = db.M_Contest_Master.Find(id);
            if (m_Contest_Master == null)
            {
                return HttpNotFound();
            }
            return View(m_Contest_Master);
        }

        // POST: M_Contest_Master/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            M_Contest_Master m_Contest_Master = db.M_Contest_Master.Find(id);
            db.M_Contest_Master.Remove(m_Contest_Master);
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
