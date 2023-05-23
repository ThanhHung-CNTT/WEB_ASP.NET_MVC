using QuanLyNhanSu.Models;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace QuanLyNhanSu.Controllers
{
    public class TaiKhoanController : Controller
    {
        private Data db = new Data();
        // GET: TaiKhoan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoan);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,TenDangNhap,MatKhau,TinhTrang,IdCV")] TaiKhoan taiKhoan)
        {
            try
            {
                var mkcu = Request["PassCu"];
                var m = db.TaiKhoans.FirstOrDefault(g => g.Id == taiKhoan.Id);
                if (m.MatKhau != mkcu)
                {
                    ViewBag.TBB = "Mật khẩu cũ không đúng";
                    return this.Edit(taiKhoan.Id);
                }
                taiKhoan.TinhTrang = true;
                db.TaiKhoans.AddOrUpdate(taiKhoan);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return View(taiKhoan);
            }
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
