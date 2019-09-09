using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BufferOverflow.Shared
{
    public interface ITagDAC : IDataAccessComponent
    {
        bool Create(List<ITagsDTO> listOfTags, int questionID);
        List<IQuestionDTO> SearchQuestion(ITagsDTO tagDTO);
        List<ITagsDTO> GetTags();
    }
}
