using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SazMart.DAL.ModelClass.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public ICollection<AppUser> AppUser { get; set; }
    }
}
