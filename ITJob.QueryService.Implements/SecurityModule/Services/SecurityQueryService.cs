using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITJob.DomainModel.Modules.ProfileModule.Interfaces.Repositories;
using ITJob.QueryModels.Interfaces.SecurityModule;
using ITJob.QueryService.Interfaces.SecurityModule;
using ITJob.SecurityService.Models;

namespace ITJob.QueryService.Implements.SecurityModule.Services
{
    public class SecurityQueryService : ISecurityQueryService
    {
        private readonly IProfileRepository _profileRepository;

        /// <summary>
        /// سازنده کلاس کوئری سرویس سکیوریتی
        /// </summary>
        /// <param name="examRepository">ریپازیتوری آزمون</param>
        public SecurityQueryService(IProfileRepository examRepository)
        {
            this._profileRepository = examRepository;
        }

        /// <summary>
        /// ارائه ی اطلاعات پروفایل کاربر
        /// </summary>
        /// <param name="examId">شناسه آزمون</param>
        /// <param name="nationalCode">کد ملی</param>
        /// <param name="userName">نام کاربری</param>
        /// <param name="password">کلمه عبور</param>
        /// <returns>اطلاعات پروفایل کاربر</returns>
        public IUserDto GetPersonDetails(Guid examId, string nationalCode, string userName, string password)
        {
            var participant = this._profileRepository.GetProfile();
            return new UserDto();
        }

        public IEnumerable<IUserDto> GetPersons()
        {
            throw new NotImplementedException();
        }
    }
}
