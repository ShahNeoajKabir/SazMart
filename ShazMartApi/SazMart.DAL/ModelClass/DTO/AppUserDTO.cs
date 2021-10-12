﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SazMart.DAL.ModelClass.DTO
{
    public class AppUserDTO
    {
        [Required(ErrorMessage ="UserName Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Email Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [StringLength(15,MinimumLength =6)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Mobile Number Required")]
        public string MobileNumber { get; set; }
        public DateTime DoB { get; set; }
        public int UserType { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Status { get; set; }

    }
}