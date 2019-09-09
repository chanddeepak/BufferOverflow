using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.BufferOverflow.Shared;

namespace Nagarro.BufferOverflow.BusinessFacades
{
    public class AnswerFacade : FacadeBase, IAnswerFacade
    {
        public AnswerFacade()
            : base(FacadeType.AnswerFacade)
        {

        }

        public OperationResult<IAnswerDTO> Create(IAnswerDTO answerDTO)
        {
            IAnswerBDC answerBDC = (IAnswerBDC)BDCFactory.Instance.Create(BDCType.AnswerBDC);
            return answerBDC.Create(answerDTO);
        }

        public OperationResult<IAnswerDTO> Delete(IAnswerDTO answerDTO)
        {
            IAnswerBDC answerBDC = (IAnswerBDC)BDCFactory.Instance.Create(BDCType.AnswerBDC);
            return answerBDC.Delete(answerDTO);
        }

        public OperationResult<IAnswerDTO> Edit(IAnswerDTO answerDTO)
        {
            IAnswerBDC answerBDC = (IAnswerBDC)BDCFactory.Instance.Create(BDCType.AnswerBDC);
            return answerBDC.Edit(answerDTO);
        }

        public OperationResult<List<IDataDTO>> GetAnswers(IAnswerDTO answerDTO)
        {
            IAnswerBDC answerBDC = (IAnswerBDC)BDCFactory.Instance.Create(BDCType.AnswerBDC);
            return answerBDC.GetAnswers(answerDTO);
        }

        public OperationResult<IDataDTO> CreateVote(IVoteDTO voteDTO)
        {
            IAnswerBDC answerBDC = (IAnswerBDC)BDCFactory.Instance.Create(BDCType.AnswerBDC);
            return answerBDC.CreateVote(voteDTO);
        }

    }
}
