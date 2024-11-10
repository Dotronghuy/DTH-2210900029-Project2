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
            return View();
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
        public ActionResult AddToCart(int id)
        {
            var car = db.danh_muc_xe_hoi.FirstOrDefault(x => x.ma_xe == id);

            if (car != null)
            {
                string userId = Session["TaiKhoan"]?.ToString(); 

                if (string.IsNullOrEmpty(userId))
                {
                    return RedirectToAction("Login", "DTHquan_tri"); 
                }

                var customer = db.khach_hang.FirstOrDefault(k => k.tai_khoan == userId);

                don_hang newOrder = new don_hang
                {
                    ma_kh = customer.ma_kh, 
                    tong_tien = car.gia_ban, 
                    ngay_dat = DateTime.Now, 
                    trang_thai = 1
                };

                db.don_hang.Add(newOrder);
                db.SaveChanges();

                var orderDetails = new chi_tiet_gio_hang
                {
                    ma_gio_hang = newOrder.ma_dh,
                    ma_xe = car.ma_xe,
                    ten_xe = car.ten_xe,
                    hang_xe = car.hang_xe,
                    so_luong = 1,
                    anh = car.anh,
                    gia_ban = car.gia_ban
                };

                db.chi_tiet_gio_hang.Add(orderDetails);
                db.SaveChanges();

                var cartSessionKey = "Cart_" + userId;
                List<danh_muc_xe_hoi> cart = Session[cartSessionKey] as List<danh_muc_xe_hoi>;

                if (cart == null)
                {
                    cart = new List<danh_muc_xe_hoi>();
                }

                cart.Add(car);
                Session[cartSessionKey] = cart;

                return RedirectToAction("Cart"); 
            }

            return RedirectToAction("Index", "DTHdanh_muc_xe_hoi");
        }

        public ActionResult Cart()
        {
            string userId = Session["TaiKhoan"]?.ToString();

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "DTHquan_tri"); // Nếu chưa đăng nhập, chuyển hướng đến trang đăng nhập
            }

            // Lấy giỏ hàng từ session
            var cartSessionKey = "Cart_" + userId;
            List<danh_muc_xe_hoi> cart = Session[cartSessionKey] as List<danh_muc_xe_hoi>;

            if (cart == null)
            {
                cart = new List<danh_muc_xe_hoi>(); // Nếu giỏ hàng trống, tạo một giỏ hàng mới
            }

            return View(cart); // Trả về view hiển thị giỏ hàng
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
