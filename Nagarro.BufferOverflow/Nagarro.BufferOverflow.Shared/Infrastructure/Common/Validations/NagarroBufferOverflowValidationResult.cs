using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BufferOverflow.Shared
{
    public class NagarroBufferOverflowValidationResult
    {
        public IList<NagarroBufferOverflowValidationFailure> Errors { get; private set; }

        public bool IsValid
        {
            get { return Errors == null || Errors.Count == 0; }
        }

        public NagarroBufferOverflowValidationResult(IList<NagarroBufferOverflowValidationFailure> failures)
        {
            Errors = failures;
        }

        public NagarroBufferOverflowValidationResult()
        {
            Errors = new List<NagarroBufferOverflowValidationFailure>();
        }
    }
}
