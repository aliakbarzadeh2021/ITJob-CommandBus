namespace ITJob.ApiService.Controllers.Security
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Security.Claims;
    using Commands.Modules.SecurityModule.Commands;
    using Commands.Modules.SecurityModule.Commands.RegisterUserCommands;
    using Infrastructure.Enums;
    using QueryService.Interfaces.SecurityModule;
    using SecurityService.Interfaces;
    using SecurityService.Models;
    using SecurityService.SeedWorks.Core;
    using SeedWorks.Core;

    /// <summary>
    /// کنترل درخواست های امنیتی ارسالی جهت مدیریت
    /// </summary>
    //[Authorize]
    public class SecurityController : ApiControllerBase
    {
        private readonly ISecurityCommandService _securityCommandService;
        private readonly ISecurityQueryService _securityQueryService;

        /// <summary>
        /// سازنده کلاس کنترل درخواست های امنیتی ارسالی جهت مدیریت
        /// </summary>
        /// <param name="securityCommandService">سرویس های سکیوریتی</param>
        /// <param name="securityQueryService">کوئری سرویس سکیوریتی</param>
        public SecurityController(ISecurityCommandService securityCommandService,
            ISecurityQueryService securityQueryService)
        {
            this._securityCommandService = securityCommandService;
            this._securityQueryService = securityQueryService;
        }

        /// <summary>
        /// ارائه ی اطلاعات پروفایل کاربر
        /// </summary>
        /// <returns>اطلاعات پروفایل کاربر</returns>
        [Roles(RolesHandler.AllRoles)]
        public ProfileDto Get()
        {
            var result = new ProfileDto();
            var identity = RequestContext.Principal.Identity as ClaimsIdentity;
            if (identity == null)
                return null;
            var nationalCodeClaim = identity.Claims.FirstOrDefault(w => w.Type.Equals("NationalCode"));
            if (nationalCodeClaim == null) return result;
            var nationalCode = nationalCodeClaim.Value;
            if (nationalCode == "0070238146")
            {
                result.FirstName = "کاربر پشتیبان";
                result.LastName = "مؤسسه فرهیختگان جوان";
                result.PersonId = Guid.Parse("134908c5-cefc-4ec2-bf14-9612316b08ba");
            }

            result.NationalCode = nationalCode;
            result.Roles = identity.Claims.Where(w => w.Type.Equals(ClaimTypes.Role)).Select(c => c.Value);
            return result;
        }

        /// <summary>
        /// درخواست ثبت نام یک حساب کاربری مدیریت
        /// </summary>
        /// <param name="command">درخواست ثبت نام</param>
        /// <returns>ثبت نام یک حساب کاربری مدیریت</returns>
        [Roles(UserRole.Admin)]
        public HttpResponseMessage Post(RegisterUserForManagerCommand command)
        {
            var response = OkResult("ثبت نام حساب کاربری مدیریت");
            var result = _securityCommandService.RegisterUserForManager(command).Result;
            if (!result.Success)
            {
                response = BadRequestResult(result.Message);
            }

            return response;
        }

        /// <summary>
        /// درخواست بازنشانی کد عبور یک حساب کاربری مدیریت
        /// </summary>
        /// <param name="command">درخواست بازنشانی کد عبور</param>
        /// <returns>بازنشانی کد عبور یک حساب کاربری مدیریت</returns>
        [Roles(RolesHandler.AllRoles)]
        public HttpResponseMessage Put(ResetPasswordCommand command)
        {
            var response = OkResult("بازنشانی کد عبور حساب کاربری مدیریت");
            var result = _securityCommandService.ResetUserPassword(command).Result;
            if (!result.Success)
            {
                response = BadRequestResult(result.Message);
            }

            return response;
        }
    }
}