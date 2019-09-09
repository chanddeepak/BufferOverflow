using Nagarro.BufferOverflow.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BufferOverflow.DTOModel
{
    [EntityMapping("Data", MappingType.TotalExplicit)]
    public class DataDTO : DTOBase, IDataDTO
    {
        [EntityPropertyMapping(MappingDirectionType.Both, "QuestionDetail")]
        public IQuestionDTO QuestionDetail { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "AnswerDetail")]
        public IAnswerDTO AnswerDetail { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "UserDetail")]
        public IUserDTO UserDetail { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "TagDetail")]
        public List<ITagsDTO> TagDetail { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "VoteDetail")]
        public IVoteDTO VoteDetail { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "TotalVote")]
        public int TotalVote { get; set; }


    }
}
