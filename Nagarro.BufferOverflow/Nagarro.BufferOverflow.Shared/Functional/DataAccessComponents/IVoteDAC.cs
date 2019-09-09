using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BufferOverflow.Shared
{
    public interface IVoteDAC : IDataAccessComponent
    {
        int CountVotes(IAnswerDTO answerDTO);
        int GetUpVoteOrDownVote(IAnswerDTO answerDTO);
        void SetUpVoteOrDownVote(IVoteDTO voteDTO);
    }
}
