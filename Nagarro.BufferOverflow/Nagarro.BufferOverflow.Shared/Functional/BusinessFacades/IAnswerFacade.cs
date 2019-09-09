using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BufferOverflow.Shared
{
    public interface IAnswerFacade : IFacade
    {
        OperationResult<IAnswerDTO> Create(IAnswerDTO answerDTO);
        OperationResult<IAnswerDTO> Edit(IAnswerDTO answerDTO);
        OperationResult<IAnswerDTO> Delete(IAnswerDTO answerDTO);
        OperationResult<List<IDataDTO>> GetAnswers(IAnswerDTO answerDTO);
        OperationResult<IDataDTO> CreateVote(IVoteDTO voteDTO);
    }
}
