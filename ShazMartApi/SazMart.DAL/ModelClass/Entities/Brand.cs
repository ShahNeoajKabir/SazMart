using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SazMart.DAL.ModelClass.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public ICollection<BrandLogo> BrandLogo { get; set; }
        public ICollection<Product> Product { get; set; }
    }
}
