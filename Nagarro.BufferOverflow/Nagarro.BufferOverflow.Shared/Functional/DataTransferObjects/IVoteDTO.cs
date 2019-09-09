using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BufferOverflow.Shared
{
    public interface IVoteDTO : IDTO
    {
        int Id { get; set; }
        int Vote { get; set; }
        int UserId { get; set; }
        int AnswerId { get; set; }
    }
}
