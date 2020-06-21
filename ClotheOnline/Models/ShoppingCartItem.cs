using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClotheOnline.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Product product { get; set; }
        public int Ammount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
