using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary
{
    public class CartItem : IEquatable<CartItem>
    {
        public int CartId { get; set; } // Navigation property
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public DateTime PriceExpiryDate { get; set; }

        public CartItem(int cartId, int productId, int quantity, double discount, DateTime priceExpiryDate)
        {
            CartId = cartId;
            ProductId = productId;
            Quantity = quantity;
            Discount = discount;
            PriceExpiryDate = priceExpiryDate;
        }

        public CartItem()
        {
        }

        public bool Equals(CartItem? other)
        {
            return (this.CartId.Equals(other.CartId) && this.ProductId.Equals(other.ProductId));
        }

        public override string ToString()
        {
            return CartId + " " + ProductId + " " + Quantity + " " + Price + " " + Discount;
        }
    }
}