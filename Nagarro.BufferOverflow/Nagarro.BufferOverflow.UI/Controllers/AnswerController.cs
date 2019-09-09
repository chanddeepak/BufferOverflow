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
    public class AnswerController : ApiController
    {
        /// <summary>
        /// Get action method to search on the basis of title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/answer/{questionId}")]
        public IHttpActionResult GetAnswers([FromUri]int questionId)
        {
            IAnswerDTO answer = (IAnswerDTO)DTOFactory.Instance.Create(DTOType.AnswerDTO);
            answer.QuestionId = questionId;
            IAnswerFacade answerFacade = (IAnswerFacade)FacadeFactory.Instance.Create(FacadeType.AnswerFacade);
            OperationResult<List<IDataDTO>> result = answerFacade.GetAnswers(answer);

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

                    EntityConverter.FillEntityFromDTO(dataDTO.AnswerDetail, data.AnswerDetail);

                    EntityConverter.FillEntityFromDTO(dataDTO.UserDetail, data.UserDetail);

                    EntityConverter.FillEntityFromDTO(dataDTO.VoteDetail, data.VoteDetail);

                    data.TotalVote = dataDTO.TotalVote;

                    dataList.Add(data);
                }
                string success = JsonConvert.SerializeObject(new { success = true, data = dataList });
                return Ok(success);
            }

            string jsonObj = JsonConvert.SerializeObject(new { success = false, data = result.Message });
            return BadRequest(jsonObj);

        }

        /// <summary>
        /// Post action method to create answer
        /// </summary>
        /// <param name="answer"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/answer/create")]
        public IHttpActionResult Create([FromBody]Answers answer)
        {
            answer.Created = DateTime.Now;
            IAnswerDTO answerDTO = (IAnswerDTO)DTOFactory.Instance.Create(DTOType.AnswerDTO);
            EntityConverter.FillDTOFromEntity(answer, answerDTO);

            IAnswerFacade answerFacade = (IAnswerFacade)FacadeFactory.Instance.Create(FacadeType.AnswerFacade);
            OperationResult<IAnswerDTO> result = answerFacade.Create(answerDTO);
            if (result.ResultType == OperationResultType.Failure)
            {
                string failed = JsonConvert.SerializeObject(new { success = false, data = result.Message });
                return BadRequest(failed);
            }

            if (result.IsValid())
            {
                //Answers answerEntity = new Answers();
                EntityConverter.FillEntityFromDTO(result.Data, answer);
                string success = JsonConvert.SerializeObject(new { success = true, data = answer });
                return Ok(success);
            }

            string jsonObj = JsonConvert.SerializeObject(new { success = false, data = result.Message });
            return BadRequest(jsonObj);
        }

        /// <summary>
        /// Post action method to update answer 
        /// </summary>
        /// <param name="answer"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/answer/edit")]
        public IHttpActionResult Edit([FromBody]IAnswerDTO answer)
        {
            answer.Created = DateTime.Now;
            IAnswerFacade answerFacade = (IAnswerFacade)FacadeFactory.Instance.Create(FacadeType.AnswerFacade);
            OperationResult<IAnswerDTO> result = answerFacade.Edit(answer);
            if (result.ResultType == OperationResultType.Failure)
            {
                return BadRequest(result.Message);
            }

            if (result.IsValid())
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        /// <summary>
        /// Delete action method to delete answer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/answer/delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            IAnswerDTO answer = (IAnswerDTO)DTOFactory.Instance.Create(DTOType.AnswerDTO);
            answer.Id = id;
            IAnswerFacade answerFacade = (IAnswerFacade)FacadeFactory.Instance.Create(FacadeType.AnswerFacade);
            OperationResult<IAnswerDTO> result = answerFacade.Delete(answer);
            if (result.ResultType == OperationResultType.Failure)
            {
                string failed = JsonConvert.SerializeObject(new { success = false, data = result.Message });
                return BadRequest(failed);
            }

            if (result.IsValid())
            {
                Answers answerModel = new Answers();
                EntityConverter.FillEntityFromDTO(result.Data, answerModel);
                string success = JsonConvert.SerializeObject(new { success = true, data = answerModel });
                return Ok(success);
            }
            string jsonObj = JsonConvert.SerializeObject(new { success = false, data = result.Message });
            return BadRequest(jsonObj);
        }

        [HttpPost]
        [Route("api/answer/votes")]
        public IHttpActionResult CreateVote([FromBody]Votes vote)
        {
            IVoteDTO votesDTO = (IVoteDTO)DTOFactory.Instance.Create(DTOType.VoteDTO);
            EntityConverter.FillDTOFromEntity(vote, votesDTO);
            IAnswerFacade answerFacade = (IAnswerFacade)FacadeFactory.Instance.Create(FacadeType.AnswerFacade);
            OperationResult<IDataDTO> result = answerFacade.CreateVote(votesDTO);
            if (result.ResultType == OperationResultType.Failure)
            {
                string failed = JsonConvert.SerializeObject(new { success = false, data = result.Message });
                return BadRequest(failed);
            }

            if (result.IsValid())
            {
                Data dataModel = new Data(); 
                EntityConverter.FillEntityFromDTO(result.Data.VoteDetail, dataModel.VoteDetail);
                dataModel.TotalVote = result.Data.TotalVote;
                string success = JsonConvert.SerializeObject(new { success = true, data = dataModel });
                return Ok(success);
            }
            string jsonObj = JsonConvert.SerializeObject(new { success = false, data = result.Message });
            return BadRequest(jsonObj);
        }
    }
}