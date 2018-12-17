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
    public class T_User_ContestController : Controller
    {
        private DreamGameEntities db = new DreamGameEntities();

        // GET: T_User_Contest
        public ActionResult Index()
        {
            var t_User_Contest = db.T_User_Contest.Include(t => t.M_Contest_Master);
            return View(t_User_Contest.ToList());
        }

        // GET: T_User_Contest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_User_Contest t_User_Contest = db.T_User_Contest.Find(id);
            if (t_User_Contest == null)
            {
                return HttpNotFound();
            }
            return View(t_User_Contest);
        }

        // GET: T_User_Contest/Create
        public ActionResult Create()
        {
            ViewBag.Contest_Id = new SelectList(db.M_Contest_Master, "Contest_ID", "Contest_Desc");
            return View();
        }

        // POST: T_User_Contest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Contest_Id,User_Id,Contest_Description,Match_Info,ModifiedBy,/*CreatedBy,ModifiedDate,CreateDate,Active*/")] T_User_Contest t_User_Contest)
        {
            if (ModelState.IsValid)
            {
                db.T_User_Contest.Add(t_User_Contest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Contest_Id = new SelectList(db.M_Contest_Master, "Contest_ID", "Contest_Desc", t_User_Contest.Contest_Id);
            return View(t_User_Contest);
        }

        // GET: T_User_Contest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_User_Contest t_User_Contest = db.T_User_Contest.Find(id);
            if (t_User_Contest == null)
            {
                return HttpNotFound();
            }
            ViewBag.Contest_Id = new SelectList(db.M_Contest_Master, "Contest_ID", "Contest_Desc", t_User_Contest.Contest_Id);
            return View(t_User_Contest);
        }

        // POST: T_User_Contest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Contest_Id,User_Id,Contest_Description,Match_Info,ModifiedBy,CreatedBy,ModifiedDate,CreateDate,Active")] T_User_Contest t_User_Contest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_User_Contest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Contest_Id = new SelectList(db.M_Contest_Master, "Contest_ID", "Contest_Desc", t_User_Contest.Contest_Id);
            return View(t_User_Contest);
        }

        // GET: T_User_Contest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_User_Contest t_User_Contest = db.T_User_Contest.Find(id);
            if (t_User_Contest == null)
            {
                return HttpNotFound();
            }
            return View(t_User_Contest);
        }

        // POST: T_User_Contest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T_User_Contest t_User_Contest = db.T_User_Contest.Find(id);
            db.T_User_Contest.Remove(t_User_Contest);
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
