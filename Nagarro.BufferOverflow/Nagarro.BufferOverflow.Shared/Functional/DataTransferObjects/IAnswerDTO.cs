using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BufferOverflow.Shared
{
    public interface IAnswerDTO : IDTO
    {
        int Id { get; set; }
        string Answer { get; set; }
        int UserId { get; set; }
        int QuestionId { get; set; }
        DateTime Created { get; set; }
    }
}

