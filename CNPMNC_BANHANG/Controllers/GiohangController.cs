using CNPMNC_BANHANG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNPMNC_BANHANG.Controllers
{
    public class GiohangController : Controller
    {
        BANHANGDBDataContext data = new BANHANGDBDataContext();

        // GET: Giohang
        public ActionResult Index()
        {
            return View();
        }
        public List<Giohang> Laygiohang()
        {
            List<Giohang> lstGiohang = Session["Giohang"] as List<Giohang>;
            if (lstGiohang == null)
            {
                lstGiohang = new List<Giohang>();
                Session["Giohang"] = lstGiohang;
            }
            return lstGiohang;
        }
        public ActionResult ThemGiohang(int iMaSp, string strURL)
        {
            List<Giohang> lstGiohang = Laygiohang();
            Giohang sanpham = lstGiohang.Find(n => n.iMasp == iMaSp);
            if (sanpham == null)
            {
                sanpham = new Giohang(iMaSp);
                lstGiohang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoluong++;
                return Redirect(strURL);
            }
        }
        private int Tongsoluong()
        {
            int iTongSoluong = 0;
            List<Giohang> lstGiohang = Session["Giohang"] as List<Giohang>;
            if (lstGiohang != null)
                iTongSoluong = lstGiohang.Sum(n => n.iSoluong);
            return iTongSoluong;
        }
        private double TongTien()
        {
            double iTongTien = 0;
            List<Giohang> lstGiohang = Session["Giohang"] as List<Giohang>;
            if (lstGiohang != null)
                iTongTien = lstGiohang.Sum(n => n.dThanhtien);
            return iTongTien;
        }
        public ActionResult Giohang()
        {
            List<Giohang> lstGiohang = Laygiohang();
            if (lstGiohang.Count == 0)
                return RedirectToAction("Index", "Store");
            ViewBag.Tongsoluong = Tongsoluong();
            ViewBag.Tongtien = TongTien();
            return View(lstGiohang);
        }
        public ActionResult GiohangPartial()
        {
            ViewBag.Tongsoluong = Tongsoluong();
            ViewBag.Tongtien = TongTien();
            return PartialView();
        }
        public ActionResult XoaGiohang(int iMaSp)
        {
            List<Giohang> lstGiohang = Laygiohang();
            Giohang sanpham = lstGiohang.SingleOrDefault(n => n.iMasp == iMaSp);
            if (sanpham != null)
            {
                lstGiohang.RemoveAll(n => n.iMasp == iMaSp);
                return RedirectToAction("Giohang");
            }
            if (lstGiohang.Count == 0)
            {
                return RedirectToAction("Index", "Store");
            }
            return RedirectToAction("Giohang");
        }
        public ActionResult CapnhatGiohang(int iMaSp, FormCollection f)
        {
            List<Giohang> lstGiohang = Laygiohang();
            Giohang sanpham = lstGiohang.SingleOrDefault(n => n.iMasp == iMaSp);
            if (sanpham != null)
            {
                sanpham.iSoluong = int.Parse(f["txtSoluong"].ToString());
            }
            return RedirectToAction("Giohang");
        }
        public ActionResult XoaTatcaGiohang()
        {
            List<Giohang> lstGiohang = Laygiohang();
            lstGiohang.Clear();
            return RedirectToAction("Index", "Store");
        }
        [HttpGet]
        public ActionResult Dathang()
        {
            if (Session["Taikhoan"] == null || Session["Taikhoan"].ToString() == "")
            {
                return RedirectToAction("Dangnhap", "Nguoidung");
            }
            if (Session["Giohang"] == null)
            {
                return RedirectToAction("Index", "Store");
            }
            List<Giohang> lstGiohang = Laygiohang();
            ViewBag.Tongsoluong = Tongsoluong();
            ViewBag.Tongtien = TongTien();
            return View(lstGiohang);
        }
        [HttpPost]
        public ActionResult Dathang(FormCollection collection)
        {
            DONHANG ddh = new DONHANG();
            KHACHHANG kh = (KHACHHANG)Session["Taikhoan"];
            List<Giohang> gh = Laygiohang();
            ddh.makh = kh.makh;
            ddh.ngaytao = DateTime.Now;
            var ngaygiao = String.Format("{0:MM/dd/yyyy}", collection["Ngaygiao"]);
            if(String.IsNullOrEmpty(ngaygiao))
            {
                ngaygiao = DateTime.Now.AddDays(3).ToShortDateString();
            }
            data.DONHANGs.InsertOnSubmit(ddh);
            data.SubmitChanges();
            decimal trigia = 0;
            foreach (var item in gh)
            {
                CHITIETDONHANG ctdh = new CHITIETDONHANG();
                ctdh.mahd = ddh.mahd;
                ctdh.masp = item.iMasp;
                ctdh.soluong = item.iSoluong;
                ctdh.ngaygiaodukien = DateTime.Parse(ngaygiao);
                ctdh.thanhtien = (decimal)(item.iSoluong * item.dDongia);
                trigia += (decimal)ctdh.thanhtien; 
                
                ctdh.matinhtrang = 1;
                data.CHITIETDONHANGs.InsertOnSubmit(ctdh);
            }
            ddh.trigia = trigia;
            Session["Giohang"] = null;
            data.SubmitChanges();
        
            return RedirectToAction("Xacnhandonhang", "Giohang");
        }
        public ActionResult Xacnhandonhang()
        {
            return View();
        }
    }
}