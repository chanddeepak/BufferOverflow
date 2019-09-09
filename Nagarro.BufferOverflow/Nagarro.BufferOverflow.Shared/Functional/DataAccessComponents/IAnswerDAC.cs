using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BufferOverflow.Shared
{
    public interface IAnswerDAC : IDataAccessComponent
    {
        IAnswerDTO Create(IAnswerDTO answerDTO);
        IAnswerDTO Edit(IAnswerDTO answerDTO);
        IAnswerDTO Delete(IAnswerDTO answerDTO);
        List<IDataDTO> GetAnswers(IAnswerDTO answerDTO);
        IDataDTO CreateVote(IVoteDTO voteDTO);
    }
}
