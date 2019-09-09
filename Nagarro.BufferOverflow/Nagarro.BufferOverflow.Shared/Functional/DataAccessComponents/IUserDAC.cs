using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BufferOverflow.Shared
{
    public interface IUserDAC : IDataAccessComponent
    {
        IUserDTO Login(IUserDTO userDTO);
        IUserDTO Register(IUserDTO userDTO);
        IUserDTO GetProfile(IUserDTO userDTO);
    }
}
