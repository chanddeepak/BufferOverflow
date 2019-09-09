using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BufferOverflow.Shared
{
    public interface IUserFacade : IFacade
    {
        OperationResult<IUserDTO> Login(IUserDTO userDTO);
        OperationResult<IUserDTO> Register(IUserDTO userDTO);
        OperationResult<IUserDTO> GetProfile(IUserDTO userDTO);
    }
}
