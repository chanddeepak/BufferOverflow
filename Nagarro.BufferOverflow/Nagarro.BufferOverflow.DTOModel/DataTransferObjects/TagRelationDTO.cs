using Nagarro.BufferOverflow.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BufferOverflow.DTOModel
{
    [EntityMapping("TagRelation", MappingType.TotalExplicit)]
    public class TagRelationDTO : DTOBase, ITagRelationDTO
    {
        [EntityPropertyMapping(MappingDirectionType.Both, "Id")]//There is no entity like Sample that exists
        public int Id { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "TagId")]
        public int TagId { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "QuestionId")]
        public int QuestionId { get; set; }

    }
}

