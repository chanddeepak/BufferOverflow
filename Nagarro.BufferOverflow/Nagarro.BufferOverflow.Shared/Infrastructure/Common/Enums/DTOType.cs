namespace Nagarro.BufferOverflow.Shared
{
    /// <summary>
    /// Data Transfer Objects
    /// </summary>
    public enum DTOType
    {
        /// <summary>
        /// Undefined DTO (Default)
        /// </summary>
        Undefined = 0,

        [QualifiedTypeName("Nagarro.BufferOverflow.DTOModel.dll", "Nagarro.BufferOverflow.DTOModel.UserDTO")]
        UserDTO = 1,

        [QualifiedTypeName("Nagarro.BufferOverflow.DTOModel.dll", "Nagarro.BufferOverflow.DTOModel.QuestionsDTO")]
        QuestionDTO = 2,

        [QualifiedTypeName("Nagarro.BufferOverflow.DTOModel.dll", "Nagarro.BufferOverflow.DTOModel.AnswersDTO")]
        AnswerDTO = 3,

        [QualifiedTypeName("Nagarro.BufferOverflow.DTOModel.dll", "Nagarro.BufferOverflow.DTOModel.TagsDTO")]
        TagsDTO = 4,

        [QualifiedTypeName("Nagarro.BufferOverflow.DTOModel.dll", "Nagarro.BufferOverflow.DTOModel.TagRelationDTO")]
        TagRelationDTO = 5,

        [QualifiedTypeName("Nagarro.BufferOverflow.DTOModel.dll", "Nagarro.BufferOverflow.DTOModel.VotesDTO")]
        VoteDTO = 6,

        [QualifiedTypeName("Nagarro.BufferOverflow.DTOModel.dll", "Nagarro.BufferOverflow.DTOModel.DataDTO")]
        DataDTO = 7
    }
}
