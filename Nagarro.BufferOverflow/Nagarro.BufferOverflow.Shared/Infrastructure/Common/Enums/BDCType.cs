namespace Nagarro.BufferOverflow.Shared
{
    /// <summary>
    /// Business Domain Component Type
    /// </summary>
    public enum BDCType
    {
        /// <summary>
        /// Undefined BDC (Default)
        /// </summary>
        Undefined = 0,

        [QualifiedTypeName("Nagarro.BufferOverflow.Business.dll", "Nagarro.BufferOverflow.Business.UserBDC")]
        UserBDC = 1,

        [QualifiedTypeName("Nagarro.BufferOverflow.Business.dll", "Nagarro.BufferOverflow.Business.QuestionBDC")]
        QuestionBDC = 2,

        [QualifiedTypeName("Nagarro.BufferOverflow.Business.dll", "Nagarro.BufferOverflow.Business.AnswerBDC")]
        AnswerBDC = 3,

        [QualifiedTypeName("Nagarro.BufferOverflow.Business.dll", "Nagarro.BufferOverflow.Business.TagBDC")]
        TagBDC = 4

    }
}
