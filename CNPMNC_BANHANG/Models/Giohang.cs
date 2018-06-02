using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNPMNC_BANHANG.Models
{
    public class Giohang
    {
        BANHANGDBDataContext data = new BANHANGDBDataContext();

        public int iMasp { get; set; }
        public string sTensp { get; set; }
        public string sAnhbia { get; set; }
        public double dDongia { get; set; }
        public int iSoluong { get; set; }
        public double dThanhtien
        {
            get { return dDongia * iSoluong; }
        }
        public Giohang(int Masp)
        {
            iMasp = Masp;
            SANPHAM sp = data.SANPHAMs.Single(n => n.masanpham == iMasp);
            sTensp = sp.tensanpham;
            sAnhbia = sp.hinh;
            dDongia = double.Parse(sp.gia.ToString());
            iSoluong = 1;
        }
    }
}