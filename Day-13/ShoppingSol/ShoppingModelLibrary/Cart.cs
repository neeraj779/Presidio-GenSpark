using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary
{
    public class Cart : IEquatable<Cart>
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }//Navigation property
        public List<CartItem> CartItems { get; set; }//Navigation property
        public double TotalPrice { get; set; }
        public double Discount { get; set; }
        public int ShippingCharges { get; set; }

        public Cart(int customerId, Customer customer, List<CartItem> cartItems, double totalPrice, double discount, int shippingCharges)
        {
            CustomerId = customerId;
            Customer = customer;
            CartItems = cartItems;
            TotalPrice = totalPrice;
            Discount = discount;
            ShippingCharges = shippingCharges;
        }

        public Cart()
        {
        }

        public bool Equals(Cart? other)
        {
            return this.Id.Equals(other.Id) || this.CustomerId.Equals(other.CustomerId);
        }

        public override string ToString()
        {
            return Id + " " + CustomerId + " " + Customer.ToString() + " " + CartItems.Count + " " + TotalPrice + " " + Discount + " " + ShippingCharges;
        }
    }
}