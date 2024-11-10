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
    public class DTHgio_hangController : Controller
    {
        private DOTRONGHUY_CNTT1_2210900029_Project2Entities db = new DOTRONGHUY_CNTT1_2210900029_Project2Entities();

        // GET: DTHgio_hang
        public ActionResult Index()
        {
            var gio_hang = db.gio_hang.Include(g => g.khach_hang);
            return View(gio_hang.ToList());
        }

        // GET: DTHgio_hang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gio_hang gio_hang = db.gio_hang.Find(id);
            if (gio_hang == null)
            {
                return HttpNotFound();
            }
            return View(gio_hang);
        }

        // GET: DTHgio_hang/Create
        public ActionResult Create()
        {
            ViewBag.ma_kh = new SelectList(db.khach_hang, "ma_kh", "ho_ten");
            return View();
        }
      


        // POST: DTHgio_hang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_gio_hang,ma_kh,ngay_tao")] gio_hang gio_hang)
        {
            if (ModelState.IsValid)
            {
                db.gio_hang.Add(gio_hang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ma_kh = new SelectList(db.khach_hang, "ma_kh", "ho_ten", gio_hang.ma_kh);
            return View(gio_hang);
        }

        // GET: DTHgio_hang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gio_hang gio_hang = db.gio_hang.Find(id);
            if (gio_hang == null)
            {
                return HttpNotFound();
            }
            ViewBag.ma_kh = new SelectList(db.khach_hang, "ma_kh", "ho_ten", gio_hang.ma_kh);
            return View(gio_hang);
        }

        // POST: DTHgio_hang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_gio_hang,ma_kh,ngay_tao")] gio_hang gio_hang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gio_hang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ma_kh = new SelectList(db.khach_hang, "ma_kh", "ho_ten", gio_hang.ma_kh);
            return View(gio_hang);
        }

        // GET: DTHgio_hang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gio_hang gio_hang = db.gio_hang.Find(id);
            if (gio_hang == null)
            {
                return HttpNotFound();
            }
            return View(gio_hang);
        }

        // POST: DTHgio_hang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            gio_hang gio_hang = db.gio_hang.Find(id);
            db.gio_hang.Remove(gio_hang);
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
