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
    public class DTHthanh_toanController : Controller
    {
        private DOTRONGHUY_CNTT1_2210900029_Project2Entities db = new DOTRONGHUY_CNTT1_2210900029_Project2Entities();

        // GET: DTHthanh_toan
        public ActionResult Index()
        {
            var thanh_toan = db.thanh_toan.Include(t => t.don_hang);
            return View(thanh_toan.ToList());
        }

        // GET: DTHthanh_toan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thanh_toan thanh_toan = db.thanh_toan.Find(id);
            if (thanh_toan == null)
            {
                return HttpNotFound();
            }
            return View(thanh_toan);
        }

        // GET: DTHthanh_toan/Create
        public ActionResult Create()
        {
            ViewBag.ma_dh = new SelectList(db.don_hang, "ma_dh", "ma_dh");
            return View();
        }

        // POST: DTHthanh_toan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_thanh_toan,ma_dh,ngay_thanh_toan,tong_tien,phuong_thuc,trang_thai,mo_ta")] thanh_toan thanh_toan)
        {
            if (ModelState.IsValid)
            {
                db.thanh_toan.Add(thanh_toan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ma_dh = new SelectList(db.don_hang, "ma_dh", "ma_dh", thanh_toan.ma_dh);
            return View(thanh_toan);
        }

        // GET: DTHthanh_toan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thanh_toan thanh_toan = db.thanh_toan.Find(id);
            if (thanh_toan == null)
            {
                return HttpNotFound();
            }
            ViewBag.ma_dh = new SelectList(db.don_hang, "ma_dh", "ma_dh", thanh_toan.ma_dh);
            return View(thanh_toan);
        }

        // POST: DTHthanh_toan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_thanh_toan,ma_dh,ngay_thanh_toan,tong_tien,phuong_thuc,trang_thai,mo_ta")] thanh_toan thanh_toan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thanh_toan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ma_dh = new SelectList(db.don_hang, "ma_dh", "ma_dh", thanh_toan.ma_dh);
            return View(thanh_toan);
        }

        // GET: DTHthanh_toan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thanh_toan thanh_toan = db.thanh_toan.Find(id);
            if (thanh_toan == null)
            {
                return HttpNotFound();
            }
            return View(thanh_toan);
        }

        // POST: DTHthanh_toan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            thanh_toan thanh_toan = db.thanh_toan.Find(id);
            db.thanh_toan.Remove(thanh_toan);
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
