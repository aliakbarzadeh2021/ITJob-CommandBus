using ITJob.Commands.Modules.SecurityModule.Validators;
using ITJob.Commands.SeedWorks.Helper;
using SAF.SSN.Kernel.CommandBus.Messages;

namespace ITJob.Commands.Modules.SecurityModule.Commands
{
    /// <summary>
    /// ثبت حساب کاربری
    /// </summary>
    public abstract class RegisterUserCommand : CommandBase
    {
        /// <summary>
        /// نام حساب کاربری
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// کد ملی کاربر
        /// </summary>
        public string NationalCode { get; set; }

        /// <summary>
        /// رمز عبور حساب کاربری
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// رمز عبور حساب کاربری تأییدی
        /// </summary>
        public string ConfirmedPassword { get; set; }

        /// <summary>
        /// اعتبارسنجی نام حساب کاربری
        /// </summary>
        public override void Validate()
        {
            new RegisterUserCommandValidator().Validate(this).RaiseExceptionIfRequired();
        }
    }
}