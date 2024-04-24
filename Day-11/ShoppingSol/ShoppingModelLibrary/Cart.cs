namespace ShoppingModelLibrary
{
    public class Cart
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; } //Navigation property

        public List<CartItem>? CartItems { get; set; } //Navigation property.

    }
}
