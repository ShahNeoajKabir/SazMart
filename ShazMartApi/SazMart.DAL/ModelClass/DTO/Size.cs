using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SazMart.DAL.ModelClass.DTO
{
    public class Size
    {
        public Size()
        {
            ProductSizes = new HashSet<ProductSize>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public int Status { get; set; }

        public virtual ICollection<ProductSize> ProductSizes { get; set; }
    }
}
