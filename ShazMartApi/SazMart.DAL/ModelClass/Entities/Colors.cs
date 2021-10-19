using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SazMart.DAL.ModelClass.Entities
{
    public class Colors
    {
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public ICollection<ProductColor> ProductColor { get; set; }

    }
}
