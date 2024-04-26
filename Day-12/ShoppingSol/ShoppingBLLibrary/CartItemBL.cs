using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;

namespace ShoppingBLLibrary
{
    public class CartItemBL : ICartItemService
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IRepository<int, Product> _productRepository;

        public CartItemBL(ICartItemRepository cartItemRepository, IRepository<int, Product> productRepository)
        {
            _cartItemRepository = cartItemRepository;
            _productRepository = productRepository;
        }

        public bool CheckProductAvailability(CartItem cartItem, Product product)
        {
            return product.QuantityInHand - cartItem.Quantity >= 0;
        }

        public CartItem AddCartItem(CartItem cartItem, int productId)
        {
            if (cartItem == null)
                throw new Exception("Null data");

            Product product = _productRepository.GetByKey(productId);
            if (!CheckProductAvailability(cartItem, product))
                throw new InsufficientStockException();

            cartItem.ProductId = productId;
            cartItem.PriceExpiryDate = DateTime.Now.AddHours(24);
            cartItem = CalculateCost(cartItem, product);
            CartItem newCartItem = _cartItemRepository.Add(cartItem);
            product.QuantityInHand -= cartItem.Quantity;
            _productRepository.Update(product);

            return newCartItem;
        }

        public CartItem CalculateCost(CartItem cartItem, Product product)
        {
            cartItem.Discount = 0;
            if (cartItem.Quantity > 5)
                throw new CartCapacityExceededException();

            double totalBeforeDiscount = cartItem.Quantity * product.Price;
            double totalCost = cartItem.Discount != 0 ? totalBeforeDiscount - (totalBeforeDiscount * (cartItem.Discount / 100)) : totalBeforeDiscount;
            cartItem.Price = totalCost;

            return cartItem;
        }

        public CartItem DeleteCartItem(CartItem cartItem)
        {
            Product product = _productRepository.GetByKey(cartItem.ProductId);
            product.QuantityInHand += cartItem.Quantity;
            _productRepository.Update(product);
            CartItem deletedCartItem = _cartItemRepository.Delete(cartItem.CartId, cartItem.ProductId);

            return deletedCartItem;
        }

        public CartItem UpdateCartItem(CartItem PrevCartItems, CartItem cartItem)
        {
            if (PrevCartItems == null || cartItem == null)
                throw new Exception("Null data");

            Product product = _productRepository.GetByKey(cartItem.ProductId);
            if (!CheckProductAvailability(cartItem, product))
                throw new InsufficientStockException();

            cartItem = CalculateCost(cartItem, product);
            CartItem updatedCartItem = _cartItemRepository.Update(cartItem);
            product.QuantityInHand += PrevCartItems.Quantity - cartItem.Quantity;
            _productRepository.Update(product);

            return updatedCartItem;
        }
    }
}
