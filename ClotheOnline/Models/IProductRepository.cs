using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClotheOnline.Models
{
    public interface IProductRepository
    {
        Product GetProduct(int Id);
        IEnumerable<Product> GetAllProducts();
        Product Add(Product product);
        Product Update(Product productChanges);
        Product Delete(int Id);
    }
}
