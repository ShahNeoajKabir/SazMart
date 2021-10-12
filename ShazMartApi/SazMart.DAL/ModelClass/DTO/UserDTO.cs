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
        public string MobileNumber { get; set; }
        public int Age  { get; set; }
        public int Gender  { get; set; }
        public string City  { get; set; }
        public string Country  { get; set; }
        public ICollection<PhotoDTO> Photos { get; set; }

    }
}
