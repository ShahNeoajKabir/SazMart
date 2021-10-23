using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SazMart.DAL.ModelClass.DTO
{
    public class Product
    {
        public Product()
        {
            ProductColors = new HashSet<ProductColor>();
            ProductSizes = new HashSet<ProductSize>();
            Tags = new HashSet<Tag>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductCode { get; set; }
        public decimal Mrp { get; set; }
        public Guid BrandId { get; set; }
        public Guid CategoriId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public int Status { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Categories Categorie { get; set; }
        public virtual ICollection<ProductColor> ProductColors { get; set; }
        public virtual ICollection<ProductSize> ProductSizes { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
