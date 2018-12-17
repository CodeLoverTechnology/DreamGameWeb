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
    public class M_User_Wellate_MasterController : Controller
    {
        private DreamGameEntities db = new DreamGameEntities();

        // GET: M_User_Wellate_Master
        public ActionResult Index()
        {
            var m_User_Wellate_Master = db.M_User_Wellate_Master.Include(m => m.M_UserMaster);
            return View(m_User_Wellate_Master.ToList());
        }

        // GET: M_User_Wellate_Master/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_User_Wellate_Master m_User_Wellate_Master = db.M_User_Wellate_Master.Find(id);
            if (m_User_Wellate_Master == null)
            {
                return HttpNotFound();
            }
            return View(m_User_Wellate_Master);
        }

        // GET: M_User_Wellate_Master/Create
        public ActionResult Create()
        {
            ViewBag.User_id = new SelectList(db.M_UserMaster, "UserCode", "UserName");
            return View();
        }

        // POST: M_User_Wellate_Master/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Wellate_Id,User_id,Total_Coins,Net_Coins,Remarks,CreateBy,ModifiedBy,CreatedDate,ModifiedDate,Active")] M_User_Wellate_Master m_User_Wellate_Master)
        {
            if (ModelState.IsValid)
            {
                db.M_User_Wellate_Master.Add(m_User_Wellate_Master);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.User_id = new SelectList(db.M_UserMaster, "UserCode", "UserName", m_User_Wellate_Master.User_id);
            return View(m_User_Wellate_Master);
        }

        // GET: M_User_Wellate_Master/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_User_Wellate_Master m_User_Wellate_Master = db.M_User_Wellate_Master.Find(id);
            if (m_User_Wellate_Master == null)
            {
                return HttpNotFound();
            }
            ViewBag.User_id = new SelectList(db.M_UserMaster, "UserCode", "UserName", m_User_Wellate_Master.User_id);
            return View(m_User_Wellate_Master);
        }

        // POST: M_User_Wellate_Master/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Wellate_Id,User_id,Total_Coins,Net_Coins,Remarks,CreateBy,ModifiedBy,CreatedDate,ModifiedDate,Active")] M_User_Wellate_Master m_User_Wellate_Master)
        {
            if (ModelState.IsValid)
            {
                db.Entry(m_User_Wellate_Master).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.User_id = new SelectList(db.M_UserMaster, "UserCode", "UserName", m_User_Wellate_Master.User_id);
            return View(m_User_Wellate_Master);
        }

        // GET: M_User_Wellate_Master/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_User_Wellate_Master m_User_Wellate_Master = db.M_User_Wellate_Master.Find(id);
            if (m_User_Wellate_Master == null)
            {
                return HttpNotFound();
            }
            return View(m_User_Wellate_Master);
        }

        // POST: M_User_Wellate_Master/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            M_User_Wellate_Master m_User_Wellate_Master = db.M_User_Wellate_Master.Find(id);
            db.M_User_Wellate_Master.Remove(m_User_Wellate_Master);
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
