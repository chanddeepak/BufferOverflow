using Nagarro.BufferOverflow.EntityDataModel;
using Nagarro.BufferOverflow.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BufferOverflow.Data
{
    public class QuestionDAC : DACBase, IQuestionDAC
    {
        public QuestionDAC()
            : base(DACType.QuestionDAC)
        {}

        /// <summary>
        /// Method to create question
        /// </summary>
        /// <param name="questionDTO"></param>
        /// <returns></returns>
        public IQuestionDTO Create(IQuestionDTO dataDTO)
        {
            using(var context = new BufferOverflowDBEntities())
            {
                Questions questionEntity = new Questions();
                EntityConverter.FillEntityFromDTO(dataDTO, questionEntity);

                var question = context.Questions.Add(questionEntity);
                context.SaveChanges();

                IQuestionDTO questionDTO = (IQuestionDTO)DTOFactory.Instance.Create(DTOType.QuestionDTO);
                if (question != null)
                { 
                    EntityConverter.FillDTOFromEntity(question, dataDTO);
                }

                return (dataDTO.Id != 0) ? dataDTO : null; ;
            }
        }

        /// <summary>
        /// Method to delete question
        /// </summary>
        /// <param name="questionDTO"></param>
        /// <returns></returns>
        public IQuestionDTO Delete(IQuestionDTO questionDTO)
        {
            using (var context = new BufferOverflowDBEntities())
            {
                var deleteQuestion = context.Questions
                    .SingleOrDefault(q => q.Id == questionDTO.Id);

                if (deleteQuestion != null)
                {
                    // Deleting Answer
                    var deleteAnswers = context.Answers.Where(a => a.QuestionId == questionDTO.Id).ToList();
                    
                    foreach (var answer in deleteAnswers)
                    {
                        var votesEntity = context.Votes.Where(v => v.AnswerId == answer.Id).ToList();
                        foreach (var vote in votesEntity)
                        {
                            context.Votes.Remove(vote);
                            context.SaveChanges();
                        }
                        context.Answers.Remove(answer);
                        context.SaveChanges();
                    }

                    // Deleting from Tag Relation
                    var deleteTagRelation = context.TagRelation.Where(t => t.QuestionId == questionDTO.Id).ToList();
                    foreach (var tag in deleteTagRelation)
                    {
                        context.TagRelation.Remove(tag);
                        context.SaveChanges();
                    }

                    // Deleting Question
                    var question = context.Questions.Remove(deleteQuestion);
                    context.SaveChanges();
                    EntityConverter.FillDTOFromEntity(question, questionDTO);
                }
                return questionDTO;

            }
        
        }

        /// <summary>
        /// Method to get question detail
        /// </summary>
        /// <param name="questionDTO"></param>
        /// <returns></returns>
        public IDataDTO Details(IQuestionDTO questionDTO)
        {
            using (var context = new BufferOverflowDBEntities())
            {
                IDataDTO dataDTO = (IDataDTO)DTOFactory.Instance.Create(DTOType.DataDTO);
                var questionDetail = context.Questions.SingleOrDefault(q => q.Id == questionDTO.Id);

                if (questionDetail != null)
                {
                    dataDTO.QuestionDetail = (IQuestionDTO)DTOFactory.Instance.Create(DTOType.QuestionDTO);
                    EntityConverter.FillDTOFromEntity(questionDetail, dataDTO.QuestionDetail);

                    // Geting Question tags
                    var tagRelationEntity = context.TagRelation.Where(t => t.QuestionId == questionDetail.Id).ToList();
                    List<ITagsDTO> tags = new List<ITagsDTO>(); 
                    foreach(var tag in tagRelationEntity)
                    {
                        var tagEntity = context.Tags.SingleOrDefault(t => t.Id == tag.TagId);
                        ITagsDTO tagsDTO = (ITagsDTO)DTOFactory.Instance.Create(DTOType.TagsDTO);
                        EntityConverter.FillDTOFromEntity(tagEntity, tagsDTO);
                        tags.Add(tagsDTO);
                    }
                    dataDTO.TagDetail = tags;

                    // Getting User Detail
                    var userEntity = context.User.SingleOrDefault(u => u.Id == questionDetail.UserId);
                    dataDTO.UserDetail = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
                    EntityConverter.FillDTOFromEntity(userEntity, dataDTO.UserDetail);


                } else
                {
                    dataDTO.QuestionDetail.Id = 0;
                }

                return (dataDTO.QuestionDetail.Id != 0) ? dataDTO : null;
            }
        }

        /// <summary>
        /// Method to edit question
        /// </summary>
        /// <param name="questionDTO"></param>
        /// <returns></returns>
        public IQuestionDTO Edit(IQuestionDTO questionDTO)
        {
            using (var context = new BufferOverflowDBEntities())
            {
                var questionEntity = context.Questions.SingleOrDefault(q => q.Id == questionDTO.Id);
                if(questionEntity != null)
                {
                    EntityConverter.FillEntityFromDTO(questionDTO, questionEntity);
                    context.SaveChanges();
                } else
                {
                    questionDTO.Id = 0;
                }

                return (questionDTO.Id != 0) ? questionDTO : null;
            }
        }

        /// <summary>
        /// Method to get all questions
        /// </summary>
        /// <returns></returns>
        public List<IDataDTO> GetQuestions()
        {
            using (var context = new BufferOverflowDBEntities())
            {
                List<IDataDTO> listOfQuestions = null;
                var questionEntityList = context.Questions.OrderByDescending(e => e.Created).ToList();

                if (questionEntityList != null)
                {
                    listOfQuestions = new List<IDataDTO>();
                    foreach (var questionEntity in questionEntityList)
                    {
                        IQuestionDTO questionDTO = (IQuestionDTO)DTOFactory.Instance.Create(DTOType.QuestionDTO);
                        EntityConverter.FillDTOFromEntity(questionEntity, questionDTO);

                        // Getting Question tags
                        var tagsEntityList = context.TagRelation.Where(t => t.QuestionId == questionEntity.Id).ToList();
                        
                        
                        List<ITagsDTO> tagName = new List<ITagsDTO>();
                        foreach(var tags in tagsEntityList)
                        {
                            ITagsDTO tagDTO = (ITagsDTO)DTOFactory.Instance.Create(DTOType.TagsDTO);
                            var tag = context.Tags.SingleOrDefault(t => t.Id == tags.TagId);
                            EntityConverter.FillDTOFromEntity(tag, tagDTO);
                            tagName.Add(tagDTO);
                        }

                        // Getting User
                        IUserDTO userDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
                        var userEntity = context.User.SingleOrDefault(u => u.Id == questionEntity.UserId);
                        EntityConverter.FillDTOFromEntity(userEntity, userDTO);

                        IDataDTO dataDTO = (IDataDTO)DTOFactory.Instance.Create(DTOType.DataDTO);
                        dataDTO.QuestionDetail = questionDTO;
                        dataDTO.TagDetail = tagName;
                        dataDTO.UserDetail = userDTO;

                        listOfQuestions.Add(dataDTO);

                    }

                }

                return listOfQuestions;
            }
        }

        /// <summary>
        /// Method to search question with given title
        /// </summary>
        /// <param name="questionDTO"></param>
        /// <returns></returns>
        public List<IQuestionDTO> Search(IQuestionDTO questionDTO)
        {
            using(var context = new BufferOverflowDBEntities())
            {
                var questionEntityList = context.Questions.OrderByDescending(e => e.Created).Where(q => q.Title == questionDTO.Title).ToList();
                List<IQuestionDTO> listOfQuestions = null;

                if(questionEntityList != null)
                {
                    listOfQuestions = new List<IQuestionDTO>();
                    foreach (var questionEntity in questionEntityList)
                    {
                        IQuestionDTO quesDTO = (IQuestionDTO)DTOFactory.Instance.Create(DTOType.QuestionDTO);
                        EntityConverter.FillDTOFromEntity(questionEntity, quesDTO);
                        listOfQuestions.Add(quesDTO);
                    }
                }

                return listOfQuestions;
            }
        }
    }
}
