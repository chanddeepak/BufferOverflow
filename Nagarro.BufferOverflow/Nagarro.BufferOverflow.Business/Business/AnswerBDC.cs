using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.BufferOverflow.Shared;

namespace Nagarro.BufferOverflow.Business
{
    public class AnswerBDC : BDCBase, IAnswerBDC
    {
        public AnswerBDC()
            : base(BDCType.AnswerBDC)
        {

        }

        public OperationResult<IAnswerDTO> Create(IAnswerDTO answerDTO)
        {
            OperationResult<IAnswerDTO> retVal = null;
            try
            {
                IAnswerDAC answerDAC = (IAnswerDAC)DACFactory.Instance.Create(DACType.AnswerDAC);
                IAnswerDTO resultDTO = answerDAC.Create(answerDTO);
                if (resultDTO != null)
                {
                    retVal = OperationResult<IAnswerDTO>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<IAnswerDTO>.CreateFailureResult("Failed to create!");
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IAnswerDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IAnswerDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }

        public OperationResult<IAnswerDTO> Delete(IAnswerDTO answerDTO)
        {
            OperationResult<IAnswerDTO> retVal = null;
            try
            {
                IAnswerDAC answerDAC = (IAnswerDAC)DACFactory.Instance.Create(DACType.AnswerDAC);
                IAnswerDTO resultDTO = answerDAC.Delete(answerDTO);
                if (resultDTO != null)
                {
                    retVal = OperationResult<IAnswerDTO>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<IAnswerDTO>.CreateFailureResult("Failed to delete!");
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IAnswerDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IAnswerDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }

        public OperationResult<IAnswerDTO> Edit(IAnswerDTO answerDTO)
        {
            OperationResult<IAnswerDTO> retVal = null;
            try
            {
                IAnswerDAC answerDAC = (IAnswerDAC)DACFactory.Instance.Create(DACType.AnswerDAC);
                IAnswerDTO resultDTO = answerDAC.Edit(answerDTO);
                if (resultDTO != null)
                {
                    retVal = OperationResult<IAnswerDTO>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<IAnswerDTO>.CreateFailureResult("Failed to edit!");
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IAnswerDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IAnswerDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }

        public OperationResult<List<IDataDTO>> GetAnswers(IAnswerDTO answerDTO)
        {
            OperationResult<List<IDataDTO>> retVal = null;
            try
            {
                IAnswerDAC answerDAC = (IAnswerDAC)DACFactory.Instance.Create(DACType.AnswerDAC);
                List<IDataDTO> resultDTO = answerDAC.GetAnswers(answerDTO);
                if (resultDTO != null)
                {
                    retVal = OperationResult<List<IDataDTO>>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<List<IDataDTO>>.CreateFailureResult("Failed to load!");
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<List<IDataDTO>>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<List<IDataDTO>>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }

        public OperationResult<IDataDTO> CreateVote(IVoteDTO voteDTO)
        {
            OperationResult<IDataDTO> retVal = null;
            try
            {
                IAnswerDAC answerDAC = (IAnswerDAC)DACFactory.Instance.Create(DACType.AnswerDAC);
                IDataDTO resultDTO = answerDAC.CreateVote(voteDTO);
                if (resultDTO != null)
                {
                    retVal = OperationResult<IDataDTO>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<IDataDTO>.CreateFailureResult("Failed to edit!");
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IDataDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IDataDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }



    }
}
