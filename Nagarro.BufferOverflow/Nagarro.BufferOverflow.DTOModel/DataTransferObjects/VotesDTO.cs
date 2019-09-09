using Nagarro.BufferOverflow.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BufferOverflow.DTOModel
{
    [EntityMapping("Votes", MappingType.TotalExplicit)]
    public class VotesDTO : DTOBase, IVoteDTO
    {
        [EntityPropertyMapping(MappingDirectionType.Both, "Id")]//There is no entity like Sample that exists
        public int Id { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "Vote")]
        public int Vote { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "UserId")]
        public int UserId { get; set; }

        [EntityPropertyMapping(MappingDirectionType.Both, "AnswerId")]
        public int AnswerId { get; set; }

    }
}

