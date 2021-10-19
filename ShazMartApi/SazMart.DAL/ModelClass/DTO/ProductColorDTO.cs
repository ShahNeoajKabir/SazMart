using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SazMart.DAL.ModelClass.DTO
{
    public class ProductColorDTO
    {
        public int ProductColorId { get; set; }
        public int ColorId { get; set; }
        public int ProductId { get; set; }
        public string ColorName { get; set; }
        public string ProductName { get; set; }
    }
}
