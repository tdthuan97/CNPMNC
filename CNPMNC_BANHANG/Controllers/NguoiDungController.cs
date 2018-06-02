using CNPMNC_BANHANG.Models;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNPMNC_BANHANG.Controllers
{
    public class NguoiDungController : Controller
    {
        BANHANGDBDataContext data = new BANHANGDBDataContext();


        // GET: NguoiDung
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Dangky()
        {
            Session["LoaiSP"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult Dangky(FormCollection collection, KHACHHANG kh)
        {
            
            var hoten = collection["HoTenKH"];
            var tendn = collection["TenDN"];
            bool contain = false;
            bool existEmail = false;
            if (!String.IsNullOrEmpty(tendn))
            {
                contain = data.KHACHHANGs.Any(n => n.username.Equals(tendn));
            }
            
            var matkhau = collection["Matkhau"];
            var matkhaunhaplai = collection["Matkhaunhaplai"];
            var diachi = collection["DiachiKH"];
            var email = collection["Email"];
            if (!String.IsNullOrEmpty(email))
            {
                existEmail = data.KHACHHANGs.Any(n => n.email.Equals(email));
            }
            var dienthoai = collection["DienthoaiKH"];
            var phai = collection["gioitinh"];
            if (String.IsNullOrEmpty(hoten))
            {
                ViewData["Loi1"] = "Họ tên khách hàng không được để trống";
            }
            else if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi2"] = "Phải nhập tên đăng nhập";
            }
            else if (contain)
            {
                ViewData["Loi2"] = "Tên đăng nhập đã tồn tại";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi3"] = "Phải nhập mật khẩu";
            }
            else if (String.IsNullOrEmpty(matkhaunhaplai))
            {
                ViewData["Loi4"] = "Phải nhập lại mật khẩu";
            }
            else if (String.IsNullOrEmpty(diachi))
            {
                ViewData["Loi5"] = "Phải nhập địa chỉ";
            }
            else if (existEmail)
            {
                ViewData["Loi7"] = "Email đã tồn đã. Vui lòng sử dụng email khác";
            }
            else if (String.IsNullOrEmpty(dienthoai))
            {
                ViewData["Loi6"] = "Phải nhập điện thoại";
            }
            else if (!matkhau.Equals(matkhaunhaplai))
            {
                ViewData["Loi4"] = "Mật khẩu không trùng khớp";
            }
            else
            {
                kh.hoten = hoten;
                kh.username = tendn;
                kh.password = matkhau;
                kh.email = email;
                kh.sdt = dienthoai;
                kh.diachi = diachi;
                if (!String.IsNullOrEmpty(phai))
                {
                    if (phai.Equals("1"))
                        kh.gioitinh = true;
                    else if (phai.Equals("2"))
                        kh.gioitinh = false;
                }
                data.KHACHHANGs.InsertOnSubmit(kh);
                data.SubmitChanges();
                return RedirectToAction("Dangnhap");
            }
            return this.Dangky();
        }
        [HttpGet]
        public ActionResult Dangnhap()
        {
            Session["LoaiSP"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult Dangnhap(FormCollection collection)
        {
            var tendn = collection["TenDN"];
            var matkhau = collection["Matkhau"];
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu";
            }
            else
            {
                KHACHHANG kh = data.KHACHHANGs.SingleOrDefault(n => n.username == tendn && n.password == matkhau);
                if (kh != null)
                {
                    //ViewBag.Thongbao = "Chúc mừng đăng nhập thành công";
                    Session["Taikhoan"] = kh;
                    if(Session["Giohang"] != null)
                        return RedirectToAction("Giohang", "Giohang");
                    return RedirectToAction("Index", "Store");
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();
        }
        public ActionResult Xinchao()
        {
            KHACHHANG kh = (KHACHHANG)Session["Taikhoan"];
            if (kh != null)
                ViewBag.Thongbao = "Xin chào " + kh.hoten;
            else
                ViewBag.Thongbao = "Đăng nhập";
            return PartialView();
        }
        public ActionResult Logout()
        {
            Session["Taikhoan"] = null;
            return RedirectToAction("Index", "Store");
        }
        public ActionResult Donhang()
        {
            KHACHHANG kh = (KHACHHANG)Session["taikhoan"];
            if (kh == null) return RedirectToAction("Index", "Store");
            var dsctdh = data.CHITIETDONHANGs.Where(x => x.DONHANG.makh == kh.makh).OrderByDescending(n => n.DONHANG.ngaytao).ToList();
            return View(dsctdh);
        }
        [HttpGet]
        public ActionResult ThongtinNguoidung()
        {
            KHACHHANG kh = (KHACHHANG)Session["taikhoan"];
            if (kh == null) return RedirectToAction("Index", "Store");
            var x = data.KHACHHANGs.Where(n => n.makh == kh.makh).SingleOrDefault();
            ViewBag.Nam = false;
            ViewBag.Nu = false;
            if (x.gioitinh == true)
                ViewBag.Nam = true;
            else if(x.gioitinh == false)
                ViewBag.Nu = true;
            return View(x);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThongtinNguoidung(FormCollection form)
        {

            KHACHHANG tmp = (KHACHHANG)Session["taikhoan"];
            KHACHHANG kh = data.KHACHHANGs.ToList().Find(n => n.makh == tmp.makh);
            var hoten = form["hoten"];
            var gioitinh = form["gioitinh"];
            bool gt = false;
            var diachi = form["diachi"];
            var email = form["email"];
            var sdt = form["sdt"];
            if (String.IsNullOrEmpty(hoten))
                ViewData["Loi1"] = "Họ tên không được để trống";
            else if (String.IsNullOrEmpty(diachi))
                ViewData["Loi2"] = "Địa chỉ không được để trống";
            else if (String.IsNullOrEmpty(sdt))
                ViewData["Loi3"] = "Số điện thoại không được để trống";
            else if (ModelState.IsValid)
            {
                String tt = kh.hoten;
                kh.hoten = hoten;
                if (!String.IsNullOrEmpty(gioitinh))
                {
                    if (int.Parse(gioitinh) == 1) gt = true;
                    else gt = false;
                    kh.gioitinh = gt;
                }
                kh.diachi = diachi;
                kh.email = email;
                kh.sdt = sdt;
                Session["taikhoan"] = kh;
                data.SubmitChanges();
                return RedirectToAction("ThongtinNguoidung");
            }
            return this.ThongtinNguoidung();
        }
        
    }
}