﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SazMart.DAL.ModelClass.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }


    }
}
