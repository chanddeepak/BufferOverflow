using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BufferOverflow.EntityDataModel
{
    public static class ContextClass
    {
        public static List<User> Users { get; set; }
        public static List<Sample> Samples { get; set; }

        static ContextClass()
        {
            Users = new List<User>();
            Samples = new List<Sample>();
        }
    }
}
