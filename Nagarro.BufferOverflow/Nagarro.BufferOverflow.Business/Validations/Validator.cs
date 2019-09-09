using FluentValidation;
using Nagarro.BufferOverflow.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BufferOverflow.Validations
{
    public static class Validator<T, T1> where T : AbstractValidator<T1>, new()
    {
        public static NagarroBufferOverflowValidationResult Validate(T1 dto)
        {
            T validator = new T();
            return validator.Validate(dto).ToValidationResult();
        }

        public static NagarroBufferOverflowValidationResult Validate(T1 dto, string ruleSet)
        {
            T validator = new T();
            return validator.Validate(dto, ruleSet: ruleSet).ToValidationResult();
        }
    }
}
