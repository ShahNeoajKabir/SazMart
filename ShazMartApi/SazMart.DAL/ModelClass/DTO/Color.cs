using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SazMart.DAL.ModelClass.DTO
{
    public class Color
    {
        public Color()
        {
            ProductColors = new HashSet<ProductColor>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }

        public virtual ICollection<ProductColor> ProductColors { get; set; }
    }
}
