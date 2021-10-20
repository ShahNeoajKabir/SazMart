using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SazMart.DAL.ModelClass.Entities
{
    public class ProductSize
    {
        public int ProductSizeId { get; set; }
        public int SizeId { get; set; }
        public int ProductId { get; set; }
        public Sizes Sizes { get; set; }
        public Product Product { get; set; }
    }
}
