﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SazMart.DAL.ModelClass.Entities
{
    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SubCategories> SubCategories { get; set; }
    }
}