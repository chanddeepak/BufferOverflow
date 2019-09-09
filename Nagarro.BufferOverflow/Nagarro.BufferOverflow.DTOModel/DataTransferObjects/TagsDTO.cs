using Nagarro.BufferOverflow.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BufferOverflow.DTOModel
{
    [EntityMapping("Tags", MappingType.TotalExplicit)]
    public class TagsDTO : DTOBase, ITagsDTO
    {
        [EntityPropertyMapping(MappingDirectionType.Both, "Id")]//There is no entity like Sample that exists
        public int Id { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Tag")]
        public string Tag { get; set; }

    }
}

