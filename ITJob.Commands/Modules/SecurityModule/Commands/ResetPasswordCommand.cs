using ITJob.Commands.Modules.SecurityModule.Validators;
using ITJob.Commands.SeedWorks.Helper;
using SAF.SSN.Kernel.CommandBus.Messages;

namespace ITJob.Commands.Modules.SecurityModule.Commands
{
    /// <summary>
    /// بازنشانی رمز حساب کاربری
    /// </summary>
    public sealed class ResetPasswordCommand : CommandBase
    {
        /// <summary>
        /// نام حساب کاربری
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// رمز عبور حساب کاربری
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// رمز جدید عبور حساب کاربری
        /// </summary>
        public string NewPassword { get; set; }

        /// <summary>
        /// رمز جدید عبور حساب کاربری تأییدی
        /// </summary>
        public string ConfirmedNewPassword { get; set; }

        /// <summary>
        /// اعتبرسنجی بازنشانی رمز حساب کاربری
        /// </summary>
        public override void Validate()
        {
            new ResetPasswordCommandValidator().Validate(this).RaiseExceptionIfRequired();
        }
    }
}