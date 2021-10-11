using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SazMart.DAL.ModelClass.Entities
{
    public class SubCategories
    {
        public int Id { get; set; }
        public string SubCategoriesName { get; set; }
        public Categories Categories { get; set; }
        public int CategoriesId { get; set; }
    }
}
