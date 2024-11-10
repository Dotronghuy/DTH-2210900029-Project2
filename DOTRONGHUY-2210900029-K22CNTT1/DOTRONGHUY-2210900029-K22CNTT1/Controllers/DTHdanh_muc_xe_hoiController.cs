using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using DOTRONGHUY_2210900029_K22CNTT1.Models;
using Newtonsoft.Json;

namespace DOTRONGHUY_2210900029_K22CNTT1.Controllers
{
    public class DTHdanh_muc_xe_hoiController : Controller
    {
        private DOTRONGHUY_CNTT1_2210900029_Project2Entities db = new DOTRONGHUY_CNTT1_2210900029_Project2Entities();

        // GET: DTHdanh_muc_xe_hoi
        public ActionResult Index()
        {
            string jsonFilePath = Server.MapPath("~/App_Data/danh_muc_xe_hoi.json");
            string jsonData = System.IO.File.ReadAllText(jsonFilePath);

            var carCatalog = JsonConvert.DeserializeObject<List<xehoi>>(jsonData);

            return View(carCatalog);
        }

        // GET: DTHdanh_muc_xe_hoi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            danh_muc_xe_hoi danh_muc_xe_hoi = db.danh_muc_xe_hoi.Find(id);
            if (danh_muc_xe_hoi == null)
            {
                return HttpNotFound();
            }
            return View(danh_muc_xe_hoi);
        }

        // GET: DTHdanh_muc_xe_hoi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DTHdanh_muc_xe_hoi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ma_xe,ten_xe,hang_xe,gia_ban,mo_ta,so_luong")] danh_muc_xe_hoi danh_muc_xe_hoi)
        {
            if (ModelState.IsValid)
            {
                db.danh_muc_xe_hoi.Add(danh_muc_xe_hoi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(danh_muc_xe_hoi);
        }

        // GET: DTHdanh_muc_xe_hoi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            danh_muc_xe_hoi danh_muc_xe_hoi = db.danh_muc_xe_hoi.Find(id);
            if (danh_muc_xe_hoi == null)
            {
                return HttpNotFound();
            }
            return View(danh_muc_xe_hoi);
        }

        // POST: DTHdanh_muc_xe_hoi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ma_xe,ten_xe,hang_xe,gia_ban,mo_ta,so_luong")] danh_muc_xe_hoi danh_muc_xe_hoi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danh_muc_xe_hoi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(danh_muc_xe_hoi);
        }

        // GET: DTHdanh_muc_xe_hoi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            danh_muc_xe_hoi danh_muc_xe_hoi = db.danh_muc_xe_hoi.Find(id);
            if (danh_muc_xe_hoi == null)
            {
                return HttpNotFound();
            }
            return View(danh_muc_xe_hoi);
        }

        // POST: DTHdanh_muc_xe_hoi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            danh_muc_xe_hoi danh_muc_xe_hoi = db.danh_muc_xe_hoi.Find(id);
            db.danh_muc_xe_hoi.Remove(danh_muc_xe_hoi);
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
