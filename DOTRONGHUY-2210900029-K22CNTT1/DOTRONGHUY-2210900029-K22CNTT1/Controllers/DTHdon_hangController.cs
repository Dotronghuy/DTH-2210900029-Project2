using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DOTRONGHUY_2210900029_K22CNTT1.Models;
using System.Diagnostics;

namespace DOTRONGHUY_2210900029_K22CNTT1.Controllers
{
    public class DTHdon_hangController : Controller
    {
        private DOTRONGHUY_CNTT1_2210900029_Project2Entities db = new DOTRONGHUY_CNTT1_2210900029_Project2Entities();

        // GET: DTHdon_hang
        public ActionResult Index()
        {
            string userId = Session["TaiKhoan"]?.ToString();

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "DTHquan_tri"); // Nếu chưa đăng nhập, chuyển hướng đến trang đăng nhập
            }

            var cartSessionKey = "Cart_" + userId;
            List<danh_muc_xe_hoi> cart = Session[cartSessionKey] as List<danh_muc_xe_hoi>;

            if (cart == null)
            {
                cart = new List<danh_muc_xe_hoi>(); // Nếu giỏ hàng trống, tạo một giỏ hàng mới
            }

            return View(cart);
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

                try
                {
                    // Save changes to the database
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    // Log exception
                    Debug.WriteLine("Error saving changes: " + ex.Message);
                    // Optionally, you can return an error message to the user
                    return View("Error", new HandleErrorInfo(ex, "DTHdon_hang", "AddToCart"));
                }

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

                try
                {
                    // Save changes to the database
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    // Log exception
                    Debug.WriteLine("Error saving changes: " + ex.Message);
                    // Optionally, you can return an error message to the user
                    return View("Error", new HandleErrorInfo(ex, "DTHdon_hang", "AddToCart"));
                }

                // Cập nhật giỏ hàng trong session
                var cartSessionKey = "Cart_" + userId;
                List<danh_muc_xe_hoi> cart = Session[cartSessionKey] as List<danh_muc_xe_hoi>;

                if (cart == null)
                {
                    cart = new List<danh_muc_xe_hoi>();
                }

                // Kiểm tra xem xe đã có trong giỏ chưa, nếu chưa thì thêm vào
                if (!cart.Any(x => x.ma_xe == car.ma_xe))
                {
                    cart.Add(car);
                }

                Session[cartSessionKey] = cart;

                return RedirectToAction("Cart");
            }

            return RedirectToAction("Index", "DTHdanh_muc_xe_hoi");
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
