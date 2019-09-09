using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Nagarro.BufferOverflow.DTOModel;
using Nagarro.BufferOverflow.Shared;
using Newtonsoft.Json;

namespace Nagarro.BufferOverflow.UI
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TagController : ApiController
    {
        /// <summary>
        /// Get action method to get tags
        /// </summary>
        /// <returns></returns>
        [Route("api/tags")]
        public IEnumerable<TagsDTO> GetTags()
        {
            ITagFacade tagsFacade = (ITagFacade)FacadeFactory.Instance.Create(FacadeType.TagFacade);
            OperationResult<List<ITagsDTO>> result = tagsFacade.GetTags();

            return (IEnumerable<TagsDTO>)result.Data;

        }

        /// <summary>
        /// Get action method to search on the basis of tags
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        [Route("api/tag/search/{tags}")]
        public IEnumerable<QuestionsDTO> SearchQuestion(string tags)
        {
            ITagsDTO tag = (ITagsDTO)DTOFactory.Instance.Create(DTOType.TagsDTO);
            tag.Tag = tags;
            ITagFacade questionFacade = (ITagFacade)FacadeFactory.Instance.Create(FacadeType.TagFacade);
            OperationResult<List<IQuestionDTO>> result = questionFacade.SearchQuestion(tag);

            return (IEnumerable<QuestionsDTO>)result.Data;

        }

        /// <summary>
        /// Post action method to create new tags
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/tag/create/{questionId}")]
        public IHttpActionResult Create([FromBody]List<Tags> tags, int questionId)
        {
            List<ITagsDTO> tagsDTO = new List<ITagsDTO>();
            foreach(var tag in tags)
            {
                ITagsDTO tagDTO = (ITagsDTO)DTOFactory.Instance.Create(DTOType.TagsDTO);
                EntityConverter.FillDTOFromEntity(tag, tagDTO);
                tagsDTO.Add(tagDTO);
            }
            ITagFacade tagsFacade = (ITagFacade)FacadeFactory.Instance.Create(FacadeType.TagFacade);
            OperationResult<bool> result = tagsFacade.Create(tagsDTO, questionId);
            if (result.ResultType == OperationResultType.Failure)
            {
                string failed = JsonConvert.SerializeObject(new { success = false, data = result.Message });
                return BadRequest(failed);
            }

            if (result.IsValid())
            {
                string success = JsonConvert.SerializeObject(new { success = true, data = true });
                return Ok(success);
            }

            string jsonObj = JsonConvert.SerializeObject(new { success = false, data = result.Message });
            return BadRequest(jsonObj);
        }

    }
}