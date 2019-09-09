using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.BufferOverflow.Shared;

namespace Nagarro.BufferOverflow.BusinessFacades
{
    public class QuestionFacade : FacadeBase, IQuestionFacade
    {
        public QuestionFacade()
            : base(FacadeType.QuestionFacade)
        {

        }

        public OperationResult<IQuestionDTO> Create(IQuestionDTO dataDTO)
        {
            IQuestionBDC questionBDC = (IQuestionBDC)BDCFactory.Instance.Create(BDCType.QuestionBDC);
            return questionBDC.Create(dataDTO);
        }

        public OperationResult<IQuestionDTO> Delete(IQuestionDTO questionDTO)
        {
            IQuestionBDC questionBDC = (IQuestionBDC)BDCFactory.Instance.Create(BDCType.QuestionBDC);
            return questionBDC.Delete(questionDTO);
        }

        public OperationResult<IDataDTO> Details(IQuestionDTO questionDTO)
        {
            IQuestionBDC questionBDC = (IQuestionBDC)BDCFactory.Instance.Create(BDCType.QuestionBDC);
            return questionBDC.Details(questionDTO);
        }

        public OperationResult<IQuestionDTO> Edit(IQuestionDTO questionDTO)
        {
            IQuestionBDC questionBDC = (IQuestionBDC)BDCFactory.Instance.Create(BDCType.QuestionBDC);
            return questionBDC.Edit(questionDTO);
        }

        public OperationResult<List<IDataDTO>> GetQuestions()
        {
            IQuestionBDC questionBDC = (IQuestionBDC)BDCFactory.Instance.Create(BDCType.QuestionBDC);
            return questionBDC.GetQuestions();
        }

        public OperationResult<List<IQuestionDTO>> Search(IQuestionDTO questionDTO)
        {
            IQuestionBDC questionBDC = (IQuestionBDC)BDCFactory.Instance.Create(BDCType.QuestionBDC);
            return questionBDC.Search(questionDTO);
        }
    }
}
