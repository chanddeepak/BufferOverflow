using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.BufferOverflow.Shared;

namespace Nagarro.BufferOverflow.BusinessFacades
{
    public class TagFacade : FacadeBase, ITagFacade
    {
        public TagFacade()
            : base(FacadeType.TagFacade)
        {

        }

        public OperationResult<bool> Create(List<ITagsDTO> listOfTags, int questionId)
        {
            ITagBDC userBDC = (ITagBDC)BDCFactory.Instance.Create(BDCType.TagBDC);
            return userBDC.Create(listOfTags, questionId);
        }

        public OperationResult<List<ITagsDTO>> GetTags()
        {
            ITagBDC userBDC = (ITagBDC)BDCFactory.Instance.Create(BDCType.TagBDC);
            return userBDC.GetTags();
        }

        public OperationResult<List<IQuestionDTO>> SearchQuestion(ITagsDTO tagDTO)
        {
            ITagBDC userBDC = (ITagBDC)BDCFactory.Instance.Create(BDCType.TagBDC);
            return userBDC.SearchQuestion(tagDTO);
        }
    }
}
