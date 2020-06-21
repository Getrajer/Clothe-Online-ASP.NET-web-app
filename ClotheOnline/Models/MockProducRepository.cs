using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClotheOnline.Models
{

    //This class is for testing
    public class MockProducRepository : IProductRepository
    {
        private List<Product> _productList;

        public MockProducRepository()
        {
            _productList = new List<Product> { };
        }

        public Product Add(Product product)
        {
            product.Id = _productList.Max(e => e.Id) + 1;
            _productList.Add(product);
            return product;
        }

        public Product Delete(int id)
        {
            Product product = _productList.FirstOrDefault(e => e.Id == id);
            if (product != null)
            {
                _productList.Remove(product);
            }
            return product;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productList;
        }

        public Product GetProduct(int Id)
        {
            return _productList.FirstOrDefault(e => e.Id == Id);
        }

        public Product Update(Product productChanges)
        {
            Product product = _productList.FirstOrDefault(e => e.Id == productChanges.Id);
            if (product != null)
            {
                product.Brand = productChanges.Brand;
                product.Category = productChanges.Category;
                product.DateOfProduction = productChanges.DateOfProduction;
                product.Description = productChanges.Description;
                product.Price = productChanges.Price;
                product.Name = productChanges.Name;
            }
            return product;
        }
    }
}
