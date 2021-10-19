using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SazMart.DAL.ModelClass.DTO
{
    public class ProductDTO
    {
        public string BrandName { get; set; }
        public string CategoriesName { get; set; }
        public string SubCategoriesName { get; set; }
        public string PhotoUrl { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public int StockQuantity { get; set; }
        public int Size { get; set; }
        public string TagName { get; set; }
        public ICollection<ProductPhotoDTO> ProductPhotoDTOs { get; set; }
        public ICollection<ProductColorDTO> ProductColorDTO { get; set; }
    }
}
