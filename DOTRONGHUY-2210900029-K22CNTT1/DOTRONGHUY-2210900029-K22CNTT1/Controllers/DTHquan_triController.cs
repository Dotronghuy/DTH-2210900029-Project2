﻿using System;
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
    public class DTHquan_triController : Controller
    {
        private readonly DOTRONGHUY_CNTT1_2210900029_Project2Entities db = new DOTRONGHUY_CNTT1_2210900029_Project2Entities();

        // GET: DTHquan_tri
        public ActionResult Index()
        {
            return View(db.quan_tri.ToList());
        }

        // GET: DTHquan_tri/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            quan_tri quan_tri = db.quan_tri.Find(id);
            if (quan_tri == null)
            {
                return HttpNotFound();
            }
            return View(quan_tri);
        }

        // GET: DTHquan_tri/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DTHquan_tri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tai_khoan,mat_khau,trang_thai")] quan_tri quan_tri)
        {
            if (ModelState.IsValid)
            {
                db.quan_tri.Add(quan_tri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quan_tri);
        }

        // GET: DTHquan_tri/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            quan_tri quan_tri = db.quan_tri.Find(id);
            if (quan_tri == null)
            {
                return HttpNotFound();
            }
            return View(quan_tri);
        }

        // POST: DTHquan_tri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tai_khoan,mat_khau,trang_thai")] quan_tri quan_tri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quan_tri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quan_tri);
        }

        // GET: DTHquan_tri/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            quan_tri quan_tri = db.quan_tri.Find(id);
            if (quan_tri == null)
            {
                return HttpNotFound();
            }
            return View(quan_tri);
        }

        // POST: DTHquan_tri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            quan_tri quan_tri = db.quan_tri.Find(id);
            db.quan_tri.Remove(quan_tri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {
            return View();
        }

        // POST: DTHquan_tri/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userAuth = db.user_auth.FirstOrDefault(u => u.tai_khoan == model.Username && u.mat_khau == model.Password);

                if (userAuth != null)
                {
                    var userQuanTri = db.quan_tri.FirstOrDefault(u => u.tai_khoan == userAuth.tai_khoan);
                    var userKhachHang = db.khach_hang.FirstOrDefault(u => u.tai_khoan == userAuth.tai_khoan);

                    if (userQuanTri != null)
                    {
                        Session["TaiKhoan"] = userQuanTri.tai_khoan;
                        Session["IsAdmin"] = true;  
                        return RedirectToAction("Index", "DTHquan_tri"); 
                    }
                    else if (userKhachHang != null)
                    {
                        Session["TaiKhoan"] = userKhachHang.tai_khoan;
                        Session["IsAdmin"] = false; 
                        return RedirectToAction("Index", "DTHkhach_hang");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Tên người dùng hoặc mật khẩu không hợp lệ.");
                }
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult HandleAction(string action, string tai_khoan)
        {
            switch (action)
            {
                case "edit":
                    return RedirectToAction("Edit", new { id = tai_khoan });
                case "details":
                    return RedirectToAction("Details", new { id = tai_khoan });
                case "delete":
                    return RedirectToAction("Delete", new { id = tai_khoan });
                default:
                    return RedirectToAction("Index");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
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
