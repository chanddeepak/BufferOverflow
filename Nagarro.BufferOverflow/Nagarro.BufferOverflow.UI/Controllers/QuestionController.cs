using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Nagarro.BufferOverflow.DTOModel;
using Nagarro.BufferOverflow.Shared;
using Newtonsoft.Json;
using System.Web.Http.Cors;

namespace Nagarro.BufferOverflow.UI
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class QuestionController : ApiController
    {
        /// <summary>
        /// Get action method to get questions
        /// </summary>
        /// <returns></returns>
        [Route("api/question")]
        public IHttpActionResult GetQuestions()
        {
            IQuestionFacade questionFacade = (IQuestionFacade)FacadeFactory.Instance.Create(FacadeType.QuestionFacade);
            OperationResult<List<IDataDTO>> result = questionFacade.GetQuestions();

            if (result.ResultType == OperationResultType.Failure)
            {
                string failed = JsonConvert.SerializeObject(new { success = false, data = result.Message });
                return BadRequest(failed);
            }

            if (result.IsValid())
            {

                List<Data> dataList = new List<Data>();
           
                foreach (var dataDTO in result.Data)
                {
                    Data data = new Data();
                    
                    EntityConverter.FillEntityFromDTO(dataDTO.QuestionDetail, data.QuestionDetail);
                    
                    EntityConverter.FillEntityFromDTO(dataDTO.UserDetail, data.UserDetail);
                    
                    List<ITagsDTO> tagsDTOList = dataDTO.TagDetail;
                    List<Tags> tagsModel = new List<Tags>();
                    foreach (var tagDTO in tagsDTOList)
                    {
                        Tags tag = new Tags();
                        EntityConverter.FillEntityFromDTO(tagDTO, tag);
                        tagsModel.Add(tag);

                    }
                    
                    data.TagDetail = tagsModel;
                    dataList.Add(data);
                }
                //string success = JsonConvert.SerializeObject(new { success = true, data = dataList });
                return Ok(result.Data[0].QuestionDetail);
            }

            string jsonObj = JsonConvert.SerializeObject(new { success = false, data = result.Message });
            return BadRequest(jsonObj);

        }

        /// <summary>
        /// Get action method to search on the basis of title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        [Route("api/question/search/{title}")]
        public IEnumerable<QuestionsDTO> Search(string title)
        {
            IQuestionDTO question = (IQuestionDTO)DTOFactory.Instance.Create(DTOType.QuestionDTO);
            question.Title = title;
            IQuestionFacade questionFacade = (IQuestionFacade)FacadeFactory.Instance.Create(FacadeType.QuestionFacade);
            OperationResult<List<IQuestionDTO>> result = questionFacade.Search(question);

            return (IEnumerable<QuestionsDTO>)result.Data;

        }

        /// <summary>
        /// Post action method to create new question
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/question/create")]
        public IHttpActionResult Create([FromBody]Questions data)
        {
            IQuestionDTO dataDTO = (IQuestionDTO)DTOFactory.Instance.Create(DTOType.QuestionDTO);
            EntityConverter.FillDTOFromEntity(data, dataDTO);
            dataDTO.Created = DateTime.Now;
          

            IQuestionFacade questionFacade = (IQuestionFacade)FacadeFactory.Instance.Create(FacadeType.QuestionFacade);
            OperationResult<IQuestionDTO> result = questionFacade.Create(dataDTO);
            if (result.ResultType == OperationResultType.Failure)
            {
                string failed = JsonConvert.SerializeObject(new { success = false, data = result.Message });
                return BadRequest(failed);
            }

            if (result.IsValid())
            {
                Questions question = new Questions();
                EntityConverter.FillEntityFromDTO(result.Data, question);
                string success = JsonConvert.SerializeObject(new { success = true, data = question });
                return Ok(success);
            }

            string jsonObj = JsonConvert.SerializeObject(new { success = false, data = result.Message });
            return BadRequest(jsonObj);
        }
        
        /// <summary>
        /// Post action method to update question 
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/question/edit")]
        public IHttpActionResult Edit([FromBody]Questions question)
        {
            IQuestionDTO questionDTO = (IQuestionDTO)DTOFactory.Instance.Create(DTOType.QuestionDTO);
            question.Created = DateTime.Now;
            EntityConverter.FillDTOFromEntity(question, questionDTO);

            IQuestionFacade questionFacade = (IQuestionFacade)FacadeFactory.Instance.Create(FacadeType.QuestionFacade);
            OperationResult<IQuestionDTO> result = questionFacade.Edit(questionDTO);

            if (result.ResultType == OperationResultType.Failure)
            {
                string failed = JsonConvert.SerializeObject(new { success = false, data = result.Message });
                return BadRequest(failed);
            }

            if (result.IsValid())
            {
                //Questions question = new Questions();
                EntityConverter.FillEntityFromDTO(result.Data, question);
                string success = JsonConvert.SerializeObject(new { success = true, data = question });
                return Ok(success);
            }

            string jsonObj = JsonConvert.SerializeObject(new { success = false, data = result.Message });
            return BadRequest(jsonObj);
        }

        /// <summary>
        /// Get action method to get questions details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/question/details/{id}")]
        public IHttpActionResult Details([FromUri]int id)
        {
            IQuestionDTO question = (IQuestionDTO)DTOFactory.Instance.Create(DTOType.QuestionDTO);
            question.Id = id;
            IQuestionFacade questionFacade = (IQuestionFacade)FacadeFactory.Instance.Create(FacadeType.QuestionFacade);
            OperationResult<IDataDTO> result = questionFacade.Details(question);
            if (result.ResultType == OperationResultType.Failure)
            {
                string failed = JsonConvert.SerializeObject(new { success = false, data = result.Message });
                return BadRequest(failed);
            }

            if (result.IsValid())
            {
                Data dataModel = new Data();

                EntityConverter.FillEntityFromDTO(result.Data.QuestionDetail, dataModel.QuestionDetail);

                EntityConverter.FillEntityFromDTO(result.Data.UserDetail, dataModel.UserDetail);

                List<ITagsDTO> tagsDTOList = result.Data.TagDetail;
                List<Tags> tagsModel = new List<Tags>();
                foreach (var tagDTO in tagsDTOList)
                {
                    Tags tag = new Tags();
                    EntityConverter.FillEntityFromDTO(tagDTO, tag);
                    tagsModel.Add(tag);

                }

                dataModel.TagDetail = tagsModel;

                string success = JsonConvert.SerializeObject(new { success = true, data = dataModel });
                return Ok(success);
            }
            string jsonObj = JsonConvert.SerializeObject(new { success = false, data = result.Message });
            return BadRequest(jsonObj);
        }

        /// <summary>
        /// Delete action method to delete question
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/question/delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            IQuestionDTO questionDTO = (IQuestionDTO)DTOFactory.Instance.Create(DTOType.QuestionDTO);
            questionDTO.Id = id;
            IQuestionFacade questionFacade = (IQuestionFacade)FacadeFactory.Instance.Create(FacadeType.QuestionFacade);
            OperationResult<IQuestionDTO> result = questionFacade.Delete(questionDTO);
            if (result.ResultType == OperationResultType.Failure)
            {
                string failed = JsonConvert.SerializeObject(new { success = false, data = result.Message });
                return BadRequest(failed);
            }

            if (result.IsValid())
            {
                Questions question = new Questions();
                EntityConverter.FillEntityFromDTO(result.Data, question);
                string success = JsonConvert.SerializeObject(new { success = true, data = question });
                return Ok(success);
            }
            string jsonObj = JsonConvert.SerializeObject(new { success = false, data = result.Message });
            return BadRequest(jsonObj);
        }
    }
}