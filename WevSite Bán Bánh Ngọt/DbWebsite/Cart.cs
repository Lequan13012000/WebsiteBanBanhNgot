using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Spatial;

namespace DbWebsite
{
    public class CartItem
    {
        public products _shopping_product { get; set; }
        public int _shopping_quantity { get; set; }

    }
    public class Cart
    {
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }
        public void Add(products _pro, int _quantity = 1)
        {
            var item = items.FirstOrDefault(s => s._shopping_product.id == _pro.id);
            if (item == null)
            {
                items.Add(new CartItem
                {
                    _shopping_product = _pro,
                    _shopping_quantity = _quantity
                });
            }
            else
            {
                item._shopping_quantity += _quantity;
            }

        }
        public void Update_Quantity_Cart(int id, int _quantity)
        {
            var item = items.Find(s => s._shopping_product.id == id);
            if (item != null)
            {
                item._shopping_quantity = _quantity;
            }
        }
        public double Total_Money()
        {
            var total = items.Sum(s => s._shopping_product.unit_price * s._shopping_quantity);
            return (double)total;
        }
        public void Remove_CartItem(int id)
        {
            items.RemoveAll(s => s._shopping_product.id == id);
        }
        public int Total_Quantity_in_Cart()
        {
            var count = items.Sum(s => s._shopping_quantity);
            return count;
        }
        public void ClearCart()
        {
            items.Clear(); // xoa gio hang de thuc hien order
        }
    }
}
