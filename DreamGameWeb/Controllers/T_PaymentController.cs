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
    public class T_PaymentController : Controller
    {
        private DreamGameEntities db = new DreamGameEntities();

        // GET: T_Payment
        public ActionResult Index()
        {
            var t_Payment = db.T_Payment.Include(t => t.M_MasterTable);
            return View(t_Payment.ToList());
        }

        // GET: T_Payment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Payment t_Payment = db.T_Payment.Find(id);
            if (t_Payment == null)
            {
                return HttpNotFound();
            }
            return View(t_Payment);
        }

        // GET: T_Payment/Create
        public ActionResult Create()
        {
            ViewBag.Payment_Mode = new SelectList(db.M_MasterTable, "MasterID", "MasterVale");
            return View();
        }

        // POST: T_Payment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Payment_Id,Payment_Amount,Payment_Desc,Payment_Mode,Transaction_Refrence_Id,TransactionDate,Amount_Transfer,To,From,Transaction_status,Remarks,CreatedBy,ModifiedBy,CreateDate,ModifiedDate,Active")] T_Payment t_Payment)
        {
            if (ModelState.IsValid)
            {
                db.T_Payment.Add(t_Payment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Payment_Mode = new SelectList(db.M_MasterTable, "MasterID", "MasterVale", t_Payment.Payment_Mode);
            return View(t_Payment);
        }

        // GET: T_Payment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Payment t_Payment = db.T_Payment.Find(id);
            if (t_Payment == null)
            {
                return HttpNotFound();
            }
            ViewBag.Payment_Mode = new SelectList(db.M_MasterTable, "MasterID", "MasterVale", t_Payment.Payment_Mode);
            return View(t_Payment);
        }

        // POST: T_Payment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Payment_Id,Payment_Amount,Payment_Desc,Payment_Mode,Transaction_Refrence_Id,TransactionDate,Amount_Transfer,To,From,Transaction_status,Remarks,CreatedBy,ModifiedBy,CreateDate,ModifiedDate,Active")] T_Payment t_Payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Payment_Mode = new SelectList(db.M_MasterTable, "MasterID", "MasterVale", t_Payment.Payment_Mode);
            return View(t_Payment);
        }

        // GET: T_Payment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Payment t_Payment = db.T_Payment.Find(id);
            if (t_Payment == null)
            {
                return HttpNotFound();
            }
            return View(t_Payment);
        }

        // POST: T_Payment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_Payment t_Payment = db.T_Payment.Find(id);
            db.T_Payment.Remove(t_Payment);
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
