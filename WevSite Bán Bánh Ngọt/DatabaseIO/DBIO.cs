using DbWebsite;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using System.Data.Entity;
using System.Collections;


namespace DatabaseIO
{
    public class DBIO
    {
        MyDb mydb = new MyDb();
        public IEnumerable type_products;
        public object products;

        public IEnumerable<products> GetProducts()
        {
            return mydb.products.OrderByDescending(x => x.id).ToList();
        }

        public IEnumerable<products> Products(int id,int page, int pagesize)
        {
            var pro = mydb.products.Find(id);
            return mydb.products.OrderByDescending(x => x.id).Where(c =>c.id_type == pro.id_type).ToPagedList(page,pagesize);
        }

        public IEnumerable<new_products> GetNewProducts(int page, int pagesize)
        {
            return mydb.new_products.OrderByDescending(x => x.id).Where(c => c.new_pr == 1).ToPagedList(page, pagesize);
        }

        public IEnumerable<new_products> GetNewProductsInDetail(int id,int page, int pagesize)
        {
            return mydb.new_products.OrderByDescending(x => x.id).Where(c => c.new_pr == 1).Take(18).ToPagedList(page, pagesize);
        }
        public IEnumerable<pro_products> GetPro_Products(int page, int pagesize)
        {
            return mydb.pro_products.OrderByDescending(x => x.id).Where(c => c.promotion_price != 0).ToPagedList(page, pagesize);
        }
        public IEnumerable<pro_products> GetPro_ProductsInDetail(int id,int page, int pagesize)
        {
            return mydb.pro_products.OrderByDescending(x => x.id).Where(c => c.promotion_price != 0).Take(18).ToPagedList(page, pagesize);
        }
        public List<type_products> GetTypeProducts()
        {
            return mydb.type_products.OrderByDescending(x => x.id).ToList();

        }
        public List<products> SanPhamTheoLoai(int idtype)
        {
            return mydb.products.OrderByDescending(x => x.id).Where(c => c.id_type == idtype).ToList();
        }

        public IEnumerable<products> lstjoin(string key = "", int idCate = 0, double min = 0, double max = 999999999999999999)
        {

            if (idCate == 0)
            {
                var lst = mydb.products.Where(item => item.name_pr.Contains(key) && item.unit_price >= min &&
             item.unit_price <= max).OrderByDescending(itemp => itemp.unit_price).ToList();
                return lst;
            }
            else
            {
                var lst = mydb.products.Where(item => item.name_pr.Contains(key) && item.id_type == idCate &&
            item.unit_price >= min && item.unit_price <= max).OrderByDescending(itemp => itemp.unit_price).ToList();
                return lst;
            }
        }



    }
}
