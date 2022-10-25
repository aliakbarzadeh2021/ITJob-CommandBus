using FluentValidation;
using ITJob.Commands.Modules.SecurityModule.Commands;
using ITJob.Commands.SeedWorks.Core.Validators;

namespace ITJob.Commands.Modules.SecurityModule.Validators
{
    internal sealed class ResetPasswordCommandValidator : CommonValidator<ResetPasswordCommand>
    {
        internal ResetPasswordCommandValidator()
        {
            CustomRuleFor(f => f.UserName, "نام کاربری");
            CustomRuleFor(f => f.Password, "رمز عبور")
                .Must(p => p.Length > 8);
            CustomRuleFor(f => f.NewPassword, "رمز عبور")
                .Must(p => p.Length > 8);
            CustomRuleFor(f => f.ConfirmedNewPassword, "رمز عبور")
                .Must(p => p.Length > 8);
        }
    }
}