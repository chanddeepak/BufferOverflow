using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nagarro.BufferOverflow.UI
{
    public class Questions
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AnswerCount { get; set; }
        public int UserId { get; set; }
        public string Image { get; set; }
        public DateTime Created { get; set; }
    }
}