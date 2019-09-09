using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BufferOverflow.Shared
{
    public interface IQuestionDAC : IDataAccessComponent
    {
        IQuestionDTO Create(IQuestionDTO dataDTO);
        IQuestionDTO Edit(IQuestionDTO questionDTO);
        IQuestionDTO Delete(IQuestionDTO questionDTO);
        IDataDTO Details(IQuestionDTO questionDTO);
        List<IQuestionDTO> Search(IQuestionDTO questionDTO);
        List<IDataDTO> GetQuestions();

    }
}
