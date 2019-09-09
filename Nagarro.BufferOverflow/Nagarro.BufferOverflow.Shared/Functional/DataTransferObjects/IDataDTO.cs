using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BufferOverflow.Shared
{
    public interface IDataDTO : IDTO
    {
        IQuestionDTO QuestionDetail { get; set; }
        IAnswerDTO AnswerDetail { get; set; }
        IUserDTO UserDetail { get; set; }
        List<ITagsDTO> TagDetail { get; set; }
        IVoteDTO VoteDetail { get; set; }
        int TotalVote { get; set; }
    }
}
