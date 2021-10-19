using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SazMart.DAL.ModelClass.Entities
{
    public class ProductColor
    {
        public int ProductColorId { get; set; }
        public int ColorId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public Colors  Colors { get; set; }
    }
}
