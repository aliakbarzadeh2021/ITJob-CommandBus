namespace ITJob.Commands.SeedWorks.Helper
{
    using System;
    using System.Linq;
    using Exceptions;
    using FluentValidation.Results;

    public static class ValidationResultExtension
    {
        public static void RaiseExceptionIfRequired(this ValidationResult validationResult)
        {
            if (!validationResult.IsValid)
                throw new CommandValidationException(validationResult.Errors.First().ErrorMessage);
        }

        public static void RaiseExceptionIfRequired(this ValidationResult validationResult,
            Action<ValidationFailure> raiseAction)
        {
            if (!validationResult.IsValid) raiseAction?.Invoke(validationResult.Errors.First());
        }
    }
}