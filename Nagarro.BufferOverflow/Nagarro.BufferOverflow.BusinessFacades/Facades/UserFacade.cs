using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.BufferOverflow.Shared;

namespace Nagarro.BufferOverflow.BusinessFacades
{
    public class UserFacade : FacadeBase, IUserFacade
    {
        public UserFacade()
            : base(FacadeType.UserFacade)
        {

        }

        /// <summary>
        /// Method to get user profile
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        public OperationResult<IUserDTO> GetProfile(IUserDTO userDTO)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            return userBDC.GetProfile(userDTO);
        }

        /// <summary>
        /// Method to login user
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        public OperationResult<IUserDTO> Login(IUserDTO userDTO)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            return userBDC.Login(userDTO);
        }
        
        /// <summary>
        /// Method to register user
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        public OperationResult<IUserDTO> Register(IUserDTO userDTO)
        {
            IUserBDC userBDC = (IUserBDC)BDCFactory.Instance.Create(BDCType.UserBDC);
            return userBDC.Register(userDTO);
        }
    }
}
