using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nagarro.BufferOverflow.UI
{
    public class TagRelation
    {
        public int Id { get; set; }
        public int TagId { get; set; }
        public int QuestionId { get; set; }
    }
}