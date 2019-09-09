using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nagarro.BufferOverflow.UI
{
    public class Answers
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public DateTime Created { get; set; }
    }
}