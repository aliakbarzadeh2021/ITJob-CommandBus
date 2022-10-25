using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ITJob.ApiService.SeedWorks.Core;
using ITJob.ApiService.SeedWorks.Models;
using ITJob.Commands.Modules.SecurityModule.Commands;
using ITJob.Commands.Modules.SecurityModule.Commands.RegisterUserCommands;
using ITJob.QueryService.Interfaces.SecurityModule;
using ITJob.SecurityService.Interfaces;
using ITJob.SecurityService.Repository;

namespace ITJob.ApiService.Controllers.Security
{
    /// <summary>
    /// ای پی ای کنترل درخواست های امنیتی ارسالی جهت شرکت کننده
    /// </summary>
    [Authorize]
    public class AllParticipantSecurityController : ApiControllerBase
    {
        private readonly ISecurityCommandService _securityCommandService;
        private readonly ISecurityQueryService _securityQueryService;
        private readonly QueryService.Interfaces.SecurityModule.ISecurityQueryService _profileCreatedQueryService;
        private readonly AuthRepository _repository;

        /// <summary>
        /// سازنده کلاس ای پی ای کنترل درخواست های امنیتی ارسالی جهت شرکت کننده
        /// </summary>
        /// <param name="securityCommandService">اجرای دستورات سکیوریتی</param>
        /// <param name="securityQueryService">کوئری سرویس سیکیوریتی</param>
        /// <param name="examCreatedQueryService">کوئری سرویس ایجاد آزمون</param>
        public AllParticipantSecurityController(ISecurityCommandService securityCommandService,
            ISecurityQueryService securityQueryService,
            QueryService.Interfaces.SecurityModule.ISecurityQueryService profileCreatedQueryService)
        {
            this._securityCommandService = securityCommandService;
            this._securityQueryService = securityQueryService;
            this._profileCreatedQueryService = profileCreatedQueryService;
            _repository = new AuthRepository();
        }

        /// <summary>
        /// درخواست ثبت نام حساب کاربری برای همه شرکت کنندگان
        /// </summary>
        /// <param name="command">درخواست ثبت نام</param>
        /// <returns>ثبت نام حساب کاربری برای همه شرکت کنندگان</returns>
//        [Roles(UserRole.Admin)]
        public async Task<HttpResponseMessage> Post(RegisterAllUserCommand command)
        {
            try
            {
                var allParticipant = _profileCreatedQueryService.GetPersons().ToList();

                var affectedUsersCount = 0;
                foreach (var participant in allParticipant)
                {
                    if(string.IsNullOrEmpty(participant.NationalCode))
                        continue;

                    var registerUser = new RegisterUserForParticipantCommand
                    {
                        FirstName = participant.FirstName,
                        LastName = participant.LastName,
                        NationalCode = participant.NationalCode,
                        UserName = participant.NationalCode,
                        Password = participant.NationalCode
                    };

                    var userExist = _repository.ExistNationalCode(participant.NationalCode).Result;

                    if (userExist)
                        continue;

                    await _securityCommandService.RegisterUserForParticipant(registerUser);

                    affectedUsersCount++;
                }

                if (affectedUsersCount == allParticipant.Count)
                {

                    return Request.CreateResponse(HttpStatusCode.OK,
                        CreateResponseModel("حساب کاربری برای تمام کاربران ثبت گردید.", ResponseMessageType.Success,
                            true, null));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK,
                        CreateResponseModel("تعدادی از کاربران حساب کاربری داشتند.", ResponseMessageType.Warning,
                            true, null));
                }


            }
            catch (Exception ex)
            {
                throw new Exception("ثبت نام حساب کاربری تمام شرکت کنندگان با خطا مواجه شد.", ex);
            }
        }
    }
}
