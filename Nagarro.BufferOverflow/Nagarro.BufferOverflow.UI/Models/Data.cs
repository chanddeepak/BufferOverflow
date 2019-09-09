using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Nagarro.BufferOverflow.UI
{
    public class Data
    {
        public List<Tags> TagDetail;
        public Questions QuestionDetail;
        public Answers AnswerDetail;
        public User UserDetail;
        public Votes VoteDetail;
        public int TotalVote { get; set; }

        public Data()
        {
            TagDetail = new List<Tags>();
            QuestionDetail = new Questions();
            AnswerDetail = new Answers();
            UserDetail = new User();
            VoteDetail = new Votes();
        }
    }
}