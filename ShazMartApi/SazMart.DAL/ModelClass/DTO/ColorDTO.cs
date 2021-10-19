using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SazMart.DAL.ModelClass.DTO
{
    public class ColorDTO
    {
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public string ProductName { get; set; }
        public ICollection<ProductColorDTO> ProductColorDTO { get; set; }

    }
}
