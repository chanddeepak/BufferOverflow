using Nagarro.BufferOverflow.EntityDataModel;
using Nagarro.BufferOverflow.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BufferOverflow.Data
{
    public class AnswerDAC : DACBase, IAnswerDAC
    {
        public AnswerDAC()
            : base(DACType.AnswerDAC)
        {}

        /// <summary>
        /// Method to create answer
        /// </summary>
        /// <param name="answerDTO"></param>
        /// <returns></returns>
        public IAnswerDTO Create(IAnswerDTO answerDTO)
        {
            using (var context = new BufferOverflowDBEntities())
            {
                Answers answerEntity = new Answers();
                EntityConverter.FillEntityFromDTO(answerDTO, answerEntity);

                var answer = context.Answers.Add(answerEntity);
                context.SaveChanges();

                if (answer != null)
                {
                    var question = context.Questions.SingleOrDefault(q => q.Id == answer.QuestionId);
                    question.AnswerCount++;
                    context.SaveChanges();
                    EntityConverter.FillDTOFromEntity(answer, answerDTO);
                }

                return (answerDTO.Id != 0) ? answerDTO : null; ;
            }
        }

        /// <summary>
        /// Method to delete answer
        /// </summary>
        /// <param name="answerDTO"></param>
        /// <returns></returns>
        public IAnswerDTO Delete(IAnswerDTO answerDTO)
        {
            using (var context = new BufferOverflowDBEntities())
            {
                var deleteAnswer = context.Answers
                    .SingleOrDefault(a => a.Id == answerDTO.Id);

                if (deleteAnswer != null)
                {
                    // Delete Vote
                    var deleteVote = context.Votes.Where(v => v.AnswerId == answerDTO.Id).ToList();
                    foreach (var vote in deleteVote)
                    {
                        context.Votes.Remove(vote);
                        context.SaveChanges();
                    }

                    // Delete Answer
                    var answer = context.Answers.Remove(deleteAnswer);
                    context.SaveChanges();
                    var question = context.Questions.SingleOrDefault(q => q.Id == answer.QuestionId);
                    question.AnswerCount--;
                    context.SaveChanges();
                    EntityConverter.FillDTOFromEntity(answer, answerDTO);
                }
                return answerDTO;

            }
        }

        public IAnswerDTO Edit(IAnswerDTO answerDTO)
        {
            using (var context = new BufferOverflowDBEntities())
            {
                var answerEntity = context.Answers.SingleOrDefault(a => a.Id == answerDTO.Id);
          
                if (answerEntity != null)
                {
                    EntityConverter.FillEntityFromDTO(answerDTO, answerEntity);
                }

                return answerDTO;
            }
        }

        public List<IDataDTO> GetAnswers(IAnswerDTO answerDTO)
        {
            using (var context = new BufferOverflowDBEntities())
            {
                List<IDataDTO> listOfAnswers = null;
                var answerEntityList = context.Answers.Where(a => a.QuestionId == answerDTO.QuestionId).ToList();

                if (answerEntityList != null)
                {
                    listOfAnswers = new List<IDataDTO>();
                    foreach (var answerEntity in answerEntityList)
                    {
                        
                        IAnswerDTO ansDTO = (IAnswerDTO)DTOFactory.Instance.Create(DTOType.AnswerDTO);
                        EntityConverter.FillDTOFromEntity(answerEntity, ansDTO);

                        // Getting user
                        var userEntity = context.User.SingleOrDefault(u => u.Id == answerEntity.UserId);
                        IUserDTO userDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
                        EntityConverter.FillDTOFromEntity(userEntity, userDTO);
                        userDTO.Password = "";

                        // Getting  votes
                        var voteEntity = context.Votes.SingleOrDefault(v => v.UserId == userEntity.Id && v.AnswerId == answerEntity.Id);
                        IVoteDTO voteDTO = (IVoteDTO)DTOFactory.Instance.Create(DTOType.VoteDTO);
                        if (voteEntity != null)
                        {
                            EntityConverter.FillDTOFromEntity(voteEntity, voteDTO);
                        } else
                        {
                            voteDTO.Vote = 0;
                        }

                        var countUp = context.Votes.Where(c => c.Vote == 1 && c.AnswerId == voteDTO.AnswerId).Count();
                        var countDown = context.Votes.Where(c => c.Vote == 2 && c.AnswerId == voteDTO.AnswerId).Count();

                        int totalVotes = countUp - countDown;

                        IDataDTO dataDTO = (IDataDTO)DTOFactory.Instance.Create(DTOType.DataDTO);
                        dataDTO.AnswerDetail = ansDTO;
                        dataDTO.UserDetail = userDTO;
                        dataDTO.VoteDetail = voteDTO;
                        dataDTO.TotalVote = totalVotes;
                        listOfAnswers.Add(dataDTO);

                    }

                }
                Console.WriteLine("Hello hi " + listOfAnswers[0].TotalVote);
                return listOfAnswers;
            }
        }

        public IDataDTO CreateVote(IVoteDTO voteDTO)
        {
            using (var context = new BufferOverflowDBEntities())
            {
                var voteEntity = context.Votes.SingleOrDefault(v => v.UserId == voteDTO.UserId && v.AnswerId == voteDTO.AnswerId);
                //context.Votes.Where(v => v.Id == voteDTO.Id).Distinct();
                if (voteEntity == null)
                {
                    Votes vote = new Votes();
                    EntityConverter.FillEntityFromDTO(voteDTO, vote);
                    context.Votes.Add(vote);
                    context.SaveChanges();
                } else if(voteEntity.Vote != voteDTO.Vote)
                {
                    voteEntity.Vote = voteDTO.Vote;
                    context.SaveChanges();
                }

                var countUp = context.Votes.Where(c => c.Vote == 1 && c.AnswerId == voteDTO.AnswerId).Count();
                var countDown = context.Votes.Where(c => c.Vote == 2 && c.AnswerId == voteDTO.AnswerId).Count();

                int totalVotes = countUp - countDown;

                IDataDTO dataDTO = (IDataDTO)DTOFactory.Instance.Create(DTOType.DataDTO);
                dataDTO.TotalVote = totalVotes;
                dataDTO.VoteDetail = voteDTO;

                return dataDTO;
            }
      
        }

    }
}
