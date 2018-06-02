using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNPMNC_BANHANG.Models;
using System.IO;
using PagedList;
using PagedList.Mvc;
using System.Web.Script.Serialization;
using CrystalDecisions.CrystalReports.Engine;
using CNPMNC_BANHANG.CrystalReports;

namespace CNPMNC_BANHANG.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        BANHANGDBDataContext data = new BANHANGDBDataContext();

        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.UserName = User.Identity.Name;
            return View();
        }
        public ActionResult Sanpham()
        {
            //int pageSize = 5;
            //int pageNum = (page ?? 1);
            var sp = data.SANPHAMs.ToList().OrderBy(n => n.masanpham);
            /*if (!String.IsNullOrEmpty(searchString))
            {
                sp = data.SANPHAMs.Where(n => n.tensanpham.Contains(searchString)).OrderBy(a => a.tensanpham).ToPagedList(pageNum, pageSize);
                ViewBag.Search = searchString;
                ViewBag.Ketqua = "Có " + sp.Count() + " sản phẩm được tìm thấy theo \"" + searchString + "\"";
            }*/

            return View(sp);
        }


        [HttpGet]
        public ActionResult Themmoisanpham()
        {
            //var dropdownDataList = ;

            var loaisp = data.LOAISANPHAMs.Where(n => n.trangthai == true).Select(d => new
            {
                id = d.maloai,
                name = d.tenloai
            });
            ViewBag.DropdownListOptions = new SelectList(loaisp, "id", "name");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Themmoisanpham(SANPHAM sp, HttpPostedFileBase fileUpload, FormCollection form)
        {
            if (String.IsNullOrEmpty(sp.tensanpham))
                ViewData["Loi1"] = "Vui lòng nhập tên sản phẩm";
            else if (sp.gia == 0)
                ViewData["Loi2"] = "Vui lòng nhập giá sản phẩm";
            else if (String.IsNullOrEmpty(sp.mota))
                ViewData["Loi3"] = "Vui lòng nhập mô tả sản phẩm";
            else if (fileUpload == null)
                ViewBag.Thongbao = "Vui lòng chọn ảnh";
            else
            {
                int t = -1;
                try
                {
                    int maloai = int.Parse(form["maloai"].ToString());
                    t = maloai;
                }
                catch (Exception ex)
                {
                    ViewData["Loi4"] = "Vui lòng chọn loại sản phẩm";
                    return this.Themmoisanpham();
                }

                var count = data.NHACUNGCAPs.Where(n => n.maloai == t).ToList();
                if (count.Count == 0)
                {
                    ViewData["Loi5"] = "Hiện tại chưa có nhà cung cấp nào... Xin vui lòng chọn loại sản phẩm khác !";
                    return this.Themmoisanpham();
                }
                else
                {
                    try
                    {
                        int mancc = int.Parse(form["mancc"].ToString());
                    }
                    catch (Exception ex)
                    {
                        ViewData["Loi5"] = "Vui lòng chọn nhà cung cấp";
                        return this.Themmoisanpham();
                    }
                }
                if (ModelState.IsValid)
                {
                    var filename = Path.GetFileName(fileUpload.FileName);
                    var path = Path.Combine(Server.MapPath("~/img"), filename);
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.Thongbao = "Hình đã tồn tại";
                    }
                    else
                    {
                        fileUpload.SaveAs(path);
                    }
                    sp.ngaycapnhat = DateTime.Now;
                    sp.trangthai = true;
                    sp.hinh = filename;
                    data.SANPHAMs.InsertOnSubmit(sp);
                    data.SubmitChanges();
                    return RedirectToAction("Sanpham");
                }
            }
            return this.Themmoisanpham();
        }

        [HttpGet]
        public ActionResult GetNhaCungCap(string maloai)
        {
            int loai;
            string input = Request["maloai"];
            List<SelectListItem> tenNCC = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(maloai))
            {
                loai = Convert.ToInt32(input);
                List<NHACUNGCAP> nccs = data.NHACUNGCAPs.Where(x => x.maloai == loai && x.trangthai == true).ToList();
                //tenNCC = new SelectList(data.NHACUNGCAPs.Where(x => x.maloai == loai).ToList(), "mancc", "tenncc");
                nccs.ForEach(x =>
                {
                    tenNCC.Add(new SelectListItem { Text = x.tenncc, Value = x.mancc.ToString() });
                });
            }
            return Json(tenNCC, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Chitietsanpham(int id)
        {
            SANPHAM sp = data.SANPHAMs.SingleOrDefault(n => n.masanpham == id);
            ViewBag.Masp = sp.masanpham;
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sp);
        }
        [HttpGet]
        public ActionResult Xoasanpham(int id)
        {
            SANPHAM sp = data.SANPHAMs.SingleOrDefault(n => n.masanpham == id);
            ViewBag.Masp = sp.masanpham;
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sp);
        }
        [HttpPost, ActionName("Xoasanpham")]
        public ActionResult Xacnhanxoa(int id)
        {
            SANPHAM sp = data.SANPHAMs.SingleOrDefault(n => n.masanpham == id);
            ViewBag.Masp = sp.masanpham;
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            data.SANPHAMs.DeleteOnSubmit(sp);
            data.SubmitChanges();
            return RedirectToAction("Sanpham");
        }
        [HttpGet]
        public ActionResult Suasanpham(int id)
        {
            SANPHAM sp = data.SANPHAMs.SingleOrDefault(n => n.masanpham == id);
            ViewBag.Masp = sp.masanpham;
            ViewBag.Mota = sp.mota;
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            var loaisp = data.LOAISANPHAMs.Where(n => n.trangthai == true).Select(d => new
            {
                id = d.maloai,
                name = d.tenloai
            });
            ViewBag.DropdownListOptions = new SelectList(loaisp, "id", "name",sp.maloai);
            var ncc = data.NHACUNGCAPs.Where(n => n.maloai == sp.maloai && n.trangthai == true).Select(d => new
            {
                id = d.mancc,
                name = d.tenncc
            });
            ViewBag.DropdownListOptionsNCC = new SelectList(ncc, "id", "name",sp.mancc);

            return View(sp);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Suasanpham(SANPHAM sp, HttpPostedFileBase uploadFile, FormCollection form)
        {
            //ViewBag.MaCD = new SelectList(data.CHUDEs.ToList().OrderBy(n => n.TenChuDe), "MaCD", "TenChude", sach.MaCD);
            //ViewBag.MaNXB = new SelectList(data.NHAXUATBANs.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB", sach.MaNXB);ViewBag.Mota = sp.mota;
            
            var count = data.NHACUNGCAPs.Where(n => n.maloai == sp.maloai).ToList();
            SANPHAM s = data.SANPHAMs.ToList().Find(n => n.masanpham == sp.masanpham);
            if (String.IsNullOrEmpty(sp.tensanpham))
                ViewData["Loi1"] = "Vui lòng nhập tên sản phẩm";
            else if (sp.gia == 0)
                ViewData["Loi2"] = "Vui lòng nhập giá sản phẩm";
            else if (String.IsNullOrEmpty(sp.mota))
                ViewData["Loi3"] = "Vui lòng nhập mô tả sản phẩm";
            else if (count.Count == 0)
            {
                ViewData["Loi5"] = "Hiện tại chưa có nhà cung cấp nào... Xin vui lòng chọn loại sản phẩm khác !";
                sp.maloai = s.maloai;
                return this.Suasanpham(sp.masanpham);
            }
            else if (ModelState.IsValid)
            {
                
                
                if (uploadFile != null)
                {
                    var fileName = Path.GetFileName(uploadFile.FileName);
                    var path = Path.Combine(Server.MapPath("~/img"), fileName);
                    if (fileName != "")
                    {
                        uploadFile.SaveAs(path);
                        s.hinh = fileName;
                    }
                }
                s.tensanpham = sp.tensanpham;
                s.gia = sp.gia;
                s.mota = sp.mota;
                s.maloai = sp.maloai;
                s.mancc = sp.mancc;
                s.ngaycapnhat = DateTime.Now;
                s.trangthai = sp.trangthai;
                data.SubmitChanges();
                return RedirectToAction("Sanpham");
            }
            return this.Suasanpham(sp.masanpham);
        }
        public ActionResult Donhang()
        {
            //int pageSize = 5;
            //int pageNum = (page ?? 1);
            var dh = data.DONHANGs.ToList().OrderBy(n => n.mahd);
            /*if (!String.IsNullOrEmpty(searchString))
            {
                dh = data.DONHANGs.Where(n => n.KHACHHANG.hoten.Contains(searchString)).OrderBy(n => n.KHACHHANG.hoten).OrderByDescending(n => n.ngaytao).ToPagedList(pageNum, pageSize);
                ViewBag.Search = searchString;
                ViewBag.Ketqua = "Có " + dh.Count() + " đơn hàng được tìm thấy theo khách hàng \"" + searchString + "\"";
            }*/
            return View(dh);
        }
        public ActionResult Chitiethoadon(int id)
        {
            var cthd = from s in data.CHITIETDONHANGs
                       where s.mahd == id
                       select s;
            DONHANG dh = data.DONHANGs.Where(n => n.mahd == id).SingleOrDefault();
            ViewData["mahd"] = dh.mahd;
            return View(cthd);
        }
        public ActionResult ExportDonHang(int id)
        {
            DONHANG donHang = data.DONHANGs.Where(n => n.mahd == id).SingleOrDefault();
            KHACHHANG kh = data.KHACHHANGs.Where(n => n.makh == donHang.makh).SingleOrDefault();
            List<CHITIETDONHANG> ctdh = data.CHITIETDONHANGs.Where(n => n.mahd == donHang.mahd).ToList();
            decimal tong = 0;
            DataSetDonHang db = new DataSetDonHang();
            
            for (int i = 0; i < ctdh.Count; i++)
            {
                SANPHAM sp = data.SANPHAMs.Where(n => n.masanpham == ctdh[i].masp).Single();
                db.DataTable1.AddDataTable1Row(donHang.mahd, kh.hoten,sp.masanpham,sp.tensanpham, String.Format("{0:0,0}", ctdh[i].thanhtien / ctdh[i].soluong)+" VNĐ", (int)ctdh[i].soluong, String.Format("{0:0,0}", ctdh[i].thanhtien)+" VNĐ" , kh.sdt, kh.email, kh.diachi);
                tong += (decimal)ctdh[i].thanhtien;
            }
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "ReportDonHang.rpt"));

            db.DataTable2.AddDataTable2Row(String.Format("{0:0,0}", tong)+" VNĐ");
            rd.SetDataSource(db);
            

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "DonHang.pdf");
        }
        [HttpGet]
        public ActionResult Capnhatctdh(int id)
        {

            CHITIETDONHANG ctdh = data.CHITIETDONHANGs.Where(n => n.mactdh == id).SingleOrDefault();
            ViewBag.Tinhtrang = new SelectList(data.TINHTRANGs.OrderBy(n => n.matinhtrang).ToList(), "matinhtrang", "tentinhtrang", ctdh.matinhtrang);
            return View(ctdh);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Capnhatctdh(CHITIETDONHANG ctdh)
        {
            ViewBag.Tinhtrang = new SelectList(data.TINHTRANGs.OrderBy(n => n.matinhtrang).ToList(), "matinhtrang", "tentinhtrang", ctdh.matinhtrang);
            CHITIETDONHANG x = data.CHITIETDONHANGs.ToList().Find(n => n.mactdh == ctdh.mactdh);

            int tt = int.Parse(Request.Form["matinhtrang"].ToString());
            x.matinhtrang = tt;
            if (x.matinhtrang == 3)
                x.ngaygiaothat = DateTime.Now;
            else
                x.ngaygiaothat = null;

            data.SubmitChanges();

            return RedirectToAction("Chitiethoadon", "Admin", new { @id = x.mahd });
        }
        public ActionResult Loaisanpham()
        {
            //int pageSize = 10;
            //int pageNum = (page ?? 1);
            var loai = data.LOAISANPHAMs.ToList().OrderBy(n => n.maloai);
            return View(loai);
        }
        [HttpGet]
        public ActionResult Themloaisanpham()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Themloaisanpham(LOAISANPHAM loai)
        {
            if (String.IsNullOrEmpty(loai.tenloai))
            {
                ViewData["Loi1"] = "Phải nhập tên loại sản phẩm";
            }
            else
            {
                loai.trangthai = true;
                data.LOAISANPHAMs.InsertOnSubmit(loai);
                data.SubmitChanges();
                return RedirectToAction("Loaisanpham");
            }
            return this.Themloaisanpham();
        }
        [HttpGet]
        public ActionResult Sualoaisanpham(int id)
        {
            LOAISANPHAM loai = data.LOAISANPHAMs.SingleOrDefault(n => n.maloai == id);
            if (loai == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(loai);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Sualoaisanpham(LOAISANPHAM loai, FormCollection form)
        {
            //ViewBag.MaCD = new SelectList(data.CHUDEs.ToList().OrderBy(n => n.TenChuDe), "MaCD", "TenChude", sach.MaCD);
            //ViewBag.MaNXB = new SelectList(data.NHAXUATBANs.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB", sach.MaNXB);
            LOAISANPHAM l = data.LOAISANPHAMs.SingleOrDefault(n => n.maloai == loai.maloai);
            if (String.IsNullOrEmpty(loai.tenloai))
            {
                ViewData["Loi1"] = "Phải nhập loại sản phẩm";
            }
            else
            {
                if (ModelState.IsValid)
                {
                    l.tenloai = loai.tenloai;
                    l.trangthai = loai.trangthai;
                    data.SubmitChanges();
                    return RedirectToAction("Loaisanpham");
                }
            }
            return this.Sualoaisanpham(l.maloai);
        }
        public ActionResult Khachhang()
        {
            //int pageSize = 8;
            //int pageNum = (page ?? 1);
            var kh = data.KHACHHANGs.ToList().OrderBy(n => n.makh);
            /*if (!String.IsNullOrEmpty(searchString))
            {
                sp = data.KHACHHANGs.Where(n => n.hoten.Contains(searchString)).OrderBy(a => a.makh).ToPagedList(pageNum, pageSize);
                ViewBag.Search = searchString;
                ViewBag.Ketqua = "Có " + sp.Count() + " khách hàng được tìm thấy theo \"" + searchString + "\"";
            }*/

            return View(kh);
        }
        
        public ActionResult Nhacungcap()
        {
            //int pageSize = 10;D:\CNPMNC_BANHANG\CNPMNC_BANHANG\Controllers\AdminController.cs
            //int pageNum = (page ?? 1);
            var ncc = data.NHACUNGCAPs.ToList().OrderBy(n => n.mancc);
            return View(ncc);
        }
        public ActionResult Themnhacungcap()
        {
            ViewBag.Maloai = new SelectList(data.LOAISANPHAMs.OrderBy(n => n.maloai).ToList(), "maloai", "tenloai");

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Themnhacungcap(NHACUNGCAP nhacc, FormCollection form)
        {
            ViewBag.Maloai = new SelectList(data.LOAISANPHAMs.OrderBy(n => n.maloai).ToList(), "maloai", "tenloai");
            if (String.IsNullOrEmpty(nhacc.tenncc))
            {
                ViewData["Loi1"] = "Phải nhập tên nhà cung cấp";

            }
            else if (String.IsNullOrEmpty(nhacc.diachi))
            {
                ViewData["Loi2"] = "Mời nhập địa chỉ cho nhà cung cấp";
            }
            else
            {
                try
                {
                    int maloai = int.Parse(form["maloai"].ToString());
                }
                catch (Exception ex)
                {
                    ViewData["Loi3"] = "Vui lòng chọn loại sản phẩm";
                    return this.Themnhacungcap();
                }
                nhacc.trangthai = true;
                data.NHACUNGCAPs.InsertOnSubmit(nhacc);
                data.SubmitChanges();
                return RedirectToAction("Nhacungcap");
            }
            return this.Themnhacungcap();
        }
        [HttpGet]
        public ActionResult Suanhacungcap(int id)
        {
            NHACUNGCAP ncc = data.NHACUNGCAPs.SingleOrDefault(n => n.mancc == id);
            if (ncc == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(ncc);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Suanhacungcap(NHACUNGCAP ncc, FormCollection form)
        {
            //ViewBag.MaCD = new SelectList(data.CHUDEs.ToList().OrderBy(n => n.TenChuDe), "MaCD", "TenChude", sach.MaCD);
            //ViewBag.MaNXB = new SelectList(data.NHAXUATBANs.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB", sach.MaNXB);
            NHACUNGCAP n = data.NHACUNGCAPs.SingleOrDefault(x => x.mancc == ncc.mancc);
            if (String.IsNullOrEmpty(ncc.tenncc))
            {
                ViewData["Loi1"] = "Phải nhập tên nhà cung cấp";
            }
            else if (String.IsNullOrEmpty(ncc.diachi))
            {
                ViewData["Loi2"] = "Phải nhập địa chỉ nhà cung cấp";
            }
            else
            {
                if (ModelState.IsValid)
                {
                    n.tenncc = ncc.tenncc;
                    n.diachi = ncc.diachi;
                    n.trangthai = ncc.trangthai;
                    data.SubmitChanges();
                    return RedirectToAction("Nhacungcap");
                }
            }
            return this.Suanhacungcap(ncc.mancc);
        }
    }
}