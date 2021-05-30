using DatabaseIO;
using DbWebsite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Net;

namespace WebsiteBanHang.Controllers
{
    public class HomeController : Controller
    {
        private MyDb db = new MyDb();
        public ActionResult Home(int page = 1, int pagesize = 8)
        {
            DBIO db = new DBIO();
            var new_product = db.GetNewProducts(page, pagesize);
            ViewBag.new_pr = new_product;
            var pro_product = db.GetPro_Products(page, pagesize);
            ViewBag.pro_pr = pro_product;
            return View();

        }


        public ActionResult Product(int id)
        {
            DBIO db = new DBIO();
            var sptheoloai = db.SanPhamTheoLoai(id);
            ViewBag.loaisp = sptheoloai;
            var spkhac = db.GetProducts().Where(c => c.id_type != id).Take(3).ToList();
            ViewBag.spkhac = spkhac;
            return View();

        }

        public struct UserInfor
        {
            public string UserName;
            public string PassWord;
        }
      public ActionResult DetailProduct(int id,int page = 1, int pagesize = 3)
        {
            DBIO dbo = new DBIO();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var pro = db.products.Find(id);
            ViewBag.pro = pro;
            var sptheoloai = dbo.Products(id,page, pagesize);
            ViewBag.loaisp = sptheoloai;
            var new_product = dbo.GetNewProductsInDetail(id, page, pagesize);
            ViewBag.new_pr = new_product;
            var pro_product = dbo.GetPro_ProductsInDetail(id,page, pagesize);
            ViewBag.pro_pr = pro_product;
            if (pro == null)
            {
                return HttpNotFound();
            }
            return View();
        }
    }
}