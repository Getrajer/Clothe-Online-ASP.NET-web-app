using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ClotheOnline.Models;
using Microsoft.AspNetCore.Authorization;

namespace ClotheOnline.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _product;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IProductRepository product)
        {
            _logger = logger;
            _product = product;

        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = _product.GetAllProducts();
            var produtcs = model.OrderByDescending(x => x.Posted).Take(3).ToArray();
            return View(produtcs);
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }


    }
}
