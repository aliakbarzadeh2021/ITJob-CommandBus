using ITJob.Commands.Modules.SecurityModule.Commands;
using ITJob.Commands.SeedWorks.Core.Validators;

namespace ITJob.Commands.Modules.SecurityModule.Validators
{
    internal sealed class RegisterAllUserCommandValidator : CommonValidator<RegisterAllUserCommand>
    {
        internal RegisterAllUserCommandValidator()
        {
            CustomRuleFor(f => f.ExamId, "شناسه آزمون");
        }
    }
}