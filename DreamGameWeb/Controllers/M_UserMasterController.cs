using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DreamGameWeb.Models;

namespace DreamGameWeb.Controllers
{
    public class M_UserMasterController : Controller
    {
        private DreamGameEntities db = new DreamGameEntities();

        // GET: M_UserMaster
        public async Task<ActionResult> Index()
        {
            var m_UserMaster = db.M_UserMaster.Include(m => m.M_MasterTable);
            return View(await m_UserMaster.ToListAsync());
        }

        // GET: M_UserMaster/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_UserMaster m_UserMaster = await db.M_UserMaster.FindAsync(id);
            if (m_UserMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_UserMaster);
        }

        // GET: M_UserMaster/Create
        public ActionResult Create()
        {
            ViewBag.Gender = new SelectList(db.M_MasterTable, "MasterID", "MasterVale");
            return View();
        }

        // POST: M_UserMaster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UserCode,UserName,Address,DOB,Gender,IdentityProf,EmailID,ContactNo,PWD,ProfilePicPath,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Active")] M_UserMaster m_UserMaster)
        {
            if (ModelState.IsValid)
            {
                db.M_UserMaster.Add(m_UserMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Gender = new SelectList(db.M_MasterTable, "MasterID", "MasterVale", m_UserMaster.Gender);
            return View(m_UserMaster);
        }

        // GET: M_UserMaster/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_UserMaster m_UserMaster = await db.M_UserMaster.FindAsync(id);
            if (m_UserMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.Gender = new SelectList(db.M_MasterTable, "MasterID", "MasterVale", m_UserMaster.Gender);
            return View(m_UserMaster);
        }

        // POST: M_UserMaster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UserCode,UserName,Address,DOB,Gender,IdentityProf,EmailID,ContactNo,PWD,ProfilePicPath,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Active")] M_UserMaster m_UserMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(m_UserMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Gender = new SelectList(db.M_MasterTable, "MasterID", "MasterVale", m_UserMaster.Gender);
            return View(m_UserMaster);
        }

        // GET: M_UserMaster/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            M_UserMaster m_UserMaster = await db.M_UserMaster.FindAsync(id);
            if (m_UserMaster == null)
            {
                return HttpNotFound();
            }
            return View(m_UserMaster);
        }

        // POST: M_UserMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            M_UserMaster m_UserMaster = await db.M_UserMaster.FindAsync(id);
            db.M_UserMaster.Remove(m_UserMaster);
            await db.SaveChangesAsync();
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
