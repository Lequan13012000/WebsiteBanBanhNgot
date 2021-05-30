using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseIO;
using DbWebsite;


namespace WebsiteBanHang.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        MyDb db = new MyDb();
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult AddtoCart(int id)
        {
            var pro = db.products.SingleOrDefault(s => s.id == id);
            if (pro != null)
            {
                GetCart().Add(pro);
            }
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
        public ActionResult ShowToCart()
        {
            if (Session["Cart"] == null)
                return RedirectToAction("ShowToCart", "ShoppingCart");
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
        public ActionResult Update_Quantity_Cart(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_pro = int.Parse(form["ID_Product"]);
            int quantity = int.Parse(form["Quantity"]);
            cart.Update_Quantity_Cart(id_pro, quantity);
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
        public ActionResult Remove_Cart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_CartItem(id);
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }

        public PartialViewResult BagCart()
        {
            int total_item = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)
                total_item = cart.Total_Quantity_in_Cart();
            ViewBag.QuantityCart = total_item;
            return PartialView("BagCart");
        }
        public ActionResult Shopping_Succsess()
        {
            return View();
        }
        public ActionResult CheckOut(FormCollection form)
        {
            try
            {
                Cart cart = Session["Cart"] as Cart;

                customer _customer = new customer();
                _customer.name_cus = form["name"];
                _customer.gender = form["gender"];
                _customer.email = form["email"];
                _customer.address_cus = form["address"];
                _customer.phone_number = form["phone"];
                _customer.note = form["note_cus"];
                _customer.created_at = DateTime.Now;
                db.customers.Add(_customer);

                bill _bill = new bill();
                /*       _bill.id = int.Parse(form["id"]);*/
                _bill.id_customer = _customer.id;
                _bill.date_order = DateTime.Now;
                _bill.total = cart.Total_Money();
                /*     _bill.payment = form["payment"];*/
                _bill.note = form["note_bill"];
                _bill.created_at = DateTime.Now;
                db.bills.Add(_bill);

                foreach (var item in cart.Items)
                {
                    bill_detail _bill_Detail = new bill_detail();
                    _bill_Detail.id_bill = _bill.id;
                    _bill_Detail.id_product = item._shopping_product.id;
                    _bill_Detail.quantity = item._shopping_quantity;
                    _bill_Detail.unit_price = Convert.ToDouble(item._shopping_product.unit_price);
                    _bill_Detail.created_at = DateTime.Now;
                    db.bill_detail.Add(_bill_Detail);
                }
                db.SaveChanges();
                cart.ClearCart();
                return RedirectToAction("Shopping_Succsess", "ShoppingCart");

            }
            catch
            {
                return Content("Error Checkout. Please information");
            }
        }


    }
}