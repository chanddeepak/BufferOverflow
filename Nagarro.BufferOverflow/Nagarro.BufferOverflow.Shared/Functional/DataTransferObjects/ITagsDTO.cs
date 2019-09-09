using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BufferOverflow.Shared
{
    public interface ITagsDTO : IDTO
    {
        int Id { get; set; }
        string Tag { get; set; }
    }
}
