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
        public int Size { get; set; }
        public int TagId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }
        public Brand Brand { get; set; }
        public SubCategories SubCategories { get; set; }
        public Tag Tag { get; set; }
        public ICollection<ProductPhoto> ProductPhoto { get; set; }
        public ICollection<ProductColor> ProductColor { get; set; }
    }
}
