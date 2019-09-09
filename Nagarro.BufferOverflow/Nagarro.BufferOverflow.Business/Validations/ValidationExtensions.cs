using FluentValidation.Results;
using Nagarro.BufferOverflow.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BufferOverflow.Validations
{
    public static class ValidationExtensions
    {
        public static NagarroBufferOverflowValidationResult ToValidationResult(this ValidationResult result)
        {
            IList<NagarroBufferOverflowValidationFailure> errors = new List<NagarroBufferOverflowValidationFailure>();

            foreach (ValidationFailure failure in result.Errors)
            {
                errors.Add(failure.ToValidationFailure());
            }

            return new NagarroBufferOverflowValidationResult(errors);
        }

        public static NagarroBufferOverflowValidationFailure ToValidationFailure(this ValidationFailure failure)
        {
            return new NagarroBufferOverflowValidationFailure(failure.PropertyName, failure.ErrorMessage, failure.AttemptedValue);
        }

    }
}
