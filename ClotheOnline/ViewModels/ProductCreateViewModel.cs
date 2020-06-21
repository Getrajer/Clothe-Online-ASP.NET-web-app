using ClotheOnline.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClotheOnline.ViewModels
{
    public class ProductCreateViewModel
    {
        //Product Id for database
        public int Id { get; set; }
        //Category of clothing (ex T-Shirt, Jeans ect...)
        [Required]
        public Categories Category { get; set; }
        [Required]
        public string Name { get; set; }
        //Quantity of product in direct size
        [Required]
        public int xsQuantity { get; set; }
        [Required]
        public int sQuantity { get; set; }
        [Required]
        public int mQuantity { get; set; }
        [Required]
        public int lQuantity { get; set; }
        [Required]
        public int xlQuantity { get; set; }

        //Price in pounds
        [Required]
        public decimal Price { get; set; }
        //Description for the product ( Material, color, ect patterns descriptions)
        [Required]
        public string Description { get; set; }
        //Date of relase of this clothing
        [Required]
        public string DateOfProduction { get; set; }
        public DateTime Posted { get; set; }
        //Brand which is producing the product
        [Required]
        public string Brand { get; set; }
        //Photopath to the clothing img one piece of clothing can have max 3 img
        public IFormFile Photo { get; set; }

        public IFormFile Photo2 { get; set; }

        public IFormFile Photo3 { get; set; }
    }
}
