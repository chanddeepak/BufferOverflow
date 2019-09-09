using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BufferOverflow.Shared
{
    public interface ITagBDC : IBusinessDomainComponent
    {
        OperationResult<bool> Create(List<ITagsDTO> listOfTags, int questionId);
        OperationResult<List<IQuestionDTO>> SearchQuestion(ITagsDTO tagDTO);
        OperationResult<List<ITagsDTO>> GetTags();
    }
}
