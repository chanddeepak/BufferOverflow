using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.BufferOverflow.Shared;

namespace Nagarro.BufferOverflow.Business
{
    public class QuestionBDC : BDCBase, IQuestionBDC
    {
        public QuestionBDC()
            : base(BDCType.QuestionBDC)
        {

        }

        public OperationResult<IQuestionDTO> Create(IQuestionDTO dataDTO)
        {                                               
            OperationResult<IQuestionDTO> retVal = null;
            try
            {
                IQuestionDAC questionDAC = (IQuestionDAC)DACFactory.Instance.Create(DACType.QuestionDAC);
                IQuestionDTO resultDTO = questionDAC.Create(dataDTO);
                if (resultDTO != null)
                {
                    retVal = OperationResult<IQuestionDTO>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<IQuestionDTO>.CreateFailureResult("Failed!");
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IQuestionDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IQuestionDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }

        public OperationResult<IQuestionDTO> Delete(IQuestionDTO questionDTO)
        {
            OperationResult<IQuestionDTO> retVal = null;
            try
            {
                IQuestionDAC questionDAC = (IQuestionDAC)DACFactory.Instance.Create(DACType.QuestionDAC);
                IQuestionDTO resultDTO = questionDAC.Delete(questionDTO);
                if (resultDTO != null)
                {
                    retVal = OperationResult<IQuestionDTO>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<IQuestionDTO>.CreateFailureResult("Failed to create!");
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IQuestionDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IQuestionDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }

        public OperationResult<IDataDTO> Details(IQuestionDTO questionDTO)
        {
            OperationResult<IDataDTO> retVal = null;
            try
            {
                IQuestionDAC questionDAC = (IQuestionDAC)DACFactory.Instance.Create(DACType.QuestionDAC);
                IDataDTO resultDTO = questionDAC.Details(questionDTO);
                if (resultDTO != null)
                {
                    retVal = OperationResult<IDataDTO>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<IDataDTO>.CreateFailureResult("Failed to get details!");
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

        public OperationResult<IQuestionDTO> Edit(IQuestionDTO questionDTO)
        {
            OperationResult<IQuestionDTO> retVal = null;
            try
            {
                IQuestionDAC questionDAC = (IQuestionDAC)DACFactory.Instance.Create(DACType.QuestionDAC);
                IQuestionDTO resultDTO = questionDAC.Edit(questionDTO);
                if (resultDTO != null)
                {
                    retVal = OperationResult<IQuestionDTO>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<IQuestionDTO>.CreateFailureResult("Failed to edit!");
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IQuestionDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IQuestionDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }

        public OperationResult<List<IDataDTO>> GetQuestions()
        {
            OperationResult<List<IDataDTO>> retVal = null;
            try
            {
                IQuestionDAC questionDAC = (IQuestionDAC)DACFactory.Instance.Create(DACType.QuestionDAC);
                List<IDataDTO> resultDTO = questionDAC.GetQuestions();
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

        public OperationResult<List<IQuestionDTO>> Search(IQuestionDTO questionDTO)
        {
            OperationResult<List<IQuestionDTO>> retVal = null;
            try
            {
                IQuestionDAC questionDAC = (IQuestionDAC)DACFactory.Instance.Create(DACType.QuestionDAC);
                List<IQuestionDTO> resultDTO = questionDAC.Search(questionDTO);
                if (resultDTO != null)
                {
                    retVal = OperationResult<List<IQuestionDTO>>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<List<IQuestionDTO>>.CreateFailureResult("Not found!");
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<List<IQuestionDTO>>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<List<IQuestionDTO>>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }
    }
}
