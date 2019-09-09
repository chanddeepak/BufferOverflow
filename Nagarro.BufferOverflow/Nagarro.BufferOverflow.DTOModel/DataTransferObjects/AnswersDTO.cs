using Nagarro.BufferOverflow.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BufferOverflow.DTOModel
{
    [EntityMapping("Answer", MappingType.TotalExplicit)]
    public class AnswersDTO : DTOBase, IAnswerDTO
    {
        [EntityPropertyMapping(MappingDirectionType.Both, "Id")]//There is no entity like Sample that exists
        public int Id { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Answer")]
        public string Answer { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "QuestionId")]
        public int QuestionId { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "UserId")]
        public int UserId { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Created")]
        public DateTime Created { get; set; }

    }
}
