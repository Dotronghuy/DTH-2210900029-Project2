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
    public class DTHdon_hangController : Controller
    {
        private DOTRONGHUY_CNTT1_2210900029_Project2Entities db = new DOTRONGHUY_CNTT1_2210900029_Project2Entities();

        // GET: DTHdon_hang
        public ActionResult Index()
        {
            var don_hang = db.don_hang.Include(d => d.khach_hang);
            return View(don_hang.ToList());
        }

        // GET: DTHdon_hang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            don_hang don_hang = db.don_hang.Find(id);
            if (don_hang == null)
            {
                return HttpNotFound();
            }
            return View(don_hang);
        }

        // GET: DTHdon_hang/Create
        public ActionResult Create()
        {
            ViewBag.ma_kh = new SelectList(db.khach_hang, "ma_kh", "ho_ten");
            return View();
        }

        // POST: DTHdon_hang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_dh,ma_kh,tong_tien,ngay_dat,trang_thai")] don_hang don_hang)
        {
            if (ModelState.IsValid)
            {
                db.don_hang.Add(don_hang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ma_kh = new SelectList(db.khach_hang, "ma_kh", "ho_ten", don_hang.ma_kh);
            return View(don_hang);
        }

        // GET: DTHdon_hang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            don_hang don_hang = db.don_hang.Find(id);
            if (don_hang == null)
            {
                return HttpNotFound();
            }
            ViewBag.ma_kh = new SelectList(db.khach_hang, "ma_kh", "ho_ten", don_hang.ma_kh);
            return View(don_hang);
        }

        // POST: DTHdon_hang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_dh,ma_kh,tong_tien,ngay_dat,trang_thai")] don_hang don_hang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(don_hang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ma_kh = new SelectList(db.khach_hang, "ma_kh", "ho_ten", don_hang.ma_kh);
            return View(don_hang);
        }

        // GET: DTHdon_hang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            don_hang don_hang = db.don_hang.Find(id);
            if (don_hang == null)
            {
                return HttpNotFound();
            }
            return View(don_hang);
        }

        // POST: DTHdon_hang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            don_hang don_hang = db.don_hang.Find(id);
            db.don_hang.Remove(don_hang);
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
