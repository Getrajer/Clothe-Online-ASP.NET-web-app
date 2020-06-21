using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClotheOnline.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;
        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
            _appDbContext = appDbContext;
        }
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            _appDbContext.Orders.Add(order);

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach(var item in shoppingCartItems)
            {
                var OrderDetail = new OrderDetail()
                {
                    Ammount = item.Ammount,
                    ProductId = item.product.Id,
                    OrderId = order.OrderId,
                    Price = item.product.Price
                };
                _appDbContext.OrderDetails.Add(OrderDetail);
            }

            _appDbContext.SaveChanges();
        }
    }
}
