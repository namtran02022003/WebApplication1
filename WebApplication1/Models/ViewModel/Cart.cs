using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI.WebControls;

namespace WebApplication1.Models.ViewModel
{
    public class Cart
    {
        private List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items => items;
        // add product to cart
        public void AddItem(int productId, string productImage, string productName, decimal unitPrice, int quantity, string catogory)
        {
            var existingItem = items.FirstOrDefault(i => i.ProductID == productId);
            if (existingItem == null)
            {
                items.Add(new CartItem
                {
                    ProductID = productId,
                    ProductImage = productImage,
                    ProductName = productName,
                    UnitPrice = unitPrice,
                    Quantity = quantity
                });

            }
            else
            {
                existingItem.Quantity += quantity;
            }
            }
        // Remove product
        public void RemoveItem(int productId) { 
        items.RemoveAll(i => i.ProductID == productId);
        }
        // caculator total cart value
        public decimal TotalValue()
        {
            return items.Sum(i => i.TotalPrice);
        }
        //clear cart
        public void Clear () { items.Clear(); } 
        // update số lượng sản phẩm đã chọn
        public void UpdateQuantity(int productId, int quantity)
        {
            var item = items.FirstOrDefault(i => i.ProductID == productId);
            if (item != null) {
                item.Quantity = quantity;
            }
        }
    }
}