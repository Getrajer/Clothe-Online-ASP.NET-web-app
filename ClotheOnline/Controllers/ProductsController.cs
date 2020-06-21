using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClotheOnline.Models;
using ClotheOnline.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ClotheOnline.Controllers
{
    public class ProductsController : Controller
    {

        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository,
            IHostingEnvironment hostingEnvironment)
        {
            _productRepository = productRepository;
            this.hostingEnvironment = hostingEnvironment;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = _productRepository.GetAllProducts();
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Shorts()
        {
            var model = _productRepository.GetAllProducts().Where( x => x.Category == Categories.Shorts);
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Tshirts()
        {
            var model = _productRepository.GetAllProducts().Where(x => x.Category == Categories.Tshirts);
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Skirts()
        {
            var model = _productRepository.GetAllProducts().Where(x => x.Category == Categories.Skirts);
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Throusers()
        {
            var model = _productRepository.GetAllProducts().Where(x => x.Category == Categories.Throusers);
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Jackets()
        {
            var model = _productRepository.GetAllProducts().Where(x => x.Category == Categories.Jackets);
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Dresses()
        {
            var model = _productRepository.GetAllProducts().Where(x => x.Category == Categories.Dresses);
            return View(model);
        }

        //HTTP GET for accesing the View
        //Create Product View
        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }


        //HTTP GET for accesing the View
        //Create Product Method
        [HttpPost]
        [Authorize]
        public IActionResult Create(ProductCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile1(model);
                string uniqueFileName2 = ProcessUploadedFile2(model);
                string uniqueFileName3 = ProcessUploadedFile3(model);


                Product newProduct = new Product
                {
                    Brand = model.Brand,
                    Category = model.Category,
                    DateOfProduction = model.DateOfProduction,
                    Description = model.Description,
                    Name = model.Name,
                    Price = model.Price,
                    lQuantity = model.lQuantity,
                    mQuantity = model.mQuantity,
                    sQuantity = model.sQuantity,
                    xlQuantity = model.xlQuantity,
                    xsQuantity = model.xsQuantity,
                    Posted = DateTime.Now,
                    PhotoPath = uniqueFileName,
                    PhotoPath2 = uniqueFileName2,
                    PhotoPath3 = uniqueFileName3
                };

                _productRepository.Add(newProduct);

                return RedirectToAction("ProductDetails", new { id = newProduct.Id });
            }
            
            return View();
        }

        [AllowAnonymous]
        public IActionResult ProductDetails(int? id)
        {
            Product product = _productRepository.GetProduct(id.Value);

            if (product == null)
            {
                Response.StatusCode = 404;
                return View("ProductNotFound", id.Value);
            }

            ProductDetailsViewModel productDetailsViewModel = new ProductDetailsViewModel()
            {
                Product = product,
                PageTitle = product.Name

            };

            return View(productDetailsViewModel);
        }


        //Http Get function for editing products
        [HttpGet]
        [Authorize]
        public IActionResult Edit(int id)
        {
            Product product = _productRepository.GetProduct(id);
            ProductEditViewModel productEditViewModel = new ProductEditViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category,
                Brand = product.Brand,
                Description = product.Description,
                Price = product.Price,
                xsQuantity = product.xsQuantity,
                sQuantity = product.sQuantity,
                mQuantity = product.mQuantity,
                lQuantity = product.lQuantity,
                xlQuantity = product.xlQuantity,
                ExistingPhotoPath1 = product.PhotoPath,
                ExistingPhotoPath2 = product.PhotoPath2,
                ExistingPhotoPath3 = product.PhotoPath3,
                DateOfProduction = product.DateOfProduction

            };
            return View(productEditViewModel);
        }


        //Http Post function for editing Proucts
        [HttpPost]
        [Authorize]
        public IActionResult Edit(ProductEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Product product = _productRepository.GetProduct(model.Id);

                product.Name = model.Name;
                product.Price = model.Price;
                product.Brand = model.Brand;
                product.Category = model.Category;
                product.Description = model.Description;
                product.xsQuantity = model.xsQuantity;
                product.sQuantity = model.sQuantity;
                product.mQuantity = model.mQuantity;
                product.lQuantity = model.lQuantity;
                product.xlQuantity = model.xlQuantity;
                product.DateOfProduction = model.DateOfProduction;

                if(model.Photo != null)
                {
                    if(model.ExistingPhotoPath1 != null)
                    {
                       string filePath1 = Path.Combine(hostingEnvironment.WebRootPath, "images",
                                        model.ExistingPhotoPath1);
                        System.IO.File.Delete(filePath1);
                    }
                    product.PhotoPath = ProcessUploadedFile1(model);
                }

                if (model.Photo2 != null)
                {
                    string filePath2 = Path.Combine(hostingEnvironment.WebRootPath, "images",
                                        model.ExistingPhotoPath2);
                    System.IO.File.Delete(filePath2);
                    product.PhotoPath2 = ProcessUploadedFile2(model);
                }

                if (model.Photo3 != null)
                {
                    string filePath3 = Path.Combine(hostingEnvironment.WebRootPath, "images",
                                        model.ExistingPhotoPath3);
                    System.IO.File.Delete(filePath3);
                    product.PhotoPath3 = ProcessUploadedFile3(model);
                }

                _productRepository.Update(product);

                return RedirectToAction("index");
            }

            return View(model);
        }



        //Category based search

        public IActionResult CategorySort(Categories? category)
        {
            IEnumerable<Product> model = _productRepository.GetAllProducts().Where(x => x.Category == category);

            if (model == null)
            {
                return View("Index");
            }


            return View(model);
                
        }





        //Functions for uploading images
        private string ProcessUploadedFile3(ProductCreateViewModel model)
        {
            string uniqueFileName3 = null;
            if (model.Photo3 != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName3 = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.Photo3.FileName);
                string filePath3 = Path.Combine(uploadsFolder, uniqueFileName3);
                using (var fileStream = new FileStream(filePath3, FileMode.Create))
                {
                    model.Photo3.CopyTo(fileStream);
                }
            }

            return uniqueFileName3;
        }

        private string ProcessUploadedFile2(ProductCreateViewModel model)
        {
            string uniqueFileName2 = null;
            if (model.Photo2 != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName2 = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.Photo2.FileName);
                string filePath2 = Path.Combine(uploadsFolder, uniqueFileName2);
                using (var fileStream = new FileStream(filePath2, FileMode.Create))
                {
                    model.Photo2.CopyTo(fileStream);
                }
            }

            return uniqueFileName2;
        }

        private string ProcessUploadedFile1(ProductCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.Photo.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }



    }
}