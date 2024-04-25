using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public interface ICartItemRepository
    {
        public CartItem Add(CartItem item);
        public ICollection<CartItem> GetAll();
        public CartItem GetByKey(int CartId, int productId);
        public CartItem Update(CartItem item);
        public CartItem Delete(int CartId, int productId);
    }
}