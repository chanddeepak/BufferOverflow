namespace Nagarro.BufferOverflow.Shared
{
    /// <summary>
    /// Data Access Component Type
    /// </summary>
    public enum DACType
    {
        /// <summary>
        /// Undefined DAC (Default)
        /// </summary>
        Undefined = 0,

        [QualifiedTypeName("Nagarro.BufferOverflow.Data.dll", "Nagarro.BufferOverflow.Data.UserDAC")]
        UserDAC = 1,

        [QualifiedTypeName("Nagarro.BufferOverflow.Data.dll", "Nagarro.BufferOverflow.Data.QuestionDAC")]
        QuestionDAC = 2,

        [QualifiedTypeName("Nagarro.BufferOverflow.Data.dll", "Nagarro.BufferOverflow.Data.AnswerDAC")]
        AnswerDAC = 3,

        [QualifiedTypeName("Nagarro.BufferOverflow.Data.dll", "Nagarro.BufferOverflow.Data.VoteDAC")]
        VoteDAC = 4,

        [QualifiedTypeName("Nagarro.BufferOverflow.Data.dll", "Nagarro.BufferOverflow.Data.TagDAC")]
        TagDAC = 5


    }
}
