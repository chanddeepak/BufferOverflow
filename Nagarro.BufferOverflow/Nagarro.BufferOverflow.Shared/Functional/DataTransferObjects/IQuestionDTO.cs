using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BufferOverflow.Shared
{
    public interface IQuestionDTO : IDTO
    {
        int Id { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        int AnswerCount { get; set; }
        int UserId { get; set; }
        string Image { get; set; }
        DateTime Created { get; set; }
    }
}
