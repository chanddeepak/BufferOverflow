using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BufferOverflow.Shared
{
    /// <summary>
    /// The Facade Types
    /// </summary>
    public enum FacadeType
    {
        /// <summary>
        /// Undefined Facade Type (Default)
        /// </summary>
        Undefined = 0,


        [QualifiedTypeName("Nagarro.BufferOverflow.BusinessFacades.dll", "Nagarro.BufferOverflow.BusinessFacades.UserFacade")]
        UserFacade = 1,

        [QualifiedTypeName("Nagarro.BufferOverflow.BusinessFacades.dll", "Nagarro.BufferOverflow.BusinessFacades.QuestionFacade")]
        QuestionFacade = 2,

        [QualifiedTypeName("Nagarro.BufferOverflow.BusinessFacades.dll", "Nagarro.BufferOverflow.BusinessFacades.AnswerFacade")]
        AnswerFacade = 3,

        [QualifiedTypeName("Nagarro.BufferOverflow.BusinessFacades.dll", "Nagarro.BufferOverflow.BusinessFacades.VoteFacade")]
        VoteFacade = 4,

        [QualifiedTypeName("Nagarro.BufferOverflow.BusinessFacades.dll", "Nagarro.BufferOverflow.BusinessFacades.TagFacade")]
        TagFacade = 5,


    }
}
