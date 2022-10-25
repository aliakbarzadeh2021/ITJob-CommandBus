using ITJob.ApiService.Controllers.Security.Models;

namespace ITJob.ApiService.Controllers.Security
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Commands.Modules.SecurityModule.Commands;
    using Commands.Modules.SecurityModule.Commands.RegisterUserCommands;
    using SeedWorks.Core;
    using QueryService.Interfaces.SecurityModule;
    using SecurityService.Interfaces;
    using SecurityService.Models;
    using SecurityService.Repository;

    /// <summary>
    /// کنترل درخواست های امنیتی ارسالی جهت شرکت کننده
    /// </summary>
//    [Authorize]
    public class ParticipantSecurityController : ApiControllerBase
    {
        private readonly ISecurityCommandService _securityCommandService;
        private readonly ISecurityQueryService _securityQueryService;

        /// <summary>
        /// سازنده کلاس کنترل درخواست های امنیتی ارسالی جهت شرکت کننده
        /// </summary>
        /// <param name="securityCommandService">سرویس های سکیوریتی</param>
        /// <param name="securityQueryService">کوئری سرویس سکیوریتی</param>
        public ParticipantSecurityController(ISecurityCommandService securityCommandService,
            ISecurityQueryService securityQueryService)
        {
            this._securityCommandService = securityCommandService;
            this._securityQueryService = securityQueryService;
        }

        /// <summary>
        /// ارائه ی اطلاعات پروفایل کاربر
        /// </summary>
        /// <returns>اطلاعات پروفایل کاربر</returns>
//        [Roles(RolesHandler.AllRoles)]
        public ProfileDto Get()
        {
            var result = new ProfileDto();

            var identity = RequestContext.Principal.Identity as ClaimsIdentity;
            if (identity == null)
                return null;
            var nationalCodeClaim = identity.Claims.FirstOrDefault(w => w.Type.Equals("NationalCode"));
            if (nationalCodeClaim == null) return result;
            var nationalCode = nationalCodeClaim.Value;
            var firstName = Request;
            var authRepository = new AuthRepository();
            var user = authRepository.FindByNationalCode(nationalCode);
            result.PersonId = Guid.Parse(user.Id);
            result.FirstName = user.FirstName;
            result.LastName = user.LastName;
            result.NationalCode = nationalCode;
            result.Roles = identity.Claims.Where(w => w.Type.Equals(ClaimTypes.Role)).Select(c => c.Value);
            return result;
        }

        /// <summary>
        /// ارائه ی اطلاعات پروفایل کاربر
        /// </summary>
        /// <returns>اطلاعات پروفایل کاربر</returns>
//        [Roles(RolesHandler.AllRoles)]
        public UserDto Get(Guid examId, string nationalCode)
        {
            var result = new UserDto(Guid.Empty, null, null, null, null, null);
            var repo = new AuthRepository();
            var user = repo.FindByNationalCode(nationalCode);
            if (user != null)
            {
                var person = _securityQueryService.GetPersonDetails(examId, nationalCode, user.UserName,
                    user.PasswordHash);
                result.PersonId = person.PersonId;
                result.FirstName = person.FirstName;
                result.LastName = person.LastName;
                result.NationalCode = nationalCode;
                result.UserName = user.UserName;
                result.Password = user.PasswordHash;
            }

            return result;
        }

        /// <summary>
        /// درخواست ثبت نام یک حساب کاربری شرکت کننده
        /// </summary>
        /// <param name="command">درخواست ثبت نام</param>
        /// <returns>ثبت نام یک حساب کاربری شرکت کننده</returns>
//        [Roles(UserRole.Admin)]
        public HttpResponseMessage Post(RegisterUserForParticipantCommand command)
        {
            var response = OkResult("ثبت نام حساب کاربری شرکت کننده");
            var result = _securityCommandService.RegisterUserForParticipant(command).Result;
            if (!result.Success)
            {
                response = BadRequestResult(result.Message);
            }

            return response;
        }

        /// <summary>
        /// درخواست بازنشانی کد عبور یک حساب کاربری شرکت کننده
        /// </summary>
        /// <param name="command">درخواست بازنشانی کد عبور</param>
        /// <returns>بازنشانی کد عبور یک حساب کاربری شرکت کننده</returns>
//        [Roles(RolesHandler.AllRoles)]
        public HttpResponseMessage Put(ResetPasswordCommand command)
        {
            var response = OkResult("بازنشانی کد عبور حساب کاربری شرکت کننده");
            var result = _securityCommandService.ResetUserPassword(command).Result;
            if (!result.Success)
            {
                response = BadRequestResult(result.Message);
            }

            return response;
        }

        /// <summary>
        /// درخواست حذف یک حساب کاربری شرکت کننده
        /// </summary>
        /// <param name="id">شناسه</param>
        /// <param name="nationalCode">کدملی</param>
        /// <returns>حذف یک حساب کاربری شرکت کننده</returns>
//        [Roles(UserRole.Admin)]
        public async Task<HttpResponseMessage> Delete(Guid id, string nationalCode)
        {
            var model = new UserDeleteModel
            {
                Id = id,
                NationalCode = nationalCode
            };
            var authRepository = new AuthRepository();
            var user = authRepository.FindByNationalCode(model.NationalCode);
            await authRepository.RemoveUser(user.UserName);
            var response = OkResult("حذف حساب کاربری شرکت کننده");
            return response;
        }
    }
}
