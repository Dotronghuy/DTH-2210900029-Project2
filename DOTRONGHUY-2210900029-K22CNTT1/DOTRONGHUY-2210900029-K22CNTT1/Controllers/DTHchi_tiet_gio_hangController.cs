using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DOTRONGHUY_2210900029_K22CNTT1.Models;

namespace DOTRONGHUY_2210900029_K22CNTT1.Controllers
{
    public class DTHchi_tiet_gio_hangController : Controller
    {
        private DOTRONGHUY_CNTT1_2210900029_Project2Entities db = new DOTRONGHUY_CNTT1_2210900029_Project2Entities();

        // GET: DTHchi_tiet_gio_hang
        public ActionResult Index()
        {
            var chi_tiet_gio_hang = db.chi_tiet_gio_hang.Include(c => c.gio_hang).Include(c => c.danh_muc_xe_hoi);
            return View(chi_tiet_gio_hang.ToList());
        }

        // GET: DTHchi_tiet_gio_hang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chi_tiet_gio_hang chi_tiet_gio_hang = db.chi_tiet_gio_hang.Find(id);
            if (chi_tiet_gio_hang == null)
            {
                return HttpNotFound();
            }
            return View(chi_tiet_gio_hang);
        }

        // GET: DTHchi_tiet_gio_hang/Create
        public ActionResult Create()
        {
            ViewBag.ma_gio_hang = new SelectList(db.gio_hang, "ma_gio_hang", "ma_gio_hang");
            ViewBag.ma_xe = new SelectList(db.danh_muc_xe_hoi, "ma_xe", "ten_xe");
            return View();
        }

        // POST: DTHchi_tiet_gio_hang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_gio_hang,ma_xe,so_luong")] chi_tiet_gio_hang chi_tiet_gio_hang)
        {
            if (ModelState.IsValid)
            {
                db.chi_tiet_gio_hang.Add(chi_tiet_gio_hang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ma_gio_hang = new SelectList(db.gio_hang, "ma_gio_hang", "ma_gio_hang", chi_tiet_gio_hang.ma_gio_hang);
            ViewBag.ma_xe = new SelectList(db.danh_muc_xe_hoi, "ma_xe", "ten_xe", chi_tiet_gio_hang.ma_xe);
            return View(chi_tiet_gio_hang);
        }

        // GET: DTHchi_tiet_gio_hang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chi_tiet_gio_hang chi_tiet_gio_hang = db.chi_tiet_gio_hang.Find(id);
            if (chi_tiet_gio_hang == null)
            {
                return HttpNotFound();
            }
            ViewBag.ma_gio_hang = new SelectList(db.gio_hang, "ma_gio_hang", "ma_gio_hang", chi_tiet_gio_hang.ma_gio_hang);
            ViewBag.ma_xe = new SelectList(db.danh_muc_xe_hoi, "ma_xe", "ten_xe", chi_tiet_gio_hang.ma_xe);
            return View(chi_tiet_gio_hang);
        }

        // POST: DTHchi_tiet_gio_hang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_gio_hang,ma_xe,so_luong")] chi_tiet_gio_hang chi_tiet_gio_hang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chi_tiet_gio_hang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ma_gio_hang = new SelectList(db.gio_hang, "ma_gio_hang", "ma_gio_hang", chi_tiet_gio_hang.ma_gio_hang);
            ViewBag.ma_xe = new SelectList(db.danh_muc_xe_hoi, "ma_xe", "ten_xe", chi_tiet_gio_hang.ma_xe);
            return View(chi_tiet_gio_hang);
        }

        // GET: DTHchi_tiet_gio_hang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chi_tiet_gio_hang chi_tiet_gio_hang = db.chi_tiet_gio_hang.Find(id);
            if (chi_tiet_gio_hang == null)
            {
                return HttpNotFound();
            }
            return View(chi_tiet_gio_hang);
        }

        // POST: DTHchi_tiet_gio_hang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            chi_tiet_gio_hang chi_tiet_gio_hang = db.chi_tiet_gio_hang.Find(id);
            db.chi_tiet_gio_hang.Remove(chi_tiet_gio_hang);
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
