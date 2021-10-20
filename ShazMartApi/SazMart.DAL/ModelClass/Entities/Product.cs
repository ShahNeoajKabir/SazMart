using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SazMart.DAL.ModelClass.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public int BrandId { get; set; }
        public int SubCategoriesId { get; set; }
        public string PhotoUrl { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public int StockQuantity { get; set; }
        public int Status { get; set; }
        public Brand Brand { get; set; }
        public SubCategories SubCategories { get; set; }

        public ICollection<ProductPhoto> ProductPhoto { get; set; }
        public ICollection<ProductColor> ProductColor { get; set; }
        public ICollection<ProductSize> ProductSize { get; set; }
        public ICollection<Tag> Tag { get; set; }

    }
}
