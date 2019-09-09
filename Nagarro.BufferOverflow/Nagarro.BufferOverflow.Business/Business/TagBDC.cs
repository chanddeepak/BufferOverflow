using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.BufferOverflow.Shared;

namespace Nagarro.BufferOverflow.Business
{
    public class TagBDC : BDCBase, ITagBDC
    {
        public TagBDC()
            : base(BDCType.TagBDC)
        {

        }

        public OperationResult<bool> Create(List<ITagsDTO> listOfTags, int questionId)
        {
            OperationResult<bool> retVal = null;
            try
            {
                ITagDAC tagDAC = (ITagDAC)DACFactory.Instance.Create(DACType.TagDAC);
                bool resultDTO = tagDAC.Create(listOfTags, questionId);
                if (resultDTO)
                {
                    retVal = OperationResult<bool>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<bool>.CreateFailureResult("Failed to create!");
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<bool>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<bool>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;

        }

        public OperationResult<List<ITagsDTO>> GetTags()
        {
            OperationResult<List<ITagsDTO>> retVal = null;
            try
            {
                ITagDAC tagDAC = (ITagDAC)DACFactory.Instance.Create(DACType.UserDAC);
                List<ITagsDTO> resultDTO = tagDAC.GetTags();
                if (resultDTO != null)
                {
                    retVal = OperationResult<List<ITagsDTO>>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    retVal = OperationResult<List<ITagsDTO>>.CreateFailureResult("Failed to load!");
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<List<ITagsDTO>>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<List<ITagsDTO>>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;

        }

        public OperationResult<List<IQuestionDTO>> SearchQuestion(ITagsDTO tagDTO)
        {
            OperationResult<List<IQuestionDTO>> retVal = null;
            try
            {
                ITagDAC tagDAC = (ITagDAC)DACFactory.Instance.Create(DACType.UserDAC);
                List<IQuestionDTO> resultDTO = tagDAC.SearchQuestion(tagDTO);
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
