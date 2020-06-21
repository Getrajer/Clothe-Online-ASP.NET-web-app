using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClotheOnline.ViewModels
{
    public class ProductEditViewModel : ProductCreateViewModel
    {
        public int Id { get; set; }
        public string ExistingPhotoPath1 { get; set; }
        public string ExistingPhotoPath2 { get; set; }
        public string ExistingPhotoPath3 { get; set; }

    }
}
