using Nagarro.BufferOverflow.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BufferOverflow.DTOModel
{
    [EntityMapping("Questions", MappingType.TotalExplicit)]
    public class QuestionsDTO : DTOBase, IQuestionDTO
    {
        [EntityPropertyMapping(MappingDirectionType.Both, "Id")]//There is no entity like Sample that exists
        public int Id { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Title")]
        public string Title { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Description")]
        public string Description { get; set; }


        [EntityPropertyMapping(MappingDirectionType.Both, "AnswerCount")]
        public int AnswerCount { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "UserId")]
        public int UserId { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Image")]
        public string Image { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Created")]
        public DateTime Created { get; set; }

    }
}
