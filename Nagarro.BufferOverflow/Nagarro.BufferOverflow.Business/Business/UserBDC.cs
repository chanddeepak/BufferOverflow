using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.BufferOverflow.Shared;

namespace Nagarro.BufferOverflow.Business
{
    public class UserBDC : BDCBase, IUserBDC
    {
        public UserBDC()
            : base(BDCType.UserBDC)
        {

        }
        /// <summary>
        /// Method to get user profile
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        public OperationResult<IUserDTO> GetProfile(IUserDTO userDTO)
        {
            OperationResult<IUserDTO> retVal = null;
            try
            {
                IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
                IUserDTO resultDTO = userDAC.GetProfile(userDTO);
                if (resultDTO != null)
                {
                    retVal = OperationResult<IUserDTO>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<IUserDTO>.CreateFailureResult("Failed to get profile!");
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IUserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IUserDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }
        /// <summary>
        /// Method to login user
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        public OperationResult<IUserDTO> Login(IUserDTO userDTO)
        {
            OperationResult<IUserDTO> retVal = null;
            try
            {
                IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
                IUserDTO resultDTO = userDAC.Login(userDTO);
                if (resultDTO != null)
                {
                    retVal = OperationResult<IUserDTO>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<IUserDTO>.CreateFailureResult("Email or password doesn't match!");
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IUserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IUserDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }

        /// <summary>
        /// Method to register user
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        public OperationResult<IUserDTO> Register(IUserDTO userDTO)
        {
            OperationResult<IUserDTO> retVal = null;
            try
            {
                IUserDAC userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
                IUserDTO resultDTO = userDAC.Register(userDTO);
                if (resultDTO != null)
                {
                    retVal = OperationResult<IUserDTO>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<IUserDTO>.CreateFailureResult("Email Id already exist!");
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IUserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IUserDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }
    }
}
