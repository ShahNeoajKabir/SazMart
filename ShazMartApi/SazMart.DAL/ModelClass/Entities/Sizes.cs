using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SazMart.DAL.ModelClass.Entities
{
    public class Sizes
    {
        public int SizeId { get; set; }
        public int SizeName { get; set; }
        public ICollection<ProductSize> ProductSize { get; set; }
    }
}
