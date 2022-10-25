using System;
using System.Linq;
using System.Threading.Tasks;
using ITJob.SecurityService.Repository;
using ITJob.SecurityService.SeedWorks.Core;
using ITJob.Commands.Modules.SecurityModule.Commands;
using ITJob.Commands.Modules.SecurityModule.Commands.RegisterUserCommands;
using ITJob.Infrastructure.Enums;
using ITJob.SecurityService.Interfaces;
using ITJob.SecurityService.Models;

namespace ITJob.SecurityService.Services
{
    public class SecurityCommandService : SecurityServiceBase, ISecurityCommandService
    {
        private readonly AuthRepository _repository;

        public SecurityCommandService()
        {
            _repository = new AuthRepository();
        }

        /// <inheritdoc />
        public async Task<SecurityResponseMessage> RegisterUserForManager(RegisterUserForManagerCommand command)
        {
            var user = new ApplicationUser(command.UserName, command.NationalCode);
            return await RegisterUserWithRole(user, command.Password, UserRole.Manager);
        }

        /// <inheritdoc />
        public async Task<SecurityResponseMessage> ResetUserPassword(ResetPasswordCommand command)
        {
            var result = new SecurityResponseMessage();
            var user = await _repository.FindUser(command.UserName, command.Password);
            if (user == null)
            {
                result.Message = "خطا در شناسایی حساب کاربری";
                result.Success = false;
            }
            try
            {
                _repository.ResetPassword(command.UserName, command.Password, command.NewPassword);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Success = false;
            }
            return result;
        }

        /// <inheritdoc />
        public async Task<SecurityResponseMessage> RegisterUserForParticipant(RegisterUserForParticipantCommand command)
        {
            var user = new ApplicationUser(command.UserName, command.NationalCode, command.FirstName, command.LastName);
            return await RegisterUserWithRole(user, command.Password, UserRole.Participant);
        }

        #region Private Method

        private async Task<SecurityResponseMessage> RegisterUserWithRole(ApplicationUser user, string password,
            UserRole userRole)
        {
            var result = new SecurityResponseMessage();

            var feedback = await _repository.RegisterUserWithRole(user, password, userRole.ToString());
            if (feedback == null)
            {
                result.Message = "Internal Server Error";
                result.Success = false;
            }
            else
            {
                if (feedback.Succeeded)
                {
                    result.Success = true;
                }
                else
                {
                    result.Success = false;
                    result.Message = feedback.Errors.Aggregate("", (current, error) => current + (error + "\n"));
                }
            }
            return result;
        }

        #endregion
    }
}