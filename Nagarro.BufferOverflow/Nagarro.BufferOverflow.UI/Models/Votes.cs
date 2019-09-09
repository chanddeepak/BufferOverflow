using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nagarro.BufferOverflow.UI
{
    public class Votes
    {
        public int Id { get; set; }
        public int Vote { get; set; }
        public int UserId { get; set; }
        public int AnswerId { get; set; }
    }
}