using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BufferOverflow.Shared
{
    public interface ITagRelationDTO : IDTO
    {
        int Id { get; set; }
        int TagId { get; set; }
        int QuestionId { get; set; }
    }
}
