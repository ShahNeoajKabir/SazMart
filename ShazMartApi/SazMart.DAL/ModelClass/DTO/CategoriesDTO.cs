using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SazMart.DAL.ModelClass.DTO
{
    public class CategoriesDTO
    {
        public int Id { get; set; }
        public string CategoriesName { get; set; }
        public string SubCategories { get; set; }
        public string Description { get; set; }
        public ICollection<SubCategoriesDTO> SubCategoriesDTO { get; set; }
    }
}
