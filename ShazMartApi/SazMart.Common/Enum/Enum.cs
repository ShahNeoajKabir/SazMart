using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SazMart.Common.Enum
{
    public class Enum
    {
        public enum Gender
        {
            Male=1,
            Femail=2,
            Others=3
        }

        public enum UserType
        {
            Admin=1,
            Moderator=2,
            Customer=3
        }

        public enum Status
        {
            Active=1,
            Inactive=2
        }

        public enum Color
        {
            White=1,
            Black=2,
            Blue=3,
            Red=4,
            Yellow=5
        }

        public enum Size
        {
            S=1,
            M=2,
            L=3,
            XL=4,
            XXL=5,
            XXX=6
        }
    }
}
