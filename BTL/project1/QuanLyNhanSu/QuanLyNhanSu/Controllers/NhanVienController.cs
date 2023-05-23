using OfficeOpenXml;
using OfficeOpenXml.Style;
using PagedList;
using QuanLyNhanSu.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace QuanLyNhanSu.Controllers
{
    public class NhanVienController : Controller
    {
        private Data db = new Data();

        // GET: NhanVien
        public ActionResult Index(int xoa = 0, string keysearch = "", int? page = 1, int IdPB = 0)
        {
            ViewBag.xoa = xoa;
            var nhanViens = db.NhanViens.Include(n => n.PhongBan).Include(n => n.TrinhDoHocVan).Include(n => n.TaiKhoan);
            if (xoa == 0 && keysearch == "" && IdPB == 0)
            {
                nhanViens = nhanViens.Where(g => g.TaiKhoan.TinhTrang == true);
            }
            else if (xoa == 0 && (keysearch != "" || IdPB != 0))
            {
                if (keysearch != null && IdPB == 0)
                {
                    nhanViens = nhanViens.Where(g => g.TaiKhoan.TinhTrang == true && g.HoTen.Contains(keysearch));

                }
                else if (keysearch == null && IdPB > 0)
                {
                    nhanViens = nhanViens.Where(g => g.TaiKhoan.TinhTrang == true && g.IdPB == IdPB);

                }
                else if (keysearch != null && IdPB > 0)
                {
                    nhanViens = nhanViens.Where(g => g.TaiKhoan.TinhTrang == true && g.IdPB == IdPB && g.HoTen.Contains(keysearch));
                }
            }
            else if (xoa != 0 && keysearch == "")
            {
                nhanViens = nhanViens.Where(g => g.TaiKhoan.TinhTrang == false);
            }
            if (Session["ID_TKadmin"] != null)
            {
                ViewData["PhongBan"] = db.PhongBans.AsQueryable().ToList();
                if (page == null) page = 1;
                var books = nhanViens.OrderBy(g => g.HoTen);
                int pageSize = 10;
                int pageNumber = (page ?? 1);
                ViewBag.total = nhanViens.Count();
                return View(books.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }

        // GET: NhanVien/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // GET: NhanVien/Create
        public ActionResult Create()
        {
            ViewBag.IdPB = new SelectList(db.PhongBans, "Id", "TenPhongBan");
            ViewBag.IdTDHV = new SelectList(db.TrinhDoHocVans, "Id", "TrinhDo");
            ViewBag.IdTK = new SelectList(db.TaiKhoans, "Id", "TenDangNhap");
            ViewBag.IdCV = new SelectList(db.ChucVus, "Id", "TenCV");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,HoTen,Email,SDT,GioiTinh,NgaySinh,QueQuan,DanToc,BacLuong,ChuyenNganh,IdTDHV,IdPB,IdTK,Luong,STK,NganHang")] NhanVien nhanVien)
        {
            try
            {
                if (nhanVien.HoTen == null || nhanVien.NgaySinh == null || nhanVien.QueQuan == null || nhanVien.DanToc == null || nhanVien.BacLuong == null || nhanVien.ChuyenNganh == null || nhanVien.STK == null || nhanVien.NganHang == null || nhanVien.Luong == null)
                {
                    ViewBag.IdPB = new SelectList(db.PhongBans, "Id", "TenPhongBan", nhanVien.IdPB);
                    ViewBag.IdTDHV = new SelectList(db.TrinhDoHocVans, "Id", "TrinhDo", nhanVien.IdTDHV);
                    ViewBag.IdCV = new SelectList(db.ChucVus, "Id", "TenCV");
                    ViewBag.IdTK = new SelectList(db.TaiKhoans, "Id", "TenDangNhap", nhanVien.IdTK);
                    ViewBag.TBNull = 1;
                    return View(nhanVien);
                }
                var email = db.NhanViens.FirstOrDefault(g => g.Email.Contains(nhanVien.Email));
                if (email != null)
                {
                    ViewBag.email = "Email bị trùng yêu cầu nhập lại";
                    ViewBag.IdPB = new SelectList(db.PhongBans, "Id", "TenPhongBan");
                    ViewBag.IdTDHV = new SelectList(db.TrinhDoHocVans, "Id", "TrinhDo");
                    ViewBag.IdTK = new SelectList(db.TaiKhoans, "Id", "TenDangNhap");
                    ViewBag.IdCV = new SelectList(db.ChucVus, "Id", "TenCV");
                    return View(nhanVien);
                }
                if (nhanVien.SDT.Length != 10)
                {
                    ViewBag.SDT = "Số điện thoại sai định dạng";
                }
                var sdt = db.NhanViens.FirstOrDefault(g => g.SDT.Contains(nhanVien.SDT));
                if (sdt != null)
                {
                    ViewBag.IdPB = new SelectList(db.PhongBans, "Id", "TenPhongBan");
                    ViewBag.IdTDHV = new SelectList(db.TrinhDoHocVans, "Id", "TrinhDo");
                    ViewBag.IdTK = new SelectList(db.TaiKhoans, "Id", "TenDangNhap");
                    ViewBag.IdCV = new SelectList(db.ChucVus, "Id", "TenCV");
                    ViewBag.SDT = "Số điện thoại bị trùng yêu cầu nhập lại";
                    return View(nhanVien);
                }
                TaiKhoan tk = new TaiKhoan();
                tk.TenDangNhap = nhanVien.Email;
                tk.MatKhau = "quanlynhansu123@";
                tk.TinhTrang = true;
                tk.IdCV = Convert.ToInt32(Request["IdCV"]);
                nhanVien.GioiTinh = Request["GioiTinh"] == "0" ? true : false;
                db.TaiKhoans.Add(tk);
                nhanVien.IdTK = tk.Id;
                db.NhanViens.Add(nhanVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.IdPB = new SelectList(db.PhongBans, "Id", "TenPhongBan", nhanVien.IdPB);
                ViewBag.IdTDHV = new SelectList(db.TrinhDoHocVans, "Id", "TrinhDo", nhanVien.IdTDHV);
                ViewBag.IdCV = new SelectList(db.ChucVus, "Id", "TenCV");
                ViewBag.IdTK = new SelectList(db.TaiKhoans, "Id", "TenDangNhap", nhanVien.IdTK);
                return View(nhanVien);
            }


        }

        // GET: NhanVien/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPB = db.PhongBans.AsQueryable().ToList();
            ViewBag.IdTDHV = db.TrinhDoHocVans.AsQueryable().ToList();
            ViewBag.IdCV = db.ChucVus.AsQueryable().ToList();
            return View(nhanVien);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,HoTen,Email,SDT,GioiTinh,NgaySinh,QueQuan,DanToc,BacLuong,ChuyenNganh,IdTDHV,IdPB,IdTK,Luong,STK,NganHang")] NhanVien nhanVien)
        {
            try
            {
                if (nhanVien.HoTen == null || nhanVien.NgaySinh == null || nhanVien.QueQuan == null || nhanVien.DanToc == null || nhanVien.BacLuong == null || nhanVien.ChuyenNganh == null || nhanVien.STK == null || nhanVien.NganHang == null || nhanVien.Luong == null)
                {
                    ViewBag.IdPB = new SelectList(db.PhongBans, "Id", "TenPhongBan", nhanVien.IdPB);
                    ViewBag.IdTDHV = new SelectList(db.TrinhDoHocVans, "Id", "TrinhDo", nhanVien.IdTDHV);
                    ViewBag.IdCV = new SelectList(db.ChucVus, "Id", "TenCV");
                    ViewBag.IdTK = new SelectList(db.TaiKhoans, "Id", "TenDangNhap", nhanVien.IdTK);
                    ViewBag.TBNull = 1;
                    return View(nhanVien);
                }
                TaiKhoan tk = db.TaiKhoans.Find(nhanVien.IdTK);
                tk.IdCV = Convert.ToInt32(Request["IdCV"]);
                db.Entry(nhanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.IdPB = new SelectList(db.PhongBans, "Id", "TenPhongBan");
                ViewBag.IdTDHV = new SelectList(db.TrinhDoHocVans, "Id", "TrinhDo");
                ViewBag.IdTK = new SelectList(db.TaiKhoans, "Id", "TenDangNhap");
                ViewBag.IdCV = new SelectList(db.ChucVus, "Id", "TenCV");
                return View(nhanVien);
            }

        }
        public ActionResult HopDong(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.Id = id;
            HopDong nhanVien = db.HopDongs.FirstOrDefault(g => g.IdNV == id);
            return View(nhanVien);
        }

        // POST: NhanVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HopDong([Bind(Include = "Id,IdNV,LoaiHD,NgayKi,NgayKT")] HopDong hopDong)
        {
            try
            {
                if (hopDong.Id == null)
                {
                    var idtk =
                    db.HopDongs.Add(hopDong);
                }
                else
                {
                    db.HopDongs.AddOrUpdate(hopDong);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(hopDong);
            }

        }


        // GET: NhanVien/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: NhanVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NhanVien nhanVien = db.NhanViens.Find(id);
            TaiKhoan tk = db.TaiKhoans.Find(nhanVien.IdTK);
            tk.TinhTrang = false;
            db.TaiKhoans.AddOrUpdate(tk);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Reset(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan tk = db.TaiKhoans.Find(id);
            tk.TinhTrang = true;
            db.TaiKhoans.AddOrUpdate(tk);
            db.SaveChanges();
            return RedirectToAction("Index", "NhanVien", new { xoa = 1 });
        }
        public ActionResult DeleteEnd(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            TaiKhoan tk = db.TaiKhoans.Find(nhanVien.IdTK);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            db.NhanViens.Remove(nhanVien);
            db.TaiKhoans.Remove(tk);
            db.SaveChanges();
            return RedirectToAction("Index", "NhanVien", new { xoa = 1 });
        }
        public ActionResult EditTT(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPB = db.PhongBans.AsQueryable().ToList();
            ViewBag.IdTDHV = db.TrinhDoHocVans.AsQueryable().ToList();
            ViewBag.IdCV = db.ChucVus.AsQueryable().ToList();
            return View(nhanVien);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTT([Bind(Include = "Id,HoTen,Email,SDT,GioiTinh,NgaySinh,QueQuan,DanToc,BacLuong,ChuyenNganh,IdTDHV,IdPB,IdTK,Luong,STK,NganHang")] NhanVien nhanVien)
        {
            try
            {
                if (nhanVien.HoTen == null || nhanVien.NgaySinh == null || nhanVien.QueQuan == null || nhanVien.DanToc == null || nhanVien.BacLuong == null || nhanVien.ChuyenNganh == null || nhanVien.STK == null || nhanVien.NganHang == null || nhanVien.Luong == null)
                {
                    ViewBag.IdPB = new SelectList(db.PhongBans, "Id", "TenPhongBan", nhanVien.IdPB);
                    ViewBag.IdTDHV = new SelectList(db.TrinhDoHocVans, "Id", "TrinhDo", nhanVien.IdTDHV);
                    ViewBag.IdCV = new SelectList(db.ChucVus, "Id", "TenCV");
                    ViewBag.IdTK = new SelectList(db.TaiKhoans, "Id", "TenDangNhap", nhanVien.IdTK);
                    ViewBag.TBNull = 1;
                    return View(nhanVien);
                }
                nhanVien.GioiTinh = Request["GioiTinh"] == "0" ? true : false;
                nhanVien.NgaySinh = Convert.ToDateTime(Request["NgaySinh"]);
                db.Entry(nhanVien).State = EntityState.Modified;
                db.SaveChanges();
                Session["HoTenadmin"] = nhanVien.HoTen;
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.IdPB = new SelectList(db.PhongBans, "Id", "TenPhongBan");
                ViewBag.IdTDHV = new SelectList(db.TrinhDoHocVans, "Id", "TrinhDo");
                ViewBag.IdTK = new SelectList(db.TaiKhoans, "Id", "TenDangNhap");
                ViewBag.IdCV = new SelectList(db.ChucVus, "Id", "TenCV");
                return View(nhanVien);
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
        public string XuatExcel()
        {
            using (var package = new ExcelPackage())
            {
                var list = db.NhanViens.AsQueryable().ToList();
                if (list == null || !list.Any())
                {
                    return null;
                }

                var maxCol = 15;
                int iRow = 1;
                int icol = 1;

                var ws = package.Workbook.Worksheets.Add("DanhSachNhanVien");
                ws.Cells[1, 1, 1, maxCol].Merge = true;
                ws.Cells[1, 1, 1, maxCol].Style.Font.Bold = true;
                ws.Cells[1, 1, 1, maxCol].Value = "Thống kê danh sách nhân viên trong công ty";
                ws.Cells[1, 1, 1, maxCol].Style.Font.Bold = true;
                ws.Cells[1, 1, 1, maxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[1, 1, 1, maxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                iRow = 2;
                ws.Cells[iRow, 1, iRow, maxCol].Merge = true;
                ws.Cells[iRow, 1, iRow, maxCol].Style.Font.Bold = true;
                ws.Cells[iRow, 1, iRow, maxCol].Value = "Danh sách nhân viên";
                ws.Cells[iRow, 1, iRow, maxCol].Style.Font.Bold = true;
                ws.Cells[iRow, 1, iRow, maxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[iRow, 1, iRow, maxCol].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                ws.Row(2).Height = 40;

                iRow = 3;


                icol = 1;
                ws.Column(icol).Width = 5;
                ws.Cells[iRow, icol++].Value = "STT";
                ws.Column(icol).Width = 30;
                ws.Cells[iRow, icol++].Value = "Họ tên nhân viên";
                ws.Column(icol).Width = 30;
                ws.Cells[iRow, icol++].Value = "Email";
                ws.Column(icol).Width = 20;
                ws.Cells[iRow, icol++].Value = "Số điện thoại";
                ws.Column(icol).Width = 10;
                ws.Cells[iRow, icol++].Value = "Giới tính";
                ws.Column(icol).Width = 15;
                ws.Cells[iRow, icol++].Value = "Ngày sinh";
                ws.Column(icol).Width = 30;
                ws.Cells[iRow, icol++].Value = "Quê quán";
                ws.Column(icol).Width = 15;
                ws.Cells[iRow, icol++].Value = "Dân tộc";
                ws.Column(icol).Width = 10;
                ws.Cells[iRow, icol++].Value = "Bậc lương";
                ws.Column(icol).Width = 30;
                ws.Cells[iRow, icol++].Value = "Chuyên ngành";
                ws.Column(icol).Width = 30;
                ws.Cells[iRow, icol++].Value = "Lương";
                ws.Column(icol).Width = 30;
                ws.Cells[iRow, icol++].Value = "Số tài khoản";
                ws.Column(icol).Width = 30;
                ws.Cells[iRow, icol++].Value = "Ngân hàng";
                ws.Column(icol).Width = 30;
                ws.Cells[iRow, icol++].Value = "Phòng ban";
                ws.Column(icol).Width = 30;
                ws.Cells[iRow, icol++].Value = "Trình độ học vấn";
                int i = 0;
                i = i + 1;
                foreach (var item in list)
                {
                    iRow++;
                    icol = 1;
                    ws.Cells[iRow, icol++].Value = (i++).ToString();
                    ws.Cells[iRow, icol++].Value = item.HoTen;
                    ws.Cells[iRow, icol++].Value = item.Email;
                    ws.Cells[iRow, icol++].Value = item.SDT;
                    ws.Cells[iRow, icol++].Value = item.GioiTinh == true ? "Nam" : "Nữ";
                    ws.Cells[iRow, icol++].Value = item.NgaySinh != null ? item.NgaySinh.Value.ToString("dd-MM-yyyy") : "";
                    ws.Cells[iRow, icol++].Value = item.QueQuan;
                    ws.Cells[iRow, icol++].Value = item.DanToc;
                    ws.Cells[iRow, icol++].Value = item.BacLuong;
                    ws.Cells[iRow, icol++].Value = item.ChuyenNganh;
                    ws.Cells[iRow, icol++].Value = QuanLyNhanSu.Models.conver.ConvertToThousand64_From_Float(item.Luong) + "VNĐ";
                    ws.Cells[iRow, icol++].Value = item.STK;
                    ws.Cells[iRow, icol++].Value = item.NganHang;
                    ws.Cells[iRow, icol++].Value = item.PhongBan.TenPhongBan;
                    ws.Cells[iRow, icol++].Value = item.TrinhDoHocVan.TrinhDo;
                }

                // căn giữa
                ws.Cells[3, 1, iRow, maxCol].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                // khung viền
                ws.Cells[3, 1, iRow, maxCol].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                ws.Cells[3, 1, iRow, maxCol].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Cells[3, 1, iRow, maxCol].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                ws.Cells[3, 1, iRow, maxCol].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                ws.Cells[3, 1, iRow, maxCol].Style.WrapText = true;

                System.Web.HttpContext.Current.Response.Clear();
                System.Web.HttpContext.Current.Response.AddHeader("content-disposition", "attachment;  filename=" + string.Format("DanhSachNhanVien{0}.xlsx", DateTime.Now.ToString("yyyyMMdd_HHmmss")));
                System.Web.HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                System.Web.HttpContext.Current.Response.BinaryWrite(package.GetAsByteArray());
                System.Web.HttpContext.Current.Response.End();
            }
            return null;
        }
    }
}
