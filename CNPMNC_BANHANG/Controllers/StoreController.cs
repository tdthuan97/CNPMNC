using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNPMNC_BANHANG.Models;
using PagedList;
using PagedList.Mvc;

namespace CNPMNC_BANHANG.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store

        BANHANGDBDataContext data = new BANHANGDBDataContext();


        private List<SANPHAM> laySanPham()
        {
            return data.SANPHAMs.
                Where(a=>a.trangthai == true && a.LOAISANPHAM.trangthai == true && a.NHACUNGCAP.trangthai==true).
                OrderByDescending(a => a.ngaycapnhat).
                ToList();
        }

        public ActionResult Index(int? page, string searchString)
        {

            Session["LoaiSP"] = null;
            ViewBag.Thongbao = "Sản phẩm mới nhất";
            var sp = laySanPham();
            
            if (!String.IsNullOrEmpty(searchString))
            {   
                sp = data.SANPHAMs.
                    Where(n => n.tensanpham.ToLower().Contains(searchString.ToLower())&& n.trangthai == true && n.LOAISANPHAM.trangthai == true && n.NHACUNGCAP.trangthai == true).
                    OrderByDescending(a => a.tensanpham).
                    ToList();
                ViewBag.Search = searchString;
                ViewBag.Ketqua = "Có " + sp.Count() + " sản phẩm được tìm thấy theo \"" + searchString + "\"";
            }
            int pageSize = 9;

            int pageNum = (page ?? 1);
            return View(sp.ToPagedList(pageNum, pageSize));
        }
        public ActionResult LoaiSanPham()
        {
            var loai = from l in data.LOAISANPHAMs where l.trangthai == true select l;
            return PartialView(loai);
        }
        public ActionResult SPTheoLoai(int? page, int maloai, string searchString)
        {
            
            var sp = from s in data.SANPHAMs where s.maloai == maloai && s.trangthai == true && s.NHACUNGCAP.trangthai == true select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                sp = from s in data.SANPHAMs
                     where s.maloai == maloai && s.tensanpham.Contains(searchString) && s.trangthai == true && s.NHACUNGCAP.trangthai == true
                     select s;
                ViewBag.Search = searchString;
                ViewBag.Ketqua = "Có " + sp.Count() + " sản phẩm được tìm thấy theo \"" + searchString + "\"";
            }
            LOAISANPHAM loai = data.LOAISANPHAMs.SingleOrDefault(a => a.maloai == maloai);
            ViewBag.Thongbao = loai.tenloai;
            Session["LoaiSP"] = loai;

            int pageSize = 9;
            int pageNum = (page ?? 1);
            return View(sp.ToPagedList(pageNum, pageSize));
        }
        public ActionResult NCCTheoLoai()
        {
            LOAISANPHAM l = (LOAISANPHAM)Session["LoaiSP"];
            var ncc = from x in data.NHACUNGCAPs
                      where x.maloai == l.maloai && x.trangthai == true
                      select x;
            return PartialView(ncc);
        }
        public ActionResult SPTheoLoaiCuaNCC(int? page, int mancc, string searchString)
        {
            
            LOAISANPHAM l = (LOAISANPHAM)Session["LoaiSP"];
            var sp = from s in data.SANPHAMs
                     where s.maloai == l.maloai && s.mancc == mancc && s.trangthai == true
                     select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                sp = from s in data.SANPHAMs
                     where s.maloai == l.maloai && s.mancc == mancc && s.tensanpham.Contains(searchString) && s.trangthai == true
                     select s;
                ViewBag.Search = searchString;
                ViewBag.Ketqua = "Có " + sp.Count() + " sản phẩm được tìm thấy theo \"" + searchString + "\"";
            }
            NHACUNGCAP ncc = data.NHACUNGCAPs.SingleOrDefault(a => a.mancc == mancc && a.maloai == l.maloai);
            ViewBag.Thongbao = l.tenloai + " " + ncc.tenncc;
            int pageSize = 9;
            int pageNum = (page ?? 1);
            return View(sp.ToPagedList(pageNum, pageSize));

        }
        public ActionResult Details(int masp, String searchString)
        {
            Session["LoaiSP"] = null;
            var sp = from s in data.SANPHAMs
                     where s.masanpham == masp
                     select s;
            if (!String.IsNullOrEmpty(searchString))
                return RedirectToAction("Index");
            return View(sp.Single());
        }
    }
}