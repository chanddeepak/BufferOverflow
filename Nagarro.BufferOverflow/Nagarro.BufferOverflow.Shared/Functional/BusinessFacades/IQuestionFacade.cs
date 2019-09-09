using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BufferOverflow.Shared
{
    public interface IQuestionFacade : IFacade
    {
        OperationResult<IQuestionDTO> Create(IQuestionDTO dataDTO);
        OperationResult<IQuestionDTO> Edit(IQuestionDTO questionDTO);
        OperationResult<IQuestionDTO> Delete(IQuestionDTO questionDTO);
        OperationResult<IDataDTO> Details(IQuestionDTO questionDTO);
        OperationResult<List<IQuestionDTO>> Search(IQuestionDTO questionDTO);
        OperationResult<List<IDataDTO>> GetQuestions();
    }
}
