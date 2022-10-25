using System.Threading.Tasks;
using ITJob.Commands.Modules.SecurityModule.Commands;
using ITJob.Commands.Modules.SecurityModule.Commands.RegisterUserCommands;
using ITJob.SecurityService.Models;

namespace ITJob.SecurityService.Interfaces
{
    public interface ISecurityCommandService
    {
        /// <summary>
        /// ثبت اطلاعات یک کاربر مدیر
        /// </summary>
        /// <param name="command">درخواست</param>
        /// <returns></returns>
        Task<SecurityResponseMessage> RegisterUserForManager(RegisterUserForManagerCommand command);

        /// <summary>
        /// تغییر رمز عبور کاربر
        /// </summary>
        /// <param name="command">درخواست</param>
        /// <returns></returns>
        Task<SecurityResponseMessage> ResetUserPassword(ResetPasswordCommand command);

        /// <summary>
        /// ثبت اطلاعات یک کاربر شرکت کننده
        /// </summary>
        /// <param name="command">درخواست</param>
        /// <returns></returns>
        Task<SecurityResponseMessage> RegisterUserForParticipant(RegisterUserForParticipantCommand command);
    }
}