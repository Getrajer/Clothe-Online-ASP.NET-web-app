using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClotheOnline.Models
{
    public class AppUser : IdentityUser
    {
        public string City { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
    }
}
