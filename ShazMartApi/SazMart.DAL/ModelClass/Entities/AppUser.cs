﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SazMart.DAL.ModelClass.Entities
{
    public class AppUser:IdentityUser<int>
    {
        public string PhotoUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int UserType { get; set; }
        public int Gender { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
        public ICollection<AppUserRole> AppUserRole { get; set; }
        public ICollection<AppUserPhoto> AppUserPhoto { get; set; }


    }
}