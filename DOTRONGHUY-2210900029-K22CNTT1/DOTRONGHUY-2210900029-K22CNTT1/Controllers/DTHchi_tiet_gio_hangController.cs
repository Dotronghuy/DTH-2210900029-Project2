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
        public ActionResult AddToCart(int id)
        {
            var car = db.danh_muc_xe_hoi.FirstOrDefault(x => x.ma_xe == id);
            string userId = Session["TaiKhoan"]?.ToString();

            if (car != null && !string.IsNullOrEmpty(userId))
            {
                var customer = db.khach_hang.FirstOrDefault(k => k.tai_khoan == userId);

                // Kiểm tra nếu người dùng đã có giỏ hàng, nếu chưa thì tạo mới
                var cart = db.gio_hang.FirstOrDefault(g => g.ma_kh == customer.ma_kh);
                if (cart == null)
                {
                    cart = new gio_hang { ma_kh = customer.ma_kh };
                    db.gio_hang.Add(cart);
                    db.SaveChanges();
                }

                // Thêm chi tiết giỏ hàng
                var cartDetail = new chi_tiet_gio_hang
                {
                    ma_gio_hang = cart.ma_gio_hang,
                    ma_xe = car.ma_xe,
                    ten_xe = car.ten_xe,
                    hang_xe = car.hang_xe,
                    so_luong = 1,
                    gia_ban = car.gia_ban,
                    anh = car.anh
                };

                db.chi_tiet_gio_hang.Add(cartDetail);
                db.SaveChanges();

                return RedirectToAction("Cart");
            }

            return RedirectToAction("Cart");
        }



        public ActionResult Cart()
        {
            // Lấy thông tin người dùng từ session
            string userId = Session["TaiKhoan"]?.ToString();

            // Kiểm tra xem người dùng đã đăng nhập chưa
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "DTHquan_tri"); // Nếu chưa đăng nhập, chuyển đến trang đăng nhập
            }

            // Lấy giỏ hàng từ session
            var cartSessionKey = "Cart_" + userId;
            List<danh_muc_xe_hoi> cart = Session[cartSessionKey] as List<danh_muc_xe_hoi>;

            if (cart == null || cart.Count == 0)
            {
                // Trả về view Cart với thông báo giỏ hàng trống
                ViewBag.Message = "Giỏ hàng của bạn hiện tại chưa có sản phẩm nào.";
                return View("Cart", new List<danh_muc_xe_hoi>());
            }

            // Trả về view Cart với các sản phẩm trong giỏ hàng
            return View(cart);
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
