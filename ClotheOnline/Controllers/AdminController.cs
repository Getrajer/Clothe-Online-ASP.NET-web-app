using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClotheOnline.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClotheOnline.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductRepository _productRepository;

        public AdminController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [Authorize]
        public IActionResult Index()
        {
            var model = _productRepository.GetAllProducts();
            return View(model);
        }
    }
}