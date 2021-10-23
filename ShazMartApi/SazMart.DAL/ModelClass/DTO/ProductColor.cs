using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SazMart.DAL.ModelClass.DTO
{
    public class ProductColor
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid ColorId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public int Status { get; set; }

        public virtual Color Color { get; set; }
        public virtual Product Product { get; set; }
    }
}
