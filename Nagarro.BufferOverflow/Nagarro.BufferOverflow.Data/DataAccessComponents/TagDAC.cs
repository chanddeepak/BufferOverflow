using Nagarro.BufferOverflow.EntityDataModel;
using Nagarro.BufferOverflow.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BufferOverflow.Data
{
    public class TagDAC : DACBase, ITagDAC
    {
        public TagDAC()
            : base(DACType.TagDAC)
        {}

        /// <summary>
        /// Method to create tag
        /// </summary>
        /// <param name=""></param>
        public bool Create(List<ITagsDTO> listOfTags, int questionId)
        {   
            using(var context = new BufferOverflowDBEntities())
            {
                foreach(var tags in listOfTags)
                {
                    var isExist = context.Tags.SingleOrDefault(t => t.Tag == tags.Tag);
                    if (isExist == null)
                    {
                        Tags tagEntity = new Tags();
                        EntityConverter.FillEntityFromDTO(tags, tagEntity);
                        isExist = context.Tags.Add(tagEntity);
                        context.SaveChanges();
                    }
                    TagRelation tagRelationEntity = context.TagRelation.SingleOrDefault(t => t.TagId == isExist.Id && t.QuestionId == questionId);
                    if (tagRelationEntity == null)
                    {
                        tagRelationEntity = new TagRelation();
                        tagRelationEntity.QuestionId = questionId;
                        tagRelationEntity.TagId = isExist.Id;
                        context.TagRelation.Add(tagRelationEntity);
                        context.SaveChanges();
                    }
                }

                return true;
            }
        }

        /// <summary>
        /// Method get all tags in table
        /// </summary>
        /// <returns></returns>
        public List<ITagsDTO> GetTags()
        {
            using(var context = new BufferOverflowDBEntities())
            {
                var tagsEntity = context.Tags.ToList();

                List<ITagsDTO> listOfTags = null;

                if(tagsEntity != null)
                {
                    foreach (var tags in tagsEntity)
                    {
                        ITagsDTO tagsDTO = (ITagsDTO)DTOFactory.Instance.Create(DTOType.TagsDTO);
                        EntityConverter.FillDTOFromEntity(tagsEntity, tagsDTO);
                        listOfTags.Add(tagsDTO);
                    }
                }

                return listOfTags;
            }
        }

        /// <summary>
        /// Method to search question with given tag
        /// </summary>
        /// <param name="tagDTO"></param>
        /// <returns></returns>
        public List<IQuestionDTO> SearchQuestion(ITagsDTO tagDTO)
        {
            using(var context = new BufferOverflowDBEntities())
            {
                var questionIds = context.TagRelation.Where(t => t.Id == tagDTO.Id).ToList();
                List<IQuestionDTO> listOfQuestions = null;

                if(questionIds != null)
                {
                    foreach(var question in questionIds)
                    {
                        var questionEntity = context.Questions.SingleOrDefault(q => q.Id == question.QuestionId);
                        IQuestionDTO questionDTO = (IQuestionDTO)DTOFactory.Instance.Create(DTOType.QuestionDTO);
                        EntityConverter.FillDTOFromEntity(questionEntity, questionDTO);
                        listOfQuestions.Add(questionDTO);
                    }
                }

                return listOfQuestions;
            }
        }
    }
}
