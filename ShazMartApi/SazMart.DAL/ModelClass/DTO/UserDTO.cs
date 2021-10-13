using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SazMart.DAL.ModelClass.DTO
{
    public class UserDTO
    {
        public string PhotoUrl { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Age  { get; set; }
        public string Gender  { get; set; }
        public string CityName  { get; set; }
        public string CountryName  { get; set; }
        public ICollection<PhotoDTO> Photos { get; set; }

    }
}
