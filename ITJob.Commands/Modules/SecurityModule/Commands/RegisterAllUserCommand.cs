using System;
using ITJob.Commands.Modules.SecurityModule.Validators;
using ITJob.Commands.SeedWorks.Helper;
using SAF.SSN.Kernel.CommandBus.Messages;

namespace ITJob.Commands.Modules.SecurityModule.Commands
{
    /// <summary>
    /// ثبت حساب کاربری برای همه شرکت کنندگان
    /// </summary>
    public class RegisterAllUserCommand : CommandBase
    {
        /// <summary>
        /// شناسه آزمون
        /// </summary>
        public Guid ExamId { get; set; }

        /// <summary>
        /// اعتبارسنجی ثبت حساب کاربری برای همه شرکت کنندگان
        /// </summary>
        public override void Validate()
        {
            new RegisterAllUserCommandValidator().Validate(this).RaiseExceptionIfRequired();
        }
    }
}